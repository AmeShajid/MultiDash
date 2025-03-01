namespace MauiApp1.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPopular { get; set; }
    }

    public class Location
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public enum Platform
    {
        DoorDash = 0,
        Grubhub = 1,
        UberEats = 2
    }

    public class Order
    {
        public string Id { get; set; }
        public Platform Platform { get; set; }
        public Restaurant Restaurant { get; set; }
        public Location PickupLocation { get; set; }
        public Location DropoffLocation { get; set; }
        public decimal BasePay { get; set; }
        public decimal EstimatedTip { get; set; }
        public decimal TotalPay { get; set; }
        public double PayPerMile { get; set; }
        public double Distance { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public double TimeEfficiency { get; set; }
        public string PickupInstructions { get; set; }
        public string DropoffInstructions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PickupBy { get; set; }
        public DateTime DeliverBy { get; set; }

        public string DisplayText => $"• {Restaurant.Name}\n  ${TotalPay:F2} ({Distance:F1} mi) - {EstimatedTime.TotalMinutes:F0} mins\n  📍 {PickupLocation.Address}";
    }
} 