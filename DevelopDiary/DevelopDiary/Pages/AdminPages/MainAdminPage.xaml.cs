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

namespace DevelopDiary.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
            LViewTask.ItemsSource = OdbConnectHelper.entObj.Users.ToList();
        }

        private void DropBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic k = (sender as Button).DataContext;
            FrameApp.frmObj.Navigate(new EditPage(k));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddPage());
        }
    }
}
