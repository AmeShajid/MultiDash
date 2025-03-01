using System;

namespace MultiDash.App.Models
{
    public class DeliveryOrder
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public double Distance { get; set; }
        public string Platform { get; set; }
        public string Description => $"{Amount:C} - {Distance} miles";
    }
} 