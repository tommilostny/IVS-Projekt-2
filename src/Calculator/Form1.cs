﻿using System;
using System.Windows.Forms;
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
			ActiveControl = textBox1;
			textBox1.SelectAll();
			textBox1.SelectionLength = 0;
			textBox1.SelectionStart++;
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
			textBox1.Text = (-1 * Convert.ToDouble(textBox1.Text)).ToString();
		}

		private void buttonPoint_Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Contains(","))
				textBox1.Text += ",";
		}

		private void buttonPrime_Click(object sender, EventArgs e)
		{
			label1.Text = textBox1.Text + ": nejbližší prvočíslo =";
			textBox1.Text = MathClass.FirstPrimeNumberAfterNumber(Convert.ToDouble(textBox1.Text)).ToString();
		}

		private void buttonFaktorial_Click(object sender, EventArgs e)
		{
			try
			{
				label1.Text = textBox1.Text + "! =";
				textBox1.Text = MathClass.Factorial(Convert.ToInt32(textBox1.Text)).ToString();
			}
			catch (FormatException)
			{
				Show_ErrorMessage("Faktoriál lze počítat pouze pro celá čísla.");
			}
			catch (OverflowException)
			{
				Show_ErrorMessage("Příliš vysoké číslo pro faktoriál.");
			}
			catch (ArgumentOutOfRangeException)
			{
				Show_ErrorMessage("Faktoriál lze počítat pouze větší než 0.");
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
			if (curr_operation != operations.NONE)
			{
				num2 = Convert.ToDouble(textBox1.Text);
				double result = 0;

				try //calculate currently set operation
				{
					switch (curr_operation)
					{
						case operations.ADD:
							result = MathClass.Add(num1, num2);
							break;
						case operations.SUB:
							result = MathClass.Subract(num1, num2);
							break;
						case operations.MUL:
							result = MathClass.Mul(num1, num2);
							break;
						case operations.DIV:
							result = MathClass.Divide(num1, num2);
							break;
						case operations.POW:
							result = MathClass.Pow(num1, num2);
							break;
						case operations.SQRT:
							result = MathClass.Sqrt(num1, num2);
							break;
					}
					textBox1.Text = Convert.ToDouble(result).ToString();
					label1.Text = num1.ToString() + ' ' + (char)curr_operation + ' ' + num2.ToString() + " =";

					curr_operation = operations.NONE;
					num1 = result;
				}
				catch (ArgumentOutOfRangeException)
				{
					Show_ErrorMessage("Zadejte kladné číslo nebo lichého odmocnitele");
				}
				catch (ArgumentException)
				{
					Show_ErrorMessage("Odmocnitel musí být větší než 0");
				}
				catch (Exception exception)
				{
					Show_ErrorMessage(exception.Message);
				}
			}
		}

		private void buttonTwoNumbersOperation_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == string.Empty || textBox1.Text == "-")
				textBox1.Text = "0";

			if (!num1_is_set)
			{
				num1 = Convert.ToDouble(textBox1.Text);
				num1_is_set = true;
			}
			//calculate previously set operation
			else if (curr_operation != operations.NONE)
				Calculate();

			//set a new operation based on sender button
			switch ((sender as Button).Text)
			{
				case "-": curr_operation = operations.SUB; break;
				case "+": curr_operation = operations.ADD; break;
				case "*": curr_operation = operations.MUL; break;
				case "/": curr_operation = operations.DIV; break;
				case "x^y": curr_operation = operations.POW; break;
				case "x√y": curr_operation = operations.SQRT; break;
			}
			label1.Text = num1.ToString() + ' ' + (char)curr_operation;
			textBox1.Text = "0";
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '-' || char.IsControl(e.KeyChar)) // Allowing digits
			{
				//Unset calculation label and num1 after previous calculation
				if (label1.Text.Contains("="))
				{
					label1.Text = string.Empty;
					num1_is_set = false;
				}

				// Allowing decimal numbers
				if (textBox1.Text.Contains(",") && e.KeyChar == ',')   // Max one ',' can be in number
				{
					e.Handled = true;
				}
				// Allowing negative numbers
				if (e.KeyChar == '-')
				{
					// Max one '-' can be in number, Cannot be negative 0
					if (!textBox1.Text.Contains("-"))
					{
						textBox1.Text = "-" + textBox1.Text;
						textBox1.SelectionStart = textBox1.Text.Length; // Set cursor to end of textbox
					}
					e.Handled = true;
				}
				//ENTER key like "buttonEquals"
				if (e.KeyChar == 13)
				{
					Calculate();
					e.Handled = true;
				}
			}
			else
			{
				e.Handled = true;
			}
		}

		private void buttonEquals_Click(object sender, EventArgs e)
		{
			Calculate();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//Remove leading zero character
			if (textBox1.Text.Length > 1 && textBox1.Text.Contains("0") && textBox1.Text[0] == '0' && textBox1.Text[1] != ',')
			{
				textBox1.Text = textBox1.Text.Remove(0, 1);
				textBox1.SelectionStart = textBox1.Text.Length;
			}
		}

		private void buttonSqrt_Click(object sender, EventArgs e)
		{
			try
			{
				label1.Text = '√' + textBox1.Text + " =";
				textBox1.Text = MathClass.Sqrt(2.0, Convert.ToDouble(textBox1.Text)).ToString();
			}
			catch (Exception exc)
			{
				Show_ErrorMessage(exc.Message);
			}
		}

		private void PowerOf2_button_Click(object sender, EventArgs e)
		{
			label1.Text = textBox1.Text + "² =";
			textBox1.Text = MathClass.Pow(Convert.ToDouble(textBox1.Text)).ToString();
		}

		private void ClearEntry_button_Click(object sender, EventArgs e)
		{
			textBox1.Text = "0";
		}

		private void Show_ErrorMessage(string message)
		{
			Clear();
			label1.Text = message;
		}
	}
}
