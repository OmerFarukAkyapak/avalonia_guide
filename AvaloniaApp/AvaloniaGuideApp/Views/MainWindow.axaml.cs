using Avalonia.Interactivity;
using FluentAvalonia.UI.Windowing;

namespace AvaloniaGuideApp.Views
{
    public partial class MainWindow : AppWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnShowSplash_Click(object? sender, RoutedEventArgs e)
        {
            var splashScreen = new SplashScreenPage();
            splashScreen.Show();

            await splashScreen.InitApp();
            splashScreen.Close();
        }

        private void btnThemeSettings_Click(object? sender, RoutedEventArgs e)
        {
            var themeSettings = new ThemeSettingsWindow();
            themeSettings.Show();
        }
    }
}