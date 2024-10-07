using proj;
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

namespace WpfApp2.ApplicationDate.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void psbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != txbPass.Text)
            {
                btnCreate.IsEnabled = false;
                psbPass.Background = Brushes.Coral;
                psbPass.Background = new SolidColorBrush(Color.FromArgb(255, 245, 71, 66));
                btnCreate.Foreground = Brushes.Black;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.BorderBrush = Brushes.Green;
                btnCreate.Foreground = Brushes.White;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model0db.Person.Count(x => x.Name==txbName.Text)>0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!", "Уведомление",MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Person userObj = new Person()
                {
                    Name = txbName.Text,
                    Number = int.Parse(txbLogin.Text),
                    Password = int.Parse(txbPass.Text),
                    ID_Role = 2
                };
                AppConnect.model0db.Person.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
