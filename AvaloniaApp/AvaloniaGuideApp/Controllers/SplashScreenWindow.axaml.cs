using Avalonia.Threading;
using System.Threading.Tasks;
using System;
using FluentAvalonia.UI.Windowing;

namespace AvaloniaGuideApp;

public partial class SplashScreenWindow : AppWindow
{
    public SplashScreenWindow()
    {
        InitializeComponent();
        CanResize = false;
        ShowAsDialog = true;
        TitleBar.Height = 0;
    }

    public async Task InitApp()
    {
        var start = DateTime.Now.Ticks;
        var time = start;
        var progressValue = 0;

        while ((time - start) < TimeSpan.TicksPerSecond)
        {
            progressValue++;
            Dispatcher.UIThread.Post(() => ProgressBar1.Value = progressValue);
            await Task.Delay(25);
            time = DateTime.Now.Ticks;
        }

        start = time;
        Dispatcher.UIThread.Post(() => LoadingText.Text = "Initializing Application Settings...");
        var limit = TimeSpan.TicksPerSecond * 2;
        while ((time - start) < limit)
        {
            progressValue += 1;
            Dispatcher.UIThread.Post(() => ProgressBar1.Value = progressValue);
            await Task.Delay(50);
            time = DateTime.Now.Ticks;
        }

        Dispatcher.UIThread.Post(() => LoadingText.Text = "Preparing App...");

        while (progressValue < 100)
        {
            progressValue += 1;
            Dispatcher.UIThread.Post(() => ProgressBar1.Value = progressValue);
            await Task.Delay(10);
        }
    }
}