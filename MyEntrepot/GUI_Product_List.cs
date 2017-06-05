using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MyEntrepot
{
    public partial class GUI_Product_List :  Form
    {
       
       
        public GUI_Product_List()
        {           
            InitializeComponent();   
                   
         }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Index guiIndex = new GUI_Index();
            guiIndex.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ADD_Tobacco gui_ADD_Tobacco= new GUI_ADD_Tobacco();
            gui_ADD_Tobacco.ShowDialog();
        }

        public void ChargeDataGridview()
        {
            try
            {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {
                    var listTobaco = from t in bd.View_TobaccoCatalogs
                                     select t;

                    gridView_ListTabaco.DataSource = listTobaco.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" "+ex.StackTrace);
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChargeDataGridview();
        }

        private void gridView_ListTabaco_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //
                DataGridViewSelectedRowCollection rows = gridView_ListTabaco.SelectedRows;

                foreach (DataGridViewRow row in rows)
                {

                   

                    string nameTobacco = row.Cells["name"].Value.ToString();

                    using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                    {


                        Tobacco tobacco = (from t in db.Tobaccos
                                           where String.Equals(t.name,nameTobacco)
                                           select t).FirstOrDefault();

                        db.Tobaccos.DeleteOnSubmit(tobacco);
                        db.SubmitChanges();
                    }

                }

                ChargeDataGridview();
                MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GUI_Product_List_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChargeDataGridview();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI_Personal_List gui_Personal_List = new GUI_Personal_List();
            gui_Personal_List.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            GUI_Index gui_index = new GUI_Index();
            gui_index.Show();
        }
    }
}
