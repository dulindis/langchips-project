﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langchips_project.Models
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }   
        public string Password { get; set; }    
        public string Username { get; set; }

        public User( string name, string surname, string email, string password, string username)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Username = username;
        }
    }
}