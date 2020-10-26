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
    /// Логика взаимодействия для EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        Equipment _equipment = new Equipment();

        private static FornitureContext fornitureContext = new FornitureContext();

        List<string> types = fornitureContext.Equipment_types.Select(et => et.type_of_equipment).ToList();

        public EquipmentWindow()
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = types;
            TypeComboBox.SelectedIndex = 0;
            DatePurchDataPicker.SelectedDate = DateTime.Today;
        }

        public EquipmentWindow(Equipment equipment)
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = types;
            TypeComboBox.SelectedIndex = 0;

            NameTextBox.Text = equipment.Name;
            TypeComboBox.SelectedItem = equipment.Type;
            DatePurchDataPicker.SelectedDate = equipment.PurchaseDate;
            SpecTextBox.Text = equipment.Specifications;

            _equipment = equipment;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _equipment.Name = NameTextBox.Text;
                _equipment.Type = TypeComboBox.SelectedItem.ToString();
                _equipment.PurchaseDate = DatePurchDataPicker.SelectedDate.Value.Date;
                _equipment.Specifications = SpecTextBox.Text;

                try
                {
                    if (_equipment.Marking == null)
                    {
                        fornitureContext.Equipments.Add(_equipment);
                        fornitureContext.SaveChanges();
                    }
                    if (_equipment.Marking != null)
                    {
                        fornitureContext.Equipments.Update(_equipment);
                        fornitureContext.SaveChanges();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
                this.Close();
            }
        }

        private bool ModelCheck()
        {
            string error = "Неккоректные значения:";
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                error += " Название";
            }
            if (error != "Неккоректные значения:")
            {
                MessageBox.Show(error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
