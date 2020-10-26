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

        private static FornitureContext fornitureContext = new FornitureContext();

        List<string> qualities = new List<string> {"Качественный", "С незначительными дефектами", "Бракованный"};
        List<string> types = new List<string> {"Металлы", "Керамика", "Композиты", "Биоматериаллы"};
        List<string> suppliers = fornitureContext.Suppliers.Select(s => s.Name).ToList();

        public MaterialWindow()
        {
            InitializeComponent();
            QualityComboBox.ItemsSource = qualities;
            QualityComboBox.SelectedIndex = 0;
            SuppComboBox.ItemsSource = suppliers;
            SuppComboBox.SelectedIndex = 0;
            TypeComboBox.ItemsSource = types;
            TypeComboBox.SelectedIndex = 0;
        }

        public MaterialWindow(Material material)
        {
            InitializeComponent();
            QualityComboBox.ItemsSource = qualities;
            QualityComboBox.SelectedIndex = 0;
            SuppComboBox.ItemsSource = suppliers;
            SuppComboBox.SelectedIndex = 0;
            TypeComboBox.ItemsSource = types;
            TypeComboBox.SelectedIndex = 0;

            QualityComboBox.SelectedItem = material.Quality;
            ArticleTextBox.Text = material.Article;
            ArticleTextBox.IsEnabled = false;
            NameTextBox.Text = material.Name;
            UnitTextBox.Text = material.Unit;
            LengthTextBox.Text = material.Length;
            CountTextBox.Text = material.Count;
            TypeComboBox.SelectedItem = material.Type_of_material;
            PurchPriceTextBox.Text = material.Purchase_price;
            GOSTTextBox.Text = material.GOST;
            SuppComboBox.SelectedItem = material.Main_supplier;

            _material = material;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _material.Quality = QualityComboBox.SelectedItem.ToString();
                _material.Article = ArticleTextBox.Text;
                _material.Name = NameTextBox.Text;
                _material.Unit = UnitTextBox.Text;
                _material.Length = LengthTextBox.Text;
                _material.Count = CountTextBox.Text;
                _material.Type_of_material = TypeComboBox.SelectedItem.ToString();
                _material.Purchase_price = PurchPriceTextBox.Text;
                _material.GOST = GOSTTextBox.Text;
                _material.Main_supplier = SuppComboBox.SelectedItem.ToString();

                try
                {
                    if (ArticleTextBox.IsEnabled == false)
                    {
                        fornitureContext.Materials.Update(_material);
                        fornitureContext.SaveChanges();
                    }
                    else
                    {
                        fornitureContext.Materials.Add(_material);
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
            string error = "Ошибки:\n";
            if (string.IsNullOrEmpty(CountTextBox.Text))
            {
                error += "Введите Кол-во\n";
            }
            if ((string)SuppComboBox.SelectedItem != "Albert")
            {
                error += "Выберите Альберта (таков капитализм)\n";
            }
            if (string.IsNullOrEmpty(ArticleTextBox.Text))
            {
                error += "Введите артикул";
            }
            if (error != "Ошибки:\n")
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
