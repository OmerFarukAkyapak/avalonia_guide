using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using AvaloniaGuideApp.Utils;
using AvaloniaGuideApp.ViewModels;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;
using System;

namespace AvaloniaGuideApp.Views
{
    public partial class MainWindow : AppWindow
    {
        private HomePageView _homePageView;
        public MainWindow()
        {
            InitializeComponent();

            _homePageView = new HomePageView();
            navigateView.Content = _homePageView;
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
            if (_homePageView is null)
            {
                _homePageView = new HomePageView();

            }
            navigateView.Content = _homePageView;
        }

        private async void Logout_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var owner = VisualRoot as Window;
            if (owner is null)
            {
                return;
            }

            var result = await TaskDialogHelper.ShowQuestionDialogAsync(owner, "Log Out", "Do you want to close the app ?");

            if (result)
            {
                //Kill the app
                await ProgressDialog.ShowProgressDialogWithDurationTime(owner, "Closing", "The application is closing ...", 3);
                Environment.Exit(0);
            }
        }
    }
}