using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class InputBoxForm : Form
    {
        public InputBoxForm()
        {
            InitializeComponent();
        }

        private void InputBoxForm_Load(object sender, EventArgs e)
        {

        }

        public string InputText
        {
            get { return this.inputTextBox.Text; }
            set { this.inputTextBox.Text = value; }
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
