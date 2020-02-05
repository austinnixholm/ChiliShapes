namespace Chili_Environment_UI
{
    partial class CircleCommandDetails
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
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.chooseColButton = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.fillPanel = new System.Windows.Forms.Panel();
            this.fillColorBtn = new System.Windows.Forms.Button();
            this.fillColorPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.fillcheckBox = new System.Windows.Forms.CheckBox();
            this.fillPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point(58, 37);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(96, 20);
            this.radiusTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CIRCLE COMMAND";
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.colorPanel.Location = new System.Drawing.Point(15, 63);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(37, 24);
            this.colorPanel.TabIndex = 3;
            // 
            // chooseColButton
            // 
            this.chooseColButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseColButton.Location = new System.Drawing.Point(58, 63);
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
            this.cancelbtn.Location = new System.Drawing.Point(16, 201);
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
            this.submitButton.Location = new System.Drawing.Point(16, 160);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(139, 35);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Finish";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // fillPanel
            // 
            this.fillPanel.BackColor = System.Drawing.SystemColors.Control;
            this.fillPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fillPanel.Controls.Add(this.label3);
            this.fillPanel.Controls.Add(this.fillColorBtn);
            this.fillPanel.Controls.Add(this.fillColorPanel);
            this.fillPanel.Enabled = false;
            this.fillPanel.Location = new System.Drawing.Point(16, 109);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(138, 45);
            this.fillPanel.TabIndex = 7;
            // 
            // fillColorBtn
            // 
            this.fillColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillColorBtn.Location = new System.Drawing.Point(42, 17);
            this.fillColorBtn.Name = "fillColorBtn";
            this.fillColorBtn.Size = new System.Drawing.Size(91, 23);
            this.fillColorBtn.TabIndex = 9;
            this.fillColorBtn.Text = "Choose Color";
            this.fillColorBtn.UseVisualStyleBackColor = true;
            this.fillColorBtn.Click += new System.EventHandler(this.fillColorBtn_Click);
            // 
            // fillColorPanel
            // 
            this.fillColorPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.fillColorPanel.Location = new System.Drawing.Point(3, 17);
            this.fillColorPanel.Name = "fillColorPanel";
            this.fillColorPanel.Size = new System.Drawing.Size(33, 24);
            this.fillColorPanel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fill Settings";
            // 
            // fillcheckBox
            // 
            this.fillcheckBox.AutoSize = true;
            this.fillcheckBox.Location = new System.Drawing.Point(16, 91);
            this.fillcheckBox.Name = "fillcheckBox";
            this.fillcheckBox.Size = new System.Drawing.Size(72, 17);
            this.fillcheckBox.TabIndex = 8;
            this.fillcheckBox.Text = "Fill circle?";
            this.fillcheckBox.UseVisualStyleBackColor = true;
            this.fillcheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CircleCommandDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(167, 230);
            this.Controls.Add(this.fillcheckBox);
            this.Controls.Add(this.fillPanel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.chooseColButton);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radiusTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CircleCommandDetails";
            this.Text = "CircleCommandDetails";
            this.fillPanel.ResumeLayout(false);
            this.fillPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button chooseColButton;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Panel fillPanel;
        private System.Windows.Forms.Button fillColorBtn;
        private System.Windows.Forms.Panel fillColorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox fillcheckBox;
    }
}