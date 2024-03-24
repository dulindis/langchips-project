using langchips_project.Data;
using langchips_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langchips_project.Controllers
{
    internal class UserController
    {
        private readonly UserContext _userContext;


        public UserController()
        {
            _userContext = new UserContext();
        }

        public User FindUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                var user = _userContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding user in database: {ex.Message}");
                return null;
            }
        }
        public void AddUserToDb(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }
        public void RemoveUserFromDb(User user)
        {
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();

        }

        public void UpdateUserInDb(User updatedUser)
        {
            var userToUpdate = _userContext.Users.Find(updatedUser.Id);
            if (userToUpdate != null)
            {
                // Update user properties
                userToUpdate.Name = updatedUser.Name;
                userToUpdate.Surname = updatedUser.Surname;
                userToUpdate.Email = updatedUser.Email;
                userToUpdate.Password = updatedUser.Password;
                userToUpdate.Username = updatedUser.Username;

                _userContext.SaveChanges();
            }
        }
    }
}
