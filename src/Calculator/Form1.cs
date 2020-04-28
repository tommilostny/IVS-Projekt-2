using System;
using System.Windows.Forms;
using MathLib;

/// <summary>
/// Calculator Windows Forms app (.NET Framework 4.7.2)
/// </summary>
namespace Calculator
{
	/// <summary>
	/// Main Windows Forms window for the calculator app.
	/// </summary>
	public partial class Form1 : Form
	{
		/// <summary>
		/// Enum constants representing set operation.
		/// </summary>
		public enum operations
		{ 
			NONE, /*!< No operation is set */
			ADD = '+', /*!< Addition */
			SUB = '-', /*!< Subtraction */
			MUL = '*', /*!< Multiplication */
			DIV = '/', /*!< Division */
			POW = '^', /*!< Power */
			SQRT = '√' /*!< Square root */
		};

		/// <value>Global variable that represents currently set operation</value>
		private operations curr_operation;

		/// <value>First number in performing calculations</value>
		private double num1 = 0;

		/// <value>Second number in performing calculations</value>
		private double num2 = 0;

		/// <value>State of global variable num1</value>
		/// <remarks><c>true</c>: num1 is set and needs to be precalculated before setting new operation</remarks>
		/// <remarks><c>false</c>: num1 is not set and is ready for loading new value</remarks>
		private bool num1_is_set = false;

		/// <summary>
		/// Calculator initial enter point.
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			Focus_textBox1();
		}

		/// <summary>
		/// Focus on the textbox input field.
		/// </summary>
		private void Focus_textBox1()
		{
			ActiveControl = textBox1;
			textBox1.SelectAll();
			textBox1.SelectionLength = 0;
			textBox1.SelectionStart = textBox1.Text.Length;
		}

		/// <summary>
		/// Numbers keypad button click event.
		/// </summary>
		private void buttonNumber_Click(object sender, EventArgs e)
		{
			if (label1.Text.Contains("="))
				Clear();

			if (textBox1.Text == "0")
				textBox1.Text = string.Empty;

			textBox1.Text += (sender as Button).Text;
		}

		/// <summary>
		/// Backspace (eraser) button event.
		/// Removes last character int textBox like backspace keyboard button.
		/// </summary>
		private void buttonBackspace_Click(object sender, EventArgs e)
		{
			if (label1.Text.Contains("="))
				Clear();

			textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

			if (textBox1.Text == string.Empty)
				textBox1.Text = "0";
		}

		/// <summary>
		/// Changes sign of number in textBox.
		/// If textBox is empty, insert '-' sign (start of a negative number).
		/// </summary>
		private void textBox1_SignChange()
		{
			if (textBox1.Text == string.Empty || textBox1.Text == "-")
			{
				textBox1.Text = "-";
				textBox1.SelectionStart++;
				return;
			}

			double number = -(Convert.ToDouble(textBox1.Text));
			if (label1.Text.Contains("="))
			{
				Clear();
			}
			textBox1.Text = number.ToString();
		}

		/// <summary>
		/// +/- button event.
		/// Changes sign of number in textBox.
		/// </summary>
		private void buttonNeg_Click(object sender, EventArgs e)
		{
			textBox1_SignChange();
		}

