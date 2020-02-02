using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chili_Environment_UI.IO;

namespace Chili_Environment_UI
{
    public partial class Main : Form
    {
        private Thread _mainLoop;
        private bool _running = false;
        private readonly string _consoleText = "\n\n\n\n\n\n\nWelcome!";
        public Main()
        {
            InitializeComponent();
            _running = true;
            _mainLoop = new Thread(Loop);
            _mainLoop.Start();
            ConsoleMessage(_consoleText, false);
        }

        private async void Loop()
        {
            await Task.Delay(1000);
            try
            {
                int cycle = 0;
                while (_running)
                {

                    MethodInvoker invoker = delegate()
                    {
                        if (cycle % 10 == 0)
                        {
                            if (Configuration.CurrentMessages.Count > 0)
                            {
                                List<string> errors = Configuration.CurrentMessages.ToList();
                                foreach (string error in errors)
                                    ConsoleMessage(error, true);
                                Configuration.CurrentMessages.Clear();
                            }

                            if (Configuration.Commands.Count > 0 && PipelineServer.Ready)
                            {
                                List<string> commands = Configuration.Commands.ToList();
                                foreach (string cmd in commands)
                                    PipelineServer.SendData(cmd);
                                Configuration.Commands.Clear();
                            }

                        }

                        cycle++;
                        if (cycle >= 200) cycle = 0;
                    };

                    Invoke(invoker);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ConsoleMessage(string message, bool endLine)
        {
            if (console.Text.Length != 0)
            {
                if (!console.Text[console.Text.Length - 1].Equals('\n'))
                    console.Text = "\n" + console.Text;
            }

            console.Text += message + (endLine ? "\n" : "");
            console.SelectionStart = console.Text.Length;
            console.ScrollToCaret();
        }

        private void createCircleButton_Click(object sender, EventArgs e)
        {
            CircleCommandDetails circleCommandPrompt = new CircleCommandDetails();

            Enabled = false;

            circleCommandPrompt.Location = new Point(Location.X + (Width - circleCommandPrompt.Width) / 2, Location.Y + (Height - circleCommandPrompt.Height) / 2);
            circleCommandPrompt.Show(this);
            circleCommandPrompt.Closing += PromptClosing;
        }

        private void PromptClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Enabled = true;
        }

        private void createSquareButtonClick(object sender, EventArgs e)
        {
            SquareCommandDetails squareCommandDetails = new SquareCommandDetails();

            Enabled = false;

            squareCommandDetails.Location = new Point(Location.X + (Width - squareCommandDetails.Width) / 2, Location.Y + (Height - squareCommandDetails.Height) / 2);
            squareCommandDetails.Show(this);
            squareCommandDetails.Closing += PromptClosing;
        }
    }
}
