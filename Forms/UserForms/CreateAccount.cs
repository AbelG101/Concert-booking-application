using FinalProject.Database;
using FinalProject.Models;
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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                FullName = txtBoxFullName.Text,
                UserName = txtBoxUserName.Text,
                Psswd = txtBoxPsswd.Text,
            };
            if(validateUser(newCustomer) == true)
            {
                string query = $@"INSERT INTO Customer (customer_name, user_name, password) VALUES (@customerName, @userName, @psswd);";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@customerName", newCustomer.FullName));
                parameters.Add(new SqlParameter("@userName", newCustomer.UserName));
                parameters.Add(new SqlParameter("@psswd", newCustomer.Psswd));
                int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
                if (rowsAffected != 0)
                {
                    MessageBox.Show("Account created");
                    Close();
                }
                else 
                    MessageBox.Show("Something went wrong, try again");
            }
        }

        private bool validateUser(Customer newCustomer)
        {
            if (inputIsValid(newCustomer))
            {
                if (!userExists(newCustomer))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool inputIsValid(Customer customer)
        {
            customer.FullName = customer.FullName.Trim();
            customer.UserName = customer.UserName.Trim();
            customer.Psswd = customer.Psswd.Trim();

            if (customer.FullName.Length == 0 || customer.UserName.Length == 0 || customer.Psswd.Length == 0)
            {
                MessageBox.Show("Invalid Input! please provide a valid input");
                return false;
            }

            if (customer.Psswd.Length < 8)
            {
                MessageBox.Show("Password must not be less than 8 characters");
                return false;
            }
            return true;
        }

        private bool userExists(Customer customer)
        {
            string query = $@"SELECT * FROM Customer WHERE user_name = @userName";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@userName", customer.UserName)
            };
            if (ConnectionManager.GetData(query, parameters).Rows.Count != 0)
            {
                MessageBox.Show("User name already exists, try another");
                return true;
            }
            return false;
        }
    }
}
