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
    /// Логика взаимодействия для EditNotePage.xaml
    /// </summary>
    public partial class EditNotePage : Page
    {
        int ID;
        public EditNotePage(Notes note)
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
            TxbTitle.Text = note.Title;
            TxbContent.Text = note.ContentNote;
            ID = note.Id;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var EditNote = OdbConnectHelper.entObj.Notes.FirstOrDefault(x => x.Id == ID);
            try
            {
                if (TxbContent.Text != "" &&
                    TxbTitle.Text != "")
                {

                    EditNote.ContentNote = TxbContent.Text;
                    EditNote.Title = TxbTitle.Text;


                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);
                    FrameApp.frmObj.Navigate(new NotePage());
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
            var DeleteNote = OdbConnectHelper.entObj.Notes.FirstOrDefault(x => x.Id == ID);
            try
            {
                OdbConnectHelper.entObj.Notes.Remove(DeleteNote);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frmObj.Navigate(new NotePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TaskPage());
        }

        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new NotePage());
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
    }
}
