using Avalonia.Controls;
using System.Threading.Tasks;
using System;
using Avalonia.Input;

namespace AvaloniaGuideApp;

public partial class TextInputDialog : Window
{
    private bool _isInputRequired = false;
    Func<string, bool>? _beforeClosing;

    public static async Task<string?> Prompt
        (
        Window parentWindow,
        string title,
        string caption,
        bool isRequired = true,
        string initialValue = "",
        Func<string, bool>? beforeClosing = null
        )
    {
        var window = new TextInputDialog();
        window._isInputRequired = isRequired;
        window.lblTitle.Content = title;
        window.lbl.Content = caption;
        window.txtBox.Text = initialValue;
        window._beforeClosing = beforeClosing;

        var result = await window.ShowDialog<string?>(parentWindow);
        return result;
    }
    public TextInputDialog()
    {
        InitializeComponent();
    }

    private void ButtonOK_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_isInputRequired && string.IsNullOrWhiteSpace(txtBox.Text))
        {
            txtBox.Watermark = "Error : Please provide a value!";
            return;
        }

        if (_beforeClosing != null && !_beforeClosing(txtBox.Text))
        {
            return;
        }

        Close(txtBox.Text);
    }
    private void Window_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ButtonOK_Click(sender, e);
        }
    }
    private void ButtonCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(null);
    }
}