using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp1.Models;
using Location = MauiApp1.Models.Location;
using Platform = MauiApp1.Models.Platform;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private bool isDoorDashExpanded = false;
        private bool isGrubhubExpanded = false;
        private bool isUberEatsExpanded = false;
        private Random random = new Random();

        public ObservableCollection<Order> DoorDashOrders { get; } = new();
        public ObservableCollection<Order> GrubhubOrders { get; } = new();
        public ObservableCollection<Order> UberEatsOrders { get; } = new();

        public ICommand DeleteOrderCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Initialize delete command
            DeleteOrderCommand = new Command<Order>(DeleteOrder);

            // Sample data - replace this with your API data
            AddSampleOrders();
        }

        private void AddSampleOrders()
        {
            var order1 = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Platform = Platform.DoorDash,
                Restaurant = new Restaurant
                {
                    Name = "Han Dynasty",
                    Cuisine = "Chinese",
                    PhoneNumber = "(215) 222-3711",
                    IsPopular = true
                },
                PickupLocation = new Location
                {
                    Address = "3401 Walnut St",
                    City = "Philadelphia",
                    State = "PA",
                    ZipCode = "19104"
                },
                BasePay = 12.50m,
                EstimatedTip = 5.42m,
                TotalPay = 17.92m,
                Distance = 1.38,
                EstimatedTime = TimeSpan.FromMinutes(29)
            };

            var order2 = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Platform = Platform.Grubhub,
                Restaurant = new Restaurant
                {
                    Name = "Shake Shack",
                    Cuisine = "Burgers",
                    PhoneNumber = "(215) 921-9940",
                    IsPopular = true
                },
                PickupLocation = new Location
                {
                    Address = "3200 Chestnut St",
                    City = "Philadelphia",
                    State = "PA",
                    ZipCode = "19104"
                },
                BasePay = 6.69m,
                EstimatedTip = 19.02m,
                TotalPay = 25.71m,
                Distance = 1.3,
                EstimatedTime = TimeSpan.FromMinutes(34)
            };

            DoorDashOrders.Add(order1);
            GrubhubOrders.Add(order2);
        }

        private void DeleteOrder(Order order)
        {
            switch (order.Platform)
            {
                case Platform.DoorDash:
                    DoorDashOrders.Remove(order);
                    break;
                case Platform.Grubhub:
                    GrubhubOrders.Remove(order);
                    break;
                case Platform.UberEats:
                    UberEatsOrders.Remove(order);
                    break;
            }
        }

        private async void OnClearDoorDashClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Clear Orders", "Are you sure you want to clear all DoorDash orders?", "Yes", "No");
            if (answer)
            {
                DoorDashOrders.Clear();
            }
        }

        private async void OnClearGrubhubClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Clear Orders", "Are you sure you want to clear all Grubhub orders?", "Yes", "No");
            if (answer)
            {
                GrubhubOrders.Clear();
            }
        }

        private async void OnClearUberEatsClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Clear Orders", "Are you sure you want to clear all UberEats orders?", "Yes", "No");
            if (answer)
            {
                UberEatsOrders.Clear();
            }
        }

        // Method to add new orders from API
        public void AddNewOrder(Order order)
        {
            switch (order.Platform)
            {
                case Platform.DoorDash:
                    DoorDashOrders.Add(order);
                    break;
                case Platform.Grubhub:
                    GrubhubOrders.Add(order);
                    break;
                case Platform.UberEats:
                    UberEatsOrders.Add(order);
                    break;
            }
        }

        private void OnDoorDashHeaderTapped(object sender, EventArgs e)
        {
            isDoorDashExpanded = !isDoorDashExpanded;
            DoorDashDetails.IsVisible = isDoorDashExpanded;
            DoorDashExpandIcon.Text = isDoorDashExpanded ? "▲" : "▼";
            DoorDashDetails.FadeTo(isDoorDashExpanded ? 1 : 0, 150);
        }

        private void OnGrubhubHeaderTapped(object sender, EventArgs e)
        {
            isGrubhubExpanded = !isGrubhubExpanded;
            GrubhubDetails.IsVisible = isGrubhubExpanded;
            GrubhubExpandIcon.Text = isGrubhubExpanded ? "▲" : "▼";
            GrubhubDetails.FadeTo(isGrubhubExpanded ? 1 : 0, 150);
        }

        private void OnUberEatsHeaderTapped(object sender, EventArgs e)
        {
            isUberEatsExpanded = !isUberEatsExpanded;
            UberEatsDetails.IsVisible = isUberEatsExpanded;
            UberEatsExpandIcon.Text = isUberEatsExpanded ? "▲" : "▼";
            UberEatsDetails.FadeTo(isUberEatsExpanded ? 1 : 0, 150);
        }

        private void OnAddTestOrderClicked(object sender, EventArgs e)
        {
            string[] restaurantNames = { "Han Dynasty", "Shake Shack", "Halal Guys", "Chipotle" };
            string[] addresses = { "3401 Walnut St", "3200 Chestnut St", "1500 Market St", "3925 Walnut St" };
            
            var platform = (Platform)random.Next(3);
            var restaurant = new Restaurant
            {
                Name = restaurantNames[random.Next(restaurantNames.Length)],
                Cuisine = "Various",
                IsPopular = true
            };

            var newOrder = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Platform = platform,
                Restaurant = restaurant,
                PickupLocation = new Location
                {
                    Address = addresses[random.Next(addresses.Length)],
                    City = "Philadelphia",
                    State = "PA"
                },
                BasePay = random.Next(5, 15),
                EstimatedTip = random.Next(3, 20),
                Distance = Math.Round(random.NextDouble() * 3, 1),
                EstimatedTime = TimeSpan.FromMinutes(random.Next(20, 45))
            };
            newOrder.TotalPay = newOrder.BasePay + newOrder.EstimatedTip;

            AddNewOrder(newOrder);

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Order Added", 
                    $"Added new order from {newOrder.Restaurant.Name}\n" +
                    $"Total: ${newOrder.TotalPay:F2} - {newOrder.Distance:F1} miles\n" +
                    $"Pickup: {newOrder.PickupLocation.Address}", 
                    "OK");
            });
        }
    }
}
