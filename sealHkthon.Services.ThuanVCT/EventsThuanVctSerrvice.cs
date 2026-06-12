using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sealHkthon.Services.ThuanVCT
{
    public class EventsThuanVctSerrvice : IEventsThuanVctService
    {
        private readonly Repositories.ThuanVCT.EventsThuanVctRepository _repository;

        public EventsThuanVctSerrvice() => _repository = new Repositories.ThuanVCT.EventsThuanVctRepository();

        //implement all 

        public async Task<List<Entities.ThuanVCT.Models.EventsThuanVct>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error retrieving events: {ex.Message}");
                throw new ApplicationException("An error occurred while retrieving events: " + ex.Message);
            }
        }

        public async Task<Entities.ThuanVCT.Models.EventsThuanVct> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error retrieving event with ID {id}: {ex.Message}");
                throw new ApplicationException($"An error occurred while retrieving event with ID {id}: " + ex.Message);
            }
        }

        public async Task<List<Entities.ThuanVCT.Models.EventsThuanVct>> SearchAsync(string eventName, string description)
        {
            try
            {
                return await _repository.SearchAsync(eventName, description);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error searching events with name '{eventName}' and description '{description}': {ex.Message}");
                throw new ApplicationException($"An error occurred while searching events with name '{eventName}' and description '{description}': " + ex.Message);
            }
        }

        public async Task<List<Entities.ThuanVCT.Models.EventsThuanVct>> SearchAsync(string name, string round, int status)
        {
            try
            {
                return await _repository.SearchAsync(name, round, status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching events: {ex.Message}");
                throw new ApplicationException("An error occurred while searching events: " + ex.Message);
            }
        }

        public async Task<int> CreateAsync(Entities.ThuanVCT.Models.EventsThuanVct events)
        {
            try
            {
                return await _repository.CreateAsync(events);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error creating event: {ex.Message}");
                throw new ApplicationException("An error occurred while creating the event: " + ex.Message);
            }
        }

        public async Task<int> UpdateAsync(Entities.ThuanVCT.Models.EventsThuanVct events)
        {
            try
            {
                return await _repository.UpdateAsync(events);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error updating event with ID {events.EventThuanVctid}: {ex.Message}");
                throw new ApplicationException($"An error occurred while updating event with ID {events.EventThuanVctid}: " + ex.Message);
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var searchItem = await _repository.GetByIdAsync(id);

                if (searchItem == null)
                {
                    Console.WriteLine($"Event with ID {id} not found for deletion.");
                    throw new KeyNotFoundException($"Event with ID {id} not found.");
                }

                return await _repository.RemoveAsync(searchItem);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed  
                Console.WriteLine($"Error deleting event with ID {id}: {ex.Message}");
                throw new ApplicationException($"An error occurred while deleting event with ID {id}: " + ex.Message);
            }
        }
    }
}
