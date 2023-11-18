
using System;
using System.Collections.Generic;
using System.Linq;

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
    public object Database { get; internal set; }
    public IEnumerable<object> FoodItems2 { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Встановіть рядок підключення до вашої бази даних
        optionsBuilder.UseSqlServer("YourConnectionString");
    }

    internal void SaveChanges()
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main()
    {
        using (FoodDbContext context = new FoodDbContext())
        {
            context.Database.EnsureCreated();

            // Перевірте, чи у базі даних є вже дані
            if (!context.FoodItems.Any())
            {
                var carrot = new FoodItem { Name = "Морква", Type = "Овоч", Color = "Orange", Calories = 41 };
                var apple = new FoodItem { Name = "Яблуко", Type = "Фрукт", Color = "Red", Calories = 52 };

                context.FoodItems.AddRange(carrot, apple);
                context.SaveChanges();

                Console.WriteLine("Дані додано до бази даних.");
            }
            else
            {
                Console.WriteLine("База даних вже містить дані.");
            }
        }
    }
}
