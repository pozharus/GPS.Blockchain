using Nito.AsyncEx;
using NSec.Cryptography;
using Omnibasis.BigchainCSharp.Api;
using Omnibasis.BigchainCSharp.Builders;
using Omnibasis.BigchainCSharp.Constants;
using Omnibasis.BigchainCSharp.Model;
using Omnibasis.BigchainCSharp.Util;
using System.Collections.Generic;
using System.IO;
using Blockchain.Persistance.TypesDBConfiguration;
using Blockchain.Persistance.Utils;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Linq;

namespace Blockchain.Persistance
{
    public class BigchainDbConfiguration
    {
        public static Ed25519 algorithm { get; set; }
        public static Key privateKey { get; set; }
        public static PublicKey publicKey { get; set; }

        public async void Configure()
        {
            using FileStream openStream = File.OpenRead("../../Infrastructure/Blockchain.Persistance/config.json");
            Configuration config = await JsonSerializer.DeserializeAsync<Configuration>(openStream);

            // Connection list
            IList<BlockchainConnection> connections = new List<BlockchainConnection>();
            connections.Add(createConnection(config.baseUrl));
            connections.Add(createConnection(config.baseUrl));

            // Multiple connections
            var builder = BigchainDbConfigBuilder
                .addConnections(connections)
                .setTimeout(60000);

            if (!AsyncContext.Run(() => builder.setup()))
            {
                Console.WriteLine("Failed to setup");
            };

            PrepareKeys(config.privateKey, config.publicKey);
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
