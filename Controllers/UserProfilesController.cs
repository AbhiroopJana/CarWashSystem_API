using AutoMapper;
using CarWashApi.DTOs;
using CarWashApi.DTOs.UserProfile;
using CarWashApi.Models;
using CarWashApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserProfilesController : ControllerBase

    {
        private readonly UserProfileService _Service;
        private readonly IMapper mapper;
        private readonly RegisterService _RegisterService;

        public UserProfilesController(IMapper mapper, UserProfileService service, RegisterService registerService)
        {
            _Service = service;
            _RegisterService = registerService;
            this.mapper = mapper;
        }


        #region GetUserProfile
        /// <summary>
        /// this action is used to get all the users
        /// </summary>
        /// <returns></returns>
        // GET: api/UserProfiles
        [HttpGet]
        public async Task<ActionResult<GetUserDto>> GetUserProfiles()
        {
            try
            {
                var users = await _Service.GetUser();
                var usersDto = mapper.Map<IEnumerable<GetUserDto>>(users);
                return Ok(usersDto);
            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {

            }
        }
        #endregion


        #region GetUserProfileById
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUserProfile(int id)
        {
            try
            {

                var userProfile = await _Service.GetUserById(id);

                if (userProfile == null)
                {
                    return NotFound();
                }
                var userDto = mapper.Map<GetUserDto>(userProfile);
                return userDto;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region UpdateUserProfile
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProfile(int id, UpdateUserDto userProfileDto)
        {
            try
            {

                var userProfile = await _Service.GetUserById(id);
                if (userProfile == null)
                {
                    return NotFound();
                }


                mapper.Map(userProfileDto, userProfile);


                if (_Service == null)
                {
                    return Problem("Entity set 'CarWashContext.UserProfile'  is null.");
                }

                var val = await _Service.UpdateUser(userProfile);

                if (val == null)
                {
                    return BadRequest();
                }
                return NoContent();


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region RegisterUserProfile
        /// <summary>
        /// this action is used to post the User
        /// </summary>
        /// <returns></returns>

        // POST: api/users/
        [HttpPost, Route("signup")]
        public async Task<ActionResult<UserProfile>> PostUserProfile(CreateUserDto profileDto)
        {
            try
            {
                if (UserProfileExists(profileDto))
                {
                    return BadRequest("User Already Exists");

                }

                if (_Service == null)
                {
                    return Problem("Entity set 'CarWashContext.UserProfiles'  is null.");
                }
                var res = await _RegisterService.RegisterUser(profileDto);
                if (res == null)
                {
                    return BadRequest();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { }
        }
        #endregion

        #region DeleteUser
        /// <summary>
        /// this action is used to deleta a user,
        /// </summary>
        /// <returns></returns>

        // DELETE: api/UserProfiles/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            try
            {
                if (_Service == null)
                {
                    return NotFound();
                }
                var userProfile = await _Service.GetUserById(id);
                if (userProfile == null)
                {
                    return NotFound();
                }

                var result = _Service.DeleteUser(userProfile);
                if (result == null)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region UserExists
        /// <summary>
        /// this action is used to check if the user exists
        /// </summary>
        /// <returns></returns>

        private bool UserProfileExists(CreateUserDto email)
        {
            try
            {
                return _RegisterService.UserExisits(email);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion
    }
}