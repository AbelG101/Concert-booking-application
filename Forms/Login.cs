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
using FinalProject.Database;
using FinalProject.Models;

namespace FinalProject.Forms
{
    public partial class Login : Form
    {
        string userName;
        string psswd;
        public Login()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            userName = txtBox_userName.Text;
            psswd = txtBox_psswd.Text;
            string query = $@"SELECT * FROM Customer WHERE user_name = @userName AND password = @psswd;";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@userName", userName));
            parameters.Add(new SqlParameter("@psswd", psswd));
            if (userIsValid(query, parameters))
            {
                Customer customer = getCustomerDetails(query, parameters);
                this.Hide();
                Form homeForm;
                if ( customer.UserName.ToLower() == "admin" && customer.Psswd.ToLower() == "admin123")
                {
                    homeForm = new AdminForm();
                }
                else
                    homeForm = new Concerts(customer);
                homeForm.Closed += (s, args) => Close();
                homeForm.Show();
            } else
            {
                MessageBox.Show("User name or password is incorrect!");
            }
        }

        private Customer getCustomerDetails(string query, List<SqlParameter> parameters)
        {
            DataRow foundUser = ConnectionManager.GetData(query, parameters).Rows[0];
            Customer customer = new Customer(
                int.Parse(foundUser["customer_id"].ToString()),
                foundUser["user_name"].ToString(),
                foundUser["customer_name"].ToString(),
                foundUser["password"].ToString()
            );
            return customer;
        }

        private bool userIsValid(string query, List<SqlParameter> parameters)
        {
            if (ConnectionManager.GetData(query, parameters).Rows.Count != 0)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createAccForm = new CreateAccount();
            createAccForm.Show();
        }
    }
}
