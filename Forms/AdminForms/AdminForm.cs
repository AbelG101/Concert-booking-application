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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void btnActive(Button activeBtn)
        {
            List<Button> btns = new List<Button>
            {
                btnAddArtist,
                btnAddGenre,
                btnCreateEvent,
                btnEditArtist,
                btnEditGenre,
                btnCreateEvent,
                btnEditEvent,
            };
            btns.ForEach(btn =>
            {
                if (btn != activeBtn)
                    btn.BackColor = ColorTranslator.FromHtml("#1A1E21");
                else
                    btn.BackColor = ColorTranslator.FromHtml("#2C3238");
            });
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            CreateConcertForm adminForm = new CreateConcertForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addToMainPanel(adminForm);
            btnActive(btnCreateEvent);
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            editConcert editConcertForm = new editConcert() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addToMainPanel(editConcertForm);
            btnActive(btnEditEvent);
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            AddArtist addArtist = new AddArtist() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addToMainPanel(addArtist);
            btnActive(btnAddArtist);
        }
        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            AddGenre genre = new AddGenre() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addToMainPanel(genre);
            btnActive(btnAddGenre);
        }
        private void btnEditGenre_Click(object sender, EventArgs e)
        {
            EditGenre editGenre = new EditGenre() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addToMainPanel(editGenre);
            btnActive(btnEditGenre);
        }

        private void btnEditArtist_Click(object sender, EventArgs e)
        {
            EditArtist editArtist = new EditArtist() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addToMainPanel(editArtist);
            btnActive(btnEditArtist);
        }
        private void addToMainPanel(Form form)
        {
            mainPanel.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
