using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FinalProject.Database;
using FinalProject.Models;

namespace FinalProject.Forms
{
    public partial class Concerts : Form
    {
        Customer customer;
        public Concerts(Customer customer)
        {
            InitializeComponent();
            lblWelcomeMsg.Text = $"Welcome, {customer.FullName}";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            this.customer = customer;
            List<ConcertComponent> concertComponents = loadConcerts();
            renderConcerts(concertComponents);
        }

        private void renderConcerts(List<ConcertComponent> concertComponents)
        {
            foreach(ConcertComponent component in concertComponents)
            {
                component.BtnBook.Click += (object o, EventArgs e) => { new Checkout(component, customer.CustomerID).Show(); };
                if (flowLayoutPanel.Controls.Count < 0)
                    flowLayoutPanel.Controls.Clear();
                else
                    flowLayoutPanel.Controls.Add(component);
            }
        }

        private List<ConcertComponent> loadConcerts()
        {
            string query = "select concert_name, venue_name, date, price, start_time, end_time, ticket_id, image_path from concert inner join venue on concert.venue_id = venue.venue_id inner join ticket on concert.concert_id = ticket.concert_id;";
            DataTable table = ConnectionManager.GetData(query);
            List<ConcertComponent> concertComponents = new List<ConcertComponent>();
            foreach(DataRow row in table.Rows)
            {
                ConcertComponent concert = new ConcertComponent();
                concert.ConcertName = row[0].ToString();
                concert.Venue = row[1].ToString();
                DateTime date = DateTime.Parse(row[2].ToString());
                concert.Date = date.Date.ToShortDateString();
                concert.Price = row[3].ToString() + " ETB";
                concert.StartTime = row[4].ToString();
                concert.EndTime = row[5].ToString();
                concert.TicketID = row[6].ToString();
                concert.Img = Image.FromFile(@"..\..\Images\" + row[7]);
                
                concertComponents.Add(concert);
            }
            return concertComponents;

        }

        private void editAccBtn_Click(object sender, EventArgs e)
        {
            var editAccountForm = new editAccount(customer);
            editAccountForm.Closed += (s, args) => this.Hide();
            editAccountForm.Show();
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            var ordersForm = new Orders(customer);
            this.Closed += (s, args) => ordersForm.Close();
            ordersForm.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
