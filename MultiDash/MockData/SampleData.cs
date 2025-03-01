namespace MultiDash.MockData;

public static class SampleData
{
    public static readonly List<Restaurant> Restaurants = new()
    {
        new Restaurant { Name = "Federal Donuts", Cuisine = "American", PhoneNumber = "(267) 928-4268", IsPopular = true },
        new Restaurant { Name = "Han Dynasty", Cuisine = "Chinese", PhoneNumber = "(215) 222-3711", IsPopular = true },
        new Restaurant { Name = "Shake Shack", Cuisine = "Burgers", PhoneNumber = "(215) 921-9940", IsPopular = true },
        new Restaurant { Name = "&pizza", Cuisine = "Pizza", PhoneNumber = "(215) 839-9768", IsPopular = true },
        new Restaurant { Name = "Halal Guys", Cuisine = "Middle Eastern", PhoneNumber = "(215) 977-7955", IsPopular = true },
        new Restaurant { Name = "Koch's Deli", Cuisine = "Deli", PhoneNumber = "(215) 222-8662", IsPopular = false },
        new Restaurant { Name = "Dim Sum House", Cuisine = "Chinese", PhoneNumber = "(215) 921-5377", IsPopular = false },
        new Restaurant { Name = "Ed's Pizza", Cuisine = "Pizza", PhoneNumber = "(215) 387-0947", IsPopular = false },
        new Restaurant { Name = "Chick-fil-A", Cuisine = "Fast Food", PhoneNumber = "(215) 662-0505", IsPopular = true },
        new Restaurant { Name = "Chipotle", Cuisine = "Mexican", PhoneNumber = "(215) 222-0253", IsPopular = true }
    };

    public static readonly List<Location> SampleLocations = new()
    {
        // Drexel University area
        new Location { 
            Address = "3141 Chestnut St", 
            City = "Philadelphia", 
            State = "PA", 
            ZipCode = "19104", 
            Latitude = 39.9566, 
            Longitude = -75.1899 
        },
        // University City
        new Location { 
            Address = "3401 Walnut St", 
            City = "Philadelphia", 
            State = "PA", 
            ZipCode = "19104", 
            Latitude = 39.9530, 
            Longitude = -75.1925 
        },
        // Center City
        new Location { 
            Address = "1500 Market St", 
            City = "Philadelphia", 
            State = "PA", 
            ZipCode = "19102", 
            Latitude = 39.9526, 
            Longitude = -75.1652 
        },
        // South Philly
        new Location { 
            Address = "1100 S Broad St", 
            City = "Philadelphia", 
            State = "PA", 
            ZipCode = "19146", 
            Latitude = 39.9338, 
            Longitude = -75.1668 
        },
        // West Philly
        new Location { 
            Address = "4800 Baltimore Ave", 
            City = "Philadelphia", 
            State = "PA", 
            ZipCode = "19143", 
            Latitude = 39.9486, 
            Longitude = -75.2179 
        }
    };

    public static readonly List<string> PickupInstructions = new()
    {
        "Park in designated pickup spots",
        "Use side entrance for pickup",
        "Call restaurant upon arrival",
        "Look for pickup shelf inside",
        "Show order number at counter",
        "Wait in delivery driver line",
        "Use DoorDash red card for payment",
        "Check order number with staff"
    };

    public static readonly List<string> DropoffInstructions = new()
    {
        "Leave at door",
        "Hand it to me",
        "Call upon arrival",
        "Text when arriving",
        "Meet in lobby",
        "Gate code: #1234",
        "Ring doorbell",
        "Leave with front desk",
        "Call for apartment access",
        "Do not ring doorbell, baby sleeping"
    };

    // Base pay ranges by platform
    public static readonly Dictionary<Platform, (decimal min, decimal max)> BasePayRanges = new()
    {
        { Platform.DoorDash, (2.50m, 10.00m) },
        { Platform.UberEats, (2.00m, 15.00m) },
        { Platform.Grubhub, (3.00m, 12.00m) }
    };

    // Tip ranges (percentage of order total)
    public static readonly (decimal min, decimal max) TipRange = (0.00m, 20.00m);

    // Time ranges (minutes)
    public static readonly (int min, int max) DeliveryTimeRange = (15, 45);
} 