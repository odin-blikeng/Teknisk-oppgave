
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


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
            Claims = new List<Claim>(){
                new Claim(ClaimTypes.Name, Name),
                new Claim("DriverId", driverId.ToString())
            };
        }

        [Key]
        public string Username { get; }
        public string Name { get; set; }
        public Guid? DriverId { get; private set; }
        public string Password { get; set; }
        public List<Claim> Claims { get; set; } = null!;
    }
}