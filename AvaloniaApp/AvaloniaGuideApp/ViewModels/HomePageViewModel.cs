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
                    Page = PagesEnum.SplashPage
                },
                new PageModel
                {
                    Name = "Theme Settings",
                    Description = "Shows a window with theme settings.",
                    Page = PagesEnum.ThemeSettingsPage
                },
                new PageModel
                {
                    Name = "Text Input Dialog",
                    Description = "Shows a dialog to input text.",
                    Page = PagesEnum.TextInputDialogPage
                },
                new PageModel
                {
                    Name = "Converter Usage",
                    Description = "Shows a window with a data grid.",
                    Page = PagesEnum.ConverterUsagePage
                },
                new PageModel
                {
                    Name = "Task Dialog",
                    Description = "Shows a window with task dialogs.",
                    Page = PagesEnum.TaskDialogPage
                }

            };
        }
    }
}
