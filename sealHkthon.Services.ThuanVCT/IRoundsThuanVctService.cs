using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sealHkthon.Services.ThuanVCT
{
    public interface IRoundsThuanVctService
    {
        Task<List<Entities.ThuanVCT.Models.RoundsThuanVct>> GetAllAsync();
        //Task<Entities.ThuanVCT.Models.RoundsThuanVct> GetByIdAsync(int id);
    }
}
