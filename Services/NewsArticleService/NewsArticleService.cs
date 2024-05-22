using BusinessObject.Models;
using Repositories.CategoryRepo;
using Repositories.NewsArticleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.NewsArticleService
{
    public class NewsArticleService: INewsArticleService
    {
        private readonly INewsArticleRepo _newsArticleRepo;
        public NewsArticleService()
        {
            
                _newsArticleRepo = new NewsArticleRepo();
            
        }
        public void AddNewsArticle(NewsArticle newsArticle)
        {
            _newsArticleRepo.AddNewsArticle(newsArticle);
        }
        public void DeleteNewsArticle(NewsArticle newsArticle)
        {
            _newsArticleRepo.DeleteNewsArticle(newsArticle);
        }
        public List<NewsArticle> GetNewsArticle()
        {
            return _newsArticleRepo.GetNewsArticle();
        }
        public NewsArticle GetNewsArticleById(string id)
        {
            return _newsArticleRepo.GetNewsArticleById(id);
        }
        public void UpdateNewsArticle(NewsArticle newsArticle)
        {
            _newsArticleRepo.UpdateNewsArticle(newsArticle);
        }

    }
}
