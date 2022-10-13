using FinalProject.Database;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class CreateConcertForm : Form
    {
        List<Artist> artists;
        List<Venue> venues;
        string imgFileName;
        public CreateConcertForm()
        {
            InitializeComponent();
            this.artists = Artist.loadArtists();
            this.venues = Venue.loadVenues();
            foreach(Artist artist in artists)
                cmbBoxArtists.Items.Add(artist.Name);
            foreach (Venue venue in venues)
                cmbBoxVenues.Items.Add(venue.Name);
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            bool inputIsValid = validateInput();
            if (inputIsValid)
            {
                createTheConcert();
            }

        }

        private void createTheTicket()
        {
            string query = "Select top 1 concert_id from Concert Order by concert_id Desc;";
            int concertID = int.Parse(ConnectionManager.GetData(query).Rows[0][0].ToString());
            string queryTicket = "INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (@price, @cocnertID, @ticketAmnt);";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@price", txtBoxPrice.Text));
            parameters.Add(new SqlParameter("@cocnertID", concertID));
            parameters.Add(new SqlParameter("@ticketAmnt", txtBoxTicketAmnt.Text));
            int rowsAffected = ConnectionManager.UpdateDatabase(queryTicket, parameters);
            if (rowsAffected != 0)
                MessageBox.Show("Succesfully created");
            else
                MessageBox.Show("Something went wrong while creating the ticket, try again");
        }

        private void createTheConcert()
        {
            Artist selectedArtist = artists.
            Where(artist => artist.Name.Equals(cmbBoxArtists.GetItemText(cmbBoxArtists.SelectedItem))).FirstOrDefault();
            Venue selectedVenue = venues.
                Where(venue => venue.Name.Equals(cmbBoxVenues.GetItemText(cmbBoxVenues.SelectedItem))).FirstOrDefault();
            string query = "INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES (@concertName, @artistID, @date, @startTime, @endTime, @venueID, @img);";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@concertName", txtBoxConcertName.Text));
            parameters.Add(new SqlParameter("@artistID", selectedArtist.ArtistID));
            parameters.Add(new SqlParameter("@date", dateTimePicker.Value.ToShortDateString()));
            parameters.Add(new SqlParameter("@startTime", startTimePicker.Value.ToLongTimeString()));
            parameters.Add(new SqlParameter("@endTime", endTimePicker.Value.ToLongTimeString()));
            parameters.Add(new SqlParameter("@venueID", selectedVenue.VenueID));
            parameters.Add(new SqlParameter("@img", imgFileName));
            int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
            if (rowsAffected != 0)
                createTheTicket();
            else
                MessageBox.Show("Something went wrong while creating the concert, try again");
        }

        private bool validateInput()
        {
            if (txtBoxConcertName.Text.Trim().Length != 0)
            {
                if (!string.IsNullOrEmpty(imgFileName))
                {
                    if (!(string.IsNullOrEmpty(txtBoxPrice.Text) || string.IsNullOrEmpty(txtBoxTicketAmnt.Text)))
                    {
                        if (!string.IsNullOrEmpty(cmbBoxArtists.Text) && !string.IsNullOrEmpty(cmbBoxVenues.Text))
                            return true;
                        MessageBox.Show("Artist or Venue not selected!");
                        return false;
                    }
                    MessageBox.Show("Please provide a price and a ticket amount");
                    return false;

                }
                MessageBox.Show("Please insert a valid image");
                return false;
            }
            MessageBox.Show("Please enter a valid concert name");
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CombinedPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Images\");
            openFileDialog1.InitialDirectory = Path.GetFullPath(CombinedPath);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.imgFileName = openFileDialog1.SafeFileName;       
            }
        }

        private void txtBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBoxTicketAmnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
