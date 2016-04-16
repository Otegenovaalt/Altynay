using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Mymypaint
{
    public partial class Form1 : Form
    {
        Drawer drawer;
        
        public Form1()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox1);
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 10;
        }


        private void pencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawer.sh = Shape.pencil;
            pictureBox1.Cursor = Cursors.PanNE;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            drawer.pen = new Pen(colorDialog1.Color);
            drawer.sb = new SolidBrush(colorDialog1.Color);
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawer.g.Clear(Color.White);
            drawer.path = null;
            pictureBox1.Refresh();
        }



        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawer.sh = Shape.rectangle;
        }             

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG files (*.jpg)|*.jpg|PNG files(*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.SaveImage(saveFileDialog1.FileName);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.openImage(openFileDialog1.FileName);
            }
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            if (drawer.sh == Shape.pencil || drawer.sh == Shape.circle || drawer.sh == Shape.rectangle || drawer.sh == Shape.line)
                drawer.pen.Width = trackBar1.Value;
            if (drawer.sh == Shape.erasor)
                drawer.er.Width = trackBar1.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            drawer.sh = Shape.rectangle;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            drawer.sh = Shape.circle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawer.sh = Shape.triangle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawer.sh = Shape.erasor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawer.sh = Shape.line;
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawer.prev = e.Location;
                drawer.start = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawer.start)
            {
                drawer.Draw(e.Location);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawer.start = false;
            drawer.saveLastPath();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawer.sh = Shape.pencil;
        }
    }

    }





