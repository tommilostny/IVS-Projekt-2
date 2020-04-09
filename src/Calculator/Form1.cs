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

        operations curr_operation;
        double num1 = 0, num2 = 0;
        bool num1_is_set = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            if (label1.Text.Contains("="))
                Clear();

            if (textBox1.Text == "0")
                textBox1.Text = string.Empty;

            textBox1.Text += (sender as Button).Text;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (label1.Text.Contains("="))
                Clear();

            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

            if (textBox1.Text == string.Empty)
                textBox1.Text = "0";
        }

        private void buttonNeg_Click(object sender, EventArgs e)
        {
            if (curr_operation == operations.NONE)
            {
                if (label1.Text == string.Empty)
                    label1.Text = textBox1.Text;

                label1.Text = "-(" + label1.Text.Replace(" =", string.Empty) + ") =";
            }

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
            textBox1.Text = "0";
            label1.Text = string.Empty;
            num1 = num2 = 0;
            num1_is_set = false;
            curr_operation = operations.NONE;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();   
        }

        private void Calculate()
        {
            num2 = Convert.ToDouble(textBox1.Text);
            double result = 0;

            try
            {
                switch (curr_operation)
                {
                    case operations.ADD:
                        //TODO: Insert add method here
                        break;
                    case operations.SUB:
                        result = MathClass.Subract(num1, num2);
                        break;
                    case operations.MUL:
                        //TODO: Insert multiplication method here
                        break;
                    case operations.DIV:
                        result = MathClass.Divide(num1, num2);
                        break;
                    case operations.POW:
                        //TODO: Insert power method here
                        break;
                    case operations.SQRT:
                        //TODO: Insert square root method here
                        break;
                }
                textBox1.Text = Convert.ToDouble(result).ToString();
                label1.Text = num1.ToString() + ' ' + (char)curr_operation + ' ' + num2.ToString() + " =";

                curr_operation = operations.NONE;
                num1 = result;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Nelze dělit nulou!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        private void buttonTwoNumbersOperation_Click(object sender, EventArgs e)
        {
            if (!num1_is_set)
            {
                num1 = Convert.ToDouble(textBox1.Text);
                num1_is_set = true;
            }

            switch ((sender as Button).Text)
            {
                case "-": curr_operation = operations.SUB; break;
                case "+": curr_operation = operations.ADD; break;
                case "*": curr_operation = operations.MUL; break;
                case "/": curr_operation = operations.DIV; break;
                case "x^y": curr_operation = operations.POW; break;
                case "√": curr_operation = operations.SQRT; break;
            }

            label1.Text = num1.ToString() + ' ' + (char)curr_operation;
            textBox1.Text = "0";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (curr_operation != operations.NONE)
                Calculate();
        }
    }
}