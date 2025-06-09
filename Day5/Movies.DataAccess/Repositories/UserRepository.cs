using Movies.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Movies.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly MovieDbContext _context;
        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public int UpdateUser(User u)
        {
            User existingUser = GetUserById(u.Id);
            if (existingUser == null)
            {
                return -1;
            }
            existingUser.Name = u.Name;
            existingUser.Email = u.Email;
            existingUser.Password = u.Password;
            existingUser.Role = u.Role;
            _context.SaveChanges();
            return 1;
        }
        public int DeleteUser(int id)
        {
            User userToDelete = GetUserById(id);
            if (userToDelete == null)
            {
                return -1;
            }
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return 1;
        }

        public User LoginUser(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}