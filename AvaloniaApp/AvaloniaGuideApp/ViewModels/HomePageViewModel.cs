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
                    Description = "Preview a polished startup window and loading sequence.",
                    Icon = LoadIcon("/Assets/loading.png"),
                    Page = PagesEnum.SplashPage
                },
                new PageModel
                {
                    Name = "Theme Settings",
                    Description = "Explore light and dark themes, accent colors and layout direction.",
                    Icon = LoadIcon("/Assets/color.png"),
                    Page = PagesEnum.ThemeSettingsPage
                },
                new PageModel
                {
                    Name = "Text Input Dialog",
                    Description = "Collect user input and work with the confirmed result.",
                    Icon = LoadIcon("/Assets/input.png"),
                    Page = PagesEnum.TextInputDialogPage
                },
                new PageModel
                {
                    Name = "Converter Usage",
                    Description = "Edit a people collection and see value converters in action.",
                    Icon = LoadIcon("/Assets/grid.png"),
                    Page = PagesEnum.ConverterUsagePage
                },
                new PageModel
                {
                    Name = "Task Dialog",
                    Description = "Try status messages, warnings and confirmation dialogs.",
                    Icon = LoadIcon("/Assets/dialog.png"),
                    Page = PagesEnum.TaskDialogPage
                },
                new PageModel
                {
                    Name = "Progress Ring Dialog",
                    Description = "Display progress while a background operation completes.",
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
