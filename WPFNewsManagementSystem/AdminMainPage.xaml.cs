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
    /// Interaction logic for AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Window
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void btnMAI_Click(object sender, RoutedEventArgs e)
        {
            AdminManageAccountInformation adminManageAccountInformation = new AdminManageAccountInformation();
            adminManageAccountInformation.Show();
            this.Close();
        }

        private void btnCRS_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
