using System;
using Avalonia.Threading;
using System.Threading.Tasks;
using FluentAvalonia.UI.Windowing;

namespace AvaloniaGuideApp;

public partial class SplashScreenWindow : AppWindow
{
    private readonly Action? _mainAction;
    public SplashScreenWindow()
    {
        InitializeComponent();
        CanResize = false;
        ShowAsDialog = true;
        TitleBar.Height = 0;
    }
    public SplashScreenWindow(Action mainAction)
    {
        InitializeComponent();
        TitleBar.Height = 0;
        this.CanResize = false;
        this.ShowAsDialog = true;

        _mainAction = mainAction;

    }
    private void Window_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        InitApp();
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

        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            _mainAction?.Invoke();
            Close();
        });
    }


}