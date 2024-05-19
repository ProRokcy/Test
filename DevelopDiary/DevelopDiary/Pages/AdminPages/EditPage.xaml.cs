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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        int ID;
        public EditPage(Users users)
        {
            InitializeComponent();
            CmbRole.ItemsSource = OdbConnectHelper.entObj.Role.ToList();
            CmbRole.DisplayMemberPath = "Title";
            CmbRole.SelectedValuePath = "Id";
            ID = users.Id;
            TxbFIO.Text = users.FIO;
            TxbLogin.Text = users.Login;
            PsbPassword.Password = users.Password;
            CmbRole.SelectedValue = users.IdRole;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var editUser = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == ID);
            try
            {
                if (TxbFIO.Text != "" &&
                        TxbLogin.Text != "" &&
                        CmbRole.SelectedValue != null &&
                        PsbPassword.Password != null)
                {
                    editUser.FIO = TxbFIO.Text;
                    editUser.Login = TxbLogin.Text;
                    editUser.Password = PsbPassword.Password;
                    editUser.IdRole = Convert.ToInt32(CmbRole.SelectedValue);
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

        private void BtnBakc_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var deleteUser = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == ID);
            try
            {
                OdbConnectHelper.entObj.Users.Remove(deleteUser);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new MainAdminPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
