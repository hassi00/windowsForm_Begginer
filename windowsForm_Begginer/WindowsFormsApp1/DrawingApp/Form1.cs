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
    public partial class Form1 : Form
    {

        private bool drawing = false;
        private Point lastPoint;
        private Color currentColor = Color.Black;
        private int currentSize = 5;
        private bool eraser = false;

        // Controls for color, size, eraser and save
        private Button colorButton, sizeButton, eraserButton, saveButton;

        public Form1()
        {
            InitializeComponent();

            // Initialize buttons
            colorButton = new Button() { Text = "色", Location = new Point(10, 10) };
            colorButton.Click += ChangeColor;

            sizeButton = new Button() { Text = "太さ", Location = new Point(110, 10) };
            sizeButton.Click += ChangeSize;

            eraserButton = new Button() { Text = "消す", Location = new Point(210, 10) };
            eraserButton.Click += ToggleEraser;

            saveButton = new Button() { Text = "保存", Location = new Point(310, 10) };
            saveButton.Click += Save;

            // Add buttons to the form
            Controls.AddRange(new[] { colorButton, sizeButton, eraserButton, saveButton });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DrawingApp_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            lastPoint = e.Location;
        }

        private void DrawingApp_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void DrawingApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                using (Graphics g = CreateGraphics())
                {
                    using (Pen p = new Pen(eraser ? Color.White : currentColor, currentSize))
                    {
                        g.DrawLine(p, lastPoint, e.Location);
                    }
                }
                lastPoint = e.Location;
            }
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentColor = colorDialog.Color;
                }
            }
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            // Create and display a new InputBoxForm
            InputBoxForm form = new InputBoxForm();
            form.InputText = currentSize.ToString();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // If OK was clicked, parse the size
                int.TryParse(form.InputText, out currentSize);
            }
        }

        private void ToggleEraser(object sender, EventArgs e)
        {
            eraser = !eraser;
        }

        private void Save(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(this.Width, this.Height))
                    {
                        this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        bmp.Save(saveFileDialog.FileName);
                    }
                }
            }
        }
    }
}
