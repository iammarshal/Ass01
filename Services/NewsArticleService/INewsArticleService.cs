using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.NewsArticleService
{
    public interface INewsArticleService
    {
        List<NewsArticle> GetNewsArticle();
        void AddNewsArticle(NewsArticle newsArticle);
        void UpdateNewsArticle(NewsArticle newsArticle);
        void DeleteNewsArticle(NewsArticle newsArticle);
        NewsArticle GetNewsArticleById(string id);
    }
}
