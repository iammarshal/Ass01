using BusinessObject.Models;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFNewsManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminManageAccountInformation.xaml
    /// </summary>
    public partial class AdminManageAccountInformation : Window
    {
        private readonly ISystemAccountService _SystemAccountService;
        public AdminManageAccountInformation()
        {
            _SystemAccountService = new SystemAccountService();
            InitializeComponent();
        }
        public void LoadAccountList()
        {
            try
            {
                var AccountList = _SystemAccountService.GetSystemAccount();
                DgData.ItemsSource = AccountList;
                DgData.Items.Refresh();
                
            }
            catch 
            {
                resetInput();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemAccount systemAccount = new SystemAccount();
                systemAccount.AccountName = txtAccountName.Text;
                systemAccount.AccountEmail = txtAccountEmail.Text;
                systemAccount.AccountPassword = txtPassword.Text;
                systemAccount.AccountRole = int.Parse(txtAccountRole.Text);
                _SystemAccountService.AddSystemAccount(systemAccount);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadAccountList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var account = _SystemAccountService.GetSystemAccountById((short)int.Parse(txtAccountID.Text));
            try
            {
                if (txtAccountID.Text.Length > 0)
                {
                    SystemAccount systemAccount = new SystemAccount();
                    systemAccount.AccountId = (short)int.Parse(txtAccountID.Text);
                    systemAccount.AccountName = txtAccountName.Text;
                    systemAccount.AccountEmail = txtAccountEmail.Text;
                    systemAccount.AccountRole = int.Parse(txtAccountRole.Text);
                    systemAccount.AccountPassword = txtPassword.Text;
                    await _SystemAccountService.DeleteNewsArticleAndTags(account.NewsArticles.ToList());
                    _SystemAccountService.DeleteSystemAccount(systemAccount);
                }
                else
                {
                    System.Windows.MessageBox.Show("Can't Delete");
                }
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show(es.Message);
            }
            finally
            {
                LoadAccountList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAccountList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)RowColumn.Content).Text;
            if (DgData.SelectedItem == null) return;
            var systemAccount = (SystemAccount)DgData.SelectedItem;
            txtAccountID.Text = systemAccount.AccountId.ToString();
            txtAccountEmail.Text = systemAccount.AccountEmail;
            txtAccountName.Text = systemAccount.AccountName;
            txtAccountRole.Text = systemAccount.AccountRole.ToString();
            txtPassword.Text = systemAccount.AccountPassword;
        }
        private void resetInput()
        {
            txtAccountID.Text = "";
            txtAccountEmail.Text = "";
            txtAccountName.Text = "";
            txtAccountRole.Text = "";
            txtPassword.Text = "";
        }
    }
}
