using System.ComponentModel;

namespace AvaloniaGuideApp.Models
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                    IsAdult = value >= 18;
                }
            }
        }

        public SexTypes Sex { get; set; }

        private bool _isAdult;
        public bool IsAdult
        {
            get => _isAdult;
            set
            {
                if (_isAdult != value)
                {
                    _isAdult = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum SexTypes
    {
        Unknown,
        Male,
        Female
    }

}
