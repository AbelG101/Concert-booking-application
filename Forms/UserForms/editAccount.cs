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
    public partial class editAccount : Form
    {
        Customer customer;
        public editAccount(Customer customer)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            this.customer = customer;
            txtBoxFullName.Text = customer.FullName;
            txtBoxUserName.Text = customer.UserName;
            txtBoxPsswd.Text = customer.Psswd;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer editedAccount = new Customer();
            editedAccount.CustomerID = customer.CustomerID;
            editedAccount.FullName = txtBoxFullName.Text;
            editedAccount.UserName = txtBoxUserName.Text;
            editedAccount.Psswd = txtBoxPsswd.Text;
            if (validateUser(editedAccount) == true)
            {
                string query = $@"UPDATE Customer SET customer_name = @customerName, user_name = @userName, password = @psswd WHERE customer_id = @customerID;";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@customerName", editedAccount.FullName));
                parameters.Add(new SqlParameter("@userName", editedAccount.UserName));
                parameters.Add(new SqlParameter("@psswd", editedAccount.Psswd));
                parameters.Add(new SqlParameter("@customerID", customer.CustomerID));
                int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
                if (rowsAffected != 0)
                {
                    MessageBox.Show("Changes saved");
                    Close();
                    new Concerts(editedAccount).Show();
                }
                else
                    MessageBox.Show("Something went wrong, try again");
            }
        }

        private bool validateUser(Customer customer)
        {
            if (inputIsValid(customer))
            {
                if (!userExists(customer))
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
            string query = $@"SELECT * FROM Customer WHERE user_name = @userName and customer_id != @customerID ";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@userName", customer.UserName),
                new SqlParameter("@customerID", customer.CustomerID),
            };
            Console.WriteLine(customer.UserName + "  " + customer.CustomerID);
            if (ConnectionManager.GetData(query, parameters).Rows.Count != 0)
            {
                MessageBox.Show("User name already exists, try another");
                return true;
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the account", "DELETING ACCOUNT", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Customer WHERE customer_id = @customerID;";
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@customerID", customer.CustomerID),
                };
                int rowsAffected = ConnectionManager.UpdateDatabase(query, parameters);
                if (rowsAffected != 0)
                {
                    MessageBox.Show("Account successfully deleted");
                    Close();
                    new Login().Show();
                } else
                {
                    MessageBox.Show("Something went wrong, try again");
                }
            }
        }
    }
}
