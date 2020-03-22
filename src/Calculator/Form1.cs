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
        MathClass math = new MathClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
