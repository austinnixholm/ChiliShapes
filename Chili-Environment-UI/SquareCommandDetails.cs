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
    public partial class SquareCommandDetails : Form
    {
        public SquareCommandDetails()
        {
            InitializeComponent();
            LostFocus += SquareCommandDetails_LostFocus;
            StartPosition = FormStartPosition.Manual;
        }

        private void SquareCommandDetails_LostFocus(object sender, EventArgs e)
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
            int width, height;
            if (string.IsNullOrEmpty(heightTextbox.Text) || string.IsNullOrEmpty(widthTextBox.Text) || !int.TryParse(widthTextBox.Text, out width) || !int.TryParse(heightTextbox.Text, out height))
                return;
            if (width > 0 && height > 0)
            {
                Color pickedColor = colorPanel.BackColor;
                string command = "SQ=" + width + "," + height + "," + pickedColor.R + "," + pickedColor.G + "," + pickedColor.B;
                Configuration.Commands.Add(command);
                Close();
            }
            
        }
    }
}
