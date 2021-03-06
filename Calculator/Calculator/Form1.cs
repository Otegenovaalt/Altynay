﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public double first;
        public double second;
        public double result;
        public double data;
        public string operation;
        public double s;
        public double minus;
        public double plus;
        public bool z;

        public Form1()
        {
            InitializeComponent();
            z = true;
        }

        private void num_click(object sender, EventArgs e)
        {
            display.Text = "";
            Button btn = sender as Button;
            display.Text += btn.Text; 

        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            first = double.Parse(display.Text);
            display.Text = "";
            operation = btn.Text;
            z = false;
        }

        private void result_click(object sender, EventArgs e)
        {
            if (!z) {
                second = double.Parse(display.Text);
            }
            /*else
            {
                first = result;
            }*/
            MessageBox.Show("first="+first+"\n"+"second="+second+"\n"+"result="+result + "\n" + "bool"+z);
            switch (operation)
            {
                
                case "+":
                    result = second + first;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                case "%":
                    result = (second * first) / 100;
                    break;
                case "x^y":
                    result = Math.Pow(first, second);
                    break;
                default:
                    break;
            }
            if(!z)
                z = true;
            
        }

        private void memory(object sender, EventArgs e)
        {
            data = double.Parse(display.Text);

        }

        private void Clear(object sender, EventArgs e)
        {
            display.Text = Convert.ToString(0);
            
        }

        private void zapyataya_click(object sender, EventArgs e)
        {
            if(!display.Text.Contains(","))
                display.Text = display.Text + ",";
        }

        private void koren(object sender, EventArgs e)
        {
            double k;
            k = Convert.ToDouble(display.Text);
            display.Text = Convert.ToString(Math.Sqrt(k));
        }

        private void kvadrat(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                double x;
                x = Convert.ToDouble(display.Text) * Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(x);
            }
            else
            {
                return;
            }
        }

        private void CEshka(object sender, EventArgs e)
        {
            display.Text = Convert.ToString(0);
            display.Clear();
        }

        private void Odin_delit(object sender, EventArgs e)
        {
            double o;
            o = Convert.ToDouble(display.Text);
            display.Text = Convert.ToString(1 / o);
        }

        private void Percent(object sender, EventArgs e)
        {

        }

        private void factorial(object sender, EventArgs e)
        {
            int fa;
            fa = int.Parse(display.Text);
            double f;
            f = 1;
            for(int i = fa; i>1; i--)
            {
                f *= i;
                display.Text = Convert.ToString(f);
            }
        }

        private void m_save(object sender, EventArgs e)
        {
            s = Convert.ToDouble(display.Text);
            Console.WriteLine(s + "Number in Memory");
        }

        private void back(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                display.Text = display.Text.Remove(display.Text.Length - 1, 1);
            }
            else
            {
                return;
            } 
        }

        private void MR(object sender, EventArgs e)
        {
            display.Text = s.ToString(); 
        }

        private void MC(object sender, EventArgs e)
        {
            s = 0;
        }

        private void Mplus(object sender, EventArgs e)
        {
            plus = double.Parse(display.Text);
            s = s + plus;
        }

        private void Mminus(object sender, EventArgs e)
        {
            minus = double.Parse(display.Text);
            s = s - minus;
        }
    }
}
