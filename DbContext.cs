public class DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Встановіть рядок підключення до вашої бази даних
        optionsBuilder.UseSqlServer("YourConnectionString");
    }
}