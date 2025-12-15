using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace AvaloniaGuideApp;

public partial class ProgressRingPageView : UserControl
{
    public ProgressRingPageView()
    {
        InitializeComponent();
        LoadCodeEditor();
    }

    private void LoadCodeEditor()
    {
        var registryOptions = new RegistryOptions(ThemeName.DarkPlus);

        var textMate = splashCodeEditor.InstallTextMate(registryOptions);

        var xmlLang = registryOptions.GetLanguageByExtension(".xml");

        textMate.SetGrammar(registryOptions.GetScopeByLanguageId(xmlLang.Id));

        splashCodeEditor.Background = new SolidColorBrush(Color.Parse("#1E1E1E"));

        splashCodeEditor.Options = new AvaloniaEdit.TextEditorOptions
        {
            HighlightCurrentLine = true
        };

        splashCodeEditor.Text = ProgressRingXamlCode;

    }

    private async void btnShowProgressRing_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = VisualRoot as Window;
        if (owner is null)
        {
            return;
        }

        await ProgressDialog.ShowProgressDialogWithDurationTime(owner, "Title", "Content...", 2);
    }

    private const string ProgressRingXamlCode =
@"<StackPanel Margin=""20"">
    
        <Label Name=""lblTitle""
               Content=""Title""
               FontSize=""24""
               FontWeight=""Bold""/>
    
        <StackPanel Orientation=""Horizontal"" Spacing=""20"">
            <Border Padding=""20"">
                <ui:ProgressRing IsIndeterminate=""True""
                                 BorderThickness=""10""
                                 Width=""75""
                                 Height=""75""/>
            </Border>
    
            <TextBlock Name=""txtContent""
                       Text=""Content ...""
                       FontSize=""16""
                       FontWeight=""SemiBold""
                       TextWrapping=""Wrap""
                       MaxWidth=""400""
                       HorizontalAlignment=""Center""
                       VerticalAlignment=""Center""/>
    
        </StackPanel>
    </StackPanel>";

}