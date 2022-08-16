using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class LoginService
    {
        ILoginRepository<Login, int> _repository;
        public LoginService(ILoginRepository<Login, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Login(Login login)
        {
            return await _repository.Login(login);
        }

        public async Task<int> GetUserId(string userid)
        {
            return await _repository.GetUserId(userid);
        }

        public async Task<string> GetUserName(string email)
        {
            return await _repository.GetUserName(email);
        }
    }
}
