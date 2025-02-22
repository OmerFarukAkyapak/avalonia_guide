using Avalonia.Controls;
using AvaloniaGuideApp.ViewModels;

namespace AvaloniaGuideApp;

public partial class ConverterUsagePageView : UserControl
{
    ConverterUsageWithDataGridWindowViewModel _viewModel = new();
    public ConverterUsagePageView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
}