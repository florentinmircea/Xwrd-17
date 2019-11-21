using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Xwrd_1._0
{
    public partial class containerMD : Form
    {
        public static string[] indicii = new string[21];
        public static string[] cuvinte = new string[21];
        public static string[] cuvinteb = new string[21];
        public static string[] inceput = new string[21];
        public static string[] romana = new string[21];
        public static int nrcol;
        public static bool timplus = false;
        private int nrcuvi = 0,nrcurent =0;
        public static List<id_cells> idc = new List<id_cells>();
        public static string[] puzzle_file = new string[6];
        private static int nrlvl=0;
        private string[] gifplay = new string[6];
        public containerMD()
        {
            puzzle_file[0] = Application.StartupPath + "\\fisiere\\leve1f.pzl";
            puzzle_file[1] = Application.StartupPath + "\\fisiere\\level2f.pzl";
            puzzle_file[2] = Application.StartupPath + "\\fisiere\\level3f.pzl";
            puzzle_file[3] = Application.StartupPath + "\\fisiere\\level4f.pzl";
            puzzle_file[4] = Application.StartupPath + "\\fisiere\\level5f.pzl";
            gifplay[0]=  Application.StartupPath + "//Gifs//8.gif";
            gifplay[1] = Application.StartupPath + "//Gifs//9.gif";
            gifplay[2] = Application.StartupPath + "//Gifs//10.gif";
            gifplay[3] = Application.StartupPath + "//Gifs//12.gif";
            gifplay[4] = Application.StartupPath + "//Gifs//13.gif";
            buildWordList();
            InitializeComponent();
            initializare();

    }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult rezul =MessageBox.Show("Est-ce que vous voulez voir le tutoriel d'abord?", "Voyez le tutoriel", MessageBoxButtons.YesNo);
            if(rezul== DialogResult.Yes)
            {
                Form4 frm4 = new Form4();
                frm4.ShowDialog();
                Timer t2 = new Timer { Interval = 5000 };
                t2.Tick += t2_Tick;
                t2.Start();
                timer1.Start();
                
         
            }
            else
            {
                timer1.Start();
            }

        }

        void t2_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            

        }

        public void buildWordList()
        {
            //citire din fisier cuvinte rebus
            string line = "";
            
            int i = 1; 
            using (StreamReader s = new StreamReader(puzzle_file[nrlvl],Encoding.UTF8))
            {
                while ((line = s.ReadLine()) != null)
                {
                    string[] l = line.Split(';');
                    idc.Add(new id_cells(Int32.Parse(l[0]), Int32.Parse(l[1]), l[2], l[3], l[4],l[5]));
                    indicii[i] = l[4];
                    cuvinteb[i] = l[3];
                    cuvinte[i] = criptare(l[3]);
                    inceput[i] = l[0];
                    romana[i] = l[5];
                    i++;
                    nrcuvi++;
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
            string vocale = "aeiou", consoane = "bcdfhjkmnpqrstvwxzy", b, c = "i";
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

        private void initializare()
        {
            pictureBox1.Image = Image.FromFile(gifplay[nrlvl]);
            tabla.BackgroundColor = Color.Black;
            tabla.DefaultCellStyle.BackColor = Color.Black;
            //this.tabla.GridColor = Color.Black;


            for (int i = 0; i < 21; i++)
                tabla.Rows.Add();

            //setezi coloane
            foreach (DataGridViewColumn c in tabla.Columns)
                c.Width = tabla.Width / tabla.Columns.Count;
            //setezi randuri
            foreach (DataGridViewRow r in tabla.Rows)
                r.Height = tabla.Height / tabla.Rows.Count;

            //sa nu se poata scrie in background
            for (int row = 0; row < tabla.Rows.Count; row++)
            {
                for (int col = 0; col < tabla.Columns.Count; col++)
                    tabla[col, row].ReadOnly = true;
            }
            foreach (id_cells i in idc)
            {
                int start_col = i.X;
                int start_row = i.Y;
                char[] word = i.word.ToCharArray();

                for (int j = 0; j < word.Length; j++)
                {
                        formatare(start_row, start_col + j, word[j].ToString());
                }
            }
        }
        private void formatare(int row, int col, string letter)
        {
            DataGridViewCell c = tabla[col, row];
            if (col == 9)
                c.Style.BackColor = Color.Red;
            else
                c.Style.BackColor = Color.White;
            c.ReadOnly = false;
            c.Style.SelectionBackColor = Color.Cyan;
        }

    private void butonhelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cliquez sur une des lignes horizontales blanches de la grille pour faire apparaître une petite fenêtre avec une phrase et un éspace déstiné à l’écriture. L’objectif est de deviner le mot que la phrase manque et puis lui introduire en cliquant OK ou bien Enter.");
        }

        private void tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = tabla[e.ColumnIndex, e.RowIndex];
            if (cell.ReadOnly== false)
            {
                nrcol = e.RowIndex;
                copilMDI copil = new copilMDI(this);
                copil.ShowDialog(this);
                if (copilMDI.inchis == true)
                {
                    scrie_celule(cuvinte[nrcol - 2]);
                    copilMDI.inchis = false;
                }
                if (nrcurent == nrcuvi)
                {
                   
                    if (nrlvl == 4)
                    {
                        MessageBox.Show("Vous avez gagné");
                        Timer t1 = new Timer { Interval = 5000 };
                        t1.Tick += t1_Tick;
                        t1.Start();
                        tabla.Hide();
                        nrlvl = 0;
                    }
                    else
                    {
                        MessageBox.Show("Bravo");
                        Timer t = new Timer { Interval = 5000 };
                        t.Tick += t_Tick;
                        t.Start();
                        tabla.Hide();
                    }
                }
                
            }
        }

        void t1_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            tabla.Show();
            idc.Clear();

        }

        void t_Tick(object sender, EventArgs e)
        {
            nrlvl++;
            tabla.Rows.Clear();
            idc.Clear();

            buildWordList();
            initializare();
            ((Timer)sender).Stop();
            tabla.Show();
            timer1.Start();
            
        }

        public void scrie_celule(string cuv)
        {
            int j = 0, col = 0, rand = nrcol;
            foreach (char c in cuv)
            {

                col = Convert.ToInt32(inceput[nrcol - 2]) + j;
                if(tabla.Rows[nrcol].Cells[col].ReadOnly == true)
                {
                    tabla.Rows[nrcol].Cells[9].Style.BackColor = Color.Red;
                    tabla.Rows[nrcol].Cells[col].Style.BackColor = Color.White;
                    tabla.Rows[nrcol].Cells[col].ReadOnly = false;
                    tabla.Rows[nrcol].Cells[col].Style.SelectionBackColor = Color.Cyan;
                }
                tabla.Rows[nrcol].Cells[col].Value = c;
                tabla.Rows[nrcol].Cells[col].ReadOnly = true;
                j++;
            }
            nrcurent++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nrcurent == nrcuvi)
                timer1.Stop();
            int secundeint = Convert.ToInt32(secunde.Text);
            if (secundeint < 59)
            {
                secunde.Text = Convert.ToString(secundeint + 1);
            }
            else if (secundeint == 60)
            {
                secunde.Text = "0";
                int minuteint = Convert.ToInt32(minute.Text);
                if (minuteint < 59)
                {
                    minute.Text = Convert.ToString(minuteint + 1);
                }
            }
            else
            {
                int s;
                s = secundeint - 59;
                secunde.Text = Convert.ToString(s);
                int minuteint = Convert.ToInt32(minute.Text);
                minute.Text = Convert.ToString(minuteint + 1);
            }
            if (timplus == true)
            {
                TimeSpan t = TimeSpan.FromSeconds(secundeint + 20);
                secunde.Text = t.ToString("ss");
                int minuteint = Convert.ToInt32(minute.Text);
                string a = t.ToString("mm");
                minute.Text = Convert.ToString(minuteint + Int32.Parse(a));

                timplus = false;
            }
        }
    }

    public class id_cells
    {
        public int X;
        public int Y;
        public string number;
        public string word;
        public string clue;
        public string cluero;

        public id_cells(int x, int y, string n, string w, string c,string v)
        {
            this.X = x;
            this.Y = y;
            this.number = n;
            this.word = w;
            this.clue = c;
        }

    }
}
