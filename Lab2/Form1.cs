using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        string data_in = string.Empty;
        string first_operand = string.Empty;
        string second_operand = string.Empty;
        char operation;
        double data_out = 0.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void zero_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 0;
            this.textBox.Text += data_in;
        }

        private void one_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 1;
            this.textBox.Text += data_in;
        }

        private void two_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 2;
            this.textBox.Text += data_in;
        }

        private void three_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 3;
            this.textBox.Text += data_in;
        }

        private void four_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 4;
            this.textBox.Text += data_in;
        }

        private void five_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 5;
            this.textBox.Text += data_in;
        }

        private void six_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 6;
        }

        private void seven_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 7;
            this.textBox.Text += data_in;
        }

        private void eight_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 8;
            this.textBox.Text += data_in;
        }

        private void nine_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += 9;
            this.textBox.Text += data_in;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            data_in += ".";
            this.textBox.Text += data_in;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            first_operand = data_in;
            operation = '+';
            data_in = string.Empty;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            first_operand = data_in;
            operation = '-';
            data_in = string.Empty;
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            first_operand = data_in;
            operation = '*';
            data_in = string.Empty;
        }

        private void division_Click(object sender, EventArgs e)
        {
            first_operand = data_in;
            operation = '/';
            data_in = string.Empty;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            second_operand = data_in;
            double num1, num2;
            double.TryParse(first_operand, out num1);
            double.TryParse(second_operand, out num2);

            this.textBox.Text = "";
            this.data_in = string.Empty;
            this.first_operand = string.Empty;
            this.second_operand = string.Empty;

            if (operation == '+')
            {
                data_out = num1 + num2;
                textBox.Text = data_out.ToString();
            }
            if (operation == '-')
            {
                data_out = num1 - num2;
                textBox.Text = data_out.ToString();
            }
            if (operation == '*')
            {
                data_out = num1 * num2;
                textBox.Text = data_out.ToString();
            }
            if (operation == '/')
            {
                if (num2 != 0)
                {
                    data_out = num1 / num2;
                    textBox.Text = data_out.ToString();
                }
                else
                {
                    textBox.Text = "DIV/Zero!";
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.textBox.Text = "";
            this.data_in = string.Empty;
            this.first_operand = string.Empty;
            this.second_operand = string.Empty;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
