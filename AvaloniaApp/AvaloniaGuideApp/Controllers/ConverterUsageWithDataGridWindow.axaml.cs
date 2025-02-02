using AvaloniaGuideApp.ViewModels;
using FluentAvalonia.UI.Windowing;

namespace AvaloniaGuideApp;

public partial class ConverterUsageWithDataGridWindow : AppWindow
{
    ConverterUsageWithDataGridWindowViewModel _viewModel = new();
    public ConverterUsageWithDataGridWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}