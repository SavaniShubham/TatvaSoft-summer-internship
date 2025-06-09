using Microsoft.AspNetCore.Mvc;
using Movies.Services.Services;
using System.Collections.Generic;
using Movies.DataAccess.Models;
using Movie_mgt.dto;
using Movie_mgt.Helper;


namespace Movie_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserServices _userServices;
        public readonly JwtHelper jwtHelper;
        public UserController(UserServices userServices , JwtHelper jwtHelper)
        {
            this._userServices = userServices;
            this.jwtHelper = jwtHelper ;
        }
        [HttpGet("GetAllUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            List<User> users = _userServices.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }
        [HttpPost("Login")]
        public ActionResult<User> login([FromBody] LoginReqdto dto )
        {
            User user = _userServices.LoginUser(dto.Email ,dto.Password);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var token = jwtHelper.GetToken(user);
            return Ok(new LoginResdto() {Email = user.Email  , Name = user.Name , Role = user.Role , Token = token });
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            _userServices.AddUser(user);
            return Ok("User added successfully.");
        }
    }
}
