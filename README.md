# Avalonia Guide

This repository is a **guide application** that showcases modern desktop application patterns and practical examples built with **Avalonia UI**.

Avalonia is a .NET-based, **truly cross-platform** UI framework that runs on Windows, macOS, and Linux, using a XAML-based architecture.

🔗 **What is Avalonia?**
[https://docs.avaloniaui.net/docs/overview/what-is-avalonia](https://docs.avaloniaui.net/docs/overview/what-is-avalonia)

---

## 🚀 Installing Avalonia

To install Avalonia UI on your computer, follow the official installation guide below:

🔗 **Getting Started – Installation**
[https://avaloniaui.net/gettingstarted#installation](https://avaloniaui.net/gettingstarted#installation)

Installation overview:

* Install the .NET SDK (LTS recommended)
* Use Visual Studio, Rider, or VS Code
* Install Avalonia project templates
* Create your first project using `dotnet new avalonia.app`

After installation, run the project to verify that your development environment is set up correctly.

---

## 📚 Samples and Resources

You can find official samples and tutorials provided by the Avalonia team at the link below:

🔗 **Avalonia Samples & Tutorials**
[https://docs.avaloniaui.net/docs/tutorials/samples?tm_source=avaloniaui&utm_medium=referral&utm_content=gettingstartedcard](https://docs.avaloniaui.net/docs/tutorials/samples?tm_source=avaloniaui&utm_medium=referral&utm_content=gettingstartedcard)

The examples in this repository are inspired by both the official documentation and real-world application scenarios.

---

## 🧩 Application Features

Below are the main features included in the **avalonia_guide** application.

---

### 🖼️ Splash Screen

> A modern splash screen displayed during application startup.

<!-- Screenshot -->
<img width="1132" height="784" alt="image" src="https://github.com/user-attachments/assets/c6835e3f-05c9-46a8-972a-8fc18c6ba02c" />

---

### 🎨 Theme Management Page (FluentAvalonia)

> Theme management page built using the FluentAvalonia package, including Light / Dark mode and accent color support.

<!-- Screenshot -->
<img width="1078" height="951" alt="image" src="https://github.com/user-attachments/assets/e5e34617-3035-4eb9-bb27-5f23296d8360" />

---

### 💬 Modern Text Input & Task Dialog

> A collection of reusable and modern dialogs, including text input dialogs, Yes/No confirmation task dialogs, and informational dialogs such as success, warning, and error messages.

<!-- Screenshot -->
**Task Dialogs**

<img width="2229" height="1553" alt="Adsız" src="https://github.com/user-attachments/assets/9e19aee1-43b1-4bdd-b583-808254658ac7" />

**Text Input Dialog**

<img width="1113" height="776" alt="image" src="https://github.com/user-attachments/assets/b4b98c21-78e2-40fe-8391-0c001df33757" />

---

### 🔄 Process Ring Dialog

> A progress / process ring dialog used for long-running operations.

<!-- Screenshot -->
<img width="1112" height="772" alt="image" src="https://github.com/user-attachments/assets/1bc7c775-9994-4375-8af4-b508871ac548" />

---

### 📊 DataGrid Example

> DataGrid usage example demonstrating data binding and basic table operations.

<!-- Screenshot -->
<img width="1116" height="778" alt="image" src="https://github.com/user-attachments/assets/a8022717-a9f2-4f79-9a8a-e9710b8239fe" />

---

### 🔁 Value Converter (Usage Converter)

> Custom value converters used within XAML bindings.
In this application, value converters are used to transform raw data into UI-friendly values directly in XAML, keeping ViewModels clean and focused on business logic.


**SexStatusToBackgroundColorConverter**

Maps a SexTypes enum value to a corresponding background color.
<!-- Code -->
```
using Avalonia.Data.Converters;
using Avalonia.Media;
using AvaloniaGuideApp.Models;
using System;
using System.Globalization;

namespace AvaloniaGuideApp.Converters
{
    public class SexStatusToBackgroundColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is SexTypes sex)
            {
                return sex switch
                {
                    SexTypes.Male => Brushes.Blue,
                    SexTypes.Female => Brushes.HotPink,
                    _ => Brushes.LightGray
                };
            }
            return Brushes.LightGray;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
```
**AgeToIsAdultConverter**

Converts an age value into a boolean indicating whether the person is an adult.

```
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace AvaloniaGuideApp.Converters
{
    public class AgeToIsAdultConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int age)
            {
                return age >= 18;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
```

These converters demonstrate how Avalonia enables flexible UI logic through XAML bindings without polluting the ViewModel layer.

```
<UserControl.Resources>
	<local:AgeToIsAdultConverter x:Key="AgeToIsAdultConverter" />
	<local:SexStatusToBackgroundColorConverter x:Key="SexStatusToBackgroundColorConverter" />

</UserControl.Resources>

<DataGridTemplateColumn Header="Sex"
									Width="*">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<Border CornerRadius="10"
								Margin="0 5"
								Background="{Binding Sex, Converter={StaticResource SexStatusToBackgroundColorConverter}}"
								HorizontalAlignment="Center">
							<TextBlock Text="{Binding Sex}"
									   Padding="5"/>
						</Border>

					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
</DataGridTemplateColumn>

<DataGridTextColumn Header="Age"
								Width="*"
								Binding="{Binding Age}"/>

<DataGridTemplateColumn Header="Is Adult"
									Width="*">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<CheckBox IsChecked="{Binding Age, Converter={StaticResource AgeToIsAdultConverter}, Mode=OneWay}"
								  IsEnabled="False"
								  HorizontalAlignment="Center"/>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
</DataGridTemplateColumn>
```

---

### 🔗 ReactiveUI (TwoWay, OneWay Data Binding)

> Two-way binding and ViewModel interaction implemented using ReactiveUI.

<!-- Codes -->
```
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
                new Person { Name = "Fatma", Age = 21, Sex = SexTypes.Female },
                new Person { Name = "Faruk", Age = 31, Sex = SexTypes.Male },
                new Person { Name = "Cem", Age = 16, Sex = SexTypes.Male },
                new Person { Name = "Deniz", Age = 22, Sex = SexTypes.Unknown }
            };

            AddPersonCommand = ReactiveCommand.Create(AddPerson);
            DeleteSelectedPersonCommand = ReactiveCommand.Create(DeleteSelectedPerson);
        }

        public void AddPerson()
        {
            try
            {
                if (NewPersonAge is null || NewPersonName is null)
                {
                    ShowErrorMessage($"Please fill the requiremt fields!");
                    return;
                }

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

```

---

## ✨ Purpose

This project aims to serve as a **reference guide** for:

* Developers who want to learn Avalonia UI
* Building cross-platform desktop applications
* Exploring MVVM, ReactiveUI, and modern UI patterns

---

📌 Contributions, feedback, and suggestions are always welcome!

If you’d like to get in touch, feel free to reach out to me on LinkedIn for questions, discussions, or collaboration opportunities:

🔗 https://www.linkedin.com/in/farukakyapak/

For in-depth explanations, technical deep dives, and detailed tutorials about the topics covered in this project, you can also check out my Medium articles, where each subject is explained in more detail:

✍️ https://medium.com/@faruk.akyapak
