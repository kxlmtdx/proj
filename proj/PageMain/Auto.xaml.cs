using proj.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private Random _random = new Random();

        public Auto()
        {
            InitializeComponent();
             // var marks = AppConnect.model0db.Mark.Select(m => m.Mark1).ToList();/

             /* var typePrivods = AppConnect.model0db.TypePrivod.Select(tp => tp.Type_Privod1).ToList();/
             / var types = AppConnect.model0db.Type1.Select(t => t.Типмашины).ToList();/
             / var Year = AppConnect.model0db.YearCar.Select(y => y.year).ToList();*/
            CmbGroup.SelectedValuePath = "Id";
            CmbGroup.DisplayMemberPath = "Mark1";
            CmbGroup.ItemsSource = AppConnect.model0db.Mark.ToList();

            CmbGroup1.SelectedValuePath = "Id";
            CmbGroup1.DisplayMemberPath = "Type_Privod1";
            CmbGroup1.ItemsSource = AppConnect.model0db.Type_Privod.ToList();

            CmbGroup2.SelectedValuePath = "Id";
            CmbGroup2.DisplayMemberPath = "Тип_машины";
            CmbGroup2.ItemsSource = AppConnect.model0db.Type1.ToList();

            CmbGroup3.SelectedValuePath = "Id";
            CmbGroup3.DisplayMemberPath = "year";
            CmbGroup3.ItemsSource = AppConnect.model0db.Year_Car.ToList();




            /* CmbGroup.ItemsSource = marks;/
            /CmbGroup1.ItemsSource = typePrivods;/
            / CmbGroup2.ItemsSource = types;/
            /CmbGroup3.ItemsSource = Year;*/

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
            int marksId = Convert.ToInt32(CmbGroup.SelectedValue);
            var output = AppConnect.model0db.Staff1.Where(x => x.ID_Mark == marksId).Select(x => new{CarBrand = x.Mark.Mark1}).ToList();

            int privodType = Convert.ToInt32(CmbGroup1.SelectedValue);
            var govno = AppConnect.model0db.Staff1.Where(x => x.ID_Type == privodType).Select(x => new { prType = x.Type_Privod.Type_Privod1 }).ToList();

            int cost = Convert.ToInt32(CmbGroup.SelectedValue);
            var outputcost = AppConnect.model0db.Staff1.Where(x => x.ID_Car_Price == cost).Select(x => new { CarCost = x.Car_Price.Price_Car }).ToList();

            int carType = Convert.ToInt32(CmbGroup2.SelectedValue);
            var carType1 = AppConnect.model0db.Staff1.Where(x => x.ID_Type == carType).Select(x => new { carType = x.Type1.Тип_машины }).ToList();

            int carYear = Convert.ToInt32(CmbGroup3.SelectedValue);
            var ZXC = AppConnect.model0db.Staff1.Where(x => x.ID_Year_Car == carYear).Select(x => new { carYear = x.Year_Car.year }).ToList();

            var carDetails = AppConnect.model0db.Staff1
                .Where(x => x.ID_Mark == marksId && x.ID_Type == privodType && x.ID_Type == carType && x.ID_Year_Car == carYear)
                .Select(x => new
                {
                    CarBrand = x.Mark.Mark1,
                    PrivodType = x.Type_Privod.Type_Privod1 + "привод, " + x.Type1.Тип_машины + ", " + x.Year_Car.year + "г.",
                    CarType = x.Car_Price.Price_Car,
                })
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Марка авто");
            dt.Columns.Add("Описание авто");
            dt.Columns.Add("Цена авто");
            dt.Columns.Add("ImagePath");

            foreach (var car in carDetails)
            {
                if (marksId == 1)
                {
                    int randomValue = _random.Next(1, 4);
                    string imagePath = $"temp/B{randomValue}.jpg";
                    dt.Rows.Add(car.CarBrand, car.PrivodType, car.CarType, imagePath);
                }
                else if (marksId == 2)
                {
                    int randomValue = _random.Next(1, 4);
                    string imagePath = $"temp/M{randomValue}.jpg";
                    dt.Rows.Add(car.CarBrand, car.PrivodType, car.CarType, imagePath);
                }
                else 
                {
                    int randomValue = _random.Next(1, 4);
                    string imagePath = $"temp/L{randomValue}.jpg";
                    dt.Rows.Add(car.CarBrand, car.PrivodType, car.CarType, imagePath);
                }
                
            }

            carGrid.ItemsSource = dt.DefaultView;
        }

    }
}
