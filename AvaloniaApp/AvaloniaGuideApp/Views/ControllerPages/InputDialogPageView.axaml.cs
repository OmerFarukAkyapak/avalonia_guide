using Avalonia.Controls;

namespace AvaloniaGuideApp;

public partial class InputDialogPageView : UserControl
{
    public InputDialogPageView()
    {
        InitializeComponent();
    }

    private async void btnTextInputDialog_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
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
}