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

    }
}
