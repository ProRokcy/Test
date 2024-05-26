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

namespace DevelopDiary.Pages.MailPages
{
    /// <summary>
    /// Логика взаимодействия для AnswerMailPage.xaml
    /// </summary>
    public partial class AnswerMailPage : Page
    {
        public AnswerMailPage()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            switch (users.IdRole)
            {
                case 1:
                    RoleTxt.Text = "Сотрудник";
                    break;
                case 2:
                    RoleTxt.Text = "ТимЛид"; ;
                    break;
                case 3:
                    RoleTxt.Text = "Админ";
                    break;
            }
            TxbFio.Text = users.FIO;
            CmbEmploye.ItemsSource = OdbConnectHelper.entObj.Users.ToList();
            CmbEmploye.DisplayMemberPath = "FIO";
            CmbEmploye.SelectedValuePath = "Id";
            var mails = OdbConnectHelper.entObj.Mails.FirstOrDefault(x => x.Id == UserControlClass.IdMail);
            CmbEmploye.SelectedValue = mails.IdSender;
        }
        private void WriteBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new WriteMailPage());
        }

        private void IncomingBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainMailPage());
        }

        private void ExistBtn_Click(object sender, RoutedEventArgs e)
        {
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            switch (users.IdRole)
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

        private void AddMailBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbContent.Text != "" &&
                    CmbEmploye.SelectedValue != null)
                {

                    Mails mail = new Mails()
                    {
                        mail = TxbContent.Text,
                        IdSender = UserControlClass.IdEmploye,
                        IdRecipient = Convert.ToInt32(CmbEmploye.SelectedValue),
                        IdMailStatus = 2
                    };

                    OdbConnectHelper.entObj.Mails.Add(mail);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("успешно добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new MainMailPage());
                }
                else
                {
                    if (TxbContent.Text == "" || CmbEmploye.SelectedValue == null)
                    {
                        if (TxbContent.Text == "")
                        {
                            TxbContent.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        else if (CmbEmploye.SelectedValue == null)
                        {
                            CmbEmploye.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            CmbEmploye.BorderBrush = new SolidColorBrush(Colors.Red);
                            TxbContent.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        MessageBox.Show("Проверьте корректность введенных данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая работа приложения " + ex.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnComboboxTextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)e.OriginalSource;
            if (tb.SelectionStart != 0)
            {
                CmbEmploye.SelectedItem = null; // Если набирается текст сбросить выбраный элемент
            }
            if (tb.SelectionStart == 0 && CmbEmploye.SelectedItem == null)
            {
                CmbEmploye.IsDropDownOpen = false; // Если сбросили текст и элемент не выбран, сбросить фокус выпадающего списка
            }

            CmbEmploye.IsDropDownOpen = true;
            if (CmbEmploye.SelectedItem == null)
            {

                    CmbEmploye.ItemsSource = OdbConnectHelper.entObj.Users.Where(x => x.FIO.Contains(CmbEmploye.Text)).ToList();

            }
        }
    }
}