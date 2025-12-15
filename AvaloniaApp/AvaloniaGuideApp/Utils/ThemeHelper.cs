using Avalonia.Styling;
using AvaloniaGuideApp.Models;
using FluentAvalonia.Styling;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AvaloniaGuideApp.Utils
{
    public class ThemeHelper
    {
        private static readonly FluentAvaloniaTheme _faTheme;
        private const string _fileName = "themesettings.json";

        static ThemeHelper()
        {
            _faTheme = App.Current.Styles[0] as FluentAvaloniaTheme;
        }

        // We use the ThemeSettingsWindowViewModel's LoadSettings method to load the theme settings.
        // If you want to use the ThemeHelper class to load the theme settings, you can uncomment the LoadSettings method and the ApplyTheme method.
        // But first, you need to remove from App.axaml.cs the following line:
        // var theme = new ThemeSettingsWindowViewModel();
        // theme.LoadSettings();
        // Then, you can uncomment the LoadSettings method and the ApplyTheme method.


        //public static void SetDefaultSettings()
        //{
        //    var defaultTheme = new ThemeModel()
        //    {
        //        AppTheme = ThemeVariant.Dark,
        //        CustomAccentColor = new CustomAccentColorARGB()
        //        {
        //            A = 255,
        //            R = 142,
        //            G = 109,
        //            B = 212
        //        }
        //    };
        //    ApplyTheme(defaultTheme.AppTheme, true);
        //}

        //public static void LoadSettings()
        //{
        //    try
        //    {
        //        var options = new JsonSerializerOptions();
        //        string directory = AppDomain.CurrentDomain.BaseDirectory;
        //        string path = Path.Combine(directory, _fileName);
        //        if (!File.Exists(path))
        //        {
        //            SetDefaultSettings();
        //            return;
        //        }
        //        string jsonString = File.ReadAllText(path);
        //        var settings = JsonSerializer.Deserialize<ThemeModel>(jsonString, options);
        //        if (settings != null)
        //        {
        //            ApplyTheme(settings.AppTheme, false);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void ApplyTheme(ThemeVariant theme, bool isDefault)
        //{
        //    if (isDefault)
        //    {
        //        Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        //        _faTheme.CustomAccentColor = Color.FromArgb(255, 142, 109, 212);
        //    }
        //    else
        //    {
        //        var themeKeyControl = theme.Key.ToString();
        //        Application.Current.RequestedThemeVariant = themeKeyControl.Contains(ThemeVariant.Dark.Key.ToString()) ? ThemeVariant.Dark : ThemeVariant.Light;
        //        _faTheme.CustomAccentColor = Color.FromArgb(255, 142, 109, 212);
        //    }
        //}

        public static void SaveSettings(ThemeVariant theme)
        {
            try
            {
                var settings = new ThemeModel
                {
                    AppTheme = theme,
                    CustomAccentColor = new CustomAccentColorARGB()
                    {
                        A = 255,
                        R = 142,
                        G = 109,
                        B = 212
                    }
                };

                var options = new JsonSerializerOptions();
                string jsonString = JsonSerializer.Serialize(settings, options);
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(directory, _fileName);
                File.WriteAllText(path, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
