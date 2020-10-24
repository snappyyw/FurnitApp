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
    /// Логика взаимодействия для DepDirector.xaml
    /// </summary>
    public partial class DepDirectorWindow : Window
    {
        public DepDirectorWindow()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow authorizationWindow = new MainWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void Button_OpeMaterAccWin_Click(object sender, RoutedEventArgs e)
        {
            MaterialsWindow materialsWindow = new MaterialsWindow("Заместитель директора");
            materialsWindow.Show();
        }

        private void Button_OpeFurnAccWin_Click(object sender, RoutedEventArgs e)
        {
            FurnitureListWindow furnitureListWindow = new FurnitureListWindow("Заместитель директора");
            furnitureListWindow.Show();
        }
    }
}
