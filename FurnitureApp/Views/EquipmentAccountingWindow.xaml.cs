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
    /// Логика взаимодействия для EquipmentAccountingWindow.xaml
    /// </summary>
    public partial class EquipmentAccountingWindow : Window
    {
        FornitureContext fornitureContext = new FornitureContext();

        public EquipmentAccountingWindow()
        {
            InitializeComponent();
            EquipmentsDataGrid.ItemsSource = fornitureContext.Equipments.ToList();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentsDataGrid.SelectedItems.Count > 0)
            {
                Equipment equipment = (Equipment)EquipmentsDataGrid.SelectedItems[0];
                fornitureContext.Equipments.Remove(equipment);
                fornitureContext.SaveChanges();
            }
        }

        private void Button_OpenSpecifications_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentsDataGrid.SelectedItems.Count > 0)
            {
                Equipment equipment = (Equipment)EquipmentsDataGrid.SelectedItems[0];
                EquipmentSpecificationsWindow equipmentSpecificationsWindow = new EquipmentSpecificationsWindow();
                equipmentSpecificationsWindow.EquipmentSpecificationsTextBox.Text = equipment.Specifications;
                equipmentSpecificationsWindow.Show();
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            EquipmentWindow equipmentWindow = new EquipmentWindow();
            equipmentWindow.Show();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentsDataGrid.SelectedItems.Count > 0)
            {
                Equipment equipment = (Equipment)EquipmentsDataGrid.SelectedItems[0];
                EquipmentWindow equipmentWindow = new EquipmentWindow(equipment);
                equipmentWindow.Show();
            }
        }
    }
}
