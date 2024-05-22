using BusinessObject.Models;
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
        
        public void LoadCategoryList()
        {
            try
            {

                var CategoryList = _categoryService.GetCategories();
                DgData.ItemsSource = CategoryList;
                
            }
            catch(Exception e) 
            {
                resetInput();
            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category category = new Category();
                category.CategoryName = txtCaterogyName.Text;
                category.CategoryDesciption = txtCaterogyDesciption.Text;
                _categoryService.AddCategory(category);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadCategoryList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCaterogyID.Text.Length > 0)
                {
                    Category category = new Category();
                    category.CategoryName = txtCaterogyName.Text;
                    category.CategoryDesciption = txtCaterogyDesciption.Text;
                    category.CategoryId = Int16.Parse(txtCaterogyID.Text);
                    _categoryService.UpdateCategory(category);
                }
                else
                {
                    MessageBox.Show("You are wrong");
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                LoadCategoryList() ;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCaterogyID.Text.Length > 0)
                {
                    Category category = new Category();
                    category.CategoryId = Int16.Parse(txtCaterogyID.Text);
                    category.CategoryName = txtCaterogyName.Text;
                    category.CategoryDesciption = txtCaterogyDesciption.Text;
                    _categoryService.DeleteCategory(category);
                }
                else
                {
                    MessageBox.Show("Can't Delete");
                }
            }
            catch (Exception es) 
            {
                MessageBox.Show(es.Message);
            }
            finally
            { 
                LoadCategoryList() ; 
            }
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
            Category category = _categoryService.GetCategoryById(Int16.Parse(id));
            txtCaterogyID.Text = category.CategoryId.ToString();
            txtCaterogyName.Text = category.CategoryName;
            txtCaterogyDesciption.Text = category.CategoryDesciption;

        }
        private void resetInput()
        {
            txtCaterogyID.Text = "";
            txtCaterogyName.Text = "";
            txtCaterogyDesciption.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
        }
    }
}
