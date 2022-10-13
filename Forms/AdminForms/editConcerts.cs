using FinalProject.Database;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class editConcert : Form
    {
        List<Artist> artists;
        List<Venue> venues;
        public editConcert()
        {
            InitializeComponent();
            DataTable concerts = loadConcerts();
            List<int> concertIds = getConcertIDs(concerts);
            foreach(int ID in concertIds)
            {
                cmbBoxConcertIDs.Items.Add(ID);
            }
        }

        private DataTable loadConcerts()
        {
            string query = "select concert.concert_id, concert_name, price, ticket_amount, artist_name, venue_name, date, start_time, end_time from concert inner join ticket on concert.concert_id = ticket.concert_id inner join Artist on concert.artist_id = Artist.artist_id inner join venue on concert.venue_id = venue.venue_id; ";
            DataTable cocnerts = ConnectionManager.GetData(query);
            dtGridConcerts.DataSource = cocnerts;
            return cocnerts;
            
        }

        private List<int> getConcertIDs(DataTable table)
        {
            cmbBoxConcertIDs.Items.Clear();
            List<int> IDs = new List<int>();
            foreach(DataRow row in table.Rows)
            {
                IDs.Add(int.Parse(row[0].ToString()));
            }
            return IDs;
        }

        private void cmbBoxConcertIDs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedID = cmbBoxConcertIDs.GetItemText(cmbBoxConcertIDs.SelectedItem);
            string query = $"select concert_name, date, price, start_time, end_time, ticket_amount, artist_name, venue_name from concert inner join ticket on concert.concert_id = ticket.concert_id inner join Artist on concert.artist_id = Artist.artist_id inner join venue on concert.venue_id = venue.venue_id where concert.concert_id = {selectedID};";
            DataRow concert = ConnectionManager.GetData(query).Rows[0];
            txtBoxConcertName.Text = concert[0].ToString();
            dateTimePicker.Value = Convert.ToDateTime(concert[1]);
            txtBoxPrice.Text = concert[2].ToString();
            startTimePicker.Value = DateTime.ParseExact(concert[3].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
            endTimePicker.Value = DateTime.ParseExact(concert[4].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
            txtBoxTicketAmnt.Text = concert[5].ToString();
            this.artists = Artist.loadArtists();
            this.venues = Venue.loadVenues();
            cmbBoxVenues.Items.Clear();
            cmbBoxArtists.Items.Clear();
            foreach (Venue venue in venues)
                cmbBoxVenues.Items.Add(venue.Name);
            foreach (Artist artist in artists)
                cmbBoxArtists.Items.Add(artist.Name);
            cmbBoxArtists.SelectedIndex = cmbBoxArtists.FindStringExact(concert[6].ToString());
            cmbBoxVenues.SelectedIndex = cmbBoxVenues.FindStringExact(concert[7].ToString());
            panel1.Visible = true;
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            bool inputIsValid = validateInput();
            if (inputIsValid)
            {
                updateConcert();
                loadConcerts();
            }
        }

        private void updateConcert()
        {
            string concertID = cmbBoxConcertIDs.GetItemText(cmbBoxConcertIDs.SelectedItem);
            Artist selectedArtist = artists.
            Where(artist => artist.Name.Equals(cmbBoxArtists.GetItemText(cmbBoxArtists.SelectedItem))).FirstOrDefault();
            Venue selectedVenue = venues.
                Where(venue => venue.Name.Equals(cmbBoxVenues.GetItemText(cmbBoxVenues.SelectedItem))).FirstOrDefault();
            string query = "update Concert set concert_name = @concertName, artist_id = @artistID, date = @date, start_time = @startTime, end_time = @endTime, venue_id = @venueID where concert_id = @concertID;";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@concertName", txtBoxConcertName.Text));
            parameters.Add(new SqlParameter("@artistID", selectedArtist.ArtistID));
            parameters.Add(new SqlParameter("@date", dateTimePicker.Value.ToShortDateString()));
            parameters.Add(new SqlParameter("@startTime", startTimePicker.Value.ToLongTimeString()));
            parameters.Add(new SqlParameter("@endTime", endTimePicker.Value.ToLongTimeString()));
            parameters.Add(new SqlParameter("@venueID", selectedVenue.VenueID));
            parameters.Add(new SqlParameter("@concertID", concertID));
            int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
            if (rowsAffected != 0)
                updateTicket(concertID);
            else
                MessageBox.Show("Something went wrong while creating the concert, try again");
        }

        private void updateTicket(string concertID)
        {
            string query = "update ticket set price = @price, ticket_amount = @ticketAmnt where concert_id = @concertID;";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@price", txtBoxPrice.Text));
            parameters.Add(new SqlParameter("@concertID", concertID));
            parameters.Add(new SqlParameter("@ticketAmnt", txtBoxTicketAmnt.Text));
            int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
            if (rowsAffected != 0)
                MessageBox.Show("Succesfully updated");
            else
                MessageBox.Show("Something went wrong while creating the ticket, try again");
        }

        private bool validateInput()
        {
            if (txtBoxConcertName.Text.Trim().Length != 0)
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
            MessageBox.Show("Please enter a valid concert name");
            return false;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this event?", "DELETING EVENT", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string concertID = cmbBoxConcertIDs.GetItemText(cmbBoxConcertIDs.SelectedItem);
                string queryDeleteOrder = $"delete customer_order from Concert inner join ticket on ticket.concert_id = Concert.concert_id inner join customer_order on customer_order.ticket_id = ticket.ticket_id where Concert.concert_id = {concertID};";
                string queryDeleteTicket = $"delete ticket from Concert inner join ticket on ticket.concert_id = Concert.concert_id where Concert.concert_id = {concertID};";
                string queryDeleteConcert = $"delete concert from Concert where Concert.concert_id = {concertID};";
                int deleteOrderRowsAffected = ConnectionManager.UpdateDatabase(queryDeleteOrder);
                int deleteTicketRowsAffected = ConnectionManager.UpdateDatabase(queryDeleteTicket);
                int deleteConcertRowsAffected = ConnectionManager.UpdateDatabase(queryDeleteConcert);
                if ((deleteConcertRowsAffected != 0 && deleteTicketRowsAffected != 0) || deleteOrderRowsAffected != 0 )
                {
                    MessageBox.Show("Succesfully removed");
                    List<int> concertIds = getConcertIDs(loadConcerts());
                    foreach (int ID in concertIds)
                    {
                        cmbBoxConcertIDs.Items.Add(ID);
                    }
                    panel1.Visible = false;
                }
                else
                    MessageBox.Show("Something went wrong");
            }
        }
    }
}
