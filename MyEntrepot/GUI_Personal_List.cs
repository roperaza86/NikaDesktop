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
    public partial class GUI_Personal_List : Form
    {
        enum enumPosition { Rolero = 0, Bonchero = 1, Office = 2 };

        public GUI_Personal_List()
        {
            InitializeComponent();
        }

        private void personalWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GUI_Personal_List_Load(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Index guiIndex = new GUI_Index();
            guiIndex.Show();
        }


        public void ChargeDataGridview()
        {
            try
            {
                using (EntrepotBDDataContext bd = new EntrepotBDDataContext())
                {
                    var listPersonal = from p in bd.View_Personals
                                       select p;
                    gridView_ListPersonal.DataSource = listPersonal.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection rows = gridView_ListPersonal.SelectedRows;

                foreach (DataGridViewRow row in rows)
                {

                    string name = row.Cells["name"].Value.ToString();

                    using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                    {

                        Personal personal = (from p in db.Personals
                                             where p.name == name
                                             select p).FirstOrDefault();

                        db.Personals.DeleteOnSubmit(personal);
                        db.SubmitChanges();
                    }

                }
                ChargeDataGridview();
                MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = gridView_ListPersonal.SelectedRows;
            string name = "No select";
            string position = "No select";
            int nPosition=-1;

    
           

            foreach (DataGridViewRow row in rows)
            {

                name = row.Cells["name"].Value.ToString();
                position = row.Cells["position"].Value.ToString();
               
            }
            //// Rolero = 0, Bonchero = 1, Office = 2
            switch (position)
            {
                case "Rolero": nPosition =(int) enumPosition.Rolero;
                    break;
                case "Bonchero":
                    nPosition = (int)enumPosition.Bonchero;
                    break;
                case "Office":
                    nPosition = (int)enumPosition.Office;
                    break;


            }

            GUI_UPDATE_Personal gu_UPDATE_Personal = new GUI_UPDATE_Personal(name, nPosition);
            gu_UPDATE_Personal.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChargeDataGridview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            GUI_Index gui_index = new GUI_Index();
            gui_index.Show();
        }

        private void gridView_ListPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
