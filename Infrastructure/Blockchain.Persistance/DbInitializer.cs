namespace Blockchain.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(TrackerPointDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
