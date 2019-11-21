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
    public partial class Form4 : Form
    {
        private string gifplay = Application.StartupPath + "//Gifs//1.gif";
        public Form4()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(gifplay);

        }
    }
}
