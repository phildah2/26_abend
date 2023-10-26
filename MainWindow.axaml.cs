using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace MeinTaschenrechnerGUI
{
    public class MainWindow : Window
    {
        private string? _currentOperation;
        private double _firstNumber;
        private TextBox? _display;

        public MainWindow()
        {
            InitializeComponent();
            _display = this.FindControl<TextBox>("Display");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var button = sender as Button;
            _display.Text += button.Content.ToString();
        }

        private void Operation_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var button = sender as Button;
            _firstNumber = Convert.ToDouble(_display.Text);
            _currentOperation = button.Content.ToString();
            _display.Text = "";
        }

        private void Clear_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _display.Text = "";
        }

        private void Equal_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var secondNumber = Convert.ToDouble(_display.Text);
            double result = 0;

            switch (_currentOperation)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "*":
                    result = _firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = _firstNumber / secondNumber;
                    }
                    else
                    {
                        _display.Text = "Error";
                        return;
                    }
                    break;
            }

            _display.Text = result.ToString();
        }
    }
}