		/// <summary>
		/// Decimal point button click event.
		/// Inserts decimal point into textBox.
		/// </summary>
		private void buttonPoint_Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Contains(","))
				textBox1.Text += ",";
		}

		/// <summary>
		/// Prime number button click event.
		/// Calls math library method to calculate closest prime number after input number.
		/// </summary>
		private void buttonPrime_Click(object sender, EventArgs e)
		{
			label1.Text = textBox1.Text + ": nejbližší prvočíslo =";
			textBox1.Text = MathClass.FirstPrimeNumberAfterNumber(Convert.ToDouble(textBox1.Text)).ToString();
		}

		/// <summary>
		/// n! (factorial) button click event.
		/// Calls math library method to calculate factorial of input number.
		/// </summary>
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

		/// <summary>
		/// Clears and resets calculator.
		/// </summary>
		private void Clear()
		{
			textBox1.Text = "0";
			label1.Text = string.Empty;
			num1 = num2 = 0;
			num1_is_set = false;
			curr_operation = operations.NONE;
		}

		/// <summary>
		/// 'C' (clear) button click event used to call the Clear() method.
		/// </summary>
		private void buttonClear_Click(object sender, EventArgs e)
		{
			Clear();
			Focus_textBox1();
		}

		/// <summary>
		/// Calculates currently set operation.
		/// Takes saved num1 and performs operation with num2 from textBox.
		/// Result is printed into textBox.
		/// </summary>
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
							result = MathClass.Subtract(num1, num2);
							break;
						case operations.MUL:
							result = MathClass.Multiply(num1, num2);
							break;
						case operations.DIV:
							result = MathClass.Divide(num1, num2);
							break;
						case operations.POW:
							result = MathClass.Power(num1, num2);
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

		/// <summary>
		/// Sets current operation base on input string.
		/// </summary>
		/// <param name="op_text">String operator text value</param>
		private void Set_TwoNumbersOperation(string op_text)
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
			switch (op_text)
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
			Focus_textBox1();
		}

		/// <summary>
		/// Click event used by buttons that set operation which takes two number inputs.
		/// Operation is set based on button.Text property.
		/// </summary>
		private void buttonTwoNumbersOperation_Click(object sender, EventArgs e)
		{
			Set_TwoNumbersOperation((sender as Button).Text);
		}

		/// <summary>
		/// Event to check keyboard input into textBox.
		/// Only numbers, sign and decimal point are allowed.
		/// ENTER key is allowed to perform calculation after setting second number.
		/// </summary>
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) || e.KeyChar == ',' || char.IsControl(e.KeyChar)) // Allowing digits
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
				//ENTER key like "buttonEquals"
				if (e.KeyChar == 13)
				{
					Calculate();
					Focus_textBox1();
					e.Handled = true;
				}
			}
			else
			{
				switch (e.KeyChar)
				{
					case '+': case '*': case '/':
						//Set operation based on key char
						Set_TwoNumbersOperation(e.KeyChar.ToString());
						break;
					case '-':
						//Cursor is in front of a number in textBox - change sign
						if (textBox1.SelectionStart == 0)
							textBox1_SignChange();

						//Set subtraction as current operation
						else
							Set_TwoNumbersOperation("-");
						break;
					case 'c':
						Clear();
						Focus_textBox1();
						break;
				}
				e.Handled = true;
			}
		}

		/// <summary>
		/// '=' button click event to perform calculation for set operation.
		/// </summary>
		private void buttonEquals_Click(object sender, EventArgs e)
		{
			Calculate();
		}

		/// <summary>
		/// Used to check textBox text for leading zero.
		/// </summary>
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//Remove leading zero character
			if (textBox1.Text.Length > 1 && textBox1.Text.Contains("0") && textBox1.Text[0] == '0' && textBox1.Text[1] != ',')
			{
				textBox1.Text = textBox1.Text.Remove(0, 1);
				textBox1.SelectionStart = textBox1.Text.Length;
			}
		}

		/// <summary>
		/// Second square root button click event.
		/// Calls math library Sqrt method with 2 as square root degree.
		/// </summary>
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

		/// <summary>
		/// Second power button click event.
		/// Calls math library MathClass.Pow() method with default degree (2).
		/// </summary>
		private void PowerOf2_button_Click(object sender, EventArgs e)
		{
			label1.Text = textBox1.Text + "² =";
			textBox1.Text = MathClass.Power(Convert.ToDouble(textBox1.Text)).ToString();
		}

		/// <summary>
		/// 'CE' button click event to clear entry.
		/// </summary>
		private void ClearEntry_button_Click(object sender, EventArgs e)
		{
			textBox1.Text = "0";
			Focus_textBox1();
		}

		/// <summary>
		/// Resets calculation (with Clear()) and prints error message.
		/// Used in try-catch blocks to print exception errors.
		/// </summary>
		/// <param name="message">Error message</param>
		private void Show_ErrorMessage(string message)
		{
			Clear();
			label1.Text = message;
		}
	}
}
