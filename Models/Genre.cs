using FinalProject.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Genre
    {
        public int GenreID { set; get; }
        public string Name { set; get; }

        public Genre (int genreID, string name)
        {
            this.GenreID = genreID;
            this.Name = name;
        }

        public Genre() { }

        public static List<Genre> loadGenres()
        {
            List<Genre> genres = new List<Genre>();
            string query = "SELECT * FROM genre;";
            DataTable table = ConnectionManager.GetData(query);
            foreach(DataRow row in table.Rows)
            {
                Genre genre = new Genre
                {
                    GenreID = int.Parse(row[0].ToString()),
                    Name = row[1].ToString()
                };
                genres.Add(genre);
            }
            return genres;
        }
    }
}
