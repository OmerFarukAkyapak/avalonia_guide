using Avalonia.Controls;

namespace AvaloniaGuideApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnShowSplash_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var splashScreen = new SplashScreenPage();
            splashScreen.Show();

            await splashScreen.InitApp();
            splashScreen.Close();
        }
    }
}