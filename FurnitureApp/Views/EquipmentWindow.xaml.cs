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

        FornitureContext fornitureContext = new FornitureContext();

        public EquipmentWindow()
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = fornitureContext.Equipment_types.Select(et => et.type_of_equipment).ToList();
            TypeComboBox.SelectedIndex = 0;
        }

        public EquipmentWindow(Equipment equipment)
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = fornitureContext.Equipment_types.Select(et => et.type_of_equipment).ToList();
            TypeComboBox.SelectedIndex = 0;

            NameTextBox.Text = equipment.Name;
            TypeComboBox.SelectedItem = equipment.Type;
            DatePurchDataPicker.SelectedDate = equipment.PurchaseDate;
            SpecificationsDataGrid.ItemsSource = getSpecList(equipment);

            _equipment = equipment;
        }

        private List<Specification> getSpecList(Equipment equipment)
        {
            List<Specification> specifications = new List<Specification>();
            string[] parts = equipment.Specifications.Split('\n');
            string[] parts2;
            for (int i = 0; i < parts.Length; i++)
            {
                parts2 = parts[i].Split(':');
                if (parts2.Length > 1)
                {
                    specifications.Add(new Specification { Name = parts2[0], value = parts2[1] });
                }
            }
            return specifications;
        }

        private string getSpecString()
        {
            string res = "";
            foreach (Specification specification in SpecificationsDataGrid.Items)
            {
                res += $"{specification.Name}:{specification.value}\n";
            }
            return res;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _equipment.Name = NameTextBox.Text;
                _equipment.Type = TypeComboBox.SelectedItem.ToString();
                _equipment.PurchaseDate = DatePurchDataPicker.DisplayDate;
                _equipment.Specifications = getSpecString();

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
