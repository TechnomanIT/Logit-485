namespace Log_It.Forms
{
    partial class UserForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxSMS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxEmail = new System.Windows.Forms.CheckBox();
            this.checkBoxSMS = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(284, 453);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 28);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(392, 453);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(49, 470);
            this.checkBoxActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(68, 21);
            this.checkBoxActive.TabIndex = 0;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(25, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Authority";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Administrator",
            "User",
            "Supervisor"});
            this.comboBoxRole.Location = new System.Drawing.Point(156, 210);
            this.comboBoxRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(280, 25);
            this.comboBoxRole.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxPassword.Location = new System.Drawing.Point(156, 174);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(280, 23);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(25, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxDescription.Location = new System.Drawing.Point(156, 60);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(280, 57);
            this.textBoxDescription.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(25, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Description:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxFullName.Location = new System.Drawing.Point(156, 28);
            this.textBoxFullName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(280, 23);
            this.textBoxFullName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(25, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Full Name:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxUserName.Location = new System.Drawing.Point(156, 142);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(280, 23);
            this.textBoxUserName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(25, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "User Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Enabled = false;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxEmail.Location = new System.Drawing.Point(156, 60);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(280, 23);
            this.textBoxEmail.TabIndex = 1;
            // 
            // textBoxSMS
            // 
            this.textBoxSMS.Enabled = false;
            this.textBoxSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxSMS.Location = new System.Drawing.Point(156, 128);
            this.textBoxSMS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSMS.Name = "textBoxSMS";
            this.textBoxSMS.Size = new System.Drawing.Size(280, 23);
            this.textBoxSMS.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Phone:";
            // 
            // checkBoxEmail
            // 
            this.checkBoxEmail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEmail.Location = new System.Drawing.Point(29, 25);
            this.checkBoxEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEmail.Name = "checkBoxEmail";
            this.checkBoxEmail.Size = new System.Drawing.Size(145, 28);
            this.checkBoxEmail.TabIndex = 0;
            this.checkBoxEmail.Text = "Email Notification";
            this.checkBoxEmail.UseVisualStyleBackColor = true;
            this.checkBoxEmail.CheckedChanged += new System.EventHandler(this.checkBoxEmail_CheckedChanged);
            // 
            // checkBoxSMS
            // 
            this.checkBoxSMS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSMS.Location = new System.Drawing.Point(29, 92);
            this.checkBoxSMS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSMS.Name = "checkBoxSMS";
            this.checkBoxSMS.Size = new System.Drawing.Size(145, 28);
            this.checkBoxSMS.TabIndex = 2;
            this.checkBoxSMS.Text = "SMS Notification";
            this.checkBoxSMS.UseVisualStyleBackColor = true;
            this.checkBoxSMS.CheckedChanged += new System.EventHandler(this.checkBoxSMS_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxSMS);
            this.groupBox1.Controls.Add(this.checkBoxSMS);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 276);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(457, 170);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFullName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxUserName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxRole);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxPassword);
            this.groupBox2.Controls.Add(this.textBoxDescription);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(35, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(457, 254);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Information";
            // 
            // UserForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(520, 527);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Setup";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource bindingSource1;
        public System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxRole;
        public System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBoxEmail;
        public System.Windows.Forms.TextBox textBoxSMS;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.CheckBox checkBoxEmail;
        public System.Windows.Forms.CheckBox checkBoxSMS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}