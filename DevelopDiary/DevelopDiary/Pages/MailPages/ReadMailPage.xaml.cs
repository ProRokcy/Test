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
    /// Логика взаимодействия для ReadMailPage.xaml
    /// </summary>
    public partial class ReadMailPage : Page
    {
        public ReadMailPage(Mails mails)
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
            UserControlClass.IdMail = mails.Id;
            TxbContent.Text = mails.mail;
            TxbEmploye.Text = mails.Users.FIO;
        }
        private void AnswerMailBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AnswerMailPage());
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
    }
}
