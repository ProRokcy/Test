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

namespace DevelopDiary.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRequestPage.xaml
    /// </summary>
    public partial class AddRequestPage : Page
    {
        public AddRequestPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbFIO.Text != "" &&
                        TxbDescrip.Text != "" &&
                        TxbPhone.Text != null)
                {

                    Requests requests = new Requests()
                    {
                        FIO = TxbFIO.Text,
                        IdStatus = 1,
                        Phone = TxbPhone.Text,
                        Descrip = TxbDescrip.Text,
                    };

                    OdbConnectHelper.entObj.Requests.Add(requests);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("успешно подано", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new LoginPage());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая работа приложения " + ex.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBakc_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LoginPage());
        }
    }
}
