namespace App.ClassLib;
public class Driver
{
    public Driver( string name )
    {
        Name = name;
    }

    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Name { get; set; }
}