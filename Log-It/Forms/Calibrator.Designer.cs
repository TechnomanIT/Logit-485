namespace Log_It.Forms
{
    partial class Calibrator
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
            this.comboBoxdevices = new System.Windows.Forms.ComboBox();
            this.textBoxoffset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxtype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labellocation = new System.Windows.Forms.Label();
            this.labelinstrument = new System.Windows.Forms.Label();
            this.labelupperlimit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labellowerlimit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labeldatetime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxdevices
            // 
            this.comboBoxdevices.FormattingEnabled = true;
            this.comboBoxdevices.Location = new System.Drawing.Point(150, 13);
            this.comboBoxdevices.Name = "comboBoxdevices";
            this.comboBoxdevices.Size = new System.Drawing.Size(155, 21);
            this.comboBoxdevices.TabIndex = 0;
            this.comboBoxdevices.SelectedValueChanged += new System.EventHandler(this.comboBoxdevices_SelectedValueChanged);
            // 
            // textBoxoffset
            // 
            this.textBoxoffset.Location = new System.Drawing.Point(150, 210);
            this.textBoxoffset.Name = "textBoxoffset";
            this.textBoxoffset.Size = new System.Drawing.Size(155, 20);
            this.textBoxoffset.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Device Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Device Type:";
            // 
            // comboBoxtype
            // 
            this.comboBoxtype.FormattingEnabled = true;
            this.comboBoxtype.Location = new System.Drawing.Point(149, 99);
            this.comboBoxtype.Name = "comboBoxtype";
            this.comboBoxtype.Size = new System.Drawing.Size(155, 21);
            this.comboBoxtype.TabIndex = 6;
            this.comboBoxtype.SelectedIndexChanged += new System.EventHandler(this.comboBoxtype_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Instrument:";
            // 
            // labellocation
            // 
            this.labellocation.AutoSize = true;
            this.labellocation.Location = new System.Drawing.Point(146, 46);
            this.labellocation.Name = "labellocation";
            this.labellocation.Size = new System.Drawing.Size(0, 13);
            this.labellocation.TabIndex = 4;
            // 
            // labelinstrument
            // 
            this.labelinstrument.AutoSize = true;
            this.labelinstrument.Location = new System.Drawing.Point(146, 72);
            this.labelinstrument.Name = "labelinstrument";
            this.labelinstrument.Size = new System.Drawing.Size(0, 13);
            this.labelinstrument.TabIndex = 8;
            // 
            // labelupperlimit
            // 
            this.labelupperlimit.AutoSize = true;
            this.labelupperlimit.Location = new System.Drawing.Point(146, 132);
            this.labelupperlimit.Name = "labelupperlimit";
            this.labelupperlimit.Size = new System.Drawing.Size(0, 13);
            this.labelupperlimit.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Upper Limit:";
            // 
            // labellowerlimit
            // 
            this.labellowerlimit.AutoSize = true;
            this.labellowerlimit.Location = new System.Drawing.Point(146, 158);
            this.labellowerlimit.Name = "labellowerlimit";
            this.labellowerlimit.Size = new System.Drawing.Size(0, 13);
            this.labellowerlimit.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Lower Limit:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Offset:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labeldatetime
            // 
            this.labeldatetime.AutoSize = true;
            this.labeldatetime.Location = new System.Drawing.Point(146, 186);
            this.labeldatetime.Name = "labeldatetime";
            this.labeldatetime.Size = new System.Drawing.Size(0, 13);
            this.labeldatetime.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Last Date of Calibration:";
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(148, 244);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(75, 23);
            this.buttonsave.TabIndex = 3;
            this.buttonsave.Text = "Save";
            this.buttonsave.UseVisualStyleBackColor = true;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // Calibrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 286);
            this.Controls.Add(this.labeldatetime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labellowerlimit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelupperlimit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelinstrument);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxtype);
            this.Controls.Add(this.labellocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxoffset);
            this.Controls.Add(this.comboBoxdevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Calibrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calibrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxdevices;
        private System.Windows.Forms.TextBox textBoxoffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxtype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labellocation;
        private System.Windows.Forms.Label labelinstrument;
        private System.Windows.Forms.Label labelupperlimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labellowerlimit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labeldatetime;
        private System.Windows.Forms.Label label6;
    }
}