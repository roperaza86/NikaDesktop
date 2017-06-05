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
    public partial class GUI_Production_Daily : Form
    {
        public GUI_Production_Daily()
        {
            InitializeComponent();
            chargeCombo();
            ChargeDataGridview();
        }


        public void ChargeDataGridview()
        {
            try
            {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {
                    var listProduct = from p in bd.View_Production_Dailies
                                      orderby p.Date descending
                                      select p;
                    dataGridProduct.DataSource = listProduct.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void GUI_Production_Daily_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection rows = dataGridProduct.SelectedRows;

            foreach (DataGridViewRow row in rows)
            {
                try
                {
                    string productS = row.Cells["Product"].Value.ToString();
                    string personalS = row.Cells["Personal"].Value.ToString();
                    DateTime dateS = (DateTime)row.Cells["Date"].Value;

                    using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                    {

                        int product = (from p in bd.Tobaccos
                                       where p.name == productS
                                       select p.id_Tobacco).FirstOrDefault();
                        int personal = (from p in bd.Personals
                                        where p.name == personalS
                                        select p.id_Personal).FirstOrDefault();

                        Production_Daily pDaily = (from p in bd.Production_Dailies
                                                   where p.product == product &&
                                                   p.personal == personal &&
                                                   p.Date == dateS
                                                   select p).FirstOrDefault();

                        Stock objStock = (from s in bd.Stocks
                                          where s.referDaily == pDaily.id_Prod_Daily
                                          select s).FirstOrDefault();


                        bd.Production_Dailies.DeleteOnSubmit(pDaily);
                        bd.Stocks.DeleteOnSubmit(objStock);
                        bd.SubmitChanges();
                     //   MessageBox.Show(" delete success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                   
                }
            }
            ChargeDataGridview();
        }

        private void chargeCombo()
        {

            try
            {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {

                    //////Product 

                    var listTobacco = from t in bd.Tobaccos
                                      select t;

                    Dictionary<int, string> sourceTobaco = new Dictionary<int, string>();

                    foreach (Tobacco t in listTobacco)
                    {
                        sourceTobaco.Add(t.id_Tobacco, t.name);
                    }

                    comboProduct.DataSource = new BindingSource(sourceTobaco, null);
                    comboProduct.DisplayMember = "Value";
                    comboProduct.ValueMember = "Key";


                    /////Personal

                  

                    var listPersonal = from p in bd.Personals
                                      select p;

                    Dictionary<int, string> sourcePersonal = new Dictionary<int, string>();

                    foreach (Personal p in listPersonal)
                    {
                        sourcePersonal.Add(p.id_Personal,p.name);
                    }

                    comboPersonal.DataSource = new BindingSource(sourcePersonal, null);
                    comboPersonal.DisplayMember = "Value";
                    comboPersonal.ValueMember = "Key";
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {
                    Production_Daily pDaily = new Production_Daily();
                    pDaily.product = (int)comboProduct.SelectedValue;
                    pDaily.personal = (int)comboPersonal.SelectedValue;

                    if (radioBonchero.Checked)
                    {
                        decimal cost = 0;
                        if (decimal.TryParse(txtCosto.Text, out cost))
                        {

                            pDaily.cost_Bonchero = cost;
                           
                        }
                    }

                    if (radioRolero.Checked)
                    {
                        decimal cost = 0;
                        if (decimal.TryParse(txtCosto.Text, out cost))
                        {

                            pDaily.cost_Rolero = cost;
                            
                        }
                    }

                    pDaily.Date = dateTimePicker1.Value;
                    int quantity;

                    if(int.TryParse(txtQuantity.Text, out quantity))
                    {
                        pDaily.quantity = quantity;
                    }

                    bd.Production_Dailies.InsertOnSubmit(pDaily);
                    bd.SubmitChanges();

                    Stock stockObj = new Stock();
                    stockObj.product = pDaily.product;
                    stockObj.stock1 = pDaily.quantity;
                    stockObj.dateE = pDaily.Date;
                    stockObj.referDaily = pDaily.id_Prod_Daily;

                    bd.Stocks.InsertOnSubmit(stockObj);
                    bd.SubmitChanges();

                    txtCosto.Clear();
                    txtQuantity.Clear();
                    ChargeDataGridview();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
