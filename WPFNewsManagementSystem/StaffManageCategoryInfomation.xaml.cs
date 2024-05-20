using Services.CategoryService;
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
    /// Interaction logic for StaffManageCategoryInfomation.xaml
    /// </summary>
    public partial class StaffManageCategoryInfomation : Window
    {
        private readonly ICategoryService _categoryService;
        public StaffManageCategoryInfomation()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }
        
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
