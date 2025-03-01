using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MultiDash.App.Models;

namespace MultiDash.App.ViewModels
{
    public class DeliveryPlatformViewModel : INotifyPropertyChanged
    {
        private bool _isExpanded;
        private string _name;
        private string _accentColor;

        public DeliveryPlatformViewModel()
        {
            ToggleExpansionCommand = new Command(() => IsExpanded = !IsExpanded);
        }

        public ICommand ToggleExpansionCommand { get; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string AccentColor
        {
            get => _accentColor;
            set
            {
                _accentColor = value;
                OnPropertyChanged();
            }
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DeliveryOrder> Orders { get; } = new ObservableCollection<DeliveryOrder>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 