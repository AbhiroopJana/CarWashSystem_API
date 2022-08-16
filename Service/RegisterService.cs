using CarWashApi.DTOs;
using CarWashApi.Models;
using CarWashApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class RegisterService
    {
        IRegisterRepository<CreateUserDto, UserProfile> _repository;
        
        
        public RegisterService(IRegisterRepository<CreateUserDto, UserProfile> repository)
        {
            _repository = repository;
        }
        
        
        public async Task<ActionResult<UserProfile>> RegisterUser(CreateUserDto userprofiledto)
        {
            return await _repository.CreateAsync(userprofiledto);
        }
        public bool UserExisits(CreateUserDto email)
        {
            return _repository.UserExists(email);
        }
    }
}
