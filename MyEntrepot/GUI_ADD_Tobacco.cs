using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;


namespace MyEntrepot
{
    public partial class GUI_ADD_Tobacco : Form
    {
        private EntrepotBDDataContext bd;

        public GUI_ADD_Tobacco()
        {
            InitializeComponent();
            chargeCombo();
            chargeGridView();


        }


        private void chargeCombo()
        {
            using (bd = new EntrepotBDDataContext())
            {
                //////Size

                var listSize = from s in bd.tb_vitolas
                               orderby s.vitola
                               select s;

                Dictionary<int, string> sourceSize = new Dictionary<int, string>();

                foreach (tb_vitola s in listSize)
                {
                    sourceSize.Add(s.id_vitola, s.vitola);
                }

                comboSize.DataSource = new BindingSource(sourceSize, null);
                comboSize.DisplayMember = "Value";
                comboSize.ValueMember = "Key";

                ///
                //////Wrapper

                var listWrapper = from w in bd.tb_capas
                                  orderby w.capa
                                  select w;

                Dictionary<int, string> sourceWrapper = new Dictionary<int, string>();

                foreach (tb_capa w in listWrapper)
                {
                    sourceWrapper.Add(w.id_capa, w.capa);
                }

                comboWrapper.DataSource = new BindingSource(sourceWrapper, null);
                comboWrapper.DisplayMember = "Value";
                comboWrapper.ValueMember = "Key";


                //////Blend

                var listBlend = from b in bd.tb_ligas
                                orderby b.liga
                                select b;

                Dictionary<int, string> sourceBlend = new Dictionary<int, string>();

                foreach (tb_liga b in listBlend)
                {
                    sourceBlend.Add(b.id_liga, b.liga);
                }

                comboBlend.DataSource = new BindingSource(sourceBlend, null);
                comboBlend.DisplayMember = "Value";
                comboBlend.ValueMember = "Key";
            }
        }


        private void chargeGridView()
        {
            using (bd = new EntrepotBDDataContext())
            {
                //////Size            


                var listSize = from s in bd.tb_vitolas
                               orderby s.vitola ascending
                               select new { name = s.vitola };
                dataGridView2.DataSource = listSize.ToList();
                ///
                //////Wrapper

                var listWrapper = from w in bd.tb_capas
                                  orderby w.capa ascending
                                  select new { name = w.capa };
                dataGridView3.DataSource = listWrapper.ToList();


                //////Blend

                var listBlend = from b in bd.tb_ligas
                                select new { name = b.liga }
                                into bX
                                orderby bX.name
                                select bX;
           
                dataGridView1.DataSource = listBlend.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                    Blend blend = new Blend();

                    blend.name = textBox1.Text;
                    db.Blends.InsertOnSubmit(blend);
                    db.SubmitChanges();
                    chargeCombo();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    chargeGridView();
                    textBox1.Focus();
                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chargeGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chargeGridView();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            deleteBlend(rows);

           
        
        }

        private void deleteBlend(DataGridViewSelectedRowCollection listSelectBlend)
        {

            try
            {
                foreach (DataGridViewRow k in listSelectBlend)
                {
                   
                    using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                    {
                        string name = k.Cells["name"].Value.ToString();
                        tb_liga blend = (from b in db.tb_ligas
                                      where b.liga == name
                                      select b).FirstOrDefault();
                       
                        db.tb_ligas.DeleteOnSubmit(blend);
                        db.SubmitChanges();
                        
                    }


                }

                MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargeGridView();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;
            string name = cell.Value.ToString();
           

            GUI_UPDATE_Blend gui_updateBlend = new GUI_UPDATE_Blend(name);
            gui_updateBlend.ShowDialog();
            chargeGridView();
            chargeCombo();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {


            try
            {
                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                    tb_vitola size = new tb_vitola();

                    size.vitola = textBox2.Text;
                    db.tb_vitolas.InsertOnSubmit(size);
                    db.SubmitChanges();
                    chargeCombo();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Clear();
                    chargeGridView();
                    textBox2.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                    tb_liga blend = new tb_liga();

                    blend.liga = textBox1.Text;
                    db.tb_ligas.InsertOnSubmit(blend);
                    db.SubmitChanges();
                    chargeCombo();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    chargeGridView();
                    textBox1.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView2.SelectedRows;
            deleteSize(rows);
        }

        private void deleteSize(DataGridViewSelectedRowCollection listSelectSize)
        {

            try
            {
                foreach (DataGridViewRow k in listSelectSize)
                {

                    using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                    {
                        string name = k.Cells["name"].Value.ToString();
                        tb_vitola size = (from b in db.tb_vitolas
                                       where b.vitola == name
                                       select b).FirstOrDefault();

                        db.tb_vitolas.DeleteOnSubmit(size);
                        db.SubmitChanges();

                    }


                }

                MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargeGridView();
                chargeCombo();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DataGridViewCell cell = dataGridView2.CurrentCell;
            string name = cell.Value.ToString();


            GUI_UPDATE_Size gui_updateSize = new GUI_UPDATE_Size(name);
            gui_updateSize.ShowDialog();
            chargeGridView();
            chargeCombo();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView3.CurrentCell;
            string name = cell.Value.ToString();


            GUI_UPDATE_Wrapper gui_updateWrapper = new GUI_UPDATE_Wrapper(name);
            gui_updateWrapper.ShowDialog();
            chargeGridView();
            chargeCombo();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                    tb_capa wrapper = new tb_capa();

                    wrapper.capa = textBox3.Text;
                    db.tb_capas.InsertOnSubmit(wrapper);
                    db.SubmitChanges();
                    chargeCombo();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Clear();
                    chargeGridView();
                    textBox3.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView3.SelectedRows;
            deleteWrapper(rows);
        }


            private void deleteWrapper(DataGridViewSelectedRowCollection listSelectWrapper)
        {

            try
            {
                foreach (DataGridViewRow k in listSelectWrapper)
                {

                    using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                    {
                        string name = k.Cells["name"].Value.ToString();
                        tb_capa wrapper = (from b in db.tb_capas
                                     where b.capa == name
                                     select b).FirstOrDefault();

                        db.tb_capas.DeleteOnSubmit(wrapper);
                        db.SubmitChanges();

                    }


                }

                MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargeGridView();
                chargeCombo();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
            {
                try
                {
                    Tobacco tobaco = new Tobacco();
                    string name = txtNameTobacco.Text;
                    int size = int.Parse(comboSize.SelectedValue.ToString());
                    int blend = int.Parse(comboBlend.SelectedValue.ToString());
                    int wrapper = int.Parse(comboWrapper.SelectedValue.ToString());

                    tobaco.size = size;
                    tobaco.blend = blend;
                    tobaco.wrapper = wrapper;
                    tobaco.name = txtNameTobacco.Text;

                    bd.Tobaccos.InsertOnSubmit(tobaco);
                    bd.SubmitChanges();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNameTobacco.Clear();
                    txtNameTobacco.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

             
            }
        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
