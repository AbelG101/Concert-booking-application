using FinalProject.Database;
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
    public partial class AddGenre : Form
    {
        public AddGenre()
        {
            InitializeComponent();
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                string query = "INSERT INTO genre (genre_name) VALUES (@genreName);";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@genreName", txtBoxName.Text),
                };
                int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
                if (rowsAffected != 0)
                    MessageBox.Show("Successfully added the genre");
                else
                    MessageBox.Show("Something went wrong, try again");
            }
        }
        private bool validateInput()
        {
            if (txtBoxName.Text.Trim().Length != 0)
            {
                errorProvider1.SetError(txtBoxName, "");
                return true;
            }
            errorProvider1.SetError(txtBoxName, "Please enter the genre name");
            return false;
        }
    }
}
