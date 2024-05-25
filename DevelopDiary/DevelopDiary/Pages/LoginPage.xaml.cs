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
using DevelopDiary.Pages.AdminPages;
using DevelopDiary.Pages.EmployePages;
using DevelopDiary.Pages.TeamLeadPages;

namespace DevelopDiary.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbLogin.Text == "" && PsbPassword.Password == "")
                {
                    if (TxbLogin.Text == "")
                    {
                        TxbLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    else if (PsbPassword.Password == "")
                    {
                        PsbPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        PsbPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                        TxbLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    MessageBox.Show("Не все поля заполнены!", "Уведомление",
                     MessageBoxButton.OK,
                     MessageBoxImage.Warning);
                }
                else
                {
                    var userObj = OdbConnectHelper.entObj.Users.FirstOrDefault(
                        x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
                    if (userObj == null)
                    {
                        var loginUser = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Login == TxbLogin.Text);
                        if (loginUser == null)
                        {
                            MessageBox.Show("Такого пользователя нету!", "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                             PsbPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                        TxbLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            loginUser.IdTypeLogin = 1;
                            loginUser.DateLastLogin = DateTime.Now;
                            OdbConnectHelper.entObj.SaveChanges();
                            MessageBox.Show("Неверный пароль", "Уведомление",
                           MessageBoxButton.OK,
                           MessageBoxImage.Warning);
                            PsbPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                        }

                    }
                    else
                    {
                        UserControlClass.IdEmploye = userObj.Id;
                        userObj.IdTypeLogin = 2;
                        userObj.DateLastLogin = DateTime.Now;
                        OdbConnectHelper.entObj.SaveChanges();

                        switch (userObj.IdRole)
                        {
                            case 1:
                                FrameApp.frmObj.Navigate(new MainEmployePage());
                                break;
                            case 2:
                                FrameApp.frmObj.Navigate(new MainTeamLeadPage());
                                break;
                            case 3:
                                FrameApp.frmObj.Navigate(new MainAdminPage());
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Уведомление" + ex.Message.ToString(),
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void TxbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxbLogin.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void PsbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PsbPassword.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddRequestPage());
        }
    }
}
