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
    /// Логика взаимодействия для AddProject.xaml
    /// </summary>
    public partial class AddProject : Page
    {
        public AddProject()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
        }

        private void BtnBakc_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainTeamLeadPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbDescrip.Text != "" &&
                    TxbTitle.Text != "" &&
                    DPDedLine.SelectedDate != null)
                {

                    Project project = new Project()
                    {
                        IdStastus = 2,
                        IdCreator = UserControlClass.IdEmploye,
                        Descripshion = TxbDescrip.Text,
                        Title = TxbTitle.Text,
                        Deadline = DPDedLine.SelectedDate,
                    };

                    OdbConnectHelper.entObj.Project.Add(project);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("успешно добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new MainTeamLeadPage());
                }
                else
                {
                    if (TxbTitle.Text == "")
                    {

                        TxbTitle.BorderBrush = new SolidColorBrush(Colors.Red);

                    }
                    MessageBox.Show("Проверьте корректность введенных данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая работа приложения " + ex.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
