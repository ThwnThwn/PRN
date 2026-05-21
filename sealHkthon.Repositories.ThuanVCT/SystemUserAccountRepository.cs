using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.Base;
using sealHkthon.Repositories.ThuanVCT.DBContext;

namespace sealHkthon.Repositories.ThuanVCT
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository()
        {
        }

        public SystemUserAccountRepository(PRN222_HACKATHONContext context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccountAsync(string userName, string password)
        {
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(
                                                            x => x.Email == userName
                                                            && x.Password == password
                                                            && x.IsActive);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(
            //                                                x => x.UserName == userName
            //                                                && x.Password == password
            //                                                && x.IsActive);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(
            //                                                x => x.Phone == userName
            //                                                && x.Password == password
            //                                                && x.IsActive);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(
            //                                                x => (x.Email == userName || x.UserName == userName)
            //                                                && x.Password == password
            //                                                && x.IsActive);
        }
    }
}
