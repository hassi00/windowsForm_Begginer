using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOperand1.Text) && !string.IsNullOrWhiteSpace(txtOperand2.Text))
            {
                double operand1 = double.Parse(txtOperand1.Text);
                double operand2 = double.Parse(txtOperand2.Text);
                string operatorSymbol = cmbOperator.SelectedItem.ToString();

                double result = 0;

                switch (operatorSymbol)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        result = operand1 / operand2;
                        break;
                }

                lblResult.Text = result.ToString();
            }

        }
    }
}
