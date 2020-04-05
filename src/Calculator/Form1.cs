using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MathLib;

namespace Calculator
{
    public partial class Form1 : Form
    {
        enum operations { NONE, ADD = '+', SUB = '-', MUL = '*', DIV = '/', POW = '^', SQRT = '√' };
        struct number
        {
            public double value;
            public bool is_set;
        }

        operations curr_operation;
        number num1, num2;

        public Form1()
        {
            InitializeComponent();
            Clear();
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

        private void Clear()
        {
            num1.value = num2.value = 0;
            num1.is_set = num2.is_set = false;
            curr_operation = operations.NONE;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = string.Empty;
            Clear();   
        }

        private void Equals()
        {
            num2.value = Convert.ToDouble(textBox1.Text);

            double result = 0;

            switch (curr_operation)
            {
                case operations.ADD:
                    break;
                case operations.SUB:
                    result = MathClass.Subract(num1.value, num2.value);
                    break;
                case operations.MUL:
                    break;
                case operations.DIV:
                    break;
                case operations.POW:
                    break;
                case operations.SQRT:
                    break;
            }
            textBox1.Text = Convert.ToDouble(result).ToString();
            label1.Text = num1.value.ToString() + ' ' + (char)curr_operation + ' ' + num2.value.ToString() + " =";

            curr_operation = operations.NONE;
            num1.value = result;
        }

        private void buttonTwoNumbersOperation_Click(object sender, EventArgs e)
        {
            if (curr_operation == operations.NONE)
            {
                num1.value = Convert.ToDouble(textBox1.Text);
                if (!num1.is_set)
                    num1.is_set = true;

                switch ((sender as Button).Text)
                {
                    case "-":   curr_operation = operations.SUB;    break;
                    case "+":   curr_operation = operations.ADD;    break;
                    case "*":   curr_operation = operations.MUL;    break;
                    case "/":   curr_operation = operations.DIV;    break;
                    case "x^y": curr_operation = operations.POW;    break;
                    case "√":   curr_operation = operations.SQRT;   break;
                }

                textBox1.Text = "0";
                label1.Text = num1.value.ToString() + ' ' + (char)curr_operation;
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Equals();
        }
    }
}