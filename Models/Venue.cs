using FinalProject.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Venue
    {
        public int VenueID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public Venue(int venueID, string name, string location, int capacity)
        {
            this.VenueID = venueID;
            this.Name = name;
            this.Location = location;
            this.Capacity = capacity;
        }

        public Venue() { }

        public static List<Venue> loadVenues()
        {
            string query = "SELECT * FROM Venue;";
            DataTable table = ConnectionManager.GetData(query);
            List<Venue> venues = new List<Venue>();
            foreach (DataRow row in table.Rows)
            {
                Venue venue = new Venue();
                venue.VenueID = int.Parse(row[0].ToString());
                venue.Name = row[1].ToString();
                venue.Location = row[2].ToString();
                venue.Capacity = int.Parse(row[3].ToString());
                venues.Add(venue);
            }
            return venues;
        }
    }
}
