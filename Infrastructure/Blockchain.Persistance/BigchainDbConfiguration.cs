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

        public void Configure()
        {
            // WTF!!!!!!!!! Why it isn't working! Fix it
            // Load connection configuration
            //Configuration item = await JsonFileReader.ReadAsync<Configuration>(@"C:\Users\Yaroslav\source\repos\GPS.Blockchain\Infrastructure\Blockchain.Persistance\appsettings.json");
            //string output = File.ReadAllText(@"./appsettings.json");
            //var item = JsonSerializer.Deserialize<Configuration>(output);

            Configuration.baseUrl = "http://localhost:9984/";
            Configuration.publicKey = "302a300506032b657003210033c43dc2180936a2a9138a05f06c892d2fb1cfda4562cbc35373bf13cd8ed373";
            Configuration.privateKey = "302e020100300506032b6570042204206f6b0cd095f1e83fc5f08bffb79c7c8a30e77a3ab65f4bc659026b76394fcea8";

            // Connection list
            IList<BlockchainConnection> connections = new List<BlockchainConnection>();
            connections.Add(createConnection(Configuration.baseUrl));
            connections.Add(createConnection(Configuration.baseUrl));

            // Multiple connections
            var builder = BigchainDbConfigBuilder
                .addConnections(connections)
                .setTimeout(60000);

            if (!AsyncContext.Run(() => builder.setup()))
            {
                Console.WriteLine("Failed to setup");
            };

            PrepareKeys(Configuration.privateKey, Configuration.publicKey);
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
