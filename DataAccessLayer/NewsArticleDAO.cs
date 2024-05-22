using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NewsArticleDAO
    {
        public static List<NewsArticle> GetNewsArticles()
        {
            var listNewsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    listNewsArticles = _context.NewsArticles
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listNewsArticles;
        }
        public static void AddNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.NewsArticles.Add(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.NewsArticles.Update(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.NewsArticles.Remove(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static NewsArticle GetNewsArticleById(string newsArticleId)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                return _context.NewsArticles
                    .SingleOrDefault(c => c.NewsArticleId == newsArticleId);
            }
        }
    }
}
