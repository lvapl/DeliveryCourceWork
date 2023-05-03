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
        /// <summary>
        /// Вызывается при добавлении данного поведения к объекту.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        /// <summary>
        /// Вызывается при удалении данного поведения из объекта.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }

        /// <summary>
        /// Обработчик события PreviewTextInput, который предотвращает ввод нечисловых значений.
        /// </summary>
        /// <param name="sender">Объект, генерирующий событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void AssociatedObject_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int result) || e.Text.Last() == ' ')
            {
                e.Handled = true;
            }
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
