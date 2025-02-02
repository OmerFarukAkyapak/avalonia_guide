using Avalonia.Interactivity;
using Avalonia.Media;
using AvaloniaGuideApp.ViewModels;
using FluentAvalonia.UI.Windowing;
using System.Runtime.CompilerServices;

namespace AvaloniaGuideApp;

public partial class ThemeSettingsWindow : AppWindow
{
    private readonly ThemeSettingsWindowViewModel _themeSettings;
    public ThemeSettingsWindow()
    {
        InitializeComponent();

        _themeSettings = new ThemeSettingsWindowViewModel();
        DataContext = _themeSettings;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        var dc = DataContext as ThemeSettingsWindowViewModel;

        if (TryGetResource("SystemAccentColor", null, out var value))
        {
            var color = Unsafe.Unbox<Color>(value);
            dc.CustomAccentColor = color;
            dc.ListBoxColor = color;
        }
    }

    private void Window_Closing(object? sender, Avalonia.Controls.WindowClosingEventArgs e)
    {
        _themeSettings.SaveSettings();
    }
}