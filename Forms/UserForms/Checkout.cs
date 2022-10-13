using FinalProject.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class Checkout : Form
    {
        private ConcertComponent concertComponent;
        private int customerID;
        public Checkout(ConcertComponent component, int customerID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            this.concertComponent = component;
            this.customerID = customerID;
            // set the first comboBox value as default
            comboBox.SelectedIndex = 0;
            renderOrderDetails(component);

        }

        private void renderOrderDetails(ConcertComponent component)
        {
            lblDate.Text = component.Date;
            lblPricePerTicket.Text = component.Price;
            lblTicketAmnt.Text = comboBox.GetItemText(comboBox.SelectedItem) + "X";
            lblVipPrice.Text = 0.00 + "";
            lblSubTotal.Text = component.Price + "";
            lblTotal.Text = component.Price;
            lblPrice.Text = component.Price;
            lblTime.Text = $"{component.StartTime} - {component.EndTime}";
            lblConcertName.Text = component.ConcertName;
            lblVenue.Text = component.Venue;
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblTicketAmnt.Text = comboBox.GetItemText(comboBox.SelectedItem) + "X";
            float ticketPrice = float.Parse(Regex.Replace(lblPrice.Text, "[^.0-9]", ""));
            int ticketAmnt = int.Parse(Regex.Replace(lblTicketAmnt.Text, "[^.0-9]", ""));
            string pricePerTicket = (ticketAmnt * ticketPrice).ToString();
            lblPricePerTicket.Text = pricePerTicket + " ETB";
            double vipPrice = calcVipPrice();
            calculateTotalPrice(vipPrice);

        }

        private void radioBtnVip_CheckedChanged(object sender, EventArgs e)
        {
            double vipPrice = calcVipPrice();
            lblVipPrice.Text = vipPrice.ToString();
            calculateTotalPrice(vipPrice);
        }

        private void radioBtnNormal_CheckedChanged(object sender, EventArgs e)
        {
            double vipPrice = 0.00;
            lblVipPrice.Text = (vipPrice).ToString();
            calculateTotalPrice(vipPrice);
        }

        private double calcVipPrice()
        {
            if( radioBtnVip.Checked )
            {
                int ticketAmnt = int.Parse(comboBox.GetItemText(comboBox.SelectedItem));
                double ticketPrice = Double.Parse(Regex.Replace(lblPrice.Text, "[^.0-9]", ""));
                double vipPrice = Math.Round(ticketPrice * 0.55 * ticketAmnt, 2);
                return vipPrice;
            } return 0.00;
        }

        private void calculateTotalPrice(double vipPrice)
        {
            double pricePerTicket = Double.Parse(Regex.Replace(lblPricePerTicket.Text, "[^.0-9]", ""));
            double subTotal = pricePerTicket + vipPrice;
            lblSubTotal.Text = subTotal + "";
            lblTotal.Text = subTotal + " ETB";
            lblVipPrice.Text = vipPrice + "";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            string query = $@"INSERT INTO customer_order (customer_id, total_price, ticket_id, vip, ticket_amount) VALUES (@customerID, @totalPrice, @ticketID, @vip, @ticketAmnt);";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@customerID", customerID));
            parameters.Add(new SqlParameter("@totalPrice", Double.Parse(Regex.Replace(lblTotal.Text, "[^.0-9]", ""))));
            parameters.Add(new SqlParameter("@ticketID", concertComponent.TicketID));
            parameters.Add(new SqlParameter("@ticketAmnt", comboBox.GetItemText(comboBox.SelectedItem)));
            int vip = radioBtnVip.Checked == true ? 1 : 0;
            parameters.Add(new SqlParameter("@vip", vip));
            int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
            if (rowsAffected != 0)
            {
                MessageBox.Show("ORDER SUCCESSFUL");
                this.Hide();
            } else MessageBox.Show("Something went wrong.");
        }
    }
}
