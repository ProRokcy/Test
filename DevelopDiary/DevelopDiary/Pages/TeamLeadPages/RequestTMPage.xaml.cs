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
using DevelopDiary.Pages.MailPages;
using DevelopDiary.Classes;

namespace DevelopDiary.Pages.TeamLeadPages
{
    /// <summary>
    /// Логика взаимодействия для RequestTMPage.xaml
    /// </summary>
    public partial class RequestTMPage : Page
    {
        void Update()
        {
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Requests.ToList();

            var filtred = OdbConnectHelper.entObj.Requests.ToList();

            if (CmbStatus.SelectedIndex == 0)
            {
                filtred = OdbConnectHelper.entObj.Requests.ToList();
            }
            else if (CmbStatus.SelectedIndex == 1)
            {
                filtred = OdbConnectHelper.entObj.Requests.Where(x => x.IdStatus == 1).ToList();
            }
            else if (CmbStatus.SelectedIndex == 2)
            {
                filtred = OdbConnectHelper.entObj.Requests.Where(x => x.IdStatus == 2).ToList();
            }


            filtred = filtred.Where(x => x.Descrip.Contains(Tbx_serhc.Text) ||
             x.Id.ToString().Contains(Tbx_serhc.Text)).ToList();

            var sort = filtred.ToList();

            LViewTask.ItemsSource = sort.ToList();
        }
        public RequestTMPage()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Requests.ToList();
        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TaskPage());
        }


        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new NotePage());
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void DropBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic k = (sender as Button).DataContext;
            int idt = k.Id;
            var editRequest = OdbConnectHelper.entObj.Requests.FirstOrDefault(x => x.Id == idt);
            try
            {
                editRequest.IdStatus = 2;
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация Зарегистрирована", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new AddProject());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CmbDedline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainTeamLeadPage());
        }

        private void LoginPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LoginPage());
        }

        private void BtnMail_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainMailPage());
        }

        private void RequestBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new RequestTMPage());
        }
    }
}
