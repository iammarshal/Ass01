﻿using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SystemAccountDAO
    {
        public static SystemAccount currentuser = new SystemAccount();
        public async Task<SystemAccount> getUserByEmail(string Accountemail, string password)
        {
            var _context = new FunewsManagementDbContext();
            return await _context.SystemAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccountEmail.Equals(Accountemail) && a.AccountPassword.Equals(password));
        }
        public void AddSystemAccount(SystemAccount systemAccount)
        {
            var _context = new FunewsManagementDbContext();
            _context.SystemAccounts.Add(systemAccount);
            _context.SaveChanges();
        }
        public void DeleteSystemAccount(SystemAccount systemAccount)
        {
            var _context = new FunewsManagementDbContext();
            _context.SystemAccounts.Remove(systemAccount);
            _context.SaveChanges();
        }
        public void UpdateSystemAccount(SystemAccount systemAccount)
        {
            var _context = new FunewsManagementDbContext();
            _context.SystemAccounts.Update(systemAccount);
            _context.SaveChanges();
        }
        public List<SystemAccount> GetSystemAccount()
        {
            var listSystemAccount = new List<SystemAccount>();
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    listSystemAccount = _context.SystemAccounts   
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listSystemAccount;
        }
        public SystemAccount GetSystemAccountById(short id)
        {
            var _context = new FunewsManagementDbContext();
            return _context.SystemAccounts.Include(a => a.NewsArticles)
                .AsNoTracking()
                .FirstOrDefault(a => a.AccountId.Equals(id));
        }
        
        public async Task DeleteNewsArticleAndTags(List<NewsArticle> newsArticles)
        {
            try
            {
                using var _context = new FunewsManagementDbContext();
                foreach (var newsArticle in newsArticles)
                {
                    var article = _context.NewsArticles.Include(a => a.Tags).First(a => a.NewsArticleId.Equals(newsArticle.NewsArticleId));
                    foreach (var tag in article.Tags)
                    {
                        var tagArticle = _context.Tags.Include(t => t.NewsArticles).First(t => t.TagId.Equals(tag.TagId));
                        tagArticle.NewsArticles.Remove(article);
                    }
                }
                var RemoveNewsArticle = await _context.NewsArticles
                    .Where(a => newsArticles.Select(a => a.NewsArticleId).Contains(a.NewsArticleId)).ToListAsync();
                _context.NewsArticles.RemoveRange(RemoveNewsArticle);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateUserProfile(string loggedInUsername, SystemAccount updatedProfile)
        {
            using var _context = new FunewsManagementDbContext();
            var user = _context.SystemAccounts.FirstOrDefault(u => u.AccountEmail == loggedInUsername);

            if (user != null)
            {
                _context.SystemAccounts.Update(updatedProfile);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Can't Update");
            }
        }
        public SystemAccount GetLoggedInUser(string email)
        {
            using var _context = new FunewsManagementDbContext();
            SystemAccount user = _context.SystemAccounts.FirstOrDefault(u => u.AccountEmail.Equals(email));
            return user;
        }

    }
}
