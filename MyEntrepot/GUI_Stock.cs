using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEntrepot
{
    public partial class GUI_Stock : Form
    {
        public GUI_Stock()
        {
            InitializeComponent();
            ChargeGridView();
        }

        private void GUI_Stock_Load(object sender, EventArgs e)
        {

        }


        private void ChargeGridView()
        {
            try {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {

                    var list = from prod in bd.View_Stocks
                               select prod;

                    GridViewStock.DataSource = list;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           

        }

        private void GridViewStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {


                    DataGridViewRow row = GridViewStock.SelectedRows[0];
                    string productName = row.Cells["Product"].Value.ToString();                   



                    var list = from stock in bd.View_Stock_Details
                               where stock.Product.Equals(productName)
                               select stock;

                    GridView_Details.DataSource = list;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
