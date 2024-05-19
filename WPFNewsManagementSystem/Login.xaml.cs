using Services.SystemAccountService;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly ISystemAccountService _systemAccountService;

        public Login(ISystemAccountService systemAccountService)
        {
            _systemAccountService = systemAccountService;

        }

        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SystemAccountService _systemAccountService = new SystemAccountService();

            var loginSuccess = await _systemAccountService.Login(txtUsername.Text, txtPassword.Password);

            if (loginSuccess != null)
            {
                if (loginSuccess.AccountRole == 1)
                {
                    AdminMainPage adminMainPage = new AdminMainPage();
                    adminMainPage.Show();
                }
                else if (loginSuccess.AccountRole == 2)
                {
                    StaffMainPage staffMainPage = new StaffMainPage();
                    staffMainPage.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Login Again");
            }
        }
    }
}

