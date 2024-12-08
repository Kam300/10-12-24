using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                if (e.Key == Key.F12)
                {
                    MessageBox.Show("Нажата комбинация Shift + F12!");
                }
            }
        }

        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, что вводимые символы - это цифры, тире или пробел
            if (!Regex.IsMatch(e.Text, @"^[0-9\-\s]+$"))
            {
                e.Handled = true; // Отклонить ввод
            }
        }

        private void PhoneTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Позволяют Backspace и Delete
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                return; // Позволить эти клавиши
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 newe= new Window1();
            newe.Show();
            this.Hide();
        }
    }
}
