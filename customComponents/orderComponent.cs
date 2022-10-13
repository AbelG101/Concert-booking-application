using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.customComponents
{
    public partial class orderComponent : UserControl
    {
        public orderComponent()
        {
            InitializeComponent();
        }

        #region properties

        private string concertName;
        private string vipStatus;
        private string price;
        private string venue;
        private string date;
        private string time;
        private string orderBy;
        private string ticketAmnt;

        [Category("Custom Props")]
        public string ConcertName
        {
            set { concertName = value; lblConcertName.Text = value; }
            get { return concertName; }
        }

        [Category("Custom Props")]
        public string VipStatus
        {
            set { vipStatus = value; lblVip.Text = value; }
            get { return vipStatus; }
        }

        [Category("Custom Props")]
        public string Price
        {
            set { price = value; lblPrice.Text = value; }
            get { return price; }
        }

        [Category("Custom Props")]
        public string Venue
        {
            set { venue = value; lblLocation.Text = value; }
            get { return venue; }
        }

        [Category("Custom Props")]
        public string Date
        {
            set { date = value; lblDate.Text = value; }
            get { return date; }
        }

        [Category("Custom Props")]
        public string Time
        {
            set { time = value; lblTime_.Text = value; }
            get { return time; }
        }

        [Category("Custom Props")]
        public string OrderBy
        {
            set { orderBy = value; lblOrderBy.Text = value; }
            get { return orderBy; }
        }

        [Category("Custom Props")]
        public string TicketAmnt
        {
            set { ticketAmnt = value; lblTicketAmnt.Text = value; }
            get { return ticketAmnt; }
        }

        #endregion
    }
}
