﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BizContacts : Form
    {
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

        private void GetData(string v)
        {
            throw new NotImplementedException();
        }
    }
}
