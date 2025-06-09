using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Models;
using Movies.DataAccess.Repositories;

namespace Movies.Services.Services
{
    public class UserServices
    {
        private readonly UserRepository _userRepository;
        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }
        public int UpdateUser(User u)
        {
            return _userRepository.UpdateUser(u);
        }
        public int DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public User LoginUser(string email, string password)
        {
            return _userRepository.LoginUser(email, password);
        }
    }
}