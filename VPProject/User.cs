using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProject
{
    public class User
    {
        public string Username { get; set; }
        public int Id { get; set; } 
        public DateTime LastTimeLogged { get; set; }
        public User(string username, int id, DateTime dt)
        {
            Username = username;
            Id = id;
            LastTimeLogged = dt;
        }
    }
}
