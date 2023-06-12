using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add new todo item
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                lstTodoItems.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete selected todo item
            if (lstTodoItems.SelectedIndex != -1)
            {
                lstTodoItems.Items.RemoveAt(lstTodoItems.SelectedIndex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all todo items
            lstTodoItems.Items.Clear();
        }
    }
}
