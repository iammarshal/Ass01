using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.SystemAccountRepo
{
    public class SystemAccountRepo : ISystemAccountRepo
    {
        private readonly SystemAccountDAO _systemAccountDAO;


        public SystemAccountRepo()
        {
            if(_systemAccountDAO == null)
            {
                _systemAccountDAO = new SystemAccountDAO(); 
            }
        }
        public async Task<SystemAccount> CheckLogin(string Accountemail, string password)
        {
            return await _systemAccountDAO.getUserByEmail(Accountemail, password);
        }
        
        public void AddSystemAccount(SystemAccount systemAccount) => _systemAccountDAO.AddSystemAccount(systemAccount);
        
        public void DeleteSystemAccount(SystemAccount systemAccount) => _systemAccountDAO.DeleteSystemAccount(systemAccount);
        
        public void UpdateSystemAccount(SystemAccount systemAccount) => _systemAccountDAO.UpdateSystemAccount(systemAccount);
        
        public List<SystemAccount> GetSystemAccount() => _systemAccountDAO.GetSystemAccount();
        
        public SystemAccount GetSystemAccountById(short id) => _systemAccountDAO.GetSystemAccountById(id);
        
        public async Task DeleteNewsArticleAndTags(List<NewsArticle> newsArticles) => await _systemAccountDAO.DeleteNewsArticleAndTags(newsArticles);
        
        public void UpdateUserProfile(string loggedInUsername, SystemAccount updatedProfile) => _systemAccountDAO.UpdateUserProfile(loggedInUsername, updatedProfile);

        public SystemAccount GetLoggedInUser(string email)
        {
            return _systemAccountDAO.GetLoggedInUser(email);
        }
    }
}
