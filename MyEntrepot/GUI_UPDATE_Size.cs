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

namespace MyEntrepot
{
    public partial class GUI_UPDATE_Size : Form
    {

        private string name;
        public GUI_UPDATE_Size(string name)
        {
            InitializeComponent();
            this.name = name;
            textBox1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateSize();
        }


        private void updateSize()
        {



            try
            {

                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                    db.ExecuteCommand("update tb_vitola set vitola={0} where vitola={1}", textBox1.Text, this.name);

                }
               

                MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

          

        }
    }
}
