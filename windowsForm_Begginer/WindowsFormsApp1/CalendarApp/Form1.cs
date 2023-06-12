using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalendarApp
{
    public partial class Form1 : Form
    {

        private Dictionary<DateTime, string> schedule;

        public Form1()
        {
            InitializeComponent();
            schedule = new Dictionary<DateTime, string>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                return;
            }

            if (schedule.ContainsKey(selectedDate))
            {
                schedule[selectedDate] = richTextBox1.Text;
            }
            else
            {
                schedule.Add(selectedDate, richTextBox1.Text);
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            if (schedule.ContainsKey(selectedDate))
            {
                richTextBox1.Text = schedule[selectedDate];
            }
            else
            {
                richTextBox1.Text = "";
            }
        }

        private void buttonDelete_Click(object sender, MouseEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            if (schedule.ContainsKey(selectedDate))
            {
                schedule.Remove(selectedDate);
                richTextBox1.Text = "";
            }
        }
    }
}
