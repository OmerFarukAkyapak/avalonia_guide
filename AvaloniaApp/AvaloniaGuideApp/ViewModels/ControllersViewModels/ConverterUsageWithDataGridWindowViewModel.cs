using AvaloniaGuideApp.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

namespace AvaloniaGuideApp.ViewModels
{
    public class ConverterUsageWithDataGridWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get => _people;
            set => RaiseAndSetIfChanged(ref _people, value);
        }

        private ObservableCollection<SexTypes> _sexTypeList;
        public ObservableCollection<SexTypes> SexTypeList
        {
            get => _sexTypeList;
            set => RaiseAndSetIfChanged(ref _sexTypeList, value);
        }

        private string _newPersonName;
        public string NewPersonName
        {
            get => _newPersonName;
            set => RaiseAndSetIfChanged(ref _newPersonName, value);
        }


        private SexTypes _selectedSexType;
        public SexTypes SelectedSexType
        {
            get => _selectedSexType;
            set => RaiseAndSetIfChanged(ref _selectedSexType, value);
        }

        private string _newPersonAge;
        public string NewPersonAge
        {
            get => _newPersonAge;
            set => RaiseAndSetIfChanged(ref _newPersonAge, value);

        }

        private bool _isOpenError;
        public bool IsOpenError
        {
            get => _isOpenError;
            set => RaiseAndSetIfChanged(ref _isOpenError, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public ReactiveCommand<Unit, Unit> AddPersonCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteSelectedPersonCommand { get; }
        public ConverterUsageWithDataGridWindowViewModel()
        {
            SexTypeList = new ObservableCollection<SexTypes>(Enum.GetValues(typeof(SexTypes)).Cast<SexTypes>());
            SelectedSexType = SexTypes.Unknown;

            People = new ObservableCollection<Person>()
            {
                new Person { Name = "Çisil", Age = 21, Sex = SexTypes.Female },
                new Person { Name = "Faruk", Age = 31, Sex = SexTypes.Male },
                new Person { Name = "Cem", Age = 16, Sex = SexTypes.Male },
                new Person { Name = "Arda", Age = 22, Sex = SexTypes.Unknown }
            };

            AddPersonCommand = ReactiveCommand.Create(AddPerson);
            DeleteSelectedPersonCommand = ReactiveCommand.Create(DeleteSelectedPerson);
        }

        public void AddPerson()
        {
            try
            {
                if (!int.TryParse(NewPersonAge.ToString(), out int age) || age < 0)
                {
                    ShowErrorMessage("Please enter a valid age.");
                    return;
                }

                var newPerson = new Person
                {
                    Name = NewPersonName ?? "New Person",
                    Age = Convert.ToInt32(NewPersonAge),
                    Sex = SelectedSexType
                };
                People.Add(newPerson);

                // Clear input fields after adding
                NewPersonName = string.Empty;
                NewPersonAge = "0";
                SelectedSexType = SexTypes.Unknown;

                IsOpenError = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error adding person: {ex.Message}");
            }
        }

        public void DeleteSelectedPerson()
        {
            var personToRemove = People.FirstOrDefault(p => p.IsSelected);
            if (personToRemove is null)
            {
                ShowErrorMessage("Please select a person.");
            }

            People.Remove(personToRemove);
        }

        private void ShowErrorMessage(string message)
        {
            ErrorMessage = message;
            IsOpenError = true;
        }
    }
}
