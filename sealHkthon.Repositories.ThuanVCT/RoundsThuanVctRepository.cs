using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sealHkthon.Repositories.ThuanVCT
{
    public class RoundsThuanVctRepository : Base.GenericRepository<Entities.ThuanVCT.Models.RoundsThuanVct>
    {
        public RoundsThuanVctRepository()
        {
        }
        public RoundsThuanVctRepository(DBContext.PRN222_HACKATHONContext context) => _context = context;

        //public async Task<List<Entities.ThuanVCT.Models.RoundsThuanVct>> GetAllAsync(int eventId)
        //{
        //    return await _context.RoundsThuanVcts.ToListAsync();
        //}
        public async Task<List<Entities.ThuanVCT.Models.RoundsThuanVct>> GetAllAsync()
        {
            return await _context.RoundsThuanVcts.ToListAsync();
        }
    }
}
