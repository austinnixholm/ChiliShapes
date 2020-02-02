using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chili_Environment_UI
{
    public partial class CircleCommandDetails : Form
    {
        public CircleCommandDetails()
        {
            InitializeComponent();
            LostFocus += CircleCommandDetails_LostFocus;
            StartPosition = FormStartPosition.Manual;
        }

        private void CircleCommandDetails_LostFocus(object sender, EventArgs e)
        {
            Focus();
        }

        private void chooseColButton_Click(object sender, EventArgs e)
        {
            ColorDialogExtension MyDialog = new ColorDialogExtension(Location.X, Location.Y);
            
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = Color.Blue;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                colorPanel.BackColor = MyDialog.Color;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int radius;
            if (string.IsNullOrEmpty(radiusTextBox.Text) || !int.TryParse(radiusTextBox.Text, out radius))
                return;
            if (radius > 0)
            {
                Color pickedColor = colorPanel.BackColor;
                string command = "CIR=" + radius + "," + pickedColor.R + "," + pickedColor.G + "," + pickedColor.B;
                Configuration.Commands.Add(command);
                Close();
            }
            
        }
    }
}
