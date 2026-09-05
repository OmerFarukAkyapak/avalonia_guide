using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace AvaloniaGuideApp;

public partial class InputDialogPageView : UserControl
{
    public InputDialogPageView()
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

        splashCodeEditor.Text = DialogXamlCode;

    }

    private async void btnTextInputDialog_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var owner = TopLevel.GetTopLevel(this) as Window;
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

    private const string DialogXamlCode =
    @"<Window xmlns=""https://github.com/avaloniaui""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
        xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
        mc:Ignorable=""d""
        d:DesignWidth=""475""
        Width=""475""
        d:DesignHeight=""180""
        Height=""260""
        x:Class=""AvaloniaGuideApp.TextInputDialog""
        Icon=""/Assets/avalonia-logo.ico""
        Title=""Text input""
        WindowStartupLocation=""CenterOwner""
        ExtendClientAreaToDecorationsHint=""True""
        ExtendClientAreaTitleBarHeightHint=""0""
        CanResize=""False""
        KeyDown=""Window_KeyDown"">
	<Border BorderBrush=""{DynamicResource CardStrokeColorDefaultBrush}""
	        BorderThickness=""1"">
		<Grid RowDefinitions=""Auto,Auto,Auto,Auto""
		      Margin=""24"">
			<StackPanel Grid.Row=""0""
			            Orientation=""Horizontal""
			            Spacing=""5""
			            Margin=""0 0 0 10"">
				<Image Source=""/Assets/avalonia-logo.ico""
				       Width=""16""
				       Height=""16""/>
				<Label Name=""lblTitle""
				       Content=""Title""
				       Padding=""0""
				       VerticalAlignment=""Center""
				       FontSize=""20""
				       FontWeight=""SemiBold""/>
			</StackPanel>
			<Label Grid.Row=""1""
			       Name=""lbl""
			       Margin=""0 0 0 10""
			       Content=""Value""
			       Padding=""0""
			       VerticalAlignment=""Center""/>
			<TextBox Grid.Row=""2""
			         Name=""txtBox""
			         PlaceholderText=""Enter a value""
			         AutomationProperties.Name=""Input value""/>
			<StackPanel Grid.Row=""3""
			            Margin=""0 20 0 0""
			            Orientation=""Horizontal""
			            HorizontalAlignment=""Right"">
				<Button Content=""OK""
				        Name=""btnOK""
				        Click=""ButtonOK_Click""
				        Margin=""0 0 10 0""
				        MinWidth=""88""
				        Padding=""14,8""/>
				<Button Content=""Cancel""
				        Name=""btnCancel""
				        Click=""ButtonCancel_Click""
				        MinWidth=""88""
				        Padding=""14,8""/>
			</StackPanel>
		</Grid>
	</Border>
</Window>";

}