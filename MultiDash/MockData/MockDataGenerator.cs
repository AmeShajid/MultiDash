using System;
using System.Collections.Generic;

namespace MultiDash.MockData;

public class MockDataGenerator
{
    private readonly Random _random = new Random();

    // Generate a single random delivery order
    public DeliveryOrder GenerateOrder()
    {
        var platform = GetRandomEnum<Platform>();
        var restaurant = GetRandomItem(SampleData.Restaurants);
        var pickupLocation = GetRandomItem(SampleData.SampleLocations);
        var dropoffLocation = GetRandomItem(SampleData.SampleLocations);
        
        while (pickupLocation == dropoffLocation)
        {
            dropoffLocation = GetRandomItem(SampleData.SampleLocations);
        }

        var distance = CalculateDistance(pickupLocation, dropoffLocation);
        var basePay = GenerateBasePay(platform);
        var estimatedTip = GenerateTip();
        var estimatedTime = GenerateDeliveryTime();

        return new DeliveryOrder
        {
            Id = Guid.NewGuid(),
            Platform = platform,
            Restaurant = restaurant,
            PickupLocation = pickupLocation,
            DropoffLocation = dropoffLocation,
            BasePay = basePay,
            EstimatedTip = estimatedTip,
            Distance = distance,
            EstimatedTime = estimatedTime,
            PickupInstructions = GetRandomItem(SampleData.PickupInstructions),
            DropoffInstructions = GetRandomItem(SampleData.DropoffInstructions),
            CreatedAt = DateTime.UtcNow,
            PickupBy = DateTime.UtcNow.AddMinutes(15),
            DeliverBy = DateTime.UtcNow.AddMinutes(45)
        };
    }

    // Generate multiple random delivery orders
    public List<DeliveryOrder> GenerateOrders(int count)
    {
        var orders = new List<DeliveryOrder>();
        for (int i = 0; i < count; i++)
        {
            orders.Add(GenerateOrder());
        }
        return orders;
    }

    private T GetRandomEnum<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(_random.Next(values.Length));
    }

    private T GetRandomItem<T>(IList<T> list)
    {
        return list[_random.Next(list.Count)];
    }

    private decimal GenerateBasePay(Platform platform)
    {
        var (min, max) = SampleData.BasePayRanges[platform];
        return decimal.Round(
            (decimal)(_random.NextDouble() * (double)(max - min) + (double)min), 
            2
        );
    }

    private decimal GenerateTip()
    {
        var (min, max) = SampleData.TipRange;
        return decimal.Round(
            (decimal)(_random.NextDouble() * (double)(max - min) + (double)min), 
            2
        );
    }

    private TimeSpan GenerateDeliveryTime()
    {
        var (min, max) = SampleData.DeliveryTimeRange;
        return TimeSpan.FromMinutes(_random.Next(min, max));
    }

    private double CalculateDistance(Location pickup, Location dropoff)
    {
        // Simple distance calculation using Haversine formula
        var R = 3959; // Earth's radius in miles
        var dLat = ToRad(dropoff.Latitude - pickup.Latitude);
        var dLon = ToRad(dropoff.Longitude - pickup.Longitude);
        var lat1 = ToRad(pickup.Latitude);
        var lat2 = ToRad(dropoff.Latitude);

        var a = Math.Sin(dLat/2) * Math.Sin(dLat/2) +
                Math.Sin(dLon/2) * Math.Sin(dLon/2) * Math.Cos(lat1) * Math.Cos(lat2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
        return Math.Round(R * c, 2); // Distance in miles
    }

    private double ToRad(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
} 