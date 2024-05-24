using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SystemAccountService
{
    public interface ISystemAccountService
    {
        public Task<SystemAccount> Login(string Accountemail, string password);
        List<SystemAccount> GetSystemAccount();
        void AddSystemAccount(SystemAccount systemAccount);
        void UpdateSystemAccount(SystemAccount systemAccount);
        void DeleteSystemAccount(SystemAccount systemAccount);
        SystemAccount GetSystemAccountById(short id);
        Task DeleteNewsArticleAndTags(List<NewsArticle> newsArticles);
        void UpdateUserProfile(string loggedInUsername, SystemAccount updatedProfile);
        SystemAccount GetLoggedInUser(string email);       
    }
}
