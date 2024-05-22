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
    /// Interaction logic for ViewNewsArticle.xaml
    /// </summary>
    public partial class ViewNewsArticle : Window
    {
        private readonly INewsArticleService _newsArticleService;
        private List<NewsArticle> _newsArticles;
        private int currentPage = 1;
        private int numberOfPages;
        
        public ViewNewsArticle()
        {
            InitializeComponent();
            _newsArticleService = new NewsArticleService();
        }
        public void LoadNewsArticleList()
        {
            try
            {
                _newsArticles = _newsArticleService.GetNewsArticle();
                numberOfPages = _newsArticles.Count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadNewsArticleList();
            PageLoaded();

        }
        private void PageLoaded()
        {
            var currentNewsArticle = _newsArticles[currentPage - 1];
            lbTitle.Content = currentNewsArticle.NewsTitle;
            lbCategory.Content += currentNewsArticle.Category.CategoryName;
            lbTag.Content += String.Join(", ", currentNewsArticle.Tags.Select(x => x.TagName)); 
            lbAuthor.Content += currentNewsArticle.CreatedBy.AccountName;
            lbCreatedTime.Content += currentNewsArticle.CreatedDate.ToString();
            tblContent.Text = currentNewsArticle.NewsContent;
            lbPageCount.Content = $"{currentPage}/{numberOfPages}";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            lbCategory.Content = "Category: ";
            lbTag.Content = "Tag: ";
            lbAuthor.Content = "Author: ";
            lbCreatedTime.Content = "Created Time: ";
            btnNext.IsEnabled = true;
            --currentPage;     
            if (currentPage == 1)
            {
                btnBack.IsEnabled = false;
            }
            PageLoaded();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            lbCategory.Content = "Category: ";
            lbTag.Content = "Tag: ";
            lbAuthor.Content = "Author: ";
            lbCreatedTime.Content = "Created Time: ";
            btnBack.IsEnabled = true;
            ++currentPage;
            if (currentPage == numberOfPages)
            {
                btnNext.IsEnabled = false;
            }
            PageLoaded();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
