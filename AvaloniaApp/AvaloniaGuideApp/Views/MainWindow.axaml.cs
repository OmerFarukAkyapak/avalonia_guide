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

        private async void btnTextInputDialog_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var result = await TextInputDialog.Prompt(
                parentWindow: this,
                title: "Text Input Dialog Title",
                caption: "Caption",
                isRequired: true
            );

            if (result != null)
            {
                txtTextInputResult.Text = result;
            }
        }
    }
}