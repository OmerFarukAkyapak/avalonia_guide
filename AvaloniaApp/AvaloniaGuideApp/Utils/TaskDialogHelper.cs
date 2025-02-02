using Avalonia.Controls;
using Avalonia.Media;
using FluentAvalonia.UI.Controls;
using System.Threading.Tasks;

namespace AvaloniaGuideApp.Utils
{
    public class TaskDialogHelper
    {
        public static async Task ShowTaskDialogAsync(Window owner, string header, string content, TaskDialogType dialogType)
        {

            var taskDialog = new TaskDialog
            {
                Header = header,
                Content = content,
                FooterVisibility = TaskDialogFooterVisibility.Never,
                IsFooterExpanded = false,
                ShowProgressBar = false,
                XamlRoot = owner
            };

            taskDialog.Buttons.Add(new TaskDialogButton { Text = "OK", DialogResult = "OK" });

            switch (dialogType)
            {
                case TaskDialogType.Warning:
                    taskDialog.IconSource = new SymbolIconSource { Symbol = Symbol.AlertOn, Foreground = Brushes.Orange };
                    taskDialog.Title = "Warning";
                    break;
                case TaskDialogType.Error:
                    taskDialog.IconSource = new SymbolIconSource { Symbol = Symbol.Clear, Foreground = Brushes.Red };
                    taskDialog.Title = "Error";
                    break;
                case TaskDialogType.Success:
                    taskDialog.IconSource = new SymbolIconSource { Symbol = Symbol.Accept, Foreground = Brushes.Green };
                    taskDialog.Title = "Success";
                    break;
                case TaskDialogType.Information:
                    taskDialog.IconSource = new SymbolIconSource { Symbol = Symbol.Important, Foreground = Brushes.Blue };
                    taskDialog.Title = "Information";
                    break;
            }

            await taskDialog.ShowAsync(true);
        }

        public static async Task<bool> ShowQuestionDialogAsync(Window owner, string header, string content)
        {

            var taskDialog = new TaskDialog
            {
                Title = "Question",
                Header = header,
                Content = content,
                FooterVisibility = TaskDialogFooterVisibility.Never,
                IsFooterExpanded = false,
                ShowProgressBar = false,
                IconSource = new SymbolIconSource { Symbol = Symbol.Help, Foreground = Brushes.BlueViolet },
                XamlRoot = owner
            };

            var yesButton = new TaskDialogButton { Text = "Yes", DialogResult = "Yes" };
            var noButton = new TaskDialogButton { Text = "No", DialogResult = "No" };

            taskDialog.Buttons.Add(yesButton);
            taskDialog.Buttons.Add(noButton);
            //var footerCheckBox = new CheckBox { Content = "Never show me this again" };
            //taskDialog.Footer = footerCheckBox;

            var result = await taskDialog.ShowAsync(true);

            return result == "Yes";
        }
    }

    public enum TaskDialogType
    {
        Warning,
        Error,
        Success,
        Information
    }
}
