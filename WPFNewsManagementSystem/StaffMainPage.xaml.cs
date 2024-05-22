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
using System.Windows.Shapes;

namespace WPFNewsManagementSystem
{
    /// <summary>
    /// Interaction logic for StaffMainPage.xaml
    /// </summary>
    public partial class StaffMainPage : Window
    {
        public StaffMainPage()
        {
            InitializeComponent();
        }

        private void btnMNA_Click(object sender, RoutedEventArgs e)
        {
            StaffManageNewsArticle staffManageNewsArticle = new StaffManageNewsArticle();
            staffManageNewsArticle.Show();
            this.Close();
        }

        private void btnMCI_Click(object sender, RoutedEventArgs e)
        {
            StaffManageCategoryInfomation staffManageCategoryInfomation = new StaffManageCategoryInfomation();
            staffManageCategoryInfomation.Show();
            this.Close();
        }

        private void btnMTP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVNHC_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
