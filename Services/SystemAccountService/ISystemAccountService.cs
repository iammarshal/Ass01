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
    }
}
