using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etstur.API.Model;
using Etstur.Business.Abstract;
using Etstur.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Etstur.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("api/[controller]/GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers().Select(x => new UserModel
                {
                    Id=x.Id,
                    Address = x.Address,
                    BloodType = x.BloodType,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber
                }).ToList();



                return Ok(new ResponseListModel<UserModel>
                {
                    Success = false,
                    Message = "Başarılı",
                    Response = users
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseListModel<UserModel>
                {
                    Success = false,
                    Message = ex.ToString(),
                    Response = null
                });
            }
        }

        [HttpPost]
        [Route("api/[controller]/CreateUser")]
        public IActionResult CreateUser(UserModel userModel)
        {

            try
            {
                var user = new User
                {
                    Address = userModel.Address,
                    BloodType = userModel.BloodType,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    PhoneNumber = userModel.PhoneNumber
                };

                _userService.CreateUser(user);

                return Ok(new ResponseObjectModel<UserModel>
                {
                    Success = true,
                    Message = "Başarılı",
                    Response = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObjectModel<UserModel>
                {
                    Success = false,
                    Message = ex.ToString(),
                    Response = null
                });
            }
          

            
        }
    }
}