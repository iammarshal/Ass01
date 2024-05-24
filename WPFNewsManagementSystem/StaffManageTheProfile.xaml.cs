using BusinessObject.Models;
using DataAccessLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WPFNewsManagementSystem
{
    /// <summary>
    /// Interaction logic for StaffManageTheProfile.xaml
    /// </summary>
    public partial class StaffManageTheProfile : Window
    {
        private readonly ISystemAccountService _SystemAccountService;
        private readonly string _email;
        public StaffManageTheProfile()
        {
            InitializeComponent();
            _SystemAccountService = new SystemAccountService();
            txtAccountName.Text = SystemAccountDAO.currentuser.AccountName;
            txtAccountEmail.Text = SystemAccountDAO.currentuser.AccountEmail;
            txtPassword.Text = SystemAccountDAO.currentuser.AccountPassword;
        }
        
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemAccountDAO.currentuser.AccountName = txtAccountName.Text;
                SystemAccountDAO.currentuser.AccountEmail = txtAccountEmail.Text;
                SystemAccountDAO.currentuser.AccountPassword = txtPassword.Text;
                SystemAccountDAO.currentuser.AccountRole = SystemAccountDAO.currentuser.AccountRole;
                _SystemAccountService.UpdateSystemAccount(SystemAccountDAO.currentuser);
                System.Windows.MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        
    }
}
