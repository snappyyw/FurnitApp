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
    /// Логика взаимодействия для FurnitureWindow.xaml
    /// </summary>
    public partial class FurnitureWindow : Window
    {
        Furniture _furniture = new Furniture();

        private static FornitureContext fornitureContext = new FornitureContext();

        List<string> suppliers = fornitureContext.Suppliers.Select(s => s.Name).ToList();

        public FurnitureWindow()
        {
            InitializeComponent();

            SuppComboBox.ItemsSource = suppliers;
            SuppComboBox.SelectedIndex = 0;
        }

        public FurnitureWindow(Furniture furniture)
        {
            InitializeComponent();

            SuppComboBox.ItemsSource = suppliers;
            SuppComboBox.SelectedIndex = 0;

            ArticleTextBox.Text = furniture.Article;
            ArticleTextBox.IsEnabled = false;
            NameTextBox.Text = furniture.Name;
            CountTextBox.Text = furniture.Count.ToString();
            UnitTextBox.Text = furniture.Unit;
            TypeTextBox.Text = furniture.type_of_accessories;
            PriceTextBox.Text = furniture.Purchase_price;
            SuppComboBox.SelectedItem = furniture.Main_supplier;

            _furniture = furniture;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _furniture.Article = ArticleTextBox.Text;
                _furniture.Name = NameTextBox.Text;
                _furniture.Count = int.Parse(CountTextBox.Text);
                _furniture.Unit = UnitTextBox.Text;
                _furniture.type_of_accessories = TypeTextBox.Text;
                _furniture.Purchase_price = PriceTextBox.Text;
                _furniture.Main_supplier = SuppComboBox.SelectedItem.ToString();

                try
                {
                    if(ArticleTextBox.IsEnabled == false)
                    {
                        fornitureContext.Furniture.Update(_furniture);
                        fornitureContext.SaveChanges();
                    }
                    else
                    {
                        fornitureContext.Furniture.Add(_furniture);
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
            try
            {
                int.Parse(CountTextBox.Text);
            }
            catch
            {
                error += "Кол-во хуйня\n";
            }
            if (string.IsNullOrEmpty(ArticleTextBox.Text))
            {
                error += "Введите артикул\n";
            }
            if ((string)SuppComboBox.SelectedItem != "Albert")
            {
                error += "Выберите Альберта (таков капитализм)";
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