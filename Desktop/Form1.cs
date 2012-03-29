using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Form1 : Form
    {
        Communicator comm;
 
        public Form1()
        {
            InitializeComponent();
            comm = new Communicator();

            comm.onGetRecords += new Communicator.getRecordsDelegate(getRecordsHandler);

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            comm.Connect();

        }

        private void buttonGetRecords_Click(object sender, EventArgs e)
        {
            comm.GetRecords();
        }

        public void getRecordsHandler(string message) 
        {
            textBox.Text = message;
        }
    }
}
