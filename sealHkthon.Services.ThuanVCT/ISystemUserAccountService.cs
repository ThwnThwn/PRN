using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sealHkthon.Services.ThuanVCT
{
    public interface ISystemUserAccountService
    {
        Task<Entities.ThuanVCT.Models.SystemUserAccount> GetUserAccountAsync(string userName, string password);
    }
}
