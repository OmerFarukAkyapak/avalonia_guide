using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using FluentAvalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Avalonia;
using System.IO;
using AvaloniaGuideApp.Models;

namespace AvaloniaGuideApp.ViewModels
{
    public class ThemeSettingsWindowViewModel : ViewModelBase
    {
        private bool _useCustomAccentColor;
        private Color _customAccentColor;
        private string _currentAppTheme;
        private FlowDirection _currentFlowDirection;
        private Color? _listBoxColor;

        private const string _fileName = "themesettings.json";
        private const string _system = "System";
        private const string _dark = "Dark";
        private const string _light = "Light";
        private readonly FluentAvaloniaTheme _faTheme;

        public List<Color> PredefinedColors { get; private set; }

        public class ThemeSettings
        {
            public string TSAppTheme { get; set; }
            public FlowDirection TSFlowDirection { get; set; }
            public bool TSUseCustomAccent { get; set; }
            public CustomAccentColorARGB TSCustomAccentColor { get; set; }
        }
        public ThemeSettingsWindowViewModel()
        {
            GetPredefColors();
            _faTheme = Application.Current.Styles[0] as FluentAvaloniaTheme;
            LoadSettings();
        }

        public string[] AppThemes { get; } =
        new[] { _system, _light, _dark };

        public FlowDirection[] AppFlowDirections { get; } =
            new[] { FlowDirection.LeftToRight, FlowDirection.RightToLeft };

        private void SetDefaultSettings()
        {
            CurrentAppTheme = _dark;
            CurrentFlowDirection = FlowDirection.LeftToRight;
            UseCustomAccent = true;
            CustomAccentColor = Color.FromArgb(255, 180, 13, 209);
        }
        public void LoadSettings()
        {
            try
            {
                var options = new JsonSerializerOptions();
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(directory, _fileName);

                if (!File.Exists(path))
                {
                    SetDefaultSettings();
                    return;
                }

                string jsonString = File.ReadAllText(path);
                var settings = JsonSerializer.Deserialize<ThemeSettings>(jsonString, options);
                var settingsWithThemeHelper = JsonSerializer.Deserialize<ThemeModel>(jsonString, options);

                if (settings != null)
                {
                    CurrentAppTheme = settings.TSAppTheme ?? settingsWithThemeHelper.AppTheme.ToString();
                    CurrentFlowDirection = settings.TSFlowDirection;
                    UseCustomAccent = settings.TSUseCustomAccent;
                    CustomAccentColor = Color.FromArgb(
                        settings.TSCustomAccentColor?.A ?? settingsWithThemeHelper.CustomAccentColor.A,
                        settings.TSCustomAccentColor?.R ?? settingsWithThemeHelper.CustomAccentColor.R,
                        settings.TSCustomAccentColor?.G ?? settingsWithThemeHelper.CustomAccentColor.G,
                        settings.TSCustomAccentColor?.B ?? settingsWithThemeHelper.CustomAccentColor.B);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SaveSettings()
        {
            try
            {
                var settings = new ThemeSettings
                {
                    TSAppTheme = CurrentAppTheme,
                    TSFlowDirection = CurrentFlowDirection,
                    TSUseCustomAccent = UseCustomAccent,
                    TSCustomAccentColor = new CustomAccentColorARGB
                    {
                        A = CustomAccentColor.A,
                        R = CustomAccentColor.R,
                        G = CustomAccentColor.G,
                        B = CustomAccentColor.B
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
                Console.WriteLine(ex.ToString());
            }
        }
        public string CurrentAppTheme
        {
            get => _currentAppTheme;
            set
            {
                if (RaiseAndSetIfChanged(ref _currentAppTheme, value))
                {
                    var newTheme = GetThemeVariant(value);
                    if (newTheme != null)
                    {
                        Application.Current.RequestedThemeVariant = newTheme;
                    }
                    if (value != _system)
                    {
                        _faTheme.PreferSystemTheme = false;
                    }
                    else
                    {
                        _faTheme.PreferSystemTheme = true;
                    }
                }
            }
        }

        private ThemeVariant GetThemeVariant(string value)
        {
            switch (value)
            {
                case _light:
                    return ThemeVariant.Light;
                case _dark:
                    return ThemeVariant.Dark;
                case _system:
                default:
                    return null;
            }
        }

        public FlowDirection CurrentFlowDirection
        {
            get => _currentFlowDirection;
            set
            {
                if (RaiseAndSetIfChanged(ref _currentFlowDirection, value))
                {
                    var lifetime = Application.Current.ApplicationLifetime;
                    if (lifetime is IClassicDesktopStyleApplicationLifetime cdl)
                    {
                        if (cdl.MainWindow.FlowDirection == value)
                            return;
                        cdl.MainWindow.FlowDirection = value;
                    }
                    else if (lifetime is ISingleViewApplicationLifetime single)
                    {
                        var mainWindow = TopLevel.GetTopLevel(single.MainView);
                        if (mainWindow.FlowDirection == value)
                            return;
                        mainWindow.FlowDirection = value;
                    }
                }
            }
        }

        public bool UseCustomAccent
        {
            get => _useCustomAccentColor;
            set
            {
                if (RaiseAndSetIfChanged(ref _useCustomAccentColor, value))
                {
                    if (value)
                    {
                        if (_faTheme.TryGetResource("SystemAccentColor", null, out var curColor))
                        {
                            _customAccentColor = (Color)curColor;
                            _listBoxColor = _customAccentColor;

                            RaisePropertyChanged(nameof(CustomAccentColor));
                            RaisePropertyChanged(nameof(ListBoxColor));
                        }
                        else
                        {
                            throw new Exception("Unable to retreive SystemAccentColor");
                        }
                    }
                    else
                    {
                        _customAccentColor = default;
                        _listBoxColor = default;
                        RaisePropertyChanged(nameof(CustomAccentColor));
                        RaisePropertyChanged(nameof(ListBoxColor));
                        UpdateAppAccentColor(null);
                    }
                }
            }
        }

        public Color? ListBoxColor
        {
            get => _listBoxColor;
            set
            {
                if (value != null)
                {
                    RaiseAndSetIfChanged(ref _listBoxColor, (Color)value);
                    _customAccentColor = value.Value;
                    RaisePropertyChanged(nameof(CustomAccentColor));
                    UpdateAppAccentColor(value.Value);
                }
                else
                {
                    _listBoxColor = null;
                    RaisePropertyChanged(nameof(CustomAccentColor));
                    UpdateAppAccentColor(null);
                }
            }
        }

        public Color CustomAccentColor
        {
            get => _customAccentColor;
            set
            {
                if (RaiseAndSetIfChanged(ref _customAccentColor, value))
                {
                    _listBoxColor = value;
                    RaisePropertyChanged(nameof(ListBoxColor));
                    UpdateAppAccentColor(value);
                }
            }
        }

        public string CurrentVersion =>
        typeof(Program).Assembly.GetName().Version?.ToString();

        public string CurrentAvaloniaVersion =>
            typeof(Application).Assembly.GetName().Version?.ToString();

        private void GetPredefColors()
        {
            PredefinedColors = new List<Color>
        {
            Color.FromRgb(255,185,0),
            Color.FromRgb(255,140,0),
            Color.FromRgb(247,99,12),
            Color.FromRgb(202,80,16),
            Color.FromRgb(218,59,1),
            Color.FromRgb(239,105,80),
            Color.FromRgb(209,52,56),
            Color.FromRgb(255,67,67),
            Color.FromRgb(231,72,86),
            Color.FromRgb(232,17,35),
            Color.FromRgb(234,0,94),
            Color.FromRgb(195,0,82),
            Color.FromRgb(227,0,140),
            Color.FromRgb(191,0,119),
            Color.FromRgb(194,57,179),
            Color.FromRgb(154,0,137),
            Color.FromRgb(0,120,212),
            Color.FromRgb(0,99,177),
            Color.FromRgb(142,140,216),
            Color.FromRgb(107,105,214),
            Color.FromRgb(135,100,184),
            Color.FromRgb(116,77,169),
            Color.FromRgb(177,70,194),
            Color.FromRgb(136,23,152),
            Color.FromRgb(0,153,188),
            Color.FromRgb(45,125,154),
            Color.FromRgb(0,183,195),
            Color.FromRgb(3,131,135),
            Color.FromRgb(0,178,148),
            Color.FromRgb(1,133,116),
            Color.FromRgb(0,204,106),
            Color.FromRgb(16,137,62),
            Color.FromRgb(122,117,116),
            Color.FromRgb(93,90,88),
            Color.FromRgb(104,118,138),
            Color.FromRgb(81,92,107),
            Color.FromRgb(86,124,115),
            Color.FromRgb(72,104,96),
            Color.FromRgb(73,130,5),
            Color.FromRgb(16,124,16),
            Color.FromRgb(118,118,118),
            Color.FromRgb(76,74,72),
            Color.FromRgb(105,121,126),
            Color.FromRgb(74,84,89),
            Color.FromRgb(100,124,100),
            Color.FromRgb(82,94,84),
            Color.FromRgb(132,117,69),
            Color.FromRgb(126,115,95)
        };
        }

        private void UpdateAppAccentColor(Color? color)
        {
            _faTheme.CustomAccentColor = color;
        }
    }
}
