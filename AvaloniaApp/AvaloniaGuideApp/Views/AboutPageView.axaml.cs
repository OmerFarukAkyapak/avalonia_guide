using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace AvaloniaGuideApp;

public partial class AboutPageView : UserControl
{
    public AboutPageView()
    {
        InitializeComponent();
    }

    private void Link_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button { Tag: string url } button ||
            !Uri.TryCreate(url, UriKind.Absolute, out var uri) || uri.Scheme != Uri.UriSchemeHttps)
        {
            return;
        }

        try
        {
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true });
            ToolTip.SetTip(button, null);
        }
        catch (Exception ex) when (ex is Win32Exception or InvalidOperationException or NotSupportedException)
        {
            ToolTip.SetTip(button, $"Could not open your browser. Visit {uri.AbsoluteUri}");
            ToolTip.SetIsOpen(button, true);
        }
    }
}
