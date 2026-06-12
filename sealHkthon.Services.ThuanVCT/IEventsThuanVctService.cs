using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sealHkthon.Entities.ThuanVCT.Models;

namespace sealHkthon.Services.ThuanVCT
{
    public interface IEventsThuanVctService
    {
        Task<List<Entities.ThuanVCT.Models.EventsThuanVct>> GetAllAsync();
        Task<Entities.ThuanVCT.Models.EventsThuanVct> GetByIdAsync(int id);
        Task<List<Entities.ThuanVCT.Models.EventsThuanVct>> SearchAsync(string eventName, string description);
        Task<List<Entities.ThuanVCT.Models.EventsThuanVct>> SearchAsync(string name, string round, int status);

        ///Mutation Methods
        Task<int> CreateAsync(Entities.ThuanVCT.Models.EventsThuanVct events);
        Task<int> UpdateAsync(EventsThuanVct events);
        Task<bool> DeleteAsync(int id);


    }
}
