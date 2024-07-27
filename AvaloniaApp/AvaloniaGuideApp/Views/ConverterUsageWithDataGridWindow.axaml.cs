using Avalonia.Controls;
using AvaloniaGuideApp.ViewModels;

namespace AvaloniaGuideApp;

public partial class ConverterUsageWithDataGridWindow : Window
{
    ConverterUsageWithDataGridWindowViewModel _viewModel = new();
    public ConverterUsageWithDataGridWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}