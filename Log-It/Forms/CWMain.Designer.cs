namespace Log_It.Forms
{
    partial class CWMain
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttoncancel = new System.Windows.Forms.Button();
            this.listBoxDevice = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.description = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(270, 221);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Next >>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttoncancel
            // 
            this.buttoncancel.Location = new System.Drawing.Point(351, 221);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(75, 23);
            this.buttoncancel.TabIndex = 1;
            this.buttoncancel.Text = "Cancel";
            this.buttoncancel.UseVisualStyleBackColor = true;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // listBoxDevice
            // 
            this.listBoxDevice.Enabled = false;
            this.listBoxDevice.FormattingEnabled = true;
            this.listBoxDevice.Location = new System.Drawing.Point(10, 12);
            this.listBoxDevice.Name = "listBoxDevice";
            this.listBoxDevice.Size = new System.Drawing.Size(138, 199);
            this.listBoxDevice.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(154, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "This wizard will help you to configure your connected device. ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(157, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(93, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "option";
            this.radioButton3.Text = "Delete Device";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "option";
            this.radioButton2.Text = "Edit Device";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "option";
            this.radioButton1.Text = "Add Device";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.description.Location = new System.Drawing.Point(154, 168);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(272, 32);
            this.description.TabIndex = 16;
            this.description.Text = "This wizard will help you to configure your connected device. ";
            // 
            // CWMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 269);
            this.ControlBox = false;
            this.Controls.Add(this.description);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxDevice);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.buttonNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CWMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Wizard: Main";
            this.Load += new System.EventHandler(this.CWMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttoncancel;
        private System.Windows.Forms.ListBox listBoxDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label description;
    }
}