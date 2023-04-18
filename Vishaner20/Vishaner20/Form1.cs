using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vishaner20
{
    public partial class Form1 : Form
    {
        bool sidebarExpand;//дижение шторки
        bool homeColapsed;//движение расшифровки
        int sh = 175;//начальное положение textbox1
        bool isFocused = false; // для передвижения надписи "Введите текст"
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gainsboro;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sidebarTime_Tick(object sender, EventArgs e)
        {
            panel2.MaximumSize = new Size(163,50);
            panel2.MinimumSize = new Size(43,50);
            panel4.MaximumSize = new Size(163,40);
            panel4.MinimumSize = new Size(43, 40);
            panel5.MaximumSize = new Size(163, 40);
            panel5.MinimumSize = new Size(43, 40);
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                panel3.Width -= 10;
                panel2.Width -= 10;
                panel4.Width -= 10;
                panel5.Width -= 10;
                panel7.Width -= 10;
                HomeContainer.Width -= 10;
                panel9.Height -= 5;
                panel8.Height -= 5;
                HomeContainer.Height -= 10;
                //перемещение текстбокса
                sh -= 10;
                if (sh > 43)
                {
                    richTextBox1.Location = new Point(sh, 27);
                    label2.Location = new Point(sh, label2.Location.Y);
                }
                else
                {
                    richTextBox1.Location = new Point(43, 27);
                    label2.Location = new Point(43, label2.Location.Y);
                }
                //
                richTextBox1.Width += 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTime.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                panel3.Width += 10;
                panel2.Width += 10;
                panel4.Width += 10;
                panel5.Width += 10;
                panel7.Width += 10;
                HomeContainer.Width += 10;
                //перемещение текстбокса
                sh += 10;
                if (sh < 175)
                {
                    richTextBox1.Location = new Point(sh, 27);
                    label2.Location = new Point(sh, label2.Location.Y);
                }
                else
                {
                    richTextBox1.Location = new Point(175, 27);
                    label2.Location = new Point(175, label2.Location.Y);
                }
                //
                richTextBox1.Width -= 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTime.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTime.Start();
        }

        private void HomeTimer_Tick(object sender, EventArgs e)
        {
            if (homeColapsed)
            {
                HomeContainer.Height += 10;
                panel9.Height += 5;
                panel8.Height += 5;
                if (HomeContainer.Height == HomeContainer.MaximumSize.Height)
                {
                    homeColapsed = false;
                    HomeTimer.Stop();
                }
            }
            else
            {
                HomeContainer.Height -= 10;
                panel9.Height -= 5;
                panel8.Height -= 5;
                if (HomeContainer.Height == HomeContainer.MinimumSize.Height)
                {
                    homeColapsed = true;
                    HomeTimer.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //движение расшифровки
            HomeTimer.Start();
        }

        private void labelTimer_Tick(object sender, EventArgs e)
        {
            int y = label2.Location.Y;
            if(isFocused == false)
            {
                y -= 2;
                label2.Location = new Point(label2.Location.X, y);
                if (y <= 5)
                {
                    isFocused = true;
                    labelTimer.Stop();
                    label2.Font = new Font("Segoi UI",10);
                    y = 5;
                    label2.ForeColor = Color.Gray;
                }
            }else
            {
                y += 2;
                label2.Location = new Point(label2.Location.X,y);
                if(y >= 27)
                {
                    isFocused = false;
                    labelTimer.Stop();
                    label2.Font = new Font("Segoi UI", 11);
                    y = 27;
                    label2.ForeColor = Color.Black;
                }
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if(richTextBox1.Text == "")
            {
                labelTimer.Start();
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                labelTimer.Start();
            }
        }
    }
}
