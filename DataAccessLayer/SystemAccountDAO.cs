using BusinessObject.Models;
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
        public async Task<SystemAccount> getUserByEmail(string Accountemail, string password)
        {
            var _context = new FunewsManagementDbContext();
            return await _context.SystemAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccountEmail.Equals(Accountemail) && a.AccountPassword.Equals(password));
        }
    }
}
