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
        var owner = TopLevel.GetTopLevel(this) as Window;
        if (owner is null)
        {
            return;
        }

        await ProgressDialog.ShowProgressDialogWithDurationTime(owner, "Title", "Content...", 2);
    }

    private const string ProgressRingXamlCode =
    @"<Window xmlns=""https://github.com/avaloniaui""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
        xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
        xmlns:ui=""using:FluentAvalonia.UI.Controls""
        mc:Ignorable=""d""
        d:DesignWidth=""600""
        d:DesignHeight=""200""
        Width=""500""
        Height=""220""
        x:Class=""AvaloniaGuideApp.ProgressDialog""
        WindowStartupLocation=""CenterOwner""
        ExtendClientAreaToDecorationsHint=""True""
        ExtendClientAreaTitleBarHeightHint=""0""
        CanResize=""False"">
	<StackPanel Margin=""24"">
		<Label Name=""lblTitle""
		       Content=""Title""
		       FontSize=""24""
		       FontWeight=""Bold""/>
		<StackPanel Orientation=""Horizontal""
		            Spacing=""20"">
			<Border Padding=""20"">
				<ui:FAProgressRing IsIndeterminate=""True""
				                   Width=""44""
				                   Height=""44""/>
			</Border>
			<TextBlock Name=""txtContent""
			           Text=""Content ...""
			           FontSize=""14""
			           FontWeight=""Normal""
			           TextWrapping=""Wrap""
			           MaxWidth=""310""
			           HorizontalAlignment=""Center""
			           VerticalAlignment=""Center""/>
		</StackPanel>
	</StackPanel>
</Window>";

}