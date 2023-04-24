using DeliveryService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace DeliveryService.Resources.Behaviors
{
    /// <summary>
    /// Поведение для связывания введенного пароля в <see cref="PasswordBox"/> с моделью представления.
    /// </summary>
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        /// <summary>
        /// Вызывается при добавлении поведения к элементу.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        /// <summary>
        /// Вызывается при удалении поведения из элемента.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
        }

        /// <summary>
        /// Обработчик события изменения пароля в <see cref="PasswordBox"/>.
        /// </summary>
        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox ?? throw new InvalidOperationException();
            PasswordHelper.SetPassword(passwordBox, passwordBox.Password);
        }
    }

}
