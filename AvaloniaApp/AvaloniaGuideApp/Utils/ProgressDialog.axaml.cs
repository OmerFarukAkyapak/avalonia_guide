using Avalonia.Controls;
using FluentAvalonia.UI.Windowing;
using System.Threading.Tasks;
using System;

namespace AvaloniaGuideApp;

public partial class ProgressDialog : AppWindow
{
    public ProgressDialog()
    {
        InitializeComponent();
    }

    public static async Task ShowProgressDialogWithDurationTime(Window owner, string title, string content, int durationInSeconds)
    {
        var progressDialog = new ProgressDialog();
        progressDialog.TitleBar.Height = 0;
        progressDialog.CanResize = false;
        progressDialog.lblTitle.Content = title;
        progressDialog.txtContent.Text = content;

        progressDialog.ShowInTaskbar = false;

        progressDialog.ShowDialog(owner);
        await Task.Delay(TimeSpan.FromSeconds(durationInSeconds));
        progressDialog.Close();
    }

    public static async Task<ProgressDialog> StartShowProgressDialog(Window owner, string title, string content)
    {
        var progressDialog = new ProgressDialog();
        progressDialog.TitleBar.Height = 0;
        progressDialog.CanResize = false;
        progressDialog.lblTitle.Content = title;
        progressDialog.txtContent.Text = content;

        progressDialog.ShowInTaskbar = false;

        progressDialog.ShowDialog(owner);
        return progressDialog;
    }

    public static async Task CloseShowProgressDialog(ProgressDialog progressDialog)
    {
        progressDialog.Close();
    }
}