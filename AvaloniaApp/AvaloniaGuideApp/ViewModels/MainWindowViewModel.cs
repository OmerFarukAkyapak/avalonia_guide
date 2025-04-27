using Avalonia.Controls;
using AvaloniaGuideApp.Models;

namespace AvaloniaGuideApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl _currentPage = new HomePageView();
        public UserControl CurrentPage
        {
            get => _currentPage;
            set => RaiseAndSetIfChanged(ref _currentPage, value);
        }

        public static Window InstanceMainWindow { get; set; }

        public static MainWindowViewModel InstanceMainWindowVM { get; private set; }

        #region Pages
        private HomePageView _homePage = new();
        private AboutPageView _aboutPage = new();
        private SplashScreenPageView _splashPage = new();
        private ThemeSettingsPageView _themeSettingsPage = new();
        private InputDialogPageView _textInputDialogPage = new();
        private ConverterUsagePageView _converterUsagePage = new();
        private TaskDialogPageView _taskDialogPage = new();
        #endregion

        public MainWindowViewModel()
        {
            InstanceMainWindowVM = this;
        }

        public void NavigateToPage(PagesEnum page)
        {
            switch (page)
            {
                case PagesEnum.HomePage:
                    InstanceMainWindowVM.CurrentPage = _homePage;
                    break;
                case PagesEnum.AboutPage:
                    InstanceMainWindowVM.CurrentPage = _aboutPage;
                    break;
                case PagesEnum.SplashPage:
                    InstanceMainWindowVM.CurrentPage = _splashPage;
                    break;
                case PagesEnum.ThemeSettingsPage:
                    InstanceMainWindowVM.CurrentPage = _themeSettingsPage;
                    break;
                case PagesEnum.TextInputDialogPage:
                    InstanceMainWindowVM.CurrentPage = _textInputDialogPage;
                    break;
                case PagesEnum.ConverterUsagePage:
                    InstanceMainWindowVM.CurrentPage = _converterUsagePage;
                    break;
                case PagesEnum.TaskDialogPage:
                    InstanceMainWindowVM.CurrentPage = _taskDialogPage;
                    break;
                default:
                    break;
            }
        }

    }
}
