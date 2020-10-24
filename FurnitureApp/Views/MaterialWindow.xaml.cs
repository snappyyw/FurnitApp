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
    /// Логика взаимодействия для MaterialWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window
    {
        Material _material = new Material();

        FornitureContext fornitureContext = new FornitureContext();

        List<string> qualities = new List<string> { "Качественный", "С незначительными дефектами", "Бракованный" };

        public MaterialWindow()
        {
            InitializeComponent();
            QualityComboBox.ItemsSource = qualities;
            QualityComboBox.SelectedIndex = 0;
        }

        public MaterialWindow(Material material)
        {
            InitializeComponent();
            QualityComboBox.ItemsSource = qualities;
            QualityComboBox.SelectedIndex = 0;

            QualityComboBox.SelectedItem = material.Quality;
            ArticulTextBox.Text = material.Article;
            NameTextBox.Text = material.Name;
            UnitTextBox.Text = material.Unit;
            LengthTextBox.Text = material.Length;
            CountTextBox.Text = material.Count;
            TypeTextBox.Text = material.Type_of_material;
            PurchPriceTextBox.Text = material.Purchase_price;
            GOSTTextBox.Text = material.GOST;
            SupplierTextBox.Text = material.Main_supplier;

            _material = material;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _material.Quality = QualityComboBox.SelectedItem.ToString();
                _material.Article = ArticulTextBox.Text;
                _material.Name = NameTextBox.Text;
                _material.Unit = UnitTextBox.Text;
                _material.Length = LengthTextBox.Text;
                _material.Count = CountTextBox.Text;
                _material.Type_of_material = TypeTextBox.Text;
                _material.Purchase_price = PurchPriceTextBox.Text;
                _material.GOST = GOSTTextBox.Text;
                _material.Main_supplier = SupplierTextBox.Text;

                try
                {
                    fornitureContext.Materials.Update(_material);
                    fornitureContext.SaveChanges();
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
            if (string.IsNullOrEmpty(CountTextBox.Text))
            {
                error += " Кол-во";
            }
            if (string.IsNullOrEmpty(TypeTextBox.Text))
            {
                error += " Тип";
            }
            if (string.IsNullOrEmpty(ArticulTextBox.Text))
            {
                error += " Артикул";
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
