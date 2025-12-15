using Avalonia;
using Avalonia.Markup.Xaml;
using AvaloniaGuideApp.Views;
using AvaloniaGuideApp.ViewModels;
using Avalonia.Controls.ApplicationLifetimes;

namespace AvaloniaGuideApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var theme = new ThemeSettingsWindowViewModel();
                theme.LoadSettings();

#if DEBUG
                // if debug mode is active, splash is closed
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
#else
        // if release mode is active, splash is opened
        desktop.MainWindow = new SplashScreenWindow(() =>
        {
            var mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };

            mainWindow.Show();
            desktop.MainWindow = mainWindow;
        });
#endif
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}