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
    /// Логика взаимодействия для EditProjectPage.xaml
    /// </summary>
    public partial class EditProjectPage : Page
    {
        int ID;
        public EditProjectPage(Project project)
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            ID = project.Id;
           UserControlClass.IdProject = ID;
           TxbTitle.Text = project.Title;
            TxbDescrip.Text = project.Descripshion;
            DPDedLine.SelectedDate = project.Deadline;
            CmbStatus.ItemsSource = OdbConnectHelper.entObj.Status.ToList();
            CmbStatus.DisplayMemberPath = "Title";
            CmbStatus.SelectedValuePath = "Id";
            CmbStatus.SelectedValue = project.IdStastus;
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Tasks.Where(x => x.IdProject == ID).ToList();

        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TaskPage());
        }

        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainTeamLeadPage());
        }

        private void NotesBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new NotePage());
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var editProject = OdbConnectHelper.entObj.Project.FirstOrDefault(x => x.Id == ID);
            try
            {
                if (
                    TxbTitle.Text != "" &&
                    CmbStatus.SelectedValue != null &&
                    DPDedLine.SelectedDate != null)
                {

                    editProject.Deadline = DPDedLine.SelectedDate;
                    editProject.Title = TxbTitle.Text;
                    editProject.IdStastus = Convert.ToInt32(CmbStatus.SelectedValue);
                    editProject.Descripshion = TxbDescrip.Text;


                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);
                    FrameApp.frmObj.Navigate(new MainTeamLeadPage());
                }
                else
                {
                    MessageBox.Show("Пустые поля", "Уведомление", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var DeleteProject = OdbConnectHelper.entObj.Project.FirstOrDefault(x => x.Id == ID);
            try
            {
                OdbConnectHelper.entObj.Project.Remove(DeleteProject);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new MainTeamLeadPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AddTaskProject_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTaskProjectPage());
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
