namespace Log_It.Forms
{
    partial class DeviceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceForm));
            this.groupBoxDevice = new System.Windows.Forms.GroupBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.checkBoxRh = new System.Windows.Forms.CheckBox();
            this.checkBoxAlaram = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxHumadity = new System.Windows.Forms.GroupBox();
            this.textBoxHUR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxHLR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxHUL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxHLL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTUR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTLR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTUL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTLL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxInstrument = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxlocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxDevice.SuspendLayout();
            this.groupBoxHumadity.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDevice
            // 
            this.groupBoxDevice.Controls.Add(this.checkBoxActive);
            this.groupBoxDevice.Controls.Add(this.label13);
            this.groupBoxDevice.Controls.Add(this.comboBox);
            this.groupBoxDevice.Controls.Add(this.checkBoxRh);
            this.groupBoxDevice.Controls.Add(this.checkBoxAlaram);
            this.groupBoxDevice.Controls.Add(this.label12);
            this.groupBoxDevice.Controls.Add(this.labelID);
            this.groupBoxDevice.Controls.Add(this.label11);
            this.groupBoxDevice.Controls.Add(this.groupBoxHumadity);
            this.groupBoxDevice.Controls.Add(this.groupBox2);
            this.groupBoxDevice.Controls.Add(this.textBoxInstrument);
            this.groupBoxDevice.Controls.Add(this.label2);
            this.groupBoxDevice.Controls.Add(this.textBoxlocation);
            this.groupBoxDevice.Controls.Add(this.label1);
            this.groupBoxDevice.Location = new System.Drawing.Point(16, 15);
            this.groupBoxDevice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDevice.Name = "groupBoxDevice";
            this.groupBoxDevice.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDevice.Size = new System.Drawing.Size(713, 155);
            this.groupBoxDevice.TabIndex = 2;
            this.groupBoxDevice.TabStop = false;
            this.groupBoxDevice.Text = "Device";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(19, 122);
            this.checkBoxActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(68, 21);
            this.checkBoxActive.TabIndex = 5;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 89);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 19;
            this.label13.Text = "Minutes";
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(101, 85);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(115, 24);
            this.comboBox.TabIndex = 2;
            // 
            // checkBoxRh
            // 
            this.checkBoxRh.AutoSize = true;
            this.checkBoxRh.Checked = true;
            this.checkBoxRh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRh.Location = new System.Drawing.Point(187, 122);
            this.checkBoxRh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxRh.Name = "checkBoxRh";
            this.checkBoxRh.Size = new System.Drawing.Size(90, 21);
            this.checkBoxRh.TabIndex = 4;
            this.checkBoxRh.Text = "Rh Active";
            this.checkBoxRh.UseVisualStyleBackColor = true;
            this.checkBoxRh.Visible = false;
            this.checkBoxRh.CheckedChanged += new System.EventHandler(this.checkBoxRh_CheckedChanged);
            // 
            // checkBoxAlaram
            // 
            this.checkBoxAlaram.AutoSize = true;
            this.checkBoxAlaram.Checked = true;
            this.checkBoxAlaram.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlaram.Location = new System.Drawing.Point(101, 122);
            this.checkBoxAlaram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAlaram.Name = "checkBoxAlaram";
            this.checkBoxAlaram.Size = new System.Drawing.Size(74, 21);
            this.checkBoxAlaram.TabIndex = 3;
            this.checkBoxAlaram.Text = "Alaram";
            this.checkBoxAlaram.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 91);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 17);
            this.label12.TabIndex = 15;
            this.label12.Text = "Interval:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(107, 17);
            this.labelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 17);
            this.labelID.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "ID:";
            // 
            // groupBoxHumadity
            // 
            this.groupBoxHumadity.Controls.Add(this.textBoxHUR);
            this.groupBoxHumadity.Controls.Add(this.label7);
            this.groupBoxHumadity.Controls.Add(this.textBoxHLR);
            this.groupBoxHumadity.Controls.Add(this.label8);
            this.groupBoxHumadity.Controls.Add(this.textBoxHUL);
            this.groupBoxHumadity.Controls.Add(this.label9);
            this.groupBoxHumadity.Controls.Add(this.textBoxHLL);
            this.groupBoxHumadity.Controls.Add(this.label10);
            this.groupBoxHumadity.Location = new System.Drawing.Point(500, 17);
            this.groupBoxHumadity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxHumadity.Name = "groupBoxHumadity";
            this.groupBoxHumadity.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxHumadity.Size = new System.Drawing.Size(200, 126);
            this.groupBoxHumadity.TabIndex = 12;
            this.groupBoxHumadity.TabStop = false;
            this.groupBoxHumadity.Text = "Humadity";
            // 
            // textBoxHUR
            // 
            this.textBoxHUR.Location = new System.Drawing.Point(117, 92);
            this.textBoxHUR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHUR.Name = "textBoxHUR";
            this.textBoxHUR.Size = new System.Drawing.Size(73, 22);
            this.textBoxHUR.TabIndex = 3;
            this.textBoxHUR.Tag = "Upper";
            this.textBoxHUR.Text = "100";
            this.textBoxHUR.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Upper Range:";
            // 
            // textBoxHLR
            // 
            this.textBoxHLR.Location = new System.Drawing.Point(117, 68);
            this.textBoxHLR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHLR.Name = "textBoxHLR";
            this.textBoxHLR.Size = new System.Drawing.Size(73, 22);
            this.textBoxHLR.TabIndex = 2;
            this.textBoxHLR.Tag = "Lower";
            this.textBoxHLR.Text = "0";
            this.textBoxHLR.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Lower Range:";
            // 
            // textBoxHUL
            // 
            this.textBoxHUL.Location = new System.Drawing.Point(117, 43);
            this.textBoxHUL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHUL.Name = "textBoxHUL";
            this.textBoxHUL.Size = new System.Drawing.Size(73, 22);
            this.textBoxHUL.TabIndex = 1;
            this.textBoxHUL.Tag = "Upper";
            this.textBoxHUL.Text = "100";
            this.textBoxHUL.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Upper Limit";
            // 
            // textBoxHLL
            // 
            this.textBoxHLL.Location = new System.Drawing.Point(117, 18);
            this.textBoxHLL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHLL.Name = "textBoxHLL";
            this.textBoxHLL.Size = new System.Drawing.Size(73, 22);
            this.textBoxHLL.TabIndex = 0;
            this.textBoxHLL.Tag = "Lower";
            this.textBoxHLL.Text = "0";
            this.textBoxHLL.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Lower Limit";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxTUR);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxTLR);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxTUL);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxTLL);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(292, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(200, 126);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temperature";
            // 
            // textBoxTUR
            // 
            this.textBoxTUR.Location = new System.Drawing.Point(117, 92);
            this.textBoxTUR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTUR.Name = "textBoxTUR";
            this.textBoxTUR.Size = new System.Drawing.Size(73, 22);
            this.textBoxTUR.TabIndex = 3;
            this.textBoxTUR.Tag = "Upper";
            this.textBoxTUR.Text = "100";
            this.textBoxTUR.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Upper Range:";
            // 
            // textBoxTLR
            // 
            this.textBoxTLR.Location = new System.Drawing.Point(117, 68);
            this.textBoxTLR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTLR.Name = "textBoxTLR";
            this.textBoxTLR.Size = new System.Drawing.Size(73, 22);
            this.textBoxTLR.TabIndex = 2;
            this.textBoxTLR.Tag = "Lower";
            this.textBoxTLR.Text = "0";
            this.textBoxTLR.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Lower Range:";
            // 
            // textBoxTUL
            // 
            this.textBoxTUL.Location = new System.Drawing.Point(117, 43);
            this.textBoxTUL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTUL.Name = "textBoxTUL";
            this.textBoxTUL.Size = new System.Drawing.Size(73, 22);
            this.textBoxTUL.TabIndex = 1;
            this.textBoxTUL.Tag = "Upper";
            this.textBoxTUL.Text = "100";
            this.textBoxTUL.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Upper Limit:";
            // 
            // textBoxTLL
            // 
            this.textBoxTLL.Location = new System.Drawing.Point(117, 18);
            this.textBoxTLL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTLL.Name = "textBoxTLL";
            this.textBoxTLL.Size = new System.Drawing.Size(73, 22);
            this.textBoxTLL.TabIndex = 0;
            this.textBoxTLL.Tag = "Lower";
            this.textBoxTLL.Text = "0";
            this.textBoxTLL.TextChanged += new System.EventHandler(this.textBoxTLL_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lower Limit:";
            // 
            // textBoxInstrument
            // 
            this.textBoxInstrument.Location = new System.Drawing.Point(101, 60);
            this.textBoxInstrument.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInstrument.Name = "textBoxInstrument";
            this.textBoxInstrument.Size = new System.Drawing.Size(181, 22);
            this.textBoxInstrument.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Instrument:";
            // 
            // textBoxlocation
            // 
            this.textBoxlocation.Location = new System.Drawing.Point(101, 36);
            this.textBoxlocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxlocation.Name = "textBoxlocation";
            this.textBoxlocation.Size = new System.Drawing.Size(181, 22);
            this.textBoxlocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 177);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(508, 177);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 218);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceForm_FormClosing);
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            this.groupBoxDevice.ResumeLayout(false);
            this.groupBoxDevice.PerformLayout();
            this.groupBoxHumadity.ResumeLayout(false);
            this.groupBoxHumadity.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDevice;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox comboBox;
        public System.Windows.Forms.CheckBox checkBoxRh;
        public System.Windows.Forms.CheckBox checkBoxAlaram;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxHumadity;
        public System.Windows.Forms.TextBox textBoxHUR;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBoxHLR;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBoxHUL;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxHLL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox textBoxTUR;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxTLR;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBoxTUL;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxTLL;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxInstrument;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxlocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.CheckBox checkBoxActive;

    }
}