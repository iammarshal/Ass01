using BusinessObject.Models;
using Services.NewsArticleService;
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
    /// Interaction logic for StaffManageNewsArticle.xaml
    /// </summary>
    public partial class StaffManageNewsArticle : Window
    {
        private readonly INewsArticleService _newsArticleService;
        public StaffManageNewsArticle()
        {
            InitializeComponent();
            _newsArticleService = new NewsArticleService();
        }
        public void LoadNewsArticleList()
        {
            try
            {
                var NewsArticleList = _newsArticleService.GetNewsArticle();
                DgData.ItemsSource = NewsArticleList;
            }
            catch (Exception e)
            {
                resetInput();
            }
        }
        private void resetInput()
        {
            txtNewsArticleID.Text = "";
            txtNewsArticleTitle.Text = "";
            txtCreatedDate.Text = "";
            txtNewsContent.Text = "";
            txtCateoryID.Text = "";
            txtNewsStatus.Text = "";
            txtCreatedByID.Text = "";
            txtModifiedDate.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadNewsArticleList();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewsArticle newsArticle = new NewsArticle();
                newsArticle.NewsArticleId = txtNewsArticleID.Text;
                newsArticle.NewsTitle = txtNewsArticleTitle.Text;
                newsArticle.CreatedDate = DateTime.Parse(txtCreatedDate.Text);
                newsArticle.NewsContent = txtNewsContent.Text;
                newsArticle.CategoryId = short.Parse(txtCateoryID.Text);
                newsArticle.NewsStatus = bool.Parse(txtNewsStatus.Text);
                newsArticle.CreatedById = short.Parse(txtCreatedByID.Text);
                newsArticle.ModifiedDate = DateTime.Parse(txtModifiedDate.Text);
                _newsArticleService.AddNewsArticle(newsArticle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadNewsArticleList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNewsArticleID.Text.Length > 0)
                {
                    NewsArticle newsArticle = new NewsArticle();
                    newsArticle.NewsArticleId = txtNewsArticleID.Text;
                    newsArticle.NewsTitle = txtNewsArticleTitle.Text;
                    newsArticle.CreatedDate = DateTime.Parse(txtCreatedDate.Text);
                    newsArticle.NewsContent = txtNewsContent.Text;
                    newsArticle.CategoryId = short.Parse(txtCateoryID.Text);
                    newsArticle.NewsStatus = bool.Parse(txtNewsStatus.Text);
                    newsArticle.CreatedById = short.Parse(txtCreatedByID.Text);
                    newsArticle.ModifiedDate = DateTime.Parse(txtModifiedDate.Text);
                    _newsArticleService.UpdateNewsArticle(newsArticle);
                }
                else
                {
                    MessageBox.Show("You are wrong");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                LoadNewsArticleList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNewsArticleID.Text.Length > 0)
                {
                    NewsArticle newsArticle = new NewsArticle();
                    newsArticle.NewsArticleId = txtNewsArticleID.Text;
                    _newsArticleService.DeleteNewsArticle(newsArticle);
                }
                else
                {
                    MessageBox.Show("You are wrong");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                LoadNewsArticleList();
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
            if (DgData.SelectedItem == null) return;
            var newsArticle = (NewsArticle)DgData.SelectedItem;
            txtNewsArticleID.Text = newsArticle.NewsArticleId;
            txtNewsArticleTitle.Text = newsArticle.NewsTitle;
            txtCreatedDate.Text = newsArticle.CreatedDate.ToString();
            txtNewsContent.Text = newsArticle.NewsContent;
            txtCateoryID.Text = newsArticle.CategoryId.ToString();
            txtNewsStatus.Text = newsArticle.NewsStatus.ToString();
            txtCreatedByID.Text = newsArticle.CreatedById.ToString();
            txtModifiedDate.Text = newsArticle.ModifiedDate.ToString();
        }
    }
}
