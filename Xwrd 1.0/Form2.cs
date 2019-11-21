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
    public partial class copilMDI : Form
    {
        public static bool inchis=false;
        public int i = 0;
        public copilMDI(containerMD parinte)
        {
            InitializeComponent();
            ControlBox = false;
            this.ActiveControl=txtinput;
            btnro.Hide();
            butrasp.Hide();
        }

        public void copilMDI_Load(object sender, EventArgs e)
        {
            txtboxraspuns.Font = new Font("Arial", 11, FontStyle.Bold);
            txtboxraspuns.Text = containerMD.indicii[containerMD.nrcol-2];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string cuv;
            cuv = this.txtinput.Text;
            if (!string.IsNullOrWhiteSpace(txtinput.Text))
            {
                string t = criptare(cuv);
            if (t == containerMD.cuvinte[containerMD.nrcol - 2] || t.ToLower() == containerMD.cuvinte[containerMD.nrcol - 2])
            {
                this.Close();
                inchis = true;
            }
            else
            {
                MessageBox.Show("Mauvaise réponse");
                this.txtinput.Text = "";
                this.ActiveControl = txtinput;
                i++;
                if (i == 2)
                
                    btnro.Show();
                if (i == 4)
                    butrasp.Show();
                
            }
            }

        }

        internal static string StrChr(string stringToSearch, char charToFind)
        {
            int index = stringToSearch.IndexOf(charToFind);
            if (index > -1)
                return stringToSearch.Substring(index);
            else
                return null;
        }

        internal static string ChangeCharacter(string sourceString, int charIndex, char changeChar)
        {
            return (charIndex > 0 ? sourceString.Substring(0, charIndex) : "")
                + changeChar.ToString() + (charIndex < sourceString.Length - 1 ? sourceString.Substring(charIndex + 1) : "");
        }

        public string criptare(string a)
        {
            string vocale = "aeiouAEIOU", consoane = "BCDEFGHJKLMNPQRSTVWXYZbcdfhjkmnpqrstvwxzy", b, c = "i";
            int i;
            bool flag = true;
            if (StrChr(consoane, a[0]) != null)
            {
                char litera = a[0];
                b = a;
                b += litera;
                b = 'l' + b.Remove(0, 1);
                b += c;
                flag = false;
                return b;
            }
            if (a[0] == 'l' || a[0] == 'L')
            {
                for (i = 1; i < a.Length; i++)
                {
                    if (StrChr(consoane, a[i]) != null)
                    {
                        char litera = a[i];
                        b = a;
                        b = ChangeCharacter(b, i, 'l');
                        b = b + litera + c;
                        flag = false;
                        return b;
                    }
                    else
                    {
                        ;
                    }
                }
            }
            if (StrChr(vocale, a[0]) != null)
            {
                for (i = 1; i < a.Length; i++)
                {
                    if (StrChr(consoane, a[i]) != null)
                    {
                        char litera = a[i];
                        b = a;
                        b += litera;
                        b += c;
                        b = ChangeCharacter(b, i, 'l');
                        flag = false;
                        b = ' ' + b;
                        b = 'l' + b.Remove(0, 1);
                        return b;
                    }
                    else
                    {
                        ;
                    }
                }
            }
            if (flag == true)
            {
                b = a;
                b = ' ' + a;
                b = 'l' + b.Remove(0, 1);
                return b;
            }
            return null;
        }


        private void btnCnc_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void butrasp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bonne réponse: " + containerMD.cuvinteb[containerMD.nrcol - 2]);
            inchis = true;
            containerMD.timplus = true;
            Close();
        }

        private void btnro_Click(object sender, EventArgs e)
        {
            txtboxraspuns.Text = containerMD.romana[containerMD.nrcol - 2];
        }

        private void txtinput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }
    }
}
