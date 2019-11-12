﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BizContacts : Form
    {
        string connString = @"Data Source=C0312-17LT001\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter;
        DataTable table;

        public BizContacts()
        {
            InitializeComponent();
        }

        private void BizContacts_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0; // first time in combobox is selected when the form loads
            dataGridView1.DataSource = bindingSource1;

            GetData("Select * from BizContacts");
        }

        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);
                table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;

            string insert = @"insert into BizContacts(Date_Added, Company, Website, Title, First_Name, Last_Name, Address, City, State, Postal_Code, Mobile, Notes) values(@Date_Added, @Company, @Website, @Title, @First_Name, @Last_Name, @Address, @City, @State, @Postal_Code, @Mobile, @Notes)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Date_Added", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue(@"Company", txtCompany.Text);
                    command.Parameters.AddWithValue(@"Website", txtWebsite);
                    command.Parameters.AddWithValue(@"Title", txtTitle.Text);
                    command.Parameters.AddWithValue(@"First_Name", txtFName.Text);
                    command.Parameters.AddWithValue(@"Last_Name", txtLName.Text);
                    command.Parameters.AddWithValue(@"Address", txtAddress.Text);
                    command.Parameters.AddWithValue(@"City", txtCity.Text);
                    command.Parameters.AddWithValue(@"State", txtState.Text);
                    command.Parameters.AddWithValue(@"Postal_Code", txtPostalCode.Text);
                    command.Parameters.AddWithValue(@"Mobile", txtMobile.Text);
                    command.Parameters.AddWithValue(@"Notes", txtNotes.Text);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            GetData("Select * from BizContacts");
            dataGridView1.Update();
        }
    }
}
