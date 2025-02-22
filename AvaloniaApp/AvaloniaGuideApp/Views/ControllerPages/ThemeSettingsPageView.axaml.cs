using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using AvaloniaGuideApp.ViewModels;
using System.Runtime.CompilerServices;

namespace AvaloniaGuideApp;

public partial class ThemeSettingsPageView : UserControl
{
    private readonly ThemeSettingsWindowViewModel _viewModel = new();
    public ThemeSettingsPageView()
    {
        InitializeComponent();
        DataContext = _viewModel;
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

    private void UserControl_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.SaveSettings();
    }
}