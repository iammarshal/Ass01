using Microsoft.Extensions.Configuration;
using Services.SystemAccountService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
            SystemAccountService systemAccountService = new SystemAccountService();
            try
        {
                systemAccountService.Login(txtUsername.Text, txtPassword.Password);
                string email = txtUsername.Text;
                string password = txtPassword.Password;
                // get the admin account from appsettings.json
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
                var directory = Directory.GetCurrentDirectory();
                var adEmail = config["AccountEmail:Email"];
                var adPassword = config["AccountPassword:Password"];
                var adRole = config["AccountRole:Role"];
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    System.Windows.Forms.MessageBox.Show("Field required!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (adEmail.Equals(email) && adPassword.Equals(password))
                {
                    AdminMainPage adminMainPage = new AdminMainPage();
                    adminMainPage.Show();
                    this.Close();
                }
                var tmp = systemAccountService.Login(email, password);

                if (tmp != null)
                {
                    StaffMainPage staffMainPage = new StaffMainPage();
                    staffMainPage.Show();
                    this.Close();

                }
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
    }
    }