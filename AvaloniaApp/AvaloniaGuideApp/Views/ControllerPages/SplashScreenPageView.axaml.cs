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

    private async void ShowSplash_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var splashScreen = new SplashScreenWindow();
        splashScreen.Show();

        await splashScreen.InitApp();
        splashScreen.Close();
    }

    private const string SplashXamlCode =
    @"<Panel>

    <StackPanel Spacing=""20""
                HorizontalAlignment=""Center""
                VerticalAlignment=""Center"">

        <Image Source=""/Assets/avalonia-logo.ico""
               Width=""250""
               Height=""250""
               RenderOptions.BitmapInterpolationMode=""HighQuality""/>

        <TextBlock Text=""Avalonia Guide App""
                   FontSize=""48""/>

        <ProgressBar MaxWidth=""200""
                     Height=""10""
                     BorderThickness=""1""
                     Margin=""0 10 0 0""/>

        <TextBlock Text=""Loading...""
                   HorizontalAlignment=""Center""
                   FontSize=""20""/>

    </StackPanel>

</Panel>";
}