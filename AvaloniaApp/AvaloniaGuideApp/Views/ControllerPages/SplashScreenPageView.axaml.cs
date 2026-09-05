using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace AvaloniaGuideApp;

public partial class SplashScreenPageView : UserControl
{
    public SplashScreenPageView()
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

        splashCodeEditor.Text = SplashXamlCode;

    }

    private void ShowSplash_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var splashScreen = new SplashScreenWindow();
        splashScreen.Show();
    }

    private const string SplashXamlCode =
    @"<Window xmlns=""https://github.com/avaloniaui""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
        xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
        mc:Ignorable=""d""
        d:DesignWidth=""500""
        d:DesignHeight=""500""
        Width=""460""
        Height=""380""
        x:Class=""AvaloniaGuideApp.SplashScreenWindow""
        Topmost=""True""
        CanResize=""False""
        WindowDecorations=""None""
        WindowStartupLocation=""CenterOwner""
        Loaded=""Window_Loaded"">
	<Panel>
		<StackPanel Spacing=""20""
		            HorizontalAlignment=""Center""
		            VerticalAlignment=""Center"">
			<Image Source=""/Assets/avalonia-logo.ico""
			       Width=""96""
			       Height=""96""
			       RenderOptions.BitmapInterpolationMode=""HighQuality""/>
			<TextBlock Text=""Avalonia Guide App""
			           FontSize=""28""
			           FontWeight=""SemiBold""/>
			<ProgressBar Name=""ProgressBar1""
			             MaxWidth=""220""
			             Height=""4""
			             BorderThickness=""0""
			             Margin=""0 10 0 0""
			             Width=""220""/>
			<TextBlock Text=""Loading...""
			           Name=""LoadingText""
			           HorizontalAlignment=""Center""
			           FontSize=""14""
			           Foreground=""{DynamicResource TextFillColorSecondaryBrush}""/>
		</StackPanel>
	</Panel>
</Window>";
}