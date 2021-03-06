﻿namespace Chili_Environment_UI
{
    partial class SquareCommandDetails
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
            this.heightTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.chooseColButton = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // heightTextbox
            // 
            this.heightTextbox.Location = new System.Drawing.Point(56, 63);
            this.heightTextbox.Name = "heightTextbox";
            this.heightTextbox.Size = new System.Drawing.Size(96, 20);
            this.heightTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQUARE COMMAND";
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.colorPanel.Location = new System.Drawing.Point(15, 91);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(37, 24);
            this.colorPanel.TabIndex = 3;
            // 
            // chooseColButton
            // 
            this.chooseColButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseColButton.Location = new System.Drawing.Point(58, 91);
            this.chooseColButton.Name = "chooseColButton";
            this.chooseColButton.Size = new System.Drawing.Size(96, 23);
            this.chooseColButton.TabIndex = 4;
            this.chooseColButton.Text = "Choose Color";
            this.chooseColButton.UseVisualStyleBackColor = true;
            this.chooseColButton.Click += new System.EventHandler(this.chooseColButton_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Location = new System.Drawing.Point(15, 162);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(139, 23);
            this.cancelbtn.TabIndex = 5;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Location = new System.Drawing.Point(15, 121);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(139, 35);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Finish";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Height";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(56, 37);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(96, 20);
            this.widthTextBox.TabIndex = 7;
            // 
            // SquareCommandDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(167, 191);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.chooseColButton);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heightTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SquareCommandDetails";
            this.Text = "CircleCommandDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button chooseColButton;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox widthTextBox;
    }
}