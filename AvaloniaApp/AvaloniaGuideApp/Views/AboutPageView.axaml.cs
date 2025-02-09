using Avalonia.Controls;
using System.Diagnostics;

namespace AvaloniaGuideApp;

public partial class AboutPageView : UserControl
{
    public AboutPageView()
    {
        InitializeComponent();
    }

    private void OpenUrl(string url)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    private void LinkedIn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenUrl("https://www.linkedin.com/in/farukakyapak/");

    }
    private void GitHub_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenUrl("https://github.com/OmerFarukAkyapak");

    }
    private void Medium_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenUrl("https://medium.com/@faruk.akyapak");

    }
}