using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proj.Main
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
            var marks = AppConnect.model0db.Mark.Select(m => m.Mark1).ToList();
            var typePrivods = AppConnect.model0db.Type_Privod.Select(tp => tp.Type_Privod1).ToList();
            var types = AppConnect.model0db.Type1.Select(t => t.Тип_машины).ToList();
            var Year = AppConnect.model0db.Year_Car.Select(y => y.year).ToList();

            CmbGroup.ItemsSource = marks;
            CmbGroup1.ItemsSource = typePrivods;
            CmbGroup2.ItemsSource = types;
            CmbGroup3.ItemsSource = Year;

            FillDataGrid();
        }
        private void FillDataGrid()
        {
            var marks = AppConnect.model0db.Mark.Select(m => m.Mark1).ToList();
            var prices = AppConnect.model0db.Car_Price.Select(p => p.Price_Car).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Марка авто");
            dt.Columns.Add("Цена авто");

            var cars = marks.Zip(prices, (mark, price) => new { Mark = mark, Price = price });

            foreach (var car in cars)
            {
                dt.Rows.Add(car.Mark, car.Price);
            }

            carGrid.ItemsSource = dt.DefaultView;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int marks = Convert.ToInt32(CmbGroup.SelectedValue);
            carGrid.ItemsSource = AppConnect.model0db.Staff1.Where(x => x.ID_Mark == marks).ToList();
            var output = carGrid.ItemsSource = AppConnect.model0db.Staff1.Where(x => x.ID_Mark == marks).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Марка авто");

            foreach (var item in )
            {
                dt.Rows.Add(item);
            }

            carGrid.ItemsSource = dt.DefaultView;
        }
    }
}
