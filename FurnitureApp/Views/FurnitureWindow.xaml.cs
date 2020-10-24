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

        FornitureContext fornitureContext = new FornitureContext();

        public FurnitureWindow()
        {
            InitializeComponent();
        }

        public FurnitureWindow(Furniture furniture)
        {
            InitializeComponent();

            ArticleTextBox.Text = furniture.Article;
            NameTextBox.Text = furniture.Name;
            CountTextBox.Text = furniture.Count.ToString();
            UnitTextBox.Text = furniture.Unit;
            TypeTextBox.Text = furniture.type_of_accessories;
            PriceTextBox.Text = furniture.Purchase_price;
            SupplierTextBox.Text = furniture.Main_supplier;

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
                _furniture.Main_supplier = SupplierTextBox.Text;

                try
                {
                    fornitureContext.Furniture.Update(_furniture);
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
            if (string.IsNullOrEmpty(ArticleTextBox.Text))
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