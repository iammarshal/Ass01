using BusinessObject.Models;
using Repositories.SystemAccountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SystemAccountService
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepo _systemAccountRepo;
        public SystemAccountService()
        {
            if (_systemAccountRepo == null)
            {
                _systemAccountRepo = new SystemAccountRepo();
            }
        }
        public async Task<SystemAccount> Login(string Accountemail, string password)
        {
            var getUser = await _systemAccountRepo.CheckLogin(Accountemail, password);
            return getUser;
        }
    }
}
