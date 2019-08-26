using System;
using System.Collections.Generic;

namespace SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Location> locations = new List<Location>() {
            new Location{ LocationId = 0, Name = "Living Room" },
            new Location{ LocationId = 1, Name = "Kitchen" },
            new Location{ LocationId = 2, Name = "Bedroom" },
            new Location{ LocationId = 3, Name = "Computer Room" },
            new Location{ LocationId = 4, Name = "Basement" }
        };
            
            List <Event> events = new List<Event>();
            DateTime endDate = DateTime.Now.AddMonths(6);
            DateTime now = DateTime.Now;
            Random r = new Random();
            for (DateTime i = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0); i.CompareTo(endDate) <= 0; i = i.AddDays(1))
                {
                int numEvents = r.Next(0, 5);
                for (int j = 0; j <= numEvents; j++)
                {
                    int numMinutes = r.Next(0, 1439);
                    int location = r.Next(0, 4);
                    events.Add(new Event { Location = locations[location], TimeStamp = i.AddMinutes(numMinutes) });
                };
            };
            events.Sort(delegate (Event e1, Event e2) { return DateTime.Compare(e1.TimeStamp, e2.TimeStamp); });
            foreach (Event e in events)
            {
                Console.WriteLine(String.Format("{0:M/d/yy HH:mm:ss tt}", e.TimeStamp) + "\t" + e.Location.Name);
            }

            Console.ReadLine();
        }
    }
}
