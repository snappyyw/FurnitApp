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
    /// Логика взаимодействия для MaterialsWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        FornitureContext fornitureContext = new FornitureContext();

        public MaterialsWindow(string role)
        {
            InitializeComponent();
            MaterialsDataGrid.ItemsSource = fornitureContext.Materials.ToList();
            AllCountLabel.Content = fornitureContext.Materials.Count();
            DisplayedLabel.Content = fornitureContext.Materials.Count();
            if(role != "Директор" && role != "Заместитель директора")
            {
                AddButton.IsEnabled = false;
                EditButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            MaterialWindow materialWindow = new MaterialWindow();
            materialWindow.Show();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItems.Count > 0)
            {
                Material material = (Material)MaterialsDataGrid.SelectedItems[0];
                MaterialWindow materialWindow = new MaterialWindow(material);
                materialWindow.Show();
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItems.Count > 0)
            {
                Material material = (Material)MaterialsDataGrid.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    fornitureContext.Materials.Remove(material);
                    fornitureContext.SaveChanges();
                }
            }
        }

        private void Button_All_Click(object sender, RoutedEventArgs e)
        {
            MaterialsDataGrid.ItemsSource = fornitureContext.Materials.ToList();
            MaterialsDataGrid.Items.Refresh();
            AllCountLabel.Content = fornitureContext.Materials.Count();
            DisplayedLabel.Content = fornitureContext.Materials.Count();
        }

        private void Button_Qual_Click(object sender, RoutedEventArgs e)
        {
            MaterialsDataGrid.ItemsSource = fornitureContext.Materials.Where(m => m.Quality == "Качественный").ToList();
            MaterialsDataGrid.Items.Refresh();
            AllCountLabel.Content = fornitureContext.Materials.Count();
            DisplayedLabel.Content = fornitureContext.Materials.Where(m => m.Quality == "Качественный").Count();
        }

        private void Button_Def_Click(object sender, RoutedEventArgs e)
        {
            MaterialsDataGrid.ItemsSource = fornitureContext.Materials.Where(m => m.Quality == "С незначительными дефектами").ToList();
            MaterialsDataGrid.Items.Refresh();
            AllCountLabel.Content = fornitureContext.Materials.Count();
            DisplayedLabel.Content = fornitureContext.Materials.Where(m => m.Quality == "С незначительными дефектами").Count();
        }

        private void Button_Brak_Click(object sender, RoutedEventArgs e)
        {
            MaterialsDataGrid.ItemsSource = fornitureContext.Materials.Where(m => m.Quality == "Бракованный").ToList();
            MaterialsDataGrid.Items.Refresh();
            AllCountLabel.Content = fornitureContext.Materials.Count();
            DisplayedLabel.Content = fornitureContext.Materials.Where(m => m.Quality == "Бракованный").Count();
        }
    }
}
