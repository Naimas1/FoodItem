public class FoodItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Овоч або фрукт
    public string Color { get; set; }
    public double Calories { get; set; }
}

public class FoodDbContext : DbContext
{
    public DbSet<FoodItem> FoodItems { get; set; }
}

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть 1 для підключення або 2 для від'єднання від бази даних:");
        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            ConnectToDatabase();
        }
        else if (userInput == "2")
        {
            DisconnectFromDatabase();
        }
        else
        {
            Console.WriteLine("Невірний ввід.");
        }
    }

    static void ConnectToDatabase()
    {
        using (var context = new FoodDbContext())
        {
            try
            {
                context.Database.EnsureCreated();
                Console.WriteLine("Підключено до бази даних.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка підключення до бази даних: {ex.Message}");
            }
        }
    }

    static void DisconnectFromDatabase()
    {
        Console.WriteLine("Від'єднано від бази даних.");
    }
}