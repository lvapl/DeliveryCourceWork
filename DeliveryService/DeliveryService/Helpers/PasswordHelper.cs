using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DeliveryService.Helpers
{
    /// <summary>
    /// Вспомогательный класс, предназначенный для работы с <see cref="PasswordBox"/> в WPF.
    /// </summary>
    public static class PasswordHelper
    {
        #region Public Fields
        /// <summary>
        /// Регистрирует зависимое свойство <see cref="PasswordBox.Password"/> для <see cref="PasswordBox"/>.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnPasswordPropertyChanged));

        private static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordHelper));
        #endregion

        #region Methods
        /// <summary>
        /// Устанавливает значение <see cref="PasswordBox.Password"/> для указанного объекта зависимостей.
        /// </summary>
        /// <param name="dp">Объект зависимостей.</param>
        /// <param name="value">Значение для установки.</param>
        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        /// <summary>
        /// Получает значение <see cref="PasswordBox.Password"/> из указанного объекта зависимостей.
        /// </summary>
        /// <param name="dp">Объект зависимостей.</param>
        /// <returns>Значение Password.</returns>
        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var password = (string)e.NewValue;

            if (passwordBox != null && passwordBox.Password != password)
            {
                passwordBox.Password = password;
                passwordBox.Focus(); // установка фокуса на PasswordBox
                var textBox = passwordBox.Template.FindName("PART_TextBox", passwordBox) as TextBox;
                if (textBox != null)
                {
                    textBox.SelectionStart = passwordBox.Password.Length; // перемещение курсора в конец строки Password
                    textBox.SelectionLength = 0; // удаление выделения текста
                }
            }
        }
        #endregion
    }

}
