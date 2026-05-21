using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sealHkthon.Repositories.ThuanVCT;

namespace sealHkthon.Services.ThuanVCT
{
    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;

        public SystemUserAccountService() => _repository = new SystemUserAccountRepository();

        public async Task<Entities.ThuanVCT.Models.SystemUserAccount> GetUserAccountAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    throw new ArgumentException("Username and password must not be empty.");

                return await _repository.GetUserAccountAsync(username, password);

            }
            catch (ArgumentException ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }
    }
}
