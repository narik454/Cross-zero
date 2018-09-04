using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrestikiNoliki
{
    public partial class Form1 : Form
    {
        bool click = true;
        char[,] mass = new char[3, 3];
        int k = 0;

        public Form1()
        {
            InitializeComponent();
        }

        static Button[,] b = new Button[3, 3];
        static Button a = new Button();

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Parent = this;
                    b[i, j].Left = i * 75;
                    b[i, j].Top = j * 75;
                    b[i, j].Width = 50;
                    b[i, j].Height = 50;
                    b[i, j].Click += Method;
                }
            }
            a = new Button();
            a.Parent = this;
            a.Left = this.Width - 125;
            a.Top = this.Height - 100;
            a.Text = "Заново";
            a.Width = 100;
            a.Height = 50;
            a.Click += Restart;

        }

        public void Restart(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    click = true;
                    mass = new char[3, 3];
                    b[i, j].Enabled = true;
                    b[i, j].Text = "";
                    k = 0; 
                }
            }
        }

        public void Method(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (click)
                    {
                        ((Button)sender).Text = "X";
                    }
                    else
                    {
                        ((Button)sender).Text = "O";
                    }
                }
            }
            click = !click;
            k++;
            ((Button)sender).Enabled = false;
            Mass();
        }

        public void Mass()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (b[i, j].Text == ('X').ToString())
                    {
                        mass[i, j] = 'x';
                    }

                    if (b[i, j].Text == ('O').ToString())
                    {
                        mass[i, j] = 'o';
                    }

                    if ((mass[i, j] != mass[j, i]) && k == 9)
                    {
                        MessageBox.Show("Ничья");
                        break;
                        
                    }
                }
            }

            Check();
        }

        public void Check()
        {
            string s = "";

            for (int i = 0; i <= 2; i++)
            {
                if ((mass[i, 0] == mass[i, 1]) && (mass[i, 1] == mass[i, 2]) && ((mass[i, 0] == 'x') || (mass[i, 0] == 'o')))
                {
                    s = mass[i, 0] + " победил";
                }

                if ((mass[0, i] == mass[1, i]) && (mass[1, i] == mass[2, i]) && ((mass[0, i] == 'x') || (mass[0, i] == 'o')))
                {
                    s = mass[0, i] + " победил";
                }
            }

            if ((mass[0, 0] == mass[1, 1]) && (mass[1, 1] == mass[2, 2]) && ((mass[0, 0] == 'x') || (mass[0, 0] == 'o')))
            {
                s = mass[0, 0] + " победил";
            }

            if ((mass[0, 2] == mass[1, 1]) && (mass[1, 1] == mass[2, 0]) && ((mass[0, 2] == 'x') || (mass[0, 2] == 'o')))
            {
                s = mass[0, 2] + " победил";
            }

            if (((s == "x победил") || (s == "o победил"))) MessageBox.Show(s + " за " + k.ToString() + " Ходов ");
        }
    }
}
