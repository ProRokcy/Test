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
using DevelopDiary.Pages.MailPages;

namespace DevelopDiary.Pages.EmployePages
{
    /// <summary>
    /// Логика взаимодействия для MainEmployePage.xaml
    /// </summary>
    public partial class MainEmployePage : Page
    {
     
        void Update()
        {
             LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.ToList();

            var filtred = OdbConnectHelper.entObj.Tasks.Where(x => x.IdExecutor == null && x.IdStatus == 3).ToList();


            filtred = filtred.Where(x => x.Title.Contains(Tbx_serhc.Text) ||
                 x.Descripshion.Contains(Tbx_serhc.Text) && x.IdExecutor == null).ToList();

            LViewTask.ItemsSource = filtred.ToList();

        }
        void SelectedTask(Tasks task)
        {
            try
            {
                task.IdStatus = 2;
            task.IdExecutor = UserControlClass.IdEmploye;
            OdbConnectHelper.entObj.SaveChanges();
            MessageBox.Show("Вы успешно забрали задачу", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new MainEmployePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public MainEmployePage()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.Where(x => x.IdExecutor == null && x.IdStatus == 3).ToList();
        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainEmployePage());
        }

        private void MyTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MyTaskPage());
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
            SelectedTask(k);
        }

        private void LoginPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LoginPage());
        }

        private void BtnMail_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainMailPage());
        }
    }
}
