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
    /// Логика взаимодействия для MyTaskPage.xaml
    /// </summary>
    public partial class MyTaskPage : Page
    {
        void Update()
        {
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.ToList();

            var filtred = OdbConnectHelper.entObj.Tasks.ToList();

            if (CmbStatus.SelectedIndex == 0)
            {
                filtred = OdbConnectHelper.entObj.Tasks.ToList();
            }
            else if (CmbStatus.SelectedIndex == 1)
            {
                filtred = OdbConnectHelper.entObj.Tasks.Where(x => x.IdStatus == 1 && x.IdExecutor == UserControlClass.IdEmploye).ToList();
            }
            else if (CmbStatus.SelectedIndex == 2)
            {
                filtred = OdbConnectHelper.entObj.Tasks.Where(x => x.IdStatus == 2 && x.IdExecutor == UserControlClass.IdEmploye).ToList();
            }


            filtred = filtred.Where(x => x.Title.Contains(Tbx_serhc.Text) ||
                 x.Descripshion.Contains(Tbx_serhc.Text) && x.IdExecutor == UserControlClass.IdEmploye).ToList();
           
            var sort = filtred.ToList();


            switch (CmbDedline.SelectedIndex)
            {
                case 0: { sort = filtred.OrderByDescending(x => x.Deadline).Where(x => x.IdExecutor == UserControlClass.IdEmploye).ToList(); break; }
                case 1: { sort = filtred.OrderBy(x => x.Deadline).Where(x=> x.IdExecutor == UserControlClass.IdEmploye).ToList(); break; }
            }
            LViewTask.ItemsSource = sort.ToList();
        }
        void SelectedTask(Tasks task)
        {
            try
            {
                task.IdStatus = 1;
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Задача выполнена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new MyTaskPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public MyTaskPage()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.Where(x => x.IdExecutor == UserControlClass.IdEmploye).ToList();
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

        private void CmbDedline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
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
