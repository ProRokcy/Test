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
using DevelopDiary.Classes;
using System.Windows.Shapes;
using DevelopDiary.Pages.MailPages;

namespace DevelopDiary.Pages.EmployePages
{
    /// <summary>
    /// Логика взаимодействия для AddNotePage.xaml
    /// </summary>
    public partial class AddNotePage : Page
    {
        public AddNotePage()
        {
            InitializeComponent();
            var users = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Id == UserControlClass.IdEmploye);
            TxbFio.Text = users.FIO;
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

        private void AddNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbContent.Text != "" &&
                    TxbTitle.Text != "")
                {

                    Notes note = new Notes()
                    {
                        ContentNote = TxbContent.Text,
                        Title = TxbTitle.Text,
                        IdWriter = Convert.ToInt32(UserControlClass.IdEmploye)
                    };

                    OdbConnectHelper.entObj.Notes.Add(note);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("успешно добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new NotePage());
                }
                else
                {
                    if (TxbContent.Text == "" && TxbTitle.Text == "")
                    {
                        if (TxbContent.Text == "")
                        {
                            TxbContent.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        else if (TxbTitle.Text == "")
                        {
                            TxbTitle.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            TxbTitle.BorderBrush = new SolidColorBrush(Colors.Red);
                            TxbContent.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        MessageBox.Show("Проверьте корректность введенных данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая работа приложения " + ex.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Error);
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
