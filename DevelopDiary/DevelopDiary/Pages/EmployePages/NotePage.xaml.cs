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
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        void Update()
        {
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.ToList();

            var filtred = OdbConnectHelper.entObj.Notes.Where(x => x.IdWriter == UserControlClass.IdEmploye).ToList();


            filtred = filtred.Where(x => x.Title.Contains(Tbx_serhc.Text)
                 && x.IdWriter == UserControlClass.IdEmploye).ToList();

            LViewTask.ItemsSource = filtred.ToList();

        }
        public NotePage()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Notes.Where(x => x.IdWriter == UserControlClass.IdEmploye).ToList();
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic k = (sender as Button).DataContext;
            FrameApp.frmObj.Navigate(new EditNotePage(k));
        }

        private void AddNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddNotePage());
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
