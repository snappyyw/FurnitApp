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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FurnitureApp.Model;
using FurnitureApp.Views;

namespace FurnitureApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FornitureContext fornitureContext = new FornitureContext();

        private string cumcha = cumchaGeneration();

        public MainWindow()
        {
            InitializeComponent();
            labelCapcha.Content = cumcha;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            bool userFined = false;
            List<User> users = fornitureContext.Users.ToList();
            foreach (var user in users)
            {
                if (TextBoxLogin.Text == user.Login && PasswordBox.Password == user.Password && TextBoxCapcha.Text == cumcha)
                {
                    switch (user.Role)
                    {
                        case "Заказчик":
                            CustomerWindow customerWindow = new CustomerWindow();
                            customerWindow.Show();
                            userFined = true;
                            this.Close();
                            break;
                        case "Менеджер":
                            ManagerWindow managerWindow = new ManagerWindow();
                            managerWindow.Show();
                            userFined = true;
                            this.Close();
                            break;
                        case "Заместитель директора":
                            DepDirectorWindow depDirectorWindow = new DepDirectorWindow();
                            depDirectorWindow.Show();
                            userFined = true;
                            this.Close();
                            break;
                        case "Мастер":
                            MasterWindow masterWindow = new MasterWindow();
                            masterWindow.Show();
                            userFined = true;
                            this.Close();
                            break;
                        case "Директор":
                            DirectorWindow directorWindow = new DirectorWindow();
                            directorWindow.Show();
                            userFined = true;
                            this.Close();
                            break;
                    }
                }
            }
            if (!userFined)
            {
                MessageBox.Show("Нет.");
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private static string cumchaGeneration()
        {
            string kastil = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            Random rnd = new Random();
            string cumcha = "";
            for(int i = 0; i< 4; i++)
            {
                int cum = rnd.Next(0, kastil.Length);
                cumcha += kastil[cum];
            }

            return cumcha;
        }

        private void Button_Update_Cumcha_Click(object sender, RoutedEventArgs e)
        {
            cumcha = cumchaGeneration();
            labelCapcha.Content = cumcha;
        }
    }
}
