using System;
using System.Text.Json;

namespace MultiDash.MockData;

public class Program
{
    public static void Main(string[] args)
    {
        var generator = new MockDataGenerator();
        
        // Generate 5 sample orders
        var orders = generator.GenerateOrders(5);
        
        // Print each order in a nice format
        foreach (var order in orders)
        {
            Console.WriteLine("\n=== New Delivery Order ===");
            Console.WriteLine($"Platform: {order.Platform}");
            Console.WriteLine($"Restaurant: {order.Restaurant.Name} ({order.Restaurant.Cuisine})");
            Console.WriteLine($"\nPickup: {order.PickupLocation.Address}, {order.PickupLocation.City}");
            Console.WriteLine($"Instructions: {order.PickupInstructions}");
            Console.WriteLine($"\nDropoff: {order.DropoffLocation.Address}, {order.DropoffLocation.City}");
            Console.WriteLine($"Instructions: {order.DropoffInstructions}");
            Console.WriteLine($"\nEarnings:");
            Console.WriteLine($"Base Pay: ${order.BasePay:F2}");
            Console.WriteLine($"Est. Tip: ${order.EstimatedTip:F2}");
            Console.WriteLine($"Total: ${order.TotalPay:F2}");
            Console.WriteLine($"\nDetails:");
            Console.WriteLine($"Distance: {order.Distance:F1} miles");
            Console.WriteLine($"Est. Time: {order.EstimatedTime.TotalMinutes:F0} minutes");
            Console.WriteLine($"Pay per Mile: ${order.PayPerMile:F2}");
            Console.WriteLine($"Time Efficiency: {order.TimeEfficiency:F1} mph");
            Console.WriteLine("========================\n");
        }
        
        // Also save to a JSON file
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(orders, options);
        File.WriteAllText("sample_orders.json", json);
        
        Console.WriteLine($"Generated {orders.Count} sample orders and saved to sample_orders.json");
    }
} 