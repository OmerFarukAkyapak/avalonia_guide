using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaGuideApp.ViewModels;
using AvaloniaGuideApp.Views;

namespace AvaloniaGuideApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var theme = new ThemeSettingsWindowViewModel();
                theme.LoadSettings();

                var splashScreen = new SplashScreenWindow();

                desktop.MainWindow = splashScreen;
                splashScreen.Show();

                await splashScreen.InitApp();

                var main = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };

                desktop.MainWindow = main;
                main.Show();
                splashScreen.Close();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}