using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaEdit.TextMate;
using AvaloniaGuideApp.Utils;
using TextMateSharp.Grammars;

namespace AvaloniaGuideApp;

public partial class TaskDialogPageView : UserControl
{
    public TaskDialogPageView()
    {
        InitializeComponent();
        LoadCodeEditor();
    }

    private void LoadCodeEditor()
    {
        var registryOptions = new RegistryOptions(ThemeName.DarkPlus);

        var textMate = splashCodeEditor.InstallTextMate(registryOptions);

        var xmlLang = registryOptions.GetLanguageByExtension(".cs");

        textMate.SetGrammar(registryOptions.GetScopeByLanguageId(xmlLang.Id));

        splashCodeEditor.Background = new SolidColorBrush(Color.Parse("#1E1E1E"));

        splashCodeEditor.Options = new AvaloniaEdit.TextEditorOptions
        {
            HighlightCurrentLine = true
        };

        splashCodeEditor.Text = TaskDialogHelperCode;

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

    private const string TaskDialogHelperCode =
@"public class TaskDialogHelper
{
    public static async Task ShowTaskDialogAsync(
        Window owner,
        string header,
        string content,
        TaskDialogType dialogType)
    {
        var taskDialog = new TaskDialog
        {
            Header = header,
            Content = content,
            FooterVisibility = TaskDialogFooterVisibility.Never,
            IsFooterExpanded = false,
            ShowProgressBar = false,
            XamlRoot = owner
        };

        taskDialog.Buttons.Add(
            new TaskDialogButton
            {
                Text = ""OK"",
                DialogResult = ""OK""
            });

        switch (dialogType)
        {
            case TaskDialogType.Warning:
                taskDialog.IconSource =
                    new SymbolIconSource
                    {
                        Symbol = Symbol.AlertOn,
                        Foreground = Brushes.Orange
                    };
                taskDialog.Title = ""Warning"";
                break;

            case TaskDialogType.Error:
                taskDialog.IconSource =
                    new SymbolIconSource
                    {
                        Symbol = Symbol.Clear,
                        Foreground = Brushes.Red
                    };
                taskDialog.Title = ""Error"";
                break;

            case TaskDialogType.Success:
                taskDialog.IconSource =
                    new SymbolIconSource
                    {
                        Symbol = Symbol.Accept,
                        Foreground = Brushes.Green
                    };
                taskDialog.Title = ""Success"";
                break;

            case TaskDialogType.Information:
                taskDialog.IconSource =
                    new SymbolIconSource
                    {
                        Symbol = Symbol.Important,
                        Foreground = Brushes.Blue
                    };
                taskDialog.Title = ""Information"";
                break;
        }

        await taskDialog.ShowAsync(true);
    }

    public static async Task<bool> ShowQuestionDialogAsync(
        Window owner,
        string header,
        string content)
    {
        var taskDialog = new TaskDialog
        {
            Title = ""Question"",
            Header = header,
            Content = content,
            FooterVisibility = TaskDialogFooterVisibility.Never,
            IsFooterExpanded = false,
            ShowProgressBar = false,
            IconSource =
                new SymbolIconSource
                {
                    Symbol = Symbol.Help,
                    Foreground = Brushes.BlueViolet
                },
            XamlRoot = owner
        };

        var yesButton =
            new TaskDialogButton
            {
                Text = ""Yes"",
                DialogResult = ""Yes""
            };

        var noButton =
            new TaskDialogButton
            {
                Text = ""No"",
                DialogResult = ""No""
            };

        taskDialog.Buttons.Add(yesButton);
        taskDialog.Buttons.Add(noButton);

        // var footerCheckBox =
        //     new CheckBox
        //     {
        //         Content = ""Never show me this again""
        //     };
        // taskDialog.Footer = footerCheckBox;

        var result = await taskDialog.ShowAsync(true);

        return result == ""Yes"";
    }
}

public enum TaskDialogType
{
    Warning,
    Error,
    Success,
    Information
}";

}