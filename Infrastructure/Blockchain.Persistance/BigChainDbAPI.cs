using System.Collections.Generic;
using Blockchain.Application.Common.Exceptions;
using Blockchain.Domain;
using Blockchain.Persistance.TypesDBConfiguration;
using Nito.AsyncEx;
using Omnibasis.BigchainCSharp.Api;
using Omnibasis.BigchainCSharp.Builders;
using Omnibasis.BigchainCSharp.Constants;
using Omnibasis.BigchainCSharp.Model;
using Omnibasis.BigchainCSharp.Util;

namespace Blockchain.Persistance
{
    public class BigChainDbAPI
    {
        public static PointAsset createAsset(TrackerPoint point)
        {
            PointAsset PointAsset = new PointAsset();
            PointAsset.id = point.id;
            PointAsset.timestamp = point.timestamp;
            PointAsset.latitude = point.latitude;
            PointAsset.longitude = point.longitude;
            PointAsset.altitude = point.altitude;
            PointAsset.speed = point.speed;
            PointAsset.satelites = point.satelites;
            PointAsset.delusionOfPresition = point.delusionOfPresition;
            PointAsset.horizontalDelusionOfPresition = point.horizontalDelusionOfPresition;
            PointAsset.verticalDelusionOfPresition = point.verticalDelusionOfPresition;
            return PointAsset;
        }

        public static PointMetadata createMetadata(string data)
        {
            PointMetadata PointMetadata = new PointMetadata();
            PointMetadata.msg = data;
            return PointMetadata;
        }

        public static Transaction<PointAsset, PointMetadata> createTransaction(PointAsset PointAsset, PointMetadata PointMetadata)
        {
            var transaction = BigchainDbTransactionBuilder<PointAsset, PointMetadata>
                .init()
                .addAssets(PointAsset)
                .addMetaData(PointMetadata)
                .operation(Operations.CREATE)
                .buildAndSignOnly(BigchainDbConfiguration.publicKey, BigchainDbConfiguration.privateKey);
            return transaction;
        }

        public static BlockchainResponse<Transaction<PointAsset, PointMetadata>> sendTransaction(Transaction<PointAsset,
                                                                                            PointMetadata> transaction)
        {
            var realisedTransaction = AsyncContext.Run(() => TransactionsApi<PointAsset, PointMetadata>.sendTransactionAsync(transaction));
            if (realisedTransaction != null && realisedTransaction.Data != null)
            {
                return realisedTransaction;
            } else
            {
                throw new TransactionException(realisedTransaction.Messsage.ToString());
            }
        }

        public static List<Asset<PointAsset>> getAssets(string key)
        {
            return AsyncContext.Run(() => AssetsApi<PointAsset>.getAssetsAsync(key));
        }
    }
}
