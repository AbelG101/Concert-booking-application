using FinalProject.Database;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class EditArtist : Form
    {
        List<Genre> genres;
        public EditArtist()
        {
            InitializeComponent();
            loadAristWithGenre();
            loadArtistIDs();
            this.genres = Genre.loadGenres();
        }

        private void loadArtistIDs()
        {
            cmbBoxArtistIDs.Items.Clear();
            List<Artist> artists = Artist.loadArtists();
            foreach (Artist artist in artists)
            {
                cmbBoxArtistIDs.Items.Add(artist.ArtistID);
            }
        }
        private void loadAristWithGenre()
        {
            string query = "SELECT artist_id, artist_name, genre_name FROM artist inner join genre ON artist.genre_id = genre.genre_id;";
            DataTable table = ConnectionManager.GetData(query);
            dtGridVeiwArtists.DataSource = table;
        }

        private void cmbBoxArtistIDs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedID = cmbBoxArtistIDs.GetItemText(cmbBoxArtistIDs.SelectedItem);
            string query = $"SELECT artist_name, genre_name FROM artist inner join genre ON artist.genre_id = genre.genre_id WHERE artist_id={selectedID};";
            DataRow artist = ConnectionManager.GetData(query).Rows[0];
            txtBoxName.Text = artist[0].ToString();
            cmbBoxGenre.Items.Clear();
            foreach (Genre genre in genres)
                cmbBoxGenre.Items.Add(genre.Name);
            cmbBoxGenre.SelectedIndex = cmbBoxGenre.FindStringExact(artist[1].ToString());
            panelArtistDetails.Visible = true;
        }

        private void btnUpdateArtist_Click(object sender, EventArgs e)
        {
            string artistID = cmbBoxArtistIDs.GetItemText(cmbBoxArtistIDs.SelectedItem);
            Genre selectedGenre = genres.Where(genre => genre.Name == cmbBoxGenre.GetItemText(cmbBoxGenre.SelectedItem)).FirstOrDefault();
            string query = "update artist set artist_name = @artistName, genre_id = @genreID where artist_id = @artistID;";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@artistName", txtBoxName.Text));
            parameters.Add(new SqlParameter("@genreID", selectedGenre.GenreID));;
            parameters.Add(new SqlParameter("@artistID", artistID));
            int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
            if (rowsAffected != 0)
            {
                MessageBox.Show("Successfully updated artist");
                loadAristWithGenre();
            }
            else
                MessageBox.Show("Something went wrong, try again");
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this artist?", "DELETING ARTIST", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string artistID = cmbBoxArtistIDs.GetItemText(cmbBoxArtistIDs.SelectedItem);
                string query = $"delete from artist where artist_id = {artistID};";
                int rowsAffected = ConnectionManager.UpdateDatabase(query);
                if (rowsAffected != 0)
                {
                    MessageBox.Show("Succesfully removed");
                    loadAristWithGenre();
                    loadArtistIDs();
                    txtBoxName.Text = "";
                }
                else
                    MessageBox.Show("Something went wrong");
            }
        }
    }
}
