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
    /// Логика взаимодействия для EditTaskPage.xaml
    /// </summary>
    public partial class EditTaskPage : Page
    {
        int ID;
        public EditTaskPage(Tasks tasks)
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            CmbEmploye.ItemsSource = OdbConnectHelper.entObj.Users.Where(x => x.IdRole == 1).ToList();
            CmbEmploye.DisplayMemberPath = "FIO";
            CmbEmploye.SelectedValuePath = "Id";
            ID = tasks.Id;
            CmbEmploye.SelectedValue = tasks.IdExecutor;
            TxbDescrip.Text = tasks.Descripshion;
            TxbTitle.Text = tasks.Title;
            DPDedLine.SelectedDate = tasks.Deadline;
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
            var editTask = OdbConnectHelper.entObj.Tasks.FirstOrDefault(x => x.Id == ID);
            try
            {
                if (TxbDescrip.Text != "" &&
                    TxbTitle.Text != "" &&
                    DPDedLine.SelectedDate != null)
                {

                    editTask.Descripshion = TxbDescrip.Text;
                    editTask.Title = TxbTitle.Text;
                    editTask.Deadline = DPDedLine.SelectedDate;
                    editTask.IdExecutor = Convert.ToInt32(CmbEmploye.SelectedValue);


                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);
                    FrameApp.frmObj.Navigate(new TaskPage());
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var deleteTask = OdbConnectHelper.entObj.Tasks.FirstOrDefault(x => x.Id == ID);
            try
            {
                OdbConnectHelper.entObj.Tasks.Remove(deleteTask);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new TaskPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
