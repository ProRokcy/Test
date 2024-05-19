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
using DevelopDiary.Classes;

namespace DevelopDiary.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            CmbRole.ItemsSource = OdbConnectHelper.entObj.Role.ToList();
            CmbRole.DisplayMemberPath = "Title";
            CmbRole.SelectedValuePath = "Id";
        }

        private void BtnBakc_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbFIO.Text != "" &&
                        TxbLogin.Text != "" &&
                        CmbRole.SelectedValue != null &&
                        PsbPassword.Password != null)
                {

                    Users user = new Users()
                    {
                        FIO = TxbFIO.Text,
                        Login = TxbLogin.Text,
                        IdRole = Convert.ToInt32(CmbRole.SelectedValue),
                        Password = PsbPassword.Password,
                    };

                    OdbConnectHelper.entObj.Users.Add(user);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("успешно добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new MainAdminPage());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая работа приложения " + ex.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
