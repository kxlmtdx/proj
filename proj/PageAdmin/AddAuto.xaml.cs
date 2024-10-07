using proj.DB;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proj.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для AddAuto.xaml
    /// </summary>
    public partial class AddAuto : Page
    {
        public AddAuto()
        {
            InitializeComponent();

            CmbGroup.SelectedValuePath = "Id";
            CmbGroup.DisplayMemberPath = "Mark1";
            CmbGroup.ItemsSource = AppConnect.model0db.Mark.ToList();


            CmbGroup1.SelectedValuePath = "Id";
            CmbGroup1.DisplayMemberPath = "Price_Car";
            CmbGroup1.ItemsSource = AppConnect.model0db.Car_Price.ToList();

            CmbGroup2.SelectedValuePath = "Id";
            CmbGroup2.DisplayMemberPath = "Тип_машины";
            CmbGroup2.ItemsSource = AppConnect.model0db.Type1.ToList();

            CmbGroup3.SelectedValuePath = "Id";
            CmbGroup3.DisplayMemberPath = "Type_KPP1";
            CmbGroup3.ItemsSource = AppConnect.model0db.Type_KPP.ToList();

            CmbGroup4.SelectedValuePath = "Id";
            CmbGroup4.DisplayMemberPath = "Type_Privod1";
            CmbGroup4.ItemsSource = AppConnect.model0db.Type_Privod.ToList();

            CmbGroup5.SelectedValuePath = "Id";
            CmbGroup5.DisplayMemberPath = "year";
            CmbGroup5.ItemsSource = AppConnect.model0db.Year_Car.ToList();

            CmbGroup6.SelectedValuePath = "Id";
            CmbGroup6.DisplayMemberPath = "Name";
            CmbGroup6.ItemsSource = AppConnect.model0db.Person.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Staff1 studObj = new Staff1()
                {
                    Mark = CmbGroup.SelectedItem as Mark,
                    Car_Price = CmbGroup1.SelectedItem as Car_Price,
                    Type1 = CmbGroup2.SelectedItem as Type1,
                    Type_KPP = CmbGroup3.SelectedItem as Type_KPP,
                    Type_Privod = CmbGroup4.SelectedItem as Type_Privod,
                    Year_Car = CmbGroup5.SelectedItem as Year_Car,
                    Person = CmbGroup6.SelectedItem as Person

                };

                AppConnect.model0db.Staff1.Add(studObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Машина!", "Уведолмение", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
