namespace Blockchain.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(BigchainDbConfiguration context)
        {
            context.Configure();
        }
    }
}
