using System.Runtime.InteropServices;

namespace Shaxmat
{
    public partial class Form1 : Form
    {
        string[,] xarita = new string[8, 8];
        Button[,] katak = new Button[8, 8];
        Bitmap r2 = new Bitmap("qruh.png");
        Bitmap o2 = new Bitmap("qot.png");
        Bitmap f2 = new Bitmap("qfil.png");
        Bitmap v2 = new Bitmap("qfarzin.png");
        Bitmap q2 = new Bitmap("qqirol.png");
        Bitmap p2 = new Bitmap("qpiyoda.png");
        Bitmap r1 = new Bitmap("ruh.png");
        Bitmap o1 = new Bitmap("ot.png");
        Bitmap f1 = new Bitmap("fil.png");
        Bitmap v1 = new Bitmap("farzin.png");
        Bitmap q1 = new Bitmap("qirol.png");
        Bitmap p1 = new Bitmap("piyoda.png");
        int navbat = 1;
        public Form1()
        {
            InitializeComponent();
            yaratishX();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        void yaratishX()
        {
            xarita = new string[8, 8]
            {
                {"r2","o2","f2","v2","q2","f2","o2","r2"},
                {"p2","p2","p2","p2","p2","p2","p2","p2"},
                {"","","","","","","","", },
                {"","","","","","","","", },
                {"","","","","","","","", },
                {"","","","","","","","", },
                {"p1","p1","p1","p1","p1","p1","p1","p1"},
                {"r1","o1","f1","v1","q1","f1","o1","r1"}
            };
            yaratishK();
        }
        void yaratishK()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    katak[i, j] = new Button();
                    katak[i, j].FlatStyle = FlatStyle.Flat;
                    katak[i, j].Size = new Size(80, 80);
                    katak[i, j].Location = new Point(j * 80, i * 80);
                    katak[i, j].Font = new Font("Segue UI", 9);
                    katak[i, j].BackgroundImageLayout = ImageLayout.Center;
                    katak[i, j].Name = i + "" + j;
                    katak[i, j].ForeColor = Color.Red;
                    if (xarita[i, j] == "r2") katak[i, j].Image = (Image)r2;
                    if (xarita[i, j] == "o2") katak[i, j].Image = (Image)o2;
                    if (xarita[i, j] == "f2") katak[i, j].Image = (Image)f2;
                    if (xarita[i, j] == "v2") katak[i, j].Image = (Image)v2;
                    if (xarita[i, j] == "q2") katak[i, j].Image = (Image)q2;
                    if (xarita[i, j] == "p2") katak[i, j].Image = (Image)p2;
                    if (xarita[i, j] == "r1") katak[i, j].Image = (Image)r1;
                    if (xarita[i, j] == "o1") katak[i, j].Image = (Image)o1;
                    if (xarita[i, j] == "f1") katak[i, j].Image = (Image)f1;
                    if (xarita[i, j] == "v1") katak[i, j].Image = (Image)v1;
                    if (xarita[i, j] == "q1") katak[i, j].Image = (Image)q1;
                    if (xarita[i, j] == "p1") katak[i, j].Image = (Image)p1;
                    katak[i, j].Click += new EventHandler(Click);
                    panel2.Controls.Add(katak[i, j]);
                }
            }
            fon();
        }
        int x = 0, y = 0, a = 0, b = 0;
        private void Click(object sender, EventArgs e)
        {
            Button bosilgan = (Button)sender;
            x = int.Parse(bosilgan.Name[0].ToString());
            y = int.Parse(bosilgan.Name[1].ToString());
            if ((xarita[x, y] != "" && katak[x, y].FlatAppearance.BorderSize == 0 && !xavf))
            {
                string d = xarita[x, y];
                xarita[x, y] = "";
                shox();
                if (!xavf)
                {
                    xarita[x, y] = d;
                    fon();
                    a = x; b = y;
                    if (navbat == 1 && (xarita[x, y] == "p1" || xarita[x, y] == "o1" || xarita[x, y] == "r1" || xarita[x, y] == "f1" || xarita[x, y] == "v1" || xarita[x, y] == "q1"))
                    {
                        bosilgan.FlatAppearance.BorderSize = 3;
                        bosilgan.FlatAppearance.BorderColor = Color.Green;
                    }

                    if (navbat == 2 && (xarita[x, y] == "p2" || xarita[x, y] == "o2" || xarita[x, y] == "r2" || xarita[x, y] == "f2" || xarita[x, y] == "v2" || xarita[x, y] == "q2"))
                    {
                        bosilgan.FlatAppearance.BorderSize = 3;
                        bosilgan.FlatAppearance.BorderColor = Color.Green;
                    }
                    if (xarita[x, y] == "p1" || xarita[x, y] == "p2") piyoda(x, y);
                    if (xarita[x, y] == "o1" || xarita[x, y] == "o2") ot(x, y);
                    if (xarita[x, y] == "r1" || xarita[x, y] == "r2") ruh(x, y);
                    if (xarita[x, y] == "f1" || xarita[x, y] == "f2") fil(x, y);
                    if (xarita[x, y] == "v1" || xarita[x, y] == "v2") farzin(x, y);
                    if (xarita[x, y] == "q1" || xarita[x, y] == "q2") qirol(x, y);
                }
                else
                {
                    xavf = false;
                    xarita[x, y] = d;
                }
            }
            if (xarita[x, y] == "" && katak[x, y].Text == "⚫")
            {
                katak[x, y].Image = katak[a, b].Image;
                katak[a, b].Image = null;
                string d = xarita[x, y];
                xarita[x, y] = xarita[a, b];
                xarita[a, b] = d;
                xavf = false;
                dama(x, y);
                fon();
                almashtirish();
                shox();
            }
            if (katak[x, y].FlatAppearance.BorderColor == Color.Red)
            {
               
                    katak[x, y].Image = katak[a, b].Image;
                    xarita[x, y] = xarita[a, b];
                    katak[a, b].Image = null;
                    if (a == p && b == q) xavf = false;
                    xarita[a, b] = "";
                    dama(x, y);
                    fon();
                    almashtirish();
                    shox();
                          
            }
            if (xavf)
            {
                almashtirish();
                fon();
                if (xarita[p, q] == "r1" || xarita[p, q] == "r2") ruh(p, q);
                if (xarita[p, q] == "f1" || xarita[p, q] == "f2") fil(p, q);
                if (xarita[p, q] == "v1" || xarita[p, q] == "v2") farzin(p, q);
                int[,] bosh = new int[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (katak[i, j].Text == "⚫")
                        {
                            bosh[i, j] = 1;
                        }
                    }
                }
                fon();
                almashtirish();



                if (xarita[x, y] == "p1" || xarita[x, y] == "p2") piyoda(x, y);
                if (xarita[x, y] == "o1" || xarita[x, y] == "o2") ot(x, y);
                if (xarita[x, y] == "r1" || xarita[x, y] == "r2") ruh(x, y);
                if (xarita[x, y] == "f1" || xarita[x, y] == "f2") fil(x, y);
                if (xarita[x, y] == "v1" || xarita[x, y] == "v2") farzin(x, y);
                bool l = false;
                int c = 0; int v = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (bosh[i, j] == 1 && katak[i, j].Text == "⚫")
                        {
                            if ((i > p && i < m && j > n && j < q)
                                || (i > p && i < m && j > q && j < n)
                                || (i > m && i < p && j > q && j < n)
                                || (i > m && i < p && j > n && j < q))
                                l = true; c = i; v = j;
                        }
                    }
                }
                if (katak[p, q].FlatAppearance.BorderColor == Color.Red)
                {
                    fon();
                    bosilgan.FlatAppearance.BorderSize = 3;
                    bosilgan.FlatAppearance.BorderColor = Color.Green;
                    katak[p, q].FlatAppearance.BorderSize = 3;
                    katak[p, q].FlatAppearance.BorderColor = Color.Red;
                    a = x; b = y;
                }
                else if (l)
                {
                    fon();
                    bosilgan.FlatAppearance.BorderSize = 3;
                    bosilgan.FlatAppearance.BorderColor = Color.Green;
                    katak[c, v].Text = "⚫";
                    a = x; b = y;
                }
                else fon();
            }
            if ((xarita[x, y] == "q1" && xavf) || (xarita[x, y] == "q2" && xavf))
            {
                fon();
                bosilgan.FlatAppearance.BorderSize = 3;
                bosilgan.FlatAppearance.BorderColor = Color.Green;
                a = x; b = y;
                qirol(x, y);
                if (xarita[p, q] == "v2" || xarita[p, q] == "v1")
                {
                    try
                    {
                        if ((p == x && q < y) && katak[x, y + 1].Text == "⚫") katak[x, y + 1].Text = "";
                        if ((p == x && q > y) && katak[x, y - 1].Text == "⚫") katak[x, y - 1].Text = "";
                        if ((p < x && q == y) && katak[x + 1, y].Text == "⚫") katak[x + 1, y].Text = "";
                        if ((p > x && q == y) && katak[x - 1, y].Text == "⚫") katak[x - 1, y].Text = "";
                        if ((p < x && q < y) && katak[x + 1, y + 1].Text == "⚫") katak[x + 1, y + 1].Text = "";
                        if ((p < x && q > y) && katak[x + 1, y - 1].Text == "⚫") katak[x + 1, y - 1].Text = "";
                        if ((p > x && q > y) && katak[x - 1, y - 1].Text == "⚫") katak[x - 1, y - 1].Text = "";
                        if ((p > x && q < y) && katak[x - 1, y + 1].Text == "⚫") katak[x - 1, y + 1].Text = "";
                    }
                    catch { }
                }
                if (xarita[p, q] == "r2" || xarita[p, q] == "r1")
                {
                    if ((p == x && q < y) && katak[x, y + 1].Text == "⚫") katak[x, y + 1].Text = "";
                    if ((p == x && q > y) && katak[x, y - 1].Text == "⚫") katak[x, y - 1].Text = "";
                    if ((p < x && q == y) && katak[x + 1, y].Text == "⚫") katak[x + 1, y].Text = "";
                    if ((p > x && q == y) && katak[x - 1, y].Text == "⚫") katak[x - 1, y].Text = "";
                }
                if (xarita[p, q] == "f2" || xarita[p, q] == "f1")
                {
                    if ((p < x && q < y) && katak[x + 1, y + 1].Text == "⚫") katak[x + 1, y + 1].Text = "";
                    if ((p < x && q > y) && katak[x + 1, y - 1].Text == "⚫") katak[x + 1, y - 1].Text = "";
                    if ((p > x && q > y) && katak[x - 1, y - 1].Text == "⚫") katak[x - 1, y - 1].Text = "";
                    if ((p > x && q < y) && katak[x - 1, y + 1].Text == "⚫") katak[x - 1, y + 1].Text = "";

                }
            }
        }
        bool xavf = false;
        int m = 0, n = 0;
        int p = 0, q = 0;
        void shox()
        {
            if (navbat == 1)
            {
                navbat = 2;
                bool aniq = false;
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (xarita[a, b] == "q1")
                        {
                            m = a; n = b;
                        }
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (xarita[i, j] == "p2") piyoda(i, j);
                        if (xarita[i, j] == "o2") ot(i, j);
                        if (xarita[i, j] == "r2") ruh(i, j);
                        if (xarita[i, j] == "f2") fil(i, j);
                        if (xarita[i, j] == "v2") farzin(i, j);
                        if (katak[m, n].FlatAppearance.BorderColor == Color.Red && !aniq)
                        {
                            xavf = true;
                            aniq = true;
                            p = i; q = j;
                        }
                        else if (!aniq) xavf = false;
                    }
                }
                navbat = 1;
            }
            if (navbat == 2)
            {
                navbat = 1;
                bool aniq = false;
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (xarita[a, b] == "q2")
                        {
                            m = a; n = b;
                        }
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (xarita[i, j] == "p1") piyoda(i, j);
                        if (xarita[i, j] == "o1") ot(i, j);
                        if (xarita[i, j] == "r1") ruh(i, j);
                        if (xarita[i, j] == "f1") fil(i, j);
                        if (xarita[i, j] == "v1") farzin(i, j);
                        if (katak[m, n].FlatAppearance.BorderColor == Color.Red && !aniq)
                        {
                            xavf = true;
                            aniq = true;
                            p = i; q = j;
                        }
                        else if (!aniq) xavf = false;
                    }
                }
                navbat = 2;
            }
            fon();
        }
        void dama(int x, int y)
        {
            if (xarita[x, y] == "p1" && x == 0)
            {
                Class1.piyoda = 1;
                Form2 obj = new Form2();
                obj.ShowDialog();
                if (Class1.kim == "v")
                {
                    xarita[x, y] = "v1";
                    katak[x, y].Image = (Image)v1;
                }
                if (Class1.kim == "f")
                {
                    xarita[x, y] = "f1";
                    katak[x, y].Image = (Image)f1;
                }
                if (Class1.kim == "o")
                {
                    xarita[x, y] = "o1";
                    katak[x, y].Image = (Image)o1;
                }
                if (Class1.kim == "r")
                {
                    xarita[x, y] = "r1";
                    katak[x, y].Image = (Image)r1;
                }
            }
            if (xarita[x, y] == "p2" && x == 7)
            {
                Class1.piyoda = 2;
                Form2 obj = new Form2();
                obj.ShowDialog();
                if (Class1.kim == "v")
                {
                    xarita[x, y] = "v2";
                    katak[x, y].Image = (Image)v2;
                }
                if (Class1.kim == "f")
                {
                    xarita[x, y] = "f2";
                    katak[x, y].Image = (Image)f2;
                }
                if (Class1.kim == "o")
                {
                    xarita[x, y] = "o2";
                    katak[x, y].Image = (Image)o2;
                }
                if (Class1.kim == "r")
                {
                    xarita[x, y] = "r2";
                    katak[x, y].Image = (Image)r2;
                }
            }
        }
        void almashtirish()
        {
            navbat = (navbat == 1) ? navbat = 2 : 1;
        }
        void piyoda(int x, int y)
        {
            if (navbat == 1 && katak[x, y].Image == (Image)p1)
            {
                bool t = true;
                try
                {
                    if (katak[x - 1, y].Image == null) katak[x - 1, y].Text = "⚫";
                    if (katak[x - 1, y].Image != null) t = false;
                }
                catch { }
                try
                {
                    if (katak[x - 2, y].Image == null && t)
                    {
                        if (x == 6)
                            katak[x - 2, y].Text = "⚫";
                    }
                }
                catch { }
                try
                {
                    if ((katak[x - 1, y - 1].Image == (Image)p2 || katak[x - 1, y - 1].Image == (Image)o2 || katak[x - 1, y - 1].Image == (Image)f2 || katak[x - 1, y - 1].Image == (Image)r2 || katak[x - 1, y - 1].Image == (Image)v2 || katak[x - 1, y - 1].Image == (Image)q2) && xarita[x - 1, y - 1] != "")
                    {
                        katak[x - 1, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if ((katak[x - 1, y + 1].Image == (Image)p2 || katak[x - 1, y + 1].Image == (Image)o2 || katak[x - 1, y + 1].Image == (Image)f2 || katak[x - 1, y + 1].Image == (Image)r2 || katak[x - 1, y + 1].Image == (Image)v2 || katak[x - 1, y + 1].Image == (Image)q2) && xarita[x - 1, y + 1] != "")
                    {
                        katak[x - 1, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
            }
            if (navbat == 2 && katak[x, y].Image == (Image)p2)
            {
                bool t = true;
                try
                {
                    if (katak[x + 1, y].Image == null) katak[x + 1, y].Text = "⚫";
                    if (katak[x + 1, y].Image != null) t = false;
                }
                catch { }
                try
                {
                    if (katak[x + 2, y].Image == null && t)
                    {
                        if (x == 1) katak[x + 2, y].Text = "⚫";
                    }
                }
                catch { }
                try
                {
                    if ((katak[x + 1, y - 1].Image == (Image)p1 || katak[x + 1, y - 1].Image == (Image)o1 || katak[x + 1, y - 1].Image == (Image)f1 || katak[x + 1, y - 1].Image == (Image)r1 || katak[x + 1, y - 1].Image == (Image)v1 || katak[x + 1, y - 1].Image == (Image)q1) && xarita[x + 1, y - 1] != "")
                    {
                        katak[x + 1, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if ((katak[x + 1, y + 1].Image == (Image)p1 || katak[x + 1, y + 1].Image == (Image)o1 || katak[x + 1, y + 1].Image == (Image)f1 || katak[x + 1, y + 1].Image == (Image)r1 || katak[x + 1, y + 1].Image == (Image)v1 || katak[x + 1, y + 1].Image == (Image)q1) && xarita[x + 1, y + 1] != "")
                    {
                        katak[x + 1, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
            }
        }
        void ot(int i, int j)
        {
            if (navbat == 1 && katak[i, j].Image == (Image)o1)
            {
                try
                {
                    if (katak[i - 2, j + 1].Image == null) katak[i - 2, j + 1].Text = "⚫";
                    if ((katak[i - 2, j + 1].Image == (Image)p2 || katak[i - 2, j + 1].Image == (Image)o2 || katak[i - 2, j + 1].Image == (Image)f2 || katak[i - 2, j + 1].Image == (Image)r2 || katak[i - 2, j + 1].Image == (Image)v2 || katak[i - 2, j + 1].Image == (Image)q2) && xarita[i - 2, j + 1] != "")
                    {
                        katak[i - 2, j + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 2, j + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i - 2, j - 1].Image == null) katak[i - 2, j - 1].Text = "⚫";
                    if ((katak[i - 2, j - 1].Image == (Image)p2 || katak[i - 2, j - 1].Image == (Image)o2 || katak[i - 2, j - 1].Image == (Image)f2 || katak[i - 2, j - 1].Image == (Image)r2 || katak[i - 2, j - 1].Image == (Image)v2 || katak[i - 2, j - 1].Image == (Image)q2) && xarita[i - 2, j - 1] != "")
                    {
                        katak[i - 2, j - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 2, j - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 2, j - 1].Image == null) katak[i + 2, j - 1].Text = "⚫";
                    if ((katak[i + 2, j - 1].Image == (Image)p2 || katak[i + 2, j - 1].Image == (Image)o2 || katak[i + 2, j - 1].Image == (Image)f2 || katak[i + 2, j - 1].Image == (Image)r2 || katak[i + 2, j - 1].Image == (Image)v2 || katak[i + 2, j - 1].Image == (Image)q2) && xarita[i + 2, j - 1] != "")
                    {
                        katak[i + 2, j - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 2, j - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 2, j + 1].Image == null) katak[i + 2, j + 1].Text = "⚫";
                    if ((katak[i + 2, j + 1].Image == (Image)p2 || katak[i + 2, j + 1].Image == (Image)o2 || katak[i + 2, j + 1].Image == (Image)f2 || katak[i + 2, j + 1].Image == (Image)r2 || katak[i + 2, j + 1].Image == (Image)v2 || katak[i + 2, j + 1].Image == (Image)q2) && xarita[i + 2, j + 1] != "")
                    {
                        katak[i + 2, j + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 2, j + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i - 1, j + 2].Image == null) katak[i - 1, j + 2].Text = "⚫";
                    if ((katak[i - 1, j + 2].Image == (Image)p2 || katak[i - 1, j + 2].Image == (Image)o2 || katak[i - 1, j + 2].Image == (Image)f2 || katak[i - 1, j + 2].Image == (Image)r2 || katak[i - 1, j + 2].Image == (Image)v2 || katak[i - 1, j + 2].Image == (Image)q2) && xarita[i - 1, j + 2] != "")
                    {
                        katak[i - 1, j + 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 1, j + 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i - 1, j - 2].Image == null) katak[i - 1, j - 2].Text = "⚫";
                    if ((katak[i - 1, j - 2].Image == (Image)p2 || katak[i - 1, j - 2].Image == (Image)o2 || katak[i - 1, j - 2].Image == (Image)f2 || katak[i - 1, j - 2].Image == (Image)r2 || katak[i - 1, j - 2].Image == (Image)v2 || katak[i - 1, j - 2].Image == (Image)q2) && xarita[i - 1, j - 2] != "")
                    {
                        katak[i - 1, j - 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 1, j - 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 1, j - 2].Image == null) katak[i + 1, j - 2].Text = "⚫";
                    if ((katak[i + 1, j - 2].Image == (Image)p2 || katak[i + 1, j - 2].Image == (Image)o2 || katak[i + 1, j - 2].Image == (Image)f2 || katak[i + 1, j - 2].Image == (Image)r2 || katak[i + 1, j - 2].Image == (Image)v2 || katak[i + 1, j - 2].Image == (Image)q2) && xarita[i + 1, j - 2] != "")
                    {
                        katak[i + 1, j - 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 1, j - 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 1, j + 2].Image == null) katak[i + 1, j + 2].Text = "⚫";
                    if ((katak[i + 1, j + 2].Image == (Image)p2 || katak[i + 1, j + 2].Image == (Image)o2 || katak[i + 1, j + 2].Image == (Image)f2 || katak[i + 1, j + 2].Image == (Image)r2 || katak[i + 1, j + 2].Image == (Image)v2 || katak[i + 1, j + 2].Image == (Image)q2) && xarita[i + 1, j + 2] != "")
                    {
                        katak[i + 1, j + 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 1, j + 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
            }
            if (navbat == 2 && katak[i, j].Image == (Image)o2)
            {
                try
                {

                    if (katak[i - 2, j + 1].Image == null) katak[i - 2, j + 1].Text = "⚫";
                    if ((katak[i - 2, j + 1].Image == (Image)p1 || katak[i - 2, j + 1].Image == (Image)o1 || katak[i - 2, j + 1].Image == (Image)f1 || katak[i - 2, j + 1].Image == (Image)r1 || katak[i - 2, j + 1].Image == (Image)v1 || katak[i - 2, j + 1].Image == (Image)q1) && xarita[i - 2, j + 1] != "")
                    {
                        katak[i - 2, j + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 2, j + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i - 2, j - 1].Image == null) katak[i - 2, j - 1].Text = "⚫";
                    if ((katak[i - 2, j - 1].Image == (Image)p1 || katak[i - 2, j - 1].Image == (Image)o1 || katak[i - 2, j - 1].Image == (Image)f1 || katak[i - 2, j - 1].Image == (Image)r1 || katak[i - 2, j - 1].Image == (Image)v1 || katak[i - 2, j - 1].Image == (Image)q1) && xarita[i - 2, j - 1] != "")
                    {
                        katak[i - 2, j - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 2, j - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 2, j - 1].Image == null) katak[i + 2, j - 1].Text = "⚫";
                    if ((katak[i + 2, j - 1].Image == (Image)p1 || katak[i + 2, j - 1].Image == (Image)o1 || katak[i + 2, j - 1].Image == (Image)f1 || katak[i + 2, j - 1].Image == (Image)r1 || katak[i + 2, j - 1].Image == (Image)v1 || katak[i + 2, j - 1].Image == (Image)q1) && xarita[i + 2, j - 1] != "")
                    {
                        katak[i + 2, j - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 2, j - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 2, j + 1].Image == null) katak[i + 2, j + 1].Text = "⚫";
                    if ((katak[i + 2, j + 1].Image == (Image)p1 || katak[i + 2, j + 1].Image == (Image)o1 || katak[i + 2, j + 1].Image == (Image)f1 || katak[i + 2, j + 1].Image == (Image)r1 || katak[i + 2, j + 1].Image == (Image)v1 || katak[i + 2, j + 1].Image == (Image)q1) && xarita[i + 2, j + 1] != "")
                    {
                        katak[i + 2, j + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 2, j + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i - 1, j + 2].Image == null) katak[i - 1, j + 2].Text = "⚫";
                    if ((katak[i - 1, j + 2].Image == (Image)p1 || katak[i - 1, j + 2].Image == (Image)o1 || katak[i - 1, j + 2].Image == (Image)f1 || katak[i - 1, j + 2].Image == (Image)r1 || katak[i - 1, j + 2].Image == (Image)v1 || katak[i - 1, j + 2].Image == (Image)q1) && xarita[i - 1, j + 2] != "")
                    {
                        katak[i - 1, j + 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 1, j + 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i - 1, j - 2].Image == null) katak[i - 1, j - 2].Text = "⚫";
                    if ((katak[i - 1, j - 2].Image == (Image)p1 || katak[i - 1, j - 2].Image == (Image)o1 || katak[i - 1, j - 2].Image == (Image)f1 || katak[i - 1, j - 2].Image == (Image)r1 || katak[i - 1, j - 2].Image == (Image)v1 || katak[i - 1, j - 2].Image == (Image)q1) && xarita[i - 1, j - 2] != "")
                    {
                        katak[i - 1, j - 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i - 1, j - 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 1, j - 2].Image == null) katak[i + 1, j - 2].Text = "⚫";
                    if ((katak[i + 1, j - 2].Image == (Image)p1 || katak[i + 1, j - 2].Image == (Image)o1 || katak[i + 1, j - 2].Image == (Image)f1 || katak[i + 1, j - 2].Image == (Image)r1 || katak[i + 1, j - 2].Image == (Image)v1 || katak[i + 1, j - 2].Image == (Image)q1) && xarita[i + 1, j - 2] != "")
                    {
                        katak[i + 1, j - 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 1, j - 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[i + 1, j + 2].Image == null) katak[i + 1, j + 2].Text = "⚫";
                    if ((katak[i + 1, j + 2].Image == (Image)p1 || katak[i + 1, j + 2].Image == (Image)o1 || katak[i + 1, j + 2].Image == (Image)f1 || katak[i + 1, j + 2].Image == (Image)r1 || katak[i + 1, j + 2].Image == (Image)v1 || katak[i + 1, j + 2].Image == (Image)q1) && xarita[i + 1, j + 2] != "")
                    {
                        katak[i + 1, j + 2].FlatAppearance.BorderColor = Color.Red;
                        katak[i + 1, j + 2].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
            }
        }
        void ruh(int i, int j)
        {
            if (navbat == 1 && katak[i, j].Image == (Image)r1)
            {
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j].Image == null && t) katak[i - p, j].Text = "⚫";
                        if ((katak[i - p, j].Image == (Image)p2 || katak[i - p, j].Image == (Image)o2 || katak[i - p, j].Image == (Image)f2 || katak[i - p, j].Image == (Image)r2 || katak[i - p, j].Image == (Image)v2 || katak[i - p, j].Image == (Image)q2) && xarita[i - p, j] != "" && f)
                        {
                            katak[i - p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j].Image == (Image)p1 || katak[i - p - 1, j].Image == (Image)o1 || katak[i - p - 1, j].Image == (Image)f1 || katak[i - p - 1, j].Image == (Image)r1 || katak[i - p - 1, j].Image == (Image)v1 || katak[i - p - 1, j].Image == (Image)q1) && xarita[i - p - 1, j] != "")
                            f = false;
                        if (katak[i - p - 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j].Image == null && t) katak[i + p, j].Text = "⚫";
                        if ((katak[i + p, j].Image == (Image)p2 || katak[i + p, j].Image == (Image)o2 || katak[i + p, j].Image == (Image)f2 || katak[i + p, j].Image == (Image)r2 || katak[i + p, j].Image == (Image)v2 || katak[i + p, j].Image == (Image)q2) && xarita[i + p, j] != "" && f)
                        {
                            katak[i + p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j].Image == (Image)p1 || katak[i + p + 1, j].Image == (Image)o1 || katak[i + p + 1, j].Image == (Image)f1 || katak[i + p + 1, j].Image == (Image)r1 || katak[i + p + 1, j].Image == (Image)v1 || katak[i + p + 1, j].Image == (Image)q1) && xarita[i + p + 1, j] != "")
                            f = false;
                        if (katak[i + p + 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = false;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j - p].Image == null && t) katak[i, j - p].Text = "⚫";
                        if ((katak[i, j - p].Image == (Image)p2 || katak[i, j - p].Image == (Image)o2 || katak[i, j - p].Image == (Image)f2 || katak[i, j - p].Image == (Image)r2 || katak[i, j - p].Image == (Image)v2 || katak[i, j - p].Image == (Image)q2) && xarita[i, j - p] != "" && f)
                        {
                            katak[i, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j - p - 1].Image == (Image)p1 || katak[i, j - p - 1].Image == (Image)o1 || katak[i, j - p - 1].Image == (Image)f1 || katak[i, j - p - 1].Image == (Image)r1 || katak[i, j - p - 1].Image == (Image)v1 || katak[i, j - p - 1].Image == (Image)q1) && xarita[i, j - p - 1] != "")
                            f = false;
                        if (katak[i, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j + p].Image == null && t) katak[i, j + p].Text = "⚫";
                        if ((katak[i, j + p].Image == (Image)p2 || katak[i, j + p].Image == (Image)o2 || katak[i, j + p].Image == (Image)f2 || katak[i, j + p].Image == (Image)r2 || katak[i, j + p].Image == (Image)v2 || katak[i, j + p].Image == (Image)q2) && xarita[i, j + p] != "" && f)
                        {
                            katak[i, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j + p + 1].Image == (Image)p1 || katak[i, j + p + 1].Image == (Image)o1 || katak[i, j + p + 1].Image == (Image)f1 || katak[i, j + p + 1].Image == (Image)r1 || katak[i, j + p + 1].Image == (Image)v1 || katak[i, j + p + 1].Image == (Image)q1) && xarita[i, j + p + 1] != "")
                            f = false;
                        if (katak[i, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
            }
            if (navbat == 2 && katak[i, j].Image == (Image)r2)
            {
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j].Image == null && t) katak[i - p, j].Text = "⚫";
                        if ((katak[i - p, j].Image == (Image)p1 || katak[i - p, j].Image == (Image)o1 || katak[i - p, j].Image == (Image)f1 || katak[i - p, j].Image == (Image)r1 || katak[i - p, j].Image == (Image)v1 || katak[i - p, j].Image == (Image)q1) && xarita[i - p, j] != "" && f)
                        {
                            katak[i - p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j].Image == (Image)p2 || katak[i - p - 1, j].Image == (Image)o2 || katak[i - p - 1, j].Image == (Image)f2 || katak[i - p - 1, j].Image == (Image)r2 || katak[i - p - 1, j].Image == (Image)v2 || katak[i - p - 1, j].Image == (Image)q2) && xarita[i - p - 1, j] != "")
                            f = false;
                        if (katak[i - p - 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j].Image == null && t) katak[i + p, j].Text = "⚫";
                        if ((katak[i + p, j].Image == (Image)p1 || katak[i + p, j].Image == (Image)o1 || katak[i + p, j].Image == (Image)f1 || katak[i + p, j].Image == (Image)r1 || katak[i + p, j].Image == (Image)v1 || katak[i + p, j].Image == (Image)q1) && xarita[i + p, j] != "" && f)
                        {
                            katak[i + p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j].Image == (Image)p2 || katak[i + p + 1, j].Image == (Image)o2 || katak[i + p + 1, j].Image == (Image)f2 || katak[i + p + 1, j].Image == (Image)r2 || katak[i + p + 1, j].Image == (Image)v2 || katak[i + p + 1, j].Image == (Image)q2) && xarita[i + p + 1, j] != "")
                            f = false;
                        if (katak[i + p + 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = false;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j - p].Image == null && t) katak[i, j - p].Text = "⚫";
                        if ((katak[i, j - p].Image == (Image)p1 || katak[i, j - p].Image == (Image)f1 || katak[i, j - p].Image == (Image)r1 || katak[i, j - p].Image == (Image)v1 || katak[i, j - p].Image == (Image)q1) && xarita[i, j - p] != "" && f)
                        {
                            katak[i, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j - p - 1].Image == (Image)p2 || katak[i, j - p].Image == (Image)o1 || katak[i, j - p - 1].Image == (Image)f2 || katak[i, j - p - 1].Image == (Image)r2 || katak[i, j - p - 1].Image == (Image)v2 || katak[i, j - p - 1].Image == (Image)q2) && xarita[i, j - p - 1] != "")
                            f = false;
                        if (katak[i, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j + p].Image == null && t) katak[i, j + p].Text = "⚫";
                        if ((katak[i, j + p].Image == (Image)p1 || katak[i, j + p].Image == (Image)o1 || katak[i, j + p].Image == (Image)f1 || katak[i, j + p].Image == (Image)r1 || katak[i, j + p].Image == (Image)v1 || katak[i, j + p].Image == (Image)q1) && xarita[i, j + p] != "" && f)
                        {
                            katak[i, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j + p + 1].Image == (Image)p2 || katak[i, j + p + 1].Image == (Image)o2 || katak[i, j + p + 1].Image == (Image)f2 || katak[i, j + p + 1].Image == (Image)r2 || katak[i, j + p + 1].Image == (Image)v2 || katak[i, j + p + 1].Image == (Image)q2) && xarita[i, j + p + 1] != "")
                            f = false;
                        if (katak[i, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
            }
        }
        void fil(int i, int j)
        {
            if (navbat == 1 && katak[i, j].Image == (Image)f1)
            {
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j - p].Image == null && t) katak[i - p, j - p].Text = "⚫";
                        if ((katak[i - p, j - p].Image == (Image)p2 || katak[i - p, j - p].Image == (Image)o2 || katak[i - p, j - p].Image == (Image)f2 || katak[i - p, j - p].Image == (Image)r2 || katak[i - p, j - p].Image == (Image)v2 || katak[i - p, j - p].Image == (Image)q2) && xarita[i - p, j - p] != "" && f)
                        {
                            katak[i - p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j - p - 1].Image == (Image)p1 || katak[i - p - 1, j - p - 1].Image == (Image)o1 || katak[i - p - 1, j - p - 1].Image == (Image)f1 || katak[i - p - 1, j - p - 1].Image == (Image)r1 || katak[i - p - 1, j - p - 1].Image == (Image)v1 || katak[i - p - 1, j - p - 1].Image == (Image)q1) && xarita[i - p - 1, j - p - 1] != "")
                            f = false;
                        if (katak[i - p - 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j - p].Image == null && t) katak[i + p, j - p].Text = "⚫";
                        if ((katak[i + p, j - p].Image == (Image)p2 || katak[i + p, j - p].Image == (Image)o2 || katak[i + p, j - p].Image == (Image)f2 || katak[i + p, j - p].Image == (Image)r2 || katak[i + p, j - p].Image == (Image)v2 || katak[i + p, j - p].Image == (Image)q2) && xarita[i + p, j - p] != "" && f)
                        {
                            katak[i + p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j - p - 1].Image == (Image)p1 || katak[i + p + 1, j - p - 1].Image == (Image)o1 || katak[i + p + 1, j - p - 1].Image == (Image)f1 || katak[i + p + 1, j - p - 1].Image == (Image)r1 || katak[i + p + 1, j - p - 1].Image == (Image)v1 || katak[i + p + 1, j - p - 1].Image == (Image)q1) && xarita[i + p + 1, j - p - 1] != "")
                            f = false;
                        if (katak[i + p + 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j + p].Image == null && t) katak[i - p, j + p].Text = "⚫";
                        if ((katak[i - p, j + p].Image == (Image)p2 || katak[i - p, j + p].Image == (Image)o2 || katak[i - p, j + p].Image == (Image)f2 || katak[i - p, j + p].Image == (Image)r2 || katak[i - p, j + p].Image == (Image)v2 || katak[i - p, j + p].Image == (Image)q2) && xarita[i - p, j + p] != "" && f)
                        {
                            katak[i - p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j + p + 1].Image == (Image)p1 || katak[i - p - 1, j + p + 1].Image == (Image)o1 || katak[i - p - 1, j + p + 1].Image == (Image)f1 || katak[i - p - 1, j + p + 1].Image == (Image)r1 || katak[i - p - 1, j + p + 1].Image == (Image)v1 || katak[i - p - 1, j + p + 1].Image == (Image)q1) && xarita[i - p - 1, j + p + 1] != "")
                            f = false;
                        if (katak[i - p - 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j + p].Image == null && t) katak[i + p, j + p].Text = "⚫";
                        if ((katak[i + p, j + p].Image == (Image)p2 || katak[i + p, j + p].Image == (Image)o2 || katak[i + p, j + p].Image == (Image)f2 || katak[i + p, j + p].Image == (Image)r2 || katak[i + p, j + p].Image == (Image)v2 || katak[i + p, j + p].Image == (Image)q2) && xarita[i + p, j + p] != "" && f)
                        {
                            katak[i + p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j + p + 1].Image == (Image)p1 || katak[i + p + 1, j + p + 1].Image == (Image)o1 || katak[i + p + 1, j + p + 1].Image == (Image)f1 || katak[i + p + 1, j + p + 1].Image == (Image)r1 || katak[i + p + 1, j + p + 1].Image == (Image)v1 || katak[i + p + 1, j + p + 1].Image == (Image)q1) && xarita[i + p + 1, j + p + 1] != "")
                            f = false;
                        if (katak[i + p + 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
            }
            if (navbat == 2 && katak[i, j].Image == (Image)f2)
            {
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j - p].Image == null && t) katak[i - p, j - p].Text = "⚫";
                        if ((katak[i - p, j - p].Image == (Image)p1 || katak[i - p, j - p].Image == (Image)o1 || katak[i - p, j - p].Image == (Image)f1 || katak[i - p, j - p].Image == (Image)r1 || katak[i - p, j - p].Image == (Image)v1 || katak[i - p, j - p].Image == (Image)q1) && xarita[i - p, j - p] != "" && f)
                        {
                            katak[i - p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j - p - 1].Image == (Image)p2 || katak[i - p - 1, j - p - 1].Image == (Image)o2 || katak[i - p - 1, j - p - 1].Image == (Image)f2 || katak[i - p - 1, j - p - 1].Image == (Image)r2 || katak[i - p - 1, j - p - 1].Image == (Image)v2 || katak[i - p - 1, j - p - 1].Image == (Image)q2) && xarita[i - p - 1, j - p - 1] != "")
                            f = false;
                        if (katak[i - p - 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j - p].Image == null && t) katak[i + p, j - p].Text = "⚫";
                        if ((katak[i + p, j - p].Image == (Image)p1 || katak[i + p, j - p].Image == (Image)o1 || katak[i + p, j - p].Image == (Image)f1 || katak[i + p, j - p].Image == (Image)r1 || katak[i + p, j - p].Image == (Image)v1 || katak[i + p, j - p].Image == (Image)q1) && xarita[i + p, j - p] != "" && f)
                        {
                            katak[i + p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j - p - 1].Image == (Image)p2 || katak[i + p + 1, j - p - 1].Image == (Image)o2 || katak[i + p + 1, j - p - 1].Image == (Image)f2 || katak[i + p + 1, j - p - 1].Image == (Image)r2 || katak[i + p + 1, j - p - 1].Image == (Image)v2 || katak[i + p + 1, j - p - 1].Image == (Image)q2) && xarita[i + p + 1, j - p - 1] != "")
                            f = false;
                        if (katak[i + p + 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j + p].Image == null && t) katak[i - p, j + p].Text = "⚫";
                        if ((katak[i - p, j + p].Image == (Image)p1 || katak[i - p, j + p].Image == (Image)o1 || katak[i - p, j + p].Image == (Image)f1 || katak[i - p, j + p].Image == (Image)r1 || katak[i - p, j + p].Image == (Image)v1 || katak[i - p, j + p].Image == (Image)q1) && xarita[i - p, j + p] != "" && f)
                        {
                            katak[i - p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j + p + 1].Image == (Image)p2 || katak[i - p - 1, j + p + 1].Image == (Image)o2 || katak[i - p - 1, j + p + 1].Image == (Image)f2 || katak[i - p - 1, j + p + 1].Image == (Image)r2 || katak[i - p - 1, j + p + 1].Image == (Image)v2 || katak[i - p - 1, j + p + 1].Image == (Image)q2) && xarita[i - p - 1, j + p + 1] != "")
                            f = false;
                        if (katak[i - p - 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j + p].Image == null && t) katak[i + p, j + p].Text = "⚫";
                        if ((katak[i + p, j + p].Image == (Image)p1 || katak[i + p, j + p].Image == (Image)o1 || katak[i + p, j + p].Image == (Image)f1 || katak[i + p, j + p].Image == (Image)r1 || katak[i + p, j + p].Image == (Image)v1 || katak[i + p, j + p].Image == (Image)q1) && xarita[i + p, j + p] != "" && f)
                        {
                            katak[i + p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j + p + 1].Image == (Image)p2 || katak[i + p + 1, j + p + 1].Image == (Image)o2 || katak[i + p + 1, j + p + 1].Image == (Image)f2 || katak[i + p + 1, j + p + 1].Image == (Image)r2 || katak[i + p + 1, j + p + 1].Image == (Image)v2 || katak[i + p + 1, j + p + 1].Image == (Image)q2) && xarita[i + p + 1, j + p + 1] != "")
                            f = false;
                        if (katak[i + p + 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            navbat = 1;
            panel2.Controls.Clear();
            yaratishX();
        }
        void farzin(int i, int j)
        {
            if (navbat == 1 && katak[i, j].Image == (Image)v1)
            {
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j].Image == null && t) katak[i - p, j].Text = "⚫";
                        if ((katak[i - p, j].Image == (Image)p2 || katak[i - p, j].Image == (Image)o2 || katak[i - p, j].Image == (Image)f2 || katak[i - p, j].Image == (Image)r2 || katak[i - p, j].Image == (Image)v2 || katak[i - p, j].Image == (Image)q2) && xarita[i - p, j] != "" && f)
                        {
                            katak[i - p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j].Image == (Image)p1 || katak[i - p - 1, j].Image == (Image)o1 || katak[i - p - 1, j].Image == (Image)f1 || katak[i - p - 1, j].Image == (Image)r1 || katak[i - p - 1, j].Image == (Image)v1 || katak[i - p - 1, j].Image == (Image)q1) && xarita[i - p - 1, j] != "")
                            f = false;

                        if (katak[i - p - 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j].Image == null && t) katak[i + p, j].Text = "⚫";
                        if ((katak[i + p, j].Image == (Image)p2 || katak[i + p, j].Image == (Image)o2 || katak[i + p, j].Image == (Image)f2 || katak[i + p, j].Image == (Image)r2 || katak[i + p, j].Image == (Image)v2 || katak[i + p, j].Image == (Image)q2) && xarita[i + p, j] != "" && f)
                        {
                            katak[i + p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j].Image == (Image)p1 || katak[i + p + 1, j].Image == (Image)o1 || katak[i + p + 1, j].Image == (Image)f1 || katak[i + p + 1, j].Image == (Image)r1 || katak[i + p + 1, j].Image == (Image)v1 || katak[i + p + 1, j].Image == (Image)q1) && xarita[i + p + 1, j] != "")
                            f = false;
                        if (katak[i + p + 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = false;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j - p].Image == null && t) katak[i, j - p].Text = "⚫";
                        if ((katak[i, j - p].Image == (Image)p2 || katak[i, j - p].Image == (Image)o2 || katak[i, j - p].Image == (Image)f2 || katak[i, j - p].Image == (Image)r2 || katak[i, j - p].Image == (Image)v2 || katak[i, j - p].Image == (Image)q2) && xarita[i, j - p] != "" && f)
                        {
                            katak[i, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j - p - 1].Image == (Image)p1 || katak[i, j - p - 1].Image == (Image)o1 || katak[i, j - p - 1].Image == (Image)f1 || katak[i, j - p - 1].Image == (Image)r1 || katak[i, j - p - 1].Image == (Image)v1 || katak[i, j - p - 1].Image == (Image)q1) && xarita[i, j - p - 1] != "")
                            f = false;
                        if (katak[i, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j + p].Image == null && t) katak[i, j + p].Text = "⚫";
                        if ((katak[i, j + p].Image == (Image)p2 || katak[i, j + p].Image == (Image)o2 || katak[i, j + p].Image == (Image)f2 || katak[i, j + p].Image == (Image)r2 || katak[i, j + p].Image == (Image)v2 || katak[i, j + p].Image == (Image)q2) && xarita[i, j + p] != "" && f)
                        {
                            katak[i, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j + p + 1].Image == (Image)p1 || katak[i, j + p + 1].Image == (Image)o1 || katak[i, j + p + 1].Image == (Image)f1 || katak[i, j + p + 1].Image == (Image)r1 || katak[i, j + p + 1].Image == (Image)v1 || katak[i, j + p + 1].Image == (Image)q1) && xarita[i, j + p + 1] != "")
                            f = false;
                        if (katak[i, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j - p].Image == null && t) katak[i - p, j - p].Text = "⚫";
                        if ((katak[i - p, j - p].Image == (Image)p2 || katak[i - p, j - p].Image == (Image)o2 || katak[i - p, j - p].Image == (Image)f2 || katak[i - p, j - p].Image == (Image)r2 || katak[i - p, j - p].Image == (Image)v2 || katak[i - p, j - p].Image == (Image)q2) && xarita[i - p, j - p] != "" && f)
                        {
                            katak[i - p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j - p - 1].Image == (Image)p1 || katak[i - p - 1, j - p - 1].Image == (Image)o1 || katak[i - p - 1, j - p - 1].Image == (Image)f1 || katak[i - p - 1, j - p - 1].Image == (Image)r1 || katak[i - p - 1, j - p - 1].Image == (Image)v1 || katak[i - p - 1, j - p - 1].Image == (Image)q1) && xarita[i - p - 1, j - p - 1] != "")
                            f = false;
                        if (katak[i - p - 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j - p].Image == null && t) katak[i + p, j - p].Text = "⚫";
                        if ((katak[i + p, j - p].Image == (Image)p2 || katak[i + p, j - p].Image == (Image)o2 || katak[i + p, j - p].Image == (Image)f2 || katak[i + p, j - p].Image == (Image)r2 || katak[i + p, j - p].Image == (Image)v2 || katak[i + p, j - p].Image == (Image)q2) && xarita[i + p, j - p] != "" && f)
                        {
                            katak[i + p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j - p - 1].Image == (Image)p1 || katak[i + p + 1, j - p - 1].Image == (Image)o1 || katak[i + p + 1, j - p - 1].Image == (Image)f1 || katak[i + p + 1, j - p - 1].Image == (Image)r1 || katak[i + p + 1, j - p - 1].Image == (Image)v1 || katak[i + p + 1, j - p - 1].Image == (Image)q1) && xarita[i + p + 1, j - p - 1] != "")
                            f = false;
                        if (katak[i + p + 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j + p].Image == null && t) katak[i - p, j + p].Text = "⚫";
                        if ((katak[i - p, j + p].Image == (Image)p2 || katak[i - p, j + p].Image == (Image)o2 || katak[i - p, j + p].Image == (Image)f2 || katak[i - p, j + p].Image == (Image)r2 || katak[i - p, j + p].Image == (Image)v2 || katak[i - p, j + p].Image == (Image)q2) && xarita[i - p, j + p] != "" && f)
                        {
                            katak[i - p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j + p + 1].Image == (Image)p1 || katak[i - p - 1, j + p + 1].Image == (Image)o1 || katak[i - p - 1, j + p + 1].Image == (Image)f1 || katak[i - p - 1, j + p + 1].Image == (Image)r1 || katak[i - p - 1, j + p + 1].Image == (Image)v1 || katak[i - p - 1, j + p + 1].Image == (Image)q1) && xarita[i - p - 1, j + p + 1] != "")
                            f = false;
                        if (katak[i - p - 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j + p].Image == null && t) katak[i + p, j + p].Text = "⚫";
                        if ((katak[i + p, j + p].Image == (Image)p2 || katak[i + p, j + p].Image == (Image)o2 || katak[i + p, j + p].Image == (Image)f2 || katak[i + p, j + p].Image == (Image)r2 || katak[i + p, j + p].Image == (Image)v2 || katak[i + p, j + p].Image == (Image)q2) && xarita[i + p, j + p] != "" && f)
                        {
                            katak[i + p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j + p + 1].Image == (Image)p1 || katak[i + p + 1, j + p + 1].Image == (Image)o1 || katak[i + p + 1, j + p + 1].Image == (Image)f1 || katak[i + p + 1, j + p + 1].Image == (Image)r1 || katak[i + p + 1, j + p + 1].Image == (Image)v1 || katak[i + p + 1, j + p + 1].Image == (Image)q1) && xarita[i + p + 1, j + p + 1] != "")
                            f = false;
                        if (katak[i + p + 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
            }
            if (navbat == 2 && katak[i, j].Image == (Image)v2)
            {
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j].Image == null && t) katak[i - p, j].Text = "⚫";
                        if ((katak[i - p, j].Image == (Image)p1 || katak[i - p, j].Image == (Image)o1 || katak[i - p, j].Image == (Image)f1 || katak[i - p, j].Image == (Image)r1 || katak[i - p, j].Image == (Image)v1 || katak[i - p, j].Image == (Image)q1) && xarita[i - p, j] != "" && f)
                        {
                            katak[i - p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j].Image == (Image)p2 || katak[i - p - 1, j].Image == (Image)o2 || katak[i - p - 1, j].Image == (Image)f2 || katak[i - p - 1, j].Image == (Image)r2 || katak[i - p - 1, j].Image == (Image)v2 || katak[i - p - 1, j].Image == (Image)q2) && xarita[i - p - 1, j] != "")
                            f = false;
                        if (katak[i - p - 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j].Image == null && t) katak[i + p, j].Text = "⚫";
                        if ((katak[i + p, j].Image == (Image)p1 || katak[i + p, j].Image == (Image)o1 || katak[i + p, j].Image == (Image)f1 || katak[i + p, j].Image == (Image)r1 || katak[i + p, j].Image == (Image)v1 || katak[i + p, j].Image == (Image)q1) && xarita[i + p, j] != "" && f)
                        {
                            katak[i + p, j].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j].Image == (Image)p2 || katak[i + p + 1, j].Image == (Image)o2 || katak[i + p + 1, j].Image == (Image)f2 || katak[i + p + 1, j].Image == (Image)r2 || katak[i + p + 1, j].Image == (Image)v2 || katak[i + p + 1, j].Image == (Image)q2) && xarita[i + p + 1, j] != "")
                            f = false;
                        if (katak[i + p + 1, j].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = false;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j - p].Image == null && t) katak[i, j - p].Text = "⚫";
                        if ((katak[i, j - p].Image == (Image)p1 || katak[i, j - p].Image == (Image)f1 || katak[i, j - p].Image == (Image)r1 || katak[i, j - p].Image == (Image)v1 || katak[i, j - p].Image == (Image)q1) && xarita[i, j - p] != "" && f)
                        {
                            katak[i, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j - p - 1].Image == (Image)p2 || katak[i, j - p].Image == (Image)o1 || katak[i, j - p - 1].Image == (Image)f2 || katak[i, j - p - 1].Image == (Image)r2 || katak[i, j - p - 1].Image == (Image)v2 || katak[i, j - p - 1].Image == (Image)q2) && xarita[i, j - p - 1] != "")
                            f = false;
                        if (katak[i, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i, j + p].Image == null && t) katak[i, j + p].Text = "⚫";
                        if ((katak[i, j + p].Image == (Image)p1 || katak[i, j + p].Image == (Image)o1 || katak[i, j + p].Image == (Image)f1 || katak[i, j + p].Image == (Image)r1 || katak[i, j + p].Image == (Image)v1 || katak[i, j + p].Image == (Image)q1) && xarita[i, j + p] != "" && f)
                        {
                            katak[i, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i, j + p + 1].Image == (Image)p2 || katak[i, j + p + 1].Image == (Image)o2 || katak[i, j + p + 1].Image == (Image)f2 || katak[i, j + p + 1].Image == (Image)r2 || katak[i, j + p + 1].Image == (Image)v2 || katak[i, j + p + 1].Image == (Image)q2) && xarita[i, j + p + 1] != "")
                            f = false;
                        if (katak[i, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j - p].Image == null && t) katak[i - p, j - p].Text = "⚫";
                        if ((katak[i - p, j - p].Image == (Image)p1 || katak[i - p, j - p].Image == (Image)o1 || katak[i - p, j - p].Image == (Image)f1 || katak[i - p, j - p].Image == (Image)r1 || katak[i - p, j - p].Image == (Image)v1 || katak[i - p, j - p].Image == (Image)q1) && xarita[i - p, j - p] != "" && f)
                        {
                            katak[i - p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j - p - 1].Image == (Image)p2 || katak[i - p - 1, j - p - 1].Image == (Image)o2 || katak[i - p - 1, j - p - 1].Image == (Image)f2 || katak[i - p - 1, j - p - 1].Image == (Image)r2 || katak[i - p - 1, j - p - 1].Image == (Image)v2 || katak[i - p - 1, j - p - 1].Image == (Image)q2) && xarita[i - p - 1, j - p - 1] != "")
                            f = false;
                        if (katak[i - p - 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j - p].Image == null && t) katak[i + p, j - p].Text = "⚫";
                        if ((katak[i + p, j - p].Image == (Image)p1 || katak[i + p, j - p].Image == (Image)o1 || katak[i + p, j - p].Image == (Image)f1 || katak[i + p, j - p].Image == (Image)r1 || katak[i + p, j - p].Image == (Image)v1 || katak[i + p, j - p].Image == (Image)q1) && xarita[i + p, j - p] != "" && f)
                        {
                            katak[i + p, j - p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j - p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j - p - 1].Image == (Image)p2 || katak[i + p + 1, j - p - 1].Image == (Image)o2 || katak[i + p + 1, j - p - 1].Image == (Image)f2 || katak[i + p + 1, j - p - 1].Image == (Image)r2 || katak[i + p + 1, j - p - 1].Image == (Image)v2 || katak[i + p + 1, j - p - 1].Image == (Image)q2) && xarita[i + p + 1, j - p - 1] != "")
                            f = false;
                        if (katak[i + p + 1, j - p - 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i - p, j + p].Image == null && t) katak[i - p, j + p].Text = "⚫";
                        if ((katak[i - p, j + p].Image == (Image)p1 || katak[i - p, j + p].Image == (Image)o1 || katak[i - p, j + p].Image == (Image)f1 || katak[i - p, j + p].Image == (Image)r1 || katak[i - p, j + p].Image == (Image)v1 || katak[i - p, j + p].Image == (Image)q1) && xarita[i - p, j + p] != "" && f)
                        {
                            katak[i - p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i - p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i - p - 1, j + p + 1].Image == (Image)p2 || katak[i - p - 1, j + p + 1].Image == (Image)o2 || katak[i - p - 1, j + p + 1].Image == (Image)f2 || katak[i - p - 1, j + p + 1].Image == (Image)r2 || katak[i - p - 1, j + p + 1].Image == (Image)v2 || katak[i - p - 1, j + p + 1].Image == (Image)q2) && xarita[i - p - 1, j + p + 1] != "")
                            f = false;
                        if (katak[i - p - 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
                try
                {
                    bool t = true;
                    bool f = true;
                    for (int p = 0; p < 8; p++)
                    {
                        if (katak[i + p, j + p].Image == null && t) katak[i + p, j + p].Text = "⚫";
                        if ((katak[i + p, j + p].Image == (Image)p1 || katak[i + p, j + p].Image == (Image)o1 || katak[i + p, j + p].Image == (Image)f1 || katak[i + p, j + p].Image == (Image)r1 || katak[i + p, j + p].Image == (Image)v1 || katak[i + p, j + p].Image == (Image)q1) && xarita[i + p, j + p] != "" && f)
                        {
                            katak[i + p, j + p].FlatAppearance.BorderColor = Color.Red;
                            katak[i + p, j + p].FlatAppearance.BorderSize = 3;
                            f = false;
                        }
                        if ((katak[i + p + 1, j + p + 1].Image == (Image)p2 || katak[i + p + 1, j + p + 1].Image == (Image)o2 || katak[i + p + 1, j + p + 1].Image == (Image)f2 || katak[i + p + 1, j + p + 1].Image == (Image)r2 || katak[i + p + 1, j + p + 1].Image == (Image)v2 || katak[i + p + 1, j + p + 1].Image == (Image)q2) && xarita[i + p + 1, j + p + 1] != "")
                            f = false;
                        if (katak[i + p + 1, j + p + 1].Image != null) t = false;
                    }
                }
                catch { }
            }
        }
        void piyodaol(int x, int y)
        {

            if (navbat == 1 && katak[x, y].Image == (Image)p1)
            {
                try
                {
                    if (katak[x - 1, y - 1].Image == null) katak[x - 1, y - 1].Text = "⚫";

                }
                catch { }
                try
                {
                    if (katak[x - 1, y + 1].Image == null) katak[x - 1, y + 1].Text = "⚫";
                }
                catch { }

            }
            if (navbat == 2 && katak[x, y].Image == (Image)p2)
            {

                try
                {
                    if (katak[x + 1, y - 1].Image == null) katak[x + 1, y - 1].Text = "⚫";
                }
                catch { }
                try
                {
                    if (katak[x + 1, y + 1].Image == null) katak[x + 1, y + 1].Text = "⚫";
                }
                catch { }
            }
        }
        void qirolol(int x, int y)
        {
            try
            {
                if (katak[x - 1, y].Image == null) katak[x - 1, y].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x + 1, y].Image == null) katak[x + 1, y].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x, y - 1].Image == null) katak[x, y - 1].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x, y + 1].Image == null) katak[x, y + 1].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x + 1, y + 1].Image == null) katak[x + 1, y + 1].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x + 1, y - 1].Image == null) katak[x + 1, y - 1].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x - 1, y + 1].Image == null) katak[x - 1, y + 1].Text = "⚫";
            }
            catch { }
            try
            {
                if (katak[x - 1, y - 1].Image == null) katak[x - 1, y - 1].Text = "⚫";
            }
            catch { }
        }

        void qirol(int x, int y)
        {
            if (navbat == 1 && katak[x, y].Image == (Image)q1)
            {
                navbat = 2;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (xarita[i, j] == "p2") piyodaol(i, j);
                        if (xarita[i, j] == "o2") ot(i, j);
                        if (xarita[i, j] == "r2") ruh(i, j);
                        if (xarita[i, j] == "f2") fil(i, j);
                        if (xarita[i, j] == "v2") farzin(i, j);
                        if (xarita[i, j] == "q2") qirolol(i, j);
                    }
                }
                int[,] bosh = new int[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (katak[i, j].Text == "⚫")
                        {
                            bosh[i, j] = 1;
                        }
                        else if (katak[i, j].Image == null) bosh[i, j] = 0;
                    }
                }
                fon();
                navbat = 1;
                katak[x, y].FlatAppearance.BorderSize = 3;
                katak[x, y].FlatAppearance.BorderColor = Color.Green;
                try
                {
                    if (katak[x - 1, y].Image == null && bosh[x - 1, y] == 0) katak[x - 1, y].Text = "⚫";
                    if ((katak[x - 1, y].Image == (Image)p2 || katak[x - 1, y].Image == (Image)o2 || katak[x - 1, y].Image == (Image)f2 || katak[x - 1, y].Image == (Image)r2 || katak[x - 1, y].Image == (Image)v2) && bosh[x - 1, y] == 0)
                    {
                        katak[x - 1, y].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x + 1, y].Image == null && bosh[x + 1, y] == 0) katak[x + 1, y].Text = "⚫";
                    if ((katak[x + 1, y].Image == (Image)p2 || katak[x + 1, y].Image == (Image)o2 || katak[x + 1, y].Image == (Image)f2 || katak[x + 1, y].Image == (Image)r2 || katak[x + 1, y].Image == (Image)v2) && bosh[x + 1, y] == 0)
                    {
                        katak[x + 1, y].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x, y - 1].Image == null && bosh[x, y - 1] == 0) katak[x, y - 1].Text = "⚫";
                    if ((katak[x, y - 1].Image == (Image)p2 || katak[x, y - 1].Image == (Image)o2 || katak[x, y - 1].Image == (Image)f2 || katak[x, y - 1].Image == (Image)r2 || katak[x, y - 1].Image == (Image)v2) && bosh[x, y - 1] == 0)
                    {
                        katak[x, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x, y + 1].Image == null && bosh[x, y + 1] == 0) katak[x, y + 1].Text = "⚫";
                    if ((katak[x, y + 1].Image == (Image)p2 || katak[x, y + 1].Image == (Image)o2 || katak[x, y + 1].Image == (Image)f2 || katak[x, y + 1].Image == (Image)r2 || katak[x, y + 1].Image == (Image)v2) && bosh[x, y + 1] == 0)
                    {
                        katak[x, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x - 1, y - 1].Image == null && bosh[x - 1, y - 1] == 0) katak[x - 1, y - 1].Text = "⚫";
                    if ((katak[x - 1, y - 1].Image == (Image)p2 || katak[x - 1, y - 1].Image == (Image)o2 || katak[x - 1, y - 1].Image == (Image)f2 || katak[x - 1, y - 1].Image == (Image)r2 || katak[x - 1, y - 1].Image == (Image)v2) && bosh[x - 1, y - 1] == 0)
                    {
                        katak[x - 1, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x + 1, y + 1].Image == null && bosh[x + 1, y + 1] == 0) katak[x + 1, y + 1].Text = "⚫";
                    if ((katak[x + 1, y + 1].Image == (Image)p2 || katak[x + 1, y + 1].Image == (Image)o2 || katak[x + 1, y + 1].Image == (Image)f2 || katak[x + 1, y + 1].Image == (Image)r2 || katak[x + 1, y + 1].Image == (Image)v2) && bosh[x + 1, y + 1] == 0)
                    {
                        katak[x + 1, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x - 1, y + 1].Image == null && bosh[x - 1, y + 1] == 0) katak[x - 1, y + 1].Text = "⚫";
                    if ((katak[x - 1, y + 1].Image == (Image)p2 || katak[x - 1, y + 1].Image == (Image)o2 || katak[x - 1, y + 1].Image == (Image)f2 || katak[x - 1, y + 1].Image == (Image)r2 || katak[x - 1, y + 1].Image == (Image)v2 || katak[x - 1, y + 1].Image == (Image)q2) && bosh[x - 1, y + 1] == 0)
                    {
                        katak[x - 1, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x + 1, y - 1].Image == null && bosh[x + 1, y - 1] == 0) katak[x + 1, y - 1].Text = "⚫";
                    if ((katak[x + 1, y - 1].Image == (Image)p2 || katak[x + 1, y - 1].Image == (Image)o2 || katak[x + 1, y - 1].Image == (Image)f2 || katak[x + 1, y - 1].Image == (Image)r2 || katak[x + 1, y - 1].Image == (Image)v2 || katak[x + 1, y - 1].Image == (Image)q2) && bosh[x + 1, y - 1] == 0)
                    {
                        katak[x + 1, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y - 1].FlatAppearance.BorderSize = 3;

                    }
                }
                catch { }
            }
            if (navbat == 2 && katak[x, y].Image == (Image)q2)
            {
                navbat = 1;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (xarita[i, j] == "p1") piyodaol(i, j);
                        if (xarita[i, j] == "o1") ot(i, j);
                        if (xarita[i, j] == "r1") ruh(i, j);
                        if (xarita[i, j] == "f1") fil(i, j);
                        if (xarita[i, j] == "v1") farzin(i, j);
                        if (xarita[i, j] == "q1") qirolol(i, j);
                    }
                }
                int[,] bosh = new int[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (katak[i, j].Text == "⚫")
                        {
                            bosh[i, j] = 1;
                        }
                        else if (katak[i, j].Image == null) bosh[i, j] = 0;
                    }
                }
                fon();
                navbat = 2;
                katak[x, y].FlatAppearance.BorderSize = 3;
                katak[x, y].FlatAppearance.BorderColor = Color.Green;
                try
                {
                    if (katak[x - 1, y].Image == null && bosh[x - 1, y] == 0) katak[x - 1, y].Text = "⚫";
                    if ((katak[x - 1, y].Image == (Image)p1 || katak[x - 1, y].Image == (Image)o1 || katak[x - 1, y].Image == (Image)f1 || katak[x - 1, y].Image == (Image)r1 || katak[x - 1, y].Image == (Image)v1) && bosh[x - 1, y] == 0)
                    {
                        katak[x - 1, y].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x + 1, y].Image == null && bosh[x + 1, y] == 0) katak[x + 1, y].Text = "⚫";
                    if ((katak[x + 1, y].Image == (Image)p1 || katak[x + 1, y].Image == (Image)o1 || katak[x + 1, y].Image == (Image)f1 || katak[x + 1, y].Image == (Image)r1 || katak[x + 1, y].Image == (Image)v1) && bosh[x + 1, y] == 0)
                    {
                        katak[x + 1, y].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x, y - 1].Image == null && bosh[x, y - 1] == 0) katak[x, y - 1].Text = "⚫";
                    if ((katak[x, y - 1].Image == (Image)p1 || katak[x, y - 1].Image == (Image)o1 || katak[x, y - 1].Image == (Image)f1 || katak[x, y - 1].Image == (Image)r1 || katak[x, y - 1].Image == (Image)v1) && bosh[x, y - 1] == 0)
                    {
                        katak[x, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x, y + 1].Image == null && bosh[x, y + 1] == 0) katak[x, y + 1].Text = "⚫";
                    if ((katak[x, y + 1].Image == (Image)p1 || katak[x, y + 1].Image == (Image)o1 || katak[x, y + 1].Image == (Image)f1 || katak[x, y + 1].Image == (Image)r1 || katak[x, y + 1].Image == (Image)v1) && bosh[x, y + 1] == 0)
                    {
                        katak[x, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x - 1, y - 1].Image == null && bosh[x - 1, y - 1] == 0) katak[x - 1, y - 1].Text = "⚫";
                    if ((katak[x - 1, y - 1].Image == (Image)p1 || katak[x - 1, y - 1].Image == (Image)o1 || katak[x - 1, y - 1].Image == (Image)f1 || katak[x - 1, y - 1].Image == (Image)r1 || katak[x - 1, y - 1].Image == (Image)v1) && bosh[x - 1, y - 1] == 0)
                    {
                        katak[x - 1, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x + 1, y + 1].Image == null && bosh[x + 1, y + 1] == 0) katak[x + 1, y + 1].Text = "⚫";
                    if ((katak[x + 1, y + 1].Image == (Image)p1 || katak[x + 1, y + 1].Image == (Image)o1 || katak[x + 1, y + 1].Image == (Image)f1 || katak[x + 1, y + 1].Image == (Image)r1 || katak[x + 1, y + 1].Image == (Image)v1) && bosh[x + 1, y + 1] == 0)
                    {
                        katak[x + 1, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x - 1, y + 1].Image == null && bosh[x - 1, y + 1] == 0) katak[x - 1, y + 1].Text = "⚫";
                    if ((katak[x - 1, y + 1].Image == (Image)p1 || katak[x - 1, y + 1].Image == (Image)o1 || katak[x - 1, y + 1].Image == (Image)f1 || katak[x - 1, y + 1].Image == (Image)r1 || katak[x - 1, y + 1].Image == (Image)v1) && bosh[x - 1, y + 1] == 0)
                    {
                        katak[x - 1, y + 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x - 1, y + 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
                try
                {
                    if (katak[x + 1, y - 1].Image == null && bosh[x + 1, y - 1] == 0) katak[x + 1, y - 1].Text = "⚫";
                    if ((katak[x + 1, y - 1].Image == (Image)p1 || katak[x + 1, y - 1].Image == (Image)o1 || katak[x + 1, y - 1].Image == (Image)f1 || katak[x + 1, y - 1].Image == (Image)r1 || katak[x + 1, y - 1].Image == (Image)v1) && bosh[x + 1, y - 1] == 0)
                    {
                        katak[x + 1, y - 1].FlatAppearance.BorderColor = Color.Red;
                        katak[x + 1, y - 1].FlatAppearance.BorderSize = 3;
                    }
                }
                catch { }
            }
        }
        void fon()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    katak[i, j].FlatAppearance.BorderSize = 0;
                    katak[i, j].FlatAppearance.BorderColor = Color.White;
                    katak[i, j].Text = "";
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        katak[i, j].BackColor = Color.FromArgb(126, 103, 80);
                        katak[i, j].FlatAppearance.MouseDownBackColor = Color.FromArgb(126, 103, 80);
                        katak[i, j].FlatAppearance.MouseOverBackColor = Color.FromArgb(126, 103, 80);
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                    {
                        katak[i, j].BackColor = Color.FromArgb(34, 27, 19);
                        katak[i, j].FlatAppearance.MouseDownBackColor = Color.FromArgb(34, 27, 19);
                        katak[i, j].FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 27, 19);
                    }
                }
            }
        }
    }
}