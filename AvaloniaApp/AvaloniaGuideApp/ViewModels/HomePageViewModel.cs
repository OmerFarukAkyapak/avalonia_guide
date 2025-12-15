using System;
using Avalonia.Platform;
using Avalonia.Media.Imaging;
using AvaloniaGuideApp.Models;
using System.Collections.ObjectModel;

namespace AvaloniaGuideApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public ObservableCollection<PageModel> Pages { get; set; }

        public HomePageViewModel()
        {
            Pages = new ObservableCollection<PageModel>
            {
                new PageModel
                {
                    Name = "Splash Screen",
                    Description = "Shows a splash screen.",
                    Icon = LoadIcon("/Assets/loading.png"),
                    Page = PagesEnum.SplashPage
                },
                new PageModel
                {
                    Name = "Theme Settings",
                    Description = "Shows a window with theme settings.",
                    Icon = LoadIcon("/Assets/color.png"),
                    Page = PagesEnum.ThemeSettingsPage
                },
                new PageModel
                {
                    Name = "Text Input Dialog",
                    Description = "Shows a dialog to input text.",
                    Icon = LoadIcon("/Assets/input.png"),
                    Page = PagesEnum.TextInputDialogPage
                },
                new PageModel
                {
                    Name = "Converter Usage",
                    Description = "Shows a window with a data grid.",
                    Icon = LoadIcon("/Assets/grid.png"),
                    Page = PagesEnum.ConverterUsagePage
                },
                new PageModel
                {
                    Name = "Task Dialog",
                    Description = "Shows a window with task dialogs.",
                    Icon = LoadIcon("/Assets/dialog.png"),
                    Page = PagesEnum.TaskDialogPage
                },
                new PageModel
                {
                    Name = "Progress Ring Dialog",
                    Description = "Shows a dialog to progressing ring.",
                    Icon = LoadIcon("/Assets/progress.png"),
                    Page = PagesEnum.ProgressRingPage
                }

            };
        }

        private static Bitmap LoadIcon(string path)
        {
            return new Bitmap(AssetLoader.Open(new Uri($"avares://AvaloniaGuideApp{path}")));
        }
    }


}
