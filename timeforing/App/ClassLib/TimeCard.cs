using Microsoft.EntityFrameworkCore;

namespace App.ClassLib
{
    [Owned]
    public class TimeCard
    {
        public TimeCard( Guid driverId, double hours )
        {
            DriverId = driverId;
            Hours = hours;
            Date = DateTimeOffset.UtcNow;
        }

        public Guid DriverId { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Hours { get; set; }

    }
}