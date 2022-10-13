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
    public partial class ConcertComponent : UserControl
    {
        public ConcertComponent()
        {
            InitializeComponent(); 
        }

        private string date;
        private string concertName;
        private string venue;
        private string price;
        private string startTime;
        private string endTime;
        private string ticketID;
        private string ticketAmnt;
        private Image img;

        public Button BtnBook
        {
            get { return bookBtn; }
        }

        public Image Img
        {
            get { return img; }
            set { img = value; picBox.Image = value;  }
        }
        public string Date
        {
            get { return date; }
            set { date = value; lblDate.Text = value;  }
        }

        public string ConcertName
        {
            get { return concertName; }
            set { concertName = value; lblConcertName.Text = value;  }
        }

        public string Venue
        {
            get { return venue; }
            set { venue = value; lblVenue.Text = value;  }
        }

        public string Price
        {
            get { return price; }
            set { price = value; lblPrice.Text = value; }
        }

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public string TicketID
        {
            get { return ticketID; }
            set { ticketID = value; }
        }

        public string TicketAmnt
        {
            get { return ticketAmnt; }
            set { ticketAmnt = value; }
        }
    }
}
