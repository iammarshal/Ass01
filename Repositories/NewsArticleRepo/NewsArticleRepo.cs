using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.NewsArticleRepo
{
    public class NewsArticleRepo : INewsArticleRepo
    {
        public void AddNewsArticle(NewsArticle newsArticle) => NewsArticleDAO.AddNewsArticle(newsArticle);
        public void DeleteNewsArticle(NewsArticle newsArticle) => NewsArticleDAO.DeleteNewsArticle(newsArticle);
        public void UpdateNewsArticle(NewsArticle newsArticle) => NewsArticleDAO.UpdateNewsArticle(newsArticle);
        public List<NewsArticle> GetNewsArticle() => NewsArticleDAO.GetNewsArticles();
        public NewsArticle GetNewsArticleById(string id) => NewsArticleDAO.GetNewsArticleById(id);
        public List<NewsArticle> GetNewsArticlesByCreatedId(short Id) => NewsArticleDAO.GetNewsArticlesByCreatedId(Id);
    }
}
