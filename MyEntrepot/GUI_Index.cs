using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEntrepot
{
    public partial class GUI_Index : Form
    {
        private GUI_Product_List gui_Product_List;
        private GUI_Personal_List gui_Personal_List;
        public GUI_wait gui_wait;

        public GUI_Index()
        {
           
            InitializeComponent();
            
    }

        protected void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            gui_wait = new GUI_wait();
            gui_wait.Show();
            backgroundWorker1.RunWorkerAsync(gui_wait);
           
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {           
            gui_Product_List = new GUI_Product_List();           
            gui_Product_List.ChargeDataGridview();
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            gui_Product_List.Show();
            gui_wait.Close();            
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GUI_Index_LocationChanged(object sender, EventArgs e)
        {
           // gui_wait.Hide();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ADD_Tobacco gui_ADD_Tobacco = new GUI_ADD_Tobacco();
            gui_ADD_Tobacco.ShowDialog();
        }

        private void personalWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            gui_wait = new GUI_wait();
            gui_wait.Show();
            backgroundWorker2.RunWorkerAsync(gui_wait);

        }

        private void GUI_Index_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

             gui_Personal_List = new GUI_Personal_List();
             gui_Personal_List.ChargeDataGridview();

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gui_Personal_List.Show();
            gui_wait.Close();
        }

        private void addDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            GUI_ADD_Personal gui_ADD_Personal = new GUI_ADD_Personal();
            gui_ADD_Personal.ShowDialog();
            

        }

        private void productionDailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this.Close();
            GUI_Production_Daily gui_Production_Daily = new GUI_Production_Daily();
            gui_Production_Daily.ShowDialog();
          
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            GUI_Stock gui_stock = new GUI_Stock();
            gui_stock.ShowDialog();
        }
    }
}
