using FinalProject.customComponents;
using FinalProject.Database;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class Orders : Form
    {
        Customer customer;
        public Orders(Customer customer)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            this.customer = customer;
            List<orderComponent> orders= loadOrders();
            renderOrders(orders);
        }

        private void renderOrders(List<orderComponent> orders)
        {
            foreach (orderComponent order in orders)
            {
                if (flowLayoutPanel.Controls.Count < 0)
                    flowLayoutPanel.Controls.Clear();
                else
                    flowLayoutPanel.Controls.Add(order);
            }
        }

        private List<orderComponent> loadOrders()
        {
            string query = $"select concert_name, vip, total_price, venue_name, date, start_time, end_time, customer_name, customer_order.ticket_amount from customer_order inner join Ticket on customer_order.ticket_id = Ticket.ticket_id inner join Concert on Ticket.concert_id = concert.concert_id inner join venue on venue.venue_id = Concert.venue_id inner join Customer on Customer.customer_id = customer_order.customer_id where customer.customer_id = {customer.CustomerID}; ";
            Console.WriteLine(customer.CustomerID);
            DataTable table = ConnectionManager.GetData(query);
            List<orderComponent> orders = new List<orderComponent>();

            foreach (DataRow row in table.Rows)
            {
                orderComponent order = new orderComponent();
                order.ConcertName = row[0].ToString();
                order.VipStatus = row[1].ToString() == "True" ? "V.I.P" : "NORMAL";
                order.Price = row[2] + " ETB";
                order.Venue = row[3].ToString();
                DateTime date = DateTime.Parse(row[4].ToString());
                order.Date = date.Date.ToShortDateString();
                order.Time = row[5] + " to " + row[6];
                order.OrderBy = "Order by " + row[7];
                order.TicketAmnt = row[8] + " X Tickets";
                orders.Add(order);
            }
            return orders;
        }
    }
}
