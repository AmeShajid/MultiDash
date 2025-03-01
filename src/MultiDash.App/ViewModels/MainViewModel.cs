using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MultiDash.App.Models;

namespace MultiDash.App.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DeliveryPlatformViewModel> Platforms { get; } = new ObservableCollection<DeliveryPlatformViewModel>();

        public MainViewModel()
        {
            InitializePlatforms();
        }

        private void InitializePlatforms()
        {
            var doordash = new DeliveryPlatformViewModel
            {
                Name = "Doordash",
                AccentColor = "#FF4500" // Red-Orange color
            };
            doordash.Orders.Add(new DeliveryOrder { Amount = 5, Distance = 6, Platform = "Doordash" });
            doordash.Orders.Add(new DeliveryOrder { Amount = 10, Distance = 10, Platform = "Doordash" });

            var grubhub = new DeliveryPlatformViewModel
            {
                Name = "Grubhub",
                AccentColor = "#FFA500" // Orange color
            };

            var uberEats = new DeliveryPlatformViewModel
            {
                Name = "Uber Eats",
                AccentColor = "#90EE90" // Light Green color
            };

            Platforms.Add(doordash);
            Platforms.Add(grubhub);
            Platforms.Add(uberEats);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 