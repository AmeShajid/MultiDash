using System;

namespace MultiDash.MockData;

// Platforms available for delivery
public enum Platform
{
    DoorDash,
    UberEats,
    Grubhub
}

// Restaurant information
public class Restaurant
{
    public string Name { get; set; }
    public string Cuisine { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsPopular { get; set; }
}

// Location details for pickup and dropoff
public class Location
{
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

// Main delivery order class
public class DeliveryOrder
{
    public Guid Id { get; set; }
    public Platform Platform { get; set; }
    public Restaurant Restaurant { get; set; }
    public Location PickupLocation { get; set; }
    public Location DropoffLocation { get; set; }
    
    // Earnings Information
    public decimal BasePay { get; set; }
    public decimal EstimatedTip { get; set; }
    public decimal TotalPay => BasePay + EstimatedTip;
    public decimal PayPerMile => TotalPay / (decimal)Distance;
    
    // Delivery Details
    public double Distance { get; set; }  // in miles
    public TimeSpan EstimatedTime { get; set; }
    public double TimeEfficiency => Distance / EstimatedTime.TotalHours;  // miles per hour
    
    // Additional Information
    public string PickupInstructions { get; set; }
    public string DropoffInstructions { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PickupBy { get; set; }
    public DateTime DeliverBy { get; set; }
} 