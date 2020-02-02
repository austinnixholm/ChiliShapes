namespace Chili_Environment_UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainControlPanel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.createCircleButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainControlPanel
            // 
            this.mainControlPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.mainControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainControlPanel.Controls.Add(this.button1);
            this.mainControlPanel.Controls.Add(this.createCircleButton);
            this.mainControlPanel.Location = new System.Drawing.Point(12, 31);
            this.mainControlPanel.Name = "mainControlPanel";
            this.mainControlPanel.Size = new System.Drawing.Size(351, 81);
            this.mainControlPanel.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.InfoText;
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(101, 18);
            this.title.TabIndex = 0;
            this.title.Text = "Main Controls";
            // 
            // createCircleButton
            // 
            this.createCircleButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.createCircleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("createCircleButton.BackgroundImage")));
            this.createCircleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.createCircleButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.createCircleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createCircleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createCircleButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.createCircleButton.Location = new System.Drawing.Point(6, 3);
            this.createCircleButton.Name = "createCircleButton";
            this.createCircleButton.Size = new System.Drawing.Size(75, 71);
            this.createCircleButton.TabIndex = 1;
            this.createCircleButton.UseVisualStyleBackColor = false;
            this.createCircleButton.Click += new System.EventHandler(this.createCircleButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(87, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 71);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.createSquareButtonClick);
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(12, 135);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(351, 96);
            this.console.TabIndex = 1;
            this.console.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Console";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(375, 234);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.console);
            this.Controls.Add(this.mainControlPanel);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Chili-Framework Communicator (v1.1.0)";
            this.mainControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainControlPanel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createCircleButton;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Label label1;
    }
}

