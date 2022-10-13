using FinalProject.Database;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class EditGenre : Form
    {
        List<Genre> genres;
        public EditGenre()
        {
            InitializeComponent();
            loadGenres();
            loadGenreIDs();
        }

        private void loadGenres()
        {
            this.genres = Genre.loadGenres();
            dtGridVeiwGenre.DataSource = genres;
        }

        private void loadGenreIDs()
        {
            cmbBoxGenreIDs.Items.Clear();
            foreach (Genre genre in genres)
            {
                cmbBoxGenreIDs.Items.Add(genre.GenreID);
            }
        }

        private void cmbBoxGenreIDs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedID = int.Parse(cmbBoxGenreIDs.GetItemText(cmbBoxGenreIDs.SelectedItem));
            string genreName = genres.Where(genre => genre.GenreID == selectedID).Select(genre => genre.Name).FirstOrDefault();
            txtBoxName.Text = genreName;
            panelGenreDetails.Visible = true;
        }

        private void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            string updatedGenreName = txtBoxName.Text.Trim();
            if (updatedGenreName.Length != 0)
            {
                errorProvider1.SetError(txtBoxName, "");
                string query = $"UPDATE genre set genre_name = @genreName WHERE genre_id = @genreID;";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@genreName", updatedGenreName),
                    new SqlParameter("@genreID", cmbBoxGenreIDs.GetItemText(cmbBoxGenreIDs.SelectedItem))
                };
                int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
                if (rowsAffected != 0)
                {
                    MessageBox.Show("Successfully updated the genre");
                    loadGenres();
                }
                else
                    MessageBox.Show("Something went wrong, try again");
            }
            else
                errorProvider1.SetError(txtBoxName, "Please select a genre");
        }

        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this genre?", "DELETING GENRE", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string genreID = cmbBoxGenreIDs.GetItemText(cmbBoxGenreIDs.SelectedItem);
                string query = $"DELETE FROM genre WHERE genre_id = {genreID}";
                int rowsAffetced = ConnectionManager.UpdateDatabase(query);
                if (rowsAffetced != 0)
                {
                    MessageBox.Show("Successfully deleted the genre");
                    loadGenres();
                    loadGenreIDs();
                    txtBoxName.Text = "";
                }
                else
                    MessageBox.Show("Something went wrong, try again");
            }
        }
    }
}
