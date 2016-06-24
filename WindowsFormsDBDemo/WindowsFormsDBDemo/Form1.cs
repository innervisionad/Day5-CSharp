using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDBDemo
{
    public partial class Form1 : Form
    {
        List<Customer> listCustomers = new List<Customer>();
        int customerListIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadPeople_Click(object sender, EventArgs e)
        {
            using (ClientsEntities1 myEntities = new ClientsEntities1())
            {
                var customers = from customer in myEntities.Customers
                                select customer;
                listCustomers = customers.ToList();
            }
            DisplayCustomer(customerListIndex);
        }

        private void DisplayCustomer(int customerId)
        {
            if (listCustomers[customerId] != null)
            {
                textBoxFirstName.Text = listCustomers[customerId].Forename;
                textBoxSurname.Text = listCustomers[customerId].Surname;
                textBoxHouseNumber.Text = (listCustomers[customerId].HouseNumber).ToString();
                textBoxStreet.Text = listCustomers[customerId].Street;
                textBoxPhoneNumber.Text = listCustomers[customerId].Phone;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            customerListIndex++;
            if (customerListIndex >= listCustomers.Count)
            {
                customerListIndex = 0;
            }
            DisplayCustomer(customerListIndex);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            customerListIndex--;
            if (customerListIndex < 0)
            {
                customerListIndex = listCustomers.Count - 1;
            }
            DisplayCustomer(customerListIndex);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //add record button
            using (ClientsEntities1 myEntities = new ClientsEntities1())
            {
                Customer addedCustomer = new Customer();
                // get customer data from screen
                addedCustomer.Forename = textBoxFirstName.Text;
                addedCustomer.Surname = textBoxSurname.Text;
                addedCustomer.HouseNumber = Convert.ToInt32(textBoxHouseNumber.Text);
                addedCustomer.Street = textBoxStreet.Text;
                addedCustomer.Phone = textBoxPhoneNumber.Text;
                //add new record to database - Customers is table name            
                myEntities.Customers.Add(addedCustomer);
                myEntities.SaveChanges();
            }
        }
    }
}



