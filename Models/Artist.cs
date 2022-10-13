using FinalProject.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public int GenreID { get; set; }

        public Artist(int ArtistID, string ArtistName, int genreID)
        {
            this.ArtistID = ArtistID;
            this.Name = ArtistName;
            this.GenreID = genreID;
        }

        public Artist() { }

        public static List<Artist> loadArtists()
        {
            string query = "SELECT * FROM Artist;";
            DataTable table = ConnectionManager.GetData(query);
            List<Artist> artists = new List<Artist>();
            foreach (DataRow row in table.Rows)
            {
                Artist artist = new Artist();
                artist.ArtistID = int.Parse(row[0].ToString());
                artist.Name = row[1].ToString();
                artist.GenreID = int.Parse(row[2].ToString());
                artists.Add(artist);
            }
            return artists;
        }
    }
}
