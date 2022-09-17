namespace Appeals.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AppealsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
