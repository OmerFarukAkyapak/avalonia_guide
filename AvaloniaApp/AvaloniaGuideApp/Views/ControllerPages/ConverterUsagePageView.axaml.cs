using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaEdit.TextMate;
using AvaloniaGuideApp.ViewModels;
using TextMateSharp.Grammars;

namespace AvaloniaGuideApp;

public partial class ConverterUsagePageView : UserControl
{
    ConverterUsageWithDataGridWindowViewModel _viewModel = new();
    public ConverterUsagePageView()
    {
        InitializeComponent();
        DataContext = _viewModel;
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

        splashCodeEditor.Text = DataGridWithConverterXamlCode;

    }

    private const string DataGridWithConverterXamlCode =
@"<UserControl.Resources>
    <local:AgeToIsAdultConverter x:Key=""AgeToIsAdultConverter"" />
    <local:SexStatusToBackgroundColorConverter x:Key=""SexStatusToBackgroundColorConverter"" />
</UserControl.Resources>

<ScrollViewer Padding=""20"">
    <StackPanel Spacing=""20"">

        <StackPanel Spacing=""10"">
            <TextBlock Text=""Data Grid With Converter Page""
                       FontWeight=""Bold""
                       FontSize=""24""/>
            <Separator/>
        </StackPanel>

        <Grid RowDefinitions=""*,Auto"">

            <DataGrid Grid.Row=""0""
                      GridLinesVisibility=""All""
                      ItemsSource=""{Binding People}""
                      AutoGenerateColumns=""False"">

                <DataGrid.Columns>

                    <DataGridCheckBoxColumn Header=""*""
                                            Binding=""{Binding IsSelected}""
                                            Width=""Auto""/>

                    <DataGridTextColumn Header=""Name""
                                        Width=""*""
                                        Binding=""{Binding Name}""/>

                    <DataGridTemplateColumn Header=""Sex""
                                            Width=""*"">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Border CornerRadius=""10""
                                        Margin=""0 5""
                                        Background=""{Binding Sex, Converter={StaticResource SexStatusToBackgroundColorConverter}}""
                                        HorizontalAlignment=""Center"">
                                    <TextBlock Text=""{Binding Sex}""
                                               Padding=""5""/>
                                </Border>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>

                    <DataGridTextColumn Header=""Age""
                                        Width=""*""
                                        Binding=""{Binding Age}""/>

                    <DataGridTemplateColumn Header=""Is Adult""
                                            Width=""*"">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <CheckBox IsChecked=""{Binding Age, Converter={StaticResource AgeToIsAdultConverter}, Mode=OneWay}""
                                          IsEnabled=""False""
                                          HorizontalAlignment=""Center""/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>

                </DataGrid.Columns>
            </DataGrid>

            <StackPanel Grid.Row=""1""
                        Margin=""0 100 0 0""
                        Spacing=""10"">

                <TextBlock Text=""Person Management""
                           FontWeight=""Bold""
                           FontSize=""16""/>

                <StackPanel Orientation=""Horizontal""
                            Spacing=""10"">

                    <TextBox Text=""{Binding NewPersonName, Mode=TwoWay}""
                             Watermark=""Name""
                             Width=""200""/>

                    <ComboBox ItemsSource=""{Binding SexTypeList}""
                              SelectedItem=""{Binding SelectedSexType}""
                              Height=""38""/>

                    <TextBox Text=""{Binding NewPersonAge, Mode=TwoWay}""
                             Watermark=""Age""/>

                    <Button Command=""{Binding AddPersonCommand}"">
                        <Button.Content>
                            <StackPanel Orientation=""Horizontal""
                                        Spacing=""10"">
                                <Image Source=""/Assets/plus.png""
                                       RenderOptions.BitmapInterpolationMode=""HighQuality""
                                       Width=""16""
                                       Height=""16""/>
                                <Label Content=""Add Person""/>
                            </StackPanel>
                        </Button.Content>
                    </Button>

                    <Button Command=""{Binding DeleteSelectedPersonCommand}""
                            HorizontalAlignment=""Right"">
                        <Button.Content>
                            <StackPanel Orientation=""Horizontal""
                                        Spacing=""10"">
                                <Image Source=""/Assets/delete.png""
                                       RenderOptions.BitmapInterpolationMode=""HighQuality""
                                       Width=""16""
                                       Height=""16""/>
                                <Label Content=""Delete Selected Person""/>
                            </StackPanel>
                        </Button.Content>
                    </Button>

                </StackPanel>

                <ui:TeachingTip Title=""Error""
                                PreferredPlacement=""BottomLeft""
                                Background=""Red""
                                IsOpen=""{Binding IsOpenError, Mode=TwoWay}""
                                Subtitle=""{Binding ErrorMessage}""/>
            </StackPanel>

        </Grid>
    </StackPanel>
</ScrollViewer>";

}