using Avalonia.Styling;
using AvaloniaGuideApp.Models;
using AvaloniaGuideApp.Utils;
using AvaloniaGuideApp.ViewModels;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;
using System;

namespace AvaloniaGuideApp.Views
{
    public partial class MainWindow : AppWindow
    {
        private MainWindowViewModel _viewModel = new();
        public MainWindow()
        {

            InitializeComponent();
            DataContext = _viewModel;

            SetThemeSymbol();
        }

        private void Window_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindowViewModel.InstanceMainWindow = this;
        }

        private void SetThemeSymbol()
        {
            if (App.Current is null || App.Current.RequestedThemeVariant is null)
            {
                return;
            }

            var appTheme = App.Current.RequestedThemeVariant.ToString();

            if (ThemeVariant.Dark.Key.ToString() == appTheme)
            {
                themeSymbol.Symbol = Symbol.WeatherMoon;

            }
            else if (ThemeVariant.Light.Key.ToString() == appTheme)
            {
                themeSymbol.Symbol = Symbol.WeatherSunny;
            }
        }

        private void Theme_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            if (App.Current is null || App.Current.RequestedThemeVariant is null)
            {
                return;
            }

            var appTheme = App.Current.RequestedThemeVariant.ToString();

            if (ThemeVariant.Dark.Key.ToString() == appTheme)
            {
                App.Current.RequestedThemeVariant = ThemeVariant.Light;
                themeSymbol.Symbol = Symbol.WeatherSunny;

            }
            else if (ThemeVariant.Light.Key.ToString() == appTheme)
            {
                App.Current.RequestedThemeVariant = ThemeVariant.Dark;
                themeSymbol.Symbol = Symbol.WeatherMoon;
            }
        }

        private void HomePage_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            _viewModel.NavigateToPage(PagesEnum.HomePage);
        }

        private void AboutPage_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            _viewModel.NavigateToPage(PagesEnum.AboutPage);
        }

        private async void Logout_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var result = await TaskDialogHelper.ShowQuestionDialogAsync(this, "Log Out", "Do you want to close the app ?");

            if (result)
            {
                //Kill the app
                await ProgressDialog.ShowProgressDialogWithDurationTime(this, "Closing", "The application is closing ...", 3);
                Environment.Exit(0);
            }
        }


        private bool _isClosing = false;
        private async void Window_Closing(object? sender, Avalonia.Controls.WindowClosingEventArgs e)
        {
            if (!_isClosing)
            {
                e.Cancel = true;
            }

            string message = "Are you sure you want to exit?";

            var result = await TaskDialogHelper.ShowQuestionDialogAsync(this, "Exit", message);
            if (result)
            {

                if (App.Current?.RequestedThemeVariant is null)
                {
                    e.Cancel = false;
                    return;
                }

                ThemeHelper.SaveSettings(App.Current.RequestedThemeVariant);
                await ProgressDialog.ShowProgressDialogWithDurationTime(this, "Closing", "The application is closing ...", 1);

                e.Cancel = false;
                _isClosing = true;
                Environment.Exit(0);
            }
        }
    }
}