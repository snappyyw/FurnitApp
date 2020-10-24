using FurnitureApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FurnitureApp.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        FornitureContext fornitureContext = new FornitureContext();

        public RegistrationWindow()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = new List<string> { "Заказчик","Директор","Менеджер","Заместитель директора","Мастер"};
            RoleComboBox.SelectedIndex = 0;
        }

        private void button_Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ModelCheck())
                {
                    User user = new User
                    {
                        Login = LoginTextBox.Text,
                        Password = PasswordBox.Password,
                        LastName = LastNameTextBox.Text,
                        FirstAndMiddleName = FirstAndMiddleNameTextBox.Text,
                        Role = RoleComboBox.SelectedItem.ToString()
                    };
                    fornitureContext.Users.Add(user);
                    fornitureContext.SaveChanges();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Нет.\n" + ex);
            }
        }
        private bool ModelCheck()
        {
            string errors = "Неккоректные значения: ";
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                errors += " Логин";
            }
            if (!(!string.IsNullOrEmpty(PasswordBox.Password) && (PasswordBox.Password.Length >= 6 && PasswordBox.Password.Length <= 18) && 
                (PasswordBox.Password.Contains("&") || PasswordBox.Password.Contains("*") || PasswordBox.Password.Contains("{") || 
                PasswordBox.Password.Contains("}") || PasswordBox.Password.Contains("|") || PasswordBox.Password.Contains("+"))))
            { 
                errors += " Пароль (должен быть длиной от 6 до 18 символов и коючать себя хотя бы один из символов: *&{}|+)";
            }
            if(errors != "Неккоректные значения: ")
            {
                MessageBox.Show(errors);
                return false;
            }
            else
            {
                return true;
            }
            //"(?=^.{6,18}$)((?=.*\d)(?=.*[*&{}|+]))(?![.\n])(?=.*[a-z])(?!.*[a-z]{3})(?:\+{2,}).*$"
        }
    }
}
