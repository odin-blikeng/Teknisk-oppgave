namespace App.ClassLib;
public class Project
{
    public Project(string title)
    {
        Title = title;
    }

    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Title { get; set; }

    public List<TimeCard> Hours { get; set; } = new List<TimeCard>();
    public void AddHours(Guid driverId, double hours)
    {
        Hours.Add(new TimeCard(driverId, hours));
    }
}