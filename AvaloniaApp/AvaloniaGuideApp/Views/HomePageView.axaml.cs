using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaGuideApp;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
    }

    private async void btnShowSplash_Click(object? sender, RoutedEventArgs e)
    {
        var splashScreen = new SplashScreenWindow();
        splashScreen.Show();

        await splashScreen.InitApp();
        splashScreen.Close();
    }

    private void btnThemeSettings_Click(object? sender, RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }

        var themeSettings = new ThemeSettingsWindow();
        themeSettings.ShowDialog(owner);
    }

    private async void btnTextInputDialog_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner =  VisualRoot as Window;
        if (owner is null) 
        {
            return;
        }

        var result = await TextInputDialog.Prompt(
            parentWindow: owner,
            title: "Text Input Dialog Title",
            caption: "Caption",
            isRequired: true
        );

        if (result != null)
        {
            txtTextInputResult.Text = result;
        }
    }

    private void btnShowConverterUsage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var converterUsageWithDataGrid = new ConverterUsageWithDataGridWindow();
        converterUsageWithDataGrid.Show();
    }
}