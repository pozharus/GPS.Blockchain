using Nito.AsyncEx;
using NSec.Cryptography;
using Omnibasis.BigchainCSharp.Builders;
using Omnibasis.BigchainCSharp.Model;
using System.Collections.Generic;
using System.IO;
using Blockchain.Persistance.TypesDBConfiguration;
using System;
using System.Text.Json;

namespace Blockchain.Persistance
{
    public class BigchainDbConfiguration
    {
        public static Ed25519 algorithm { get; set; }
        public static Key privateKey { get; set; }
        public static PublicKey publicKey { get; set; } 

        public async void Configure()
        {
            using FileStream openStream = File.OpenRead("config.json");
            List<Configuration> configs = new List<Configuration>();
            configs = await JsonSerializer.DeserializeAsync<List<Configuration>>(openStream);

            // Connection list
            IList<BlockchainConnection> connections = new List<BlockchainConnection>();
            foreach (Configuration config in configs)
            {
                connections.Add(createConnection(config.baseUrl));
                PrepareKeys(config.privateKey, config.publicKey);
            }

            // Multiple connections
            var builder = BigchainDbConfigBuilder
                .addConnections(connections)
                .setTimeout(60000);

            if (!AsyncContext.Run(() => builder.setup()))
            {
                Console.WriteLine("Failed to setup");
            };
        }

        public BlockchainConnection createConnection(string baseUrl)
        {
            // Define connection
            var connection = new Dictionary<string, object>();
            // Define headers for connections
            var headers = new Dictionary<string, string>();
            // Config connection
            connection.Add("baseUrl", baseUrl);
            connection.Add("headers", headers);

            return new BlockchainConnection(connection);
        }

        public void PrepareKeys(string rawPrivateKey, string rawPublicKey)
        {
            algorithm = SignatureAlgorithm.Ed25519;
            privateKey = Key.Import(algorithm, Omnibasis.BigchainCSharp.Util.Utils.StringToByteArray(rawPrivateKey),
                KeyBlobFormat.PkixPrivateKey);
            publicKey = PublicKey.Import(algorithm, Omnibasis.BigchainCSharp.Util.Utils.StringToByteArray(rawPublicKey),
                KeyBlobFormat.PkixPublicKey);
        }
    }
}
