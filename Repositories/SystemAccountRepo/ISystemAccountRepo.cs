using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.SystemAccountRepo
{
    public interface ISystemAccountRepo
    {
        public Task<SystemAccount> CheckLogin(string Accountemail, string password);
    }
}
