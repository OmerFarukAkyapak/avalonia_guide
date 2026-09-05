using Avalonia.Controls;
using System;
using System.Threading.Tasks;

namespace AvaloniaGuideApp;

public partial class ProgressDialog : Window
{
    public ProgressDialog()
    {
        InitializeComponent();
    }

    public static async Task ShowProgressDialogWithDurationTime(Window owner, string title, string content, int durationInSeconds)
    {
        var progressDialog = new ProgressDialog();
        progressDialog.CanResize = false;
        progressDialog.lblTitle.Content = title;
        progressDialog.txtContent.Text = content;

        progressDialog.ShowInTaskbar = false;

        _ = progressDialog.ShowDialog(owner);
        await Task.Delay(TimeSpan.FromSeconds(durationInSeconds));
        progressDialog.Close();
    }

    public static Task<ProgressDialog> StartShowProgressDialog(Window owner, string title, string content)
    {
        var progressDialog = new ProgressDialog();
        progressDialog.CanResize = false;
        progressDialog.lblTitle.Content = title;
        progressDialog.txtContent.Text = content;

        progressDialog.ShowInTaskbar = false;

        _ = progressDialog.ShowDialog(owner);
        return Task.FromResult(progressDialog);
    }

    public static Task CloseShowProgressDialog(ProgressDialog progressDialog)
    {
        progressDialog.Close();
        return Task.CompletedTask;
    }
}