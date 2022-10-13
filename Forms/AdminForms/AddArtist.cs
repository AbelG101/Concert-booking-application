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
    public partial class AddArtist : Form
    {
        List<Genre> genres;
        public AddArtist()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            genres = Genre.loadGenres();
            foreach(Genre genre in genres)
            {
                cmbBoxGenre.Items.Add(genre.Name);
            }
        }
        private bool validateInput()
        {
            if (txtBoxName.Text.Trim().Length != 0)
            {
                errorProvider1.SetError(txtBoxName, "");
                if (!string.IsNullOrEmpty(cmbBoxGenre.Text))
                {
                    errorProvider1.SetError(cmbBoxGenre, "");
                    return true;
                }
                errorProvider1.SetError(cmbBoxGenre, "Please select a genre");
                return false;
            }
            errorProvider1.SetError(txtBoxName, "Please enter the artists Name");
            return false;
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                Genre selectedGenre = genres.Where(genre => genre.Name.Equals(cmbBoxGenre.GetItemText(cmbBoxGenre.SelectedItem))).FirstOrDefault();
                string query = "INSERT INTO artist (artist_name, genre_id) VALUES (@artistName, @genreID);";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@artistName", txtBoxName.Text),
                    new SqlParameter("genreID", selectedGenre.GenreID),
                };
                int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
                if (rowsAffected != 0)
                    MessageBox.Show("Successfully created the artist");
                else
                    MessageBox.Show("Something went wrong, try again");
            }
        }
    }
}
