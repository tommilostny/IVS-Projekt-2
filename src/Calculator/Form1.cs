using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathLib;

namespace Calculator
{
    public partial class Form1 : Form
    {
        //Funkce z matematické knihovny voláme v událostech tlačítek
        double num1 = 0, num2 = 0;
        char operation = char.MinValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = string.Empty;

            textBox1.Text += (sender as Button).Text;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

            if (textBox1.Text == string.Empty)
                textBox1.Text = "0";
        }

        private void buttonNeg_Click(object sender, EventArgs e)
        {
            textBox1.Text = (-1 * Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
                textBox1.Text += ",";
        }

        private void buttonPrime_Click(object sender, EventArgs e)
        {
            long number=Convert.ToInt64(textBox1.Text);
            number = MathClass.FirstPrimeNumberAfterNumber(number);
            textBox1.Text = number.ToString();
        }

        private void buttonFaktorial_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = MathClass.Factorial(Convert.ToInt64(textBox1.Text)).ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Faktoriál lze počítat pouze pro čísla větší než 0.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Faktoriál lze počítat pouze pro celá čísla.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            num1 = num2 = 0;
            operation = char.MinValue;
            textBox1.Text = "0";
        }
    }
}