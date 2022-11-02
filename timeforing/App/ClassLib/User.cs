
using System.ComponentModel.DataAnnotations;

namespace App.ClassLib
{
    public class User
    {

        public User( string username, string name, Guid driverId, string password )
        {
            Username = username;
            Name = name;
            DriverId = driverId;
            Password = password;
        }

        [Key]
        public string Username { get; }
        public string Name { get; set; }
        public Guid? DriverId { get; private set; }
        public string Password { get; set; }
    }
}