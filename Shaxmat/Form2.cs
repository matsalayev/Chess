using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shaxmat
{
    public partial class Form2 : Form
    {
        Bitmap r2 = new Bitmap("qruh.png");
        Bitmap o2 = new Bitmap("qot.png");
        Bitmap f2 = new Bitmap("qfil.png");
        Bitmap v2 = new Bitmap("qfarzin.png");
        Bitmap r1 = new Bitmap("ruh.png");
        Bitmap o1 = new Bitmap("ot.png");
        Bitmap f1 = new Bitmap("fil.png");
        Bitmap v1 = new Bitmap("farzin.png");
        public Form2()
        {
            InitializeComponent();
            if (Class1.piyoda == 1)
            {
                button1.Image = (Image)v1;
                button2.Image = (Image)f1;
                button3.Image = (Image)o1;
                button4.Image = (Image)r1;
            }
            if (Class1.piyoda == 2)
            {
                button1.Image = (Image)v2;
                button2.Image = (Image)f2;
                button3.Image = (Image)o2;
                button4.Image = (Image)r2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.kim = "v";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.kim = "f";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.kim = "o";
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.kim = "r";
            this.Close();
        }
    }
}
