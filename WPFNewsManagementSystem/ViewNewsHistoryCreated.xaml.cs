using BusinessObject.Models;
using DataAccessLayer;
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
    /// Interaction logic for ViewNewsHistoryCreated.xaml
    /// </summary>
    public partial class ViewNewsHistoryCreated : Window
    {
        private readonly INewsArticleService _newsArticleService;
        private List<NewsArticle> _newsArticles;
        private int currentPage = 1;
        private int numberOfPages;
        public ViewNewsHistoryCreated()
        {
            InitializeComponent();
            _newsArticleService = new NewsArticleService();
        }
        public void LoadNewsArticleList()
        {
            try
            {
                _newsArticles = _newsArticleService.GetNewsArticlesByCreatedId(SystemAccountDAO.currentuser.AccountId);
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

    }
}
