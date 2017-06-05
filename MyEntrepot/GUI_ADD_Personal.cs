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
    public partial class GUI_ADD_Personal : Form
    {
        public GUI_ADD_Personal()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (EntrepotBDDataContext db = new EntrepotBDDataContext())
                {
                    Personal personal = new Personal();
                    personal.name = textBox2.Text;
                    personal.position = comboBox1.SelectedItem.ToString();

                    db.Personals.InsertOnSubmit(personal);
                    db.SubmitChanges();
                    MessageBox.Show("success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GUI_ADD_Personal_Load(object sender, EventArgs e)
        {

        }
    }
}
