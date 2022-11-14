namespace App.ClassLib;
public class Driver
{
    public Driver( string name, string password)
    {
        Name = name;
        Password = BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Password { get; set; }
}