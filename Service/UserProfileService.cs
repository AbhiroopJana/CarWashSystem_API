using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class UserProfileService
    {
        IRepository<UserProfile, int> _repository;


        public UserProfileService(IRepository<UserProfile, int> repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<UserProfile>> GetUser()
        {
            return await _repository.GetAsync();
        }

        public async Task<UserProfile> GetUserById(int id)
        {
            return await _repository.GetIdAsync(id);
        }
        public Task<int> CreateUser(UserProfile userProfile)
        {
            return _repository.CreateAsync(userProfile);
        }
        public Task<int> UpdateUser(UserProfile userProfile)
        {
            return _repository.UpdateAsync(userProfile);
        }
        public bool UserExists(int id)
        {
            return _repository.Exists(id);
        }
        public Task<int> DeleteUser(UserProfile userProfile)
        {
            return _repository.DeleteAsync(userProfile);
        }
    }
    


}
