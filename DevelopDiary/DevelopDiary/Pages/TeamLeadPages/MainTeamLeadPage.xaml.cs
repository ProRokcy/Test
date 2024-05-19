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

namespace DevelopDiary.Pages.TeamLeadPages
{
    /// <summary>
    /// Логика взаимодействия для MainTeamLeadPage.xaml
    /// </summary>
    public partial class MainTeamLeadPage : Page
    {
        void Update()
        {
            LViewProject.ItemsSource = OdbConnectHelper.entObj.Project.ToList();

            var filtred = OdbConnectHelper.entObj.Project.ToList();

            if (CmbStatus.SelectedIndex == 0)
            {
                filtred = OdbConnectHelper.entObj.Project.ToList();
            }
            else if (CmbStatus.SelectedIndex == 1)
            {
                filtred = OdbConnectHelper.entObj.Project.Where(x => x.IdStastus == 1).ToList();
            }
            else if (CmbStatus.SelectedIndex == 2)
            {
                filtred = OdbConnectHelper.entObj.Project.Where(x => x.IdStastus == 2).ToList();
            }
            else if (CmbStatus.SelectedIndex == 3)
            {
                filtred = OdbConnectHelper.entObj.Project.Where(x => x.IdStastus == 3).ToList();
            }


            filtred = filtred.Where(x => x.Title.Contains(Tbx_serhc.Text)).ToList();

            var sort = filtred.ToList();


            switch (CmbDedline.SelectedIndex)
            {
                case 0: { sort = filtred.OrderByDescending(x => x.Deadline).ToList(); break; }
                case 1: { sort = filtred.OrderBy(x => x.Deadline).ToList(); break; }
            }
            LViewProject.ItemsSource = sort.ToList();
        }
        public MainTeamLeadPage()
        {
            InitializeComponent();
            LViewProject.ItemsSource = OdbConnectHelper.entObj.Project.ToList();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic k =(sender as Button).DataContext;
            FrameApp.frmObj.Navigate(new EditProjectPage(k));
        }

        private void NotesBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new NotePage());
        }

        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainTeamLeadPage());
        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TaskPage());
        }

        private void CmbDedline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddProject());
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
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
