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
    /// Логика взаимодействия для FurnitureListWindow.xaml
    /// </summary>
    public partial class FurnitureListWindow : Window
    {
        FornitureContext fornitureContext = new FornitureContext();

        public FurnitureListWindow(string role)
        {
            InitializeComponent();
            FurnitureDataGrid.ItemsSource = fornitureContext.Furniture.ToList();
            if (role != "Директор" && role != "Заместитель директора")
            {
                AddButton.IsEnabled = false;
                EditButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (FurnitureDataGrid.SelectedItems.Count > 0)
            {
                Furniture furniture = (Furniture)FurnitureDataGrid.SelectedItems[0];
                fornitureContext.Furniture.Remove(furniture);
                fornitureContext.SaveChanges();
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (FurnitureDataGrid.SelectedItems.Count > 0)
            {
                Furniture furniture = (Furniture)FurnitureDataGrid.SelectedItems[0];
                FurnitureWindow furnitureWindow = new FurnitureWindow(furniture);
                furnitureWindow.Show();
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            FurnitureWindow furnitureWindow = new FurnitureWindow();
            furnitureWindow.Show();
        }
    }
}
