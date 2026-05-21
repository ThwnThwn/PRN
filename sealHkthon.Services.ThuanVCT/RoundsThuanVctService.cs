using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sealHkthon.Repositories.ThuanVCT;

namespace sealHkthon.Services.ThuanVCT
{
    public class RoundsThuanVctService : IRoundsThuanVctService
    {
        private readonly RoundsThuanVctRepository _repository;
        public RoundsThuanVctService() => _repository = new RoundsThuanVctRepository();

        public async Task<List<Entities.ThuanVCT.Models.RoundsThuanVct>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error retrieving rounds: {ex.Message}");
                throw new ApplicationException("An error occurred while retrieving rounds: " + ex.Message);
            }
        }

        //GetByIdAsync

        //public async Task<Entities.ThuanVCT.Models.RoundsThuanVct> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        var round = await _repository.GetByIdAsync(id);
        //        if (round == null)
        //            throw new KeyNotFoundException($"Round with ID {id} not found.");
        //        return round;
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        // Log the exception or handle it as needed
        //        Console.WriteLine($"Not found error: {ex.Message}");
        //        throw new ApplicationException("Round not found: " + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        Console.WriteLine($"Error retrieving round: {ex.Message}");
        //        throw new ApplicationException("An error occurred while retrieving the round: " + ex.Message);
        //    }
        //}

    }
}
