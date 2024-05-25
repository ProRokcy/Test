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
using DevelopDiary.Pages.TeamLeadPages;
using DevelopDiary.Pages.EmployePages;
using DevelopDiary.Pages.AdminPages;

namespace DevelopDiary.Pages.MailPages
{
    /// <summary>
    /// Логика взаимодействия для MainMailPage.xaml
    /// </summary>
    public partial class MainMailPage : Page
    {
        void Update()
        {
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.ToList();

            var filtred = OdbConnectHelper.entObj.Mails.Where(x => x.IdRecipient == UserControlClass.IdEmploye).ToList();


            filtred = filtred.Where(x => x.mail.Contains(Tbx_serhc.Text)
                 && x.IdRecipient == UserControlClass.IdEmploye).ToList();

            LViewTask.ItemsSource = filtred.ToList();

        }
        public MainMailPage()
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
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Mails.Where(x => x.IdRecipient == UserControlClass.IdEmploye).ToList();
        }
        private void IncomingBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainMailPage());
        }

        void SelectedTask(Mails mail)
        {
            try
            {

                mail.IdMailStatus = 1;
                OdbConnectHelper.entObj.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic k = (sender as Button).DataContext;
            SelectedTask(k);
            FrameApp.frmObj.Navigate(new ReadMailPage(k)); 
        }
        private void WriteBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new WriteMailPage());
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

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
