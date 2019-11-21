using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwrd_1._0
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void StartGm_Click(object sender, EventArgs e)
        {
            int i = 0;
            containerMD frm1 = new containerMD();
            Hide();
            for (i = 0; i < 3; i++)
            {
                var buttons = panel1.Controls.OfType<RadioButton>().ElementAt(i);
                buttons.Checked = false;
            }
            frm1.ShowDialog();
            BringToFront();
            Show();           
        }

        private void exitgm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                howtopl_Click(sender, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            StartGm_Click(sender,e);
            

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Close();
        }

        private void howtopl_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
            int i = 0;
            for(;i<3;i++)
            {
                var buttons = panel1.Controls.OfType<RadioButton>().ElementAt(i);
                buttons.Checked = false;
            }

        }
    }
}
