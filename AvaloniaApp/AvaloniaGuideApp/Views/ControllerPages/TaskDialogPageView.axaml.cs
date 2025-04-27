using Avalonia.Controls;
using AvaloniaGuideApp.Utils;

namespace AvaloniaGuideApp;

public partial class TaskDialogPageView : UserControl
{
    public TaskDialogPageView()
    {
        InitializeComponent();
    }

    private async void btnWarning_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }

        // Show a warning dialog
        await TaskDialogHelper.ShowTaskDialogAsync(owner, "Warning", "This is a warning message.", TaskDialogType.Warning);
    }

    private async void btnError_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }
        // Show an error dialog
        await TaskDialogHelper.ShowTaskDialogAsync(owner, "Error", "This is an error message.", TaskDialogType.Error);
    }

    private async void btnSuccess_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }
        // Show a success dialog
        await TaskDialogHelper.ShowTaskDialogAsync(owner, "Success", "This is a success message.", TaskDialogType.Success);
    }

    private async void btnInformation_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }
        // Show an information dialog
        await TaskDialogHelper.ShowTaskDialogAsync(owner, "Information", "This is an information message.", TaskDialogType.Information);
    }

    private async void btnQuestion_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }
        // Show a question dialog
        var result = await TaskDialogHelper.ShowQuestionDialogAsync(owner, "Question", "This is a question message.");

        if (result)
        {
            // User clicked Yes
            txtDialogResult.Text = "Yes";
        }
        else
        {
            // User clicked No
            txtDialogResult.Text = "No";
        }
    }
}