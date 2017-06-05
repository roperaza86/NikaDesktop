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

namespace MyEntrepot
{
    public partial class GUI_UPDATE_Wrapper : Form
    {

        private string name;
        public GUI_UPDATE_Wrapper(string name)
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
            updateWrapper();
        }


        private void updateWrapper()
        {
            try
            {

                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                  
                    db.ExecuteCommand("update tb_capa set capa={0} where capa={1}",textBox1.Text,this.name);
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                    }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ ex.Source);
            }

           

            }

          

        }
    }

