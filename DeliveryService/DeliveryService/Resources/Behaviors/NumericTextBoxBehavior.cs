using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeliveryService.Resources.Behaviors
{
    /// <summary>
    /// Поведение для числового текстового поля, которое позволяет вводить только целочисленные значения.
    /// </summary>
    public class NumericTextBoxBehavior : Behavior<TextBox>
    {
        private bool _userTextChanged = true;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += OnTextChanged;
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;
            DataObject.AddPastingHandler(AssociatedObject, OnPaste);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.TextChanged -= OnTextChanged;
            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            DataObject.RemovePastingHandler(AssociatedObject, OnPaste);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_userTextChanged) return;

            _userTextChanged = false;

            if (double.TryParse(AssociatedObject.Text, out double result))
            {
                NumericValue = result;
            }
            else
            {
                NumericValue = default(double);

                if (string.IsNullOrEmpty(AssociatedObject.Text))
                {
                    AssociatedObject.Text = "0";
                    _userTextChanged = true;
                    AssociatedObject.CaretIndex = 1;
                }
            }

            _userTextChanged = true;
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
            {
                e.Handled = true;
                return;
            }

            if (e.Text != "0" && AssociatedObject.Text == "0")
            {
                // если пользователь начал вводить число, удаляем автоматически подставленный ноль
                AssociatedObject.Text = e.Text;
                AssociatedObject.CaretIndex = 1;
                e.Handled = true;
            }
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));

                if (!IsTextAllowed(pastedText))
                {
                    e.CancelCommand();
                }
                else if (AssociatedObject.Text.Length == 0)
                {
                    // если вставляем текст и строка пустая, подставляем 0
                    AssociatedObject.Text = "0";
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsTextAllowed(string text)
        {
            return !string.IsNullOrEmpty(text) && text.All(char.IsDigit);
        }

        public static readonly DependencyProperty NumericValueProperty =
        DependencyProperty.Register("NumericValue", typeof(double), typeof(NumericTextBoxBehavior), new PropertyMetadata(default(double), OnNumericValueChanged));

        private static void OnNumericValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as NumericTextBoxBehavior;

            if (behavior._userTextChanged) // только если изменение вызвано пользователем
            {
                behavior.AssociatedObject.Text = e.NewValue.ToString();
            }
        }

        public double NumericValue
        {
            get { return (double)GetValue(NumericValueProperty); }
            set { SetValue(NumericValueProperty, value); }
        }
    }
}
