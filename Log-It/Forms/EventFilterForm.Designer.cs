namespace Log_It.Forms
{
    partial class EventFilterForm
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
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBoxEvents = new System.Windows.Forms.GroupBox();
            this.checkedListBoxEvents = new System.Windows.Forms.CheckedListBox();
            this.radioButtonFilterEvents = new System.Windows.Forms.RadioButton();
            this.radioButtonAllEvents = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.checkedListBoxUsers = new System.Windows.Forms.CheckedListBox();
            this.radioButtonFilterUser = new System.Windows.Forms.RadioButton();
            this.radioButtonAlluser = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBoxDateTime = new System.Windows.Forms.GroupBox();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonFilterDate = new System.Windows.Forms.RadioButton();
            this.radioButtonAllDate = new System.Windows.Forms.RadioButton();
            this.radioButtonAllLogs = new System.Windows.Forms.RadioButton();
            this.radioButtonFilterLogs = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxFilter.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBoxEvents.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxUser.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxDateTime.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.groupBox7);
            this.groupBoxFilter.Controls.Add(this.groupBox5);
            this.groupBoxFilter.Controls.Add(this.groupBox3);
            this.groupBoxFilter.Enabled = false;
            this.groupBoxFilter.Location = new System.Drawing.Point(23, 87);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(797, 325);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBoxEvents);
            this.groupBox7.Controls.Add(this.radioButtonFilterEvents);
            this.groupBox7.Controls.Add(this.radioButtonAllEvents);
            this.groupBox7.Location = new System.Drawing.Point(437, 29);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(348, 288);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select Events";
            // 
            // groupBoxEvents
            // 
            this.groupBoxEvents.Controls.Add(this.checkedListBoxEvents);
            this.groupBoxEvents.Enabled = false;
            this.groupBoxEvents.Location = new System.Drawing.Point(69, 19);
            this.groupBoxEvents.Name = "groupBoxEvents";
            this.groupBoxEvents.Size = new System.Drawing.Size(259, 261);
            this.groupBoxEvents.TabIndex = 3;
            this.groupBoxEvents.TabStop = false;
            this.groupBoxEvents.Text = "Events";
            // 
            // checkedListBoxEvents
            // 
            this.checkedListBoxEvents.FormattingEnabled = true;
            this.checkedListBoxEvents.Location = new System.Drawing.Point(24, 20);
            this.checkedListBoxEvents.Name = "checkedListBoxEvents";
            this.checkedListBoxEvents.Size = new System.Drawing.Size(216, 229);
            this.checkedListBoxEvents.TabIndex = 7;
            // 
            // radioButtonFilterEvents
            // 
            this.radioButtonFilterEvents.AutoSize = true;
            this.radioButtonFilterEvents.Location = new System.Drawing.Point(16, 49);
            this.radioButtonFilterEvents.Name = "radioButtonFilterEvents";
            this.radioButtonFilterEvents.Size = new System.Drawing.Size(47, 17);
            this.radioButtonFilterEvents.TabIndex = 2;
            this.radioButtonFilterEvents.Text = "Filter";
            this.radioButtonFilterEvents.UseVisualStyleBackColor = true;
            this.radioButtonFilterEvents.CheckedChanged += new System.EventHandler(this.radioButtonFilterEvents_CheckedChanged);
            // 
            // radioButtonAllEvents
            // 
            this.radioButtonAllEvents.AutoSize = true;
            this.radioButtonAllEvents.Checked = true;
            this.radioButtonAllEvents.Location = new System.Drawing.Point(16, 26);
            this.radioButtonAllEvents.Name = "radioButtonAllEvents";
            this.radioButtonAllEvents.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAllEvents.TabIndex = 1;
            this.radioButtonAllEvents.TabStop = true;
            this.radioButtonAllEvents.Text = "All";
            this.radioButtonAllEvents.UseVisualStyleBackColor = true;
            this.radioButtonAllEvents.CheckedChanged += new System.EventHandler(this.radioButtonAllEvents_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBoxUser);
            this.groupBox5.Controls.Add(this.radioButtonFilterUser);
            this.groupBox5.Controls.Add(this.radioButtonAlluser);
            this.groupBox5.Location = new System.Drawing.Point(16, 147);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 170);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Select Users";
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.checkedListBoxUsers);
            this.groupBoxUser.Enabled = false;
            this.groupBoxUser.Location = new System.Drawing.Point(94, 19);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(302, 143);
            this.groupBoxUser.TabIndex = 3;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Users";
            // 
            // checkedListBoxUsers
            // 
            this.checkedListBoxUsers.FormattingEnabled = true;
            this.checkedListBoxUsers.Location = new System.Drawing.Point(55, 19);
            this.checkedListBoxUsers.Name = "checkedListBoxUsers";
            this.checkedListBoxUsers.Size = new System.Drawing.Size(216, 109);
            this.checkedListBoxUsers.TabIndex = 6;
            // 
            // radioButtonFilterUser
            // 
            this.radioButtonFilterUser.AutoSize = true;
            this.radioButtonFilterUser.Location = new System.Drawing.Point(16, 49);
            this.radioButtonFilterUser.Name = "radioButtonFilterUser";
            this.radioButtonFilterUser.Size = new System.Drawing.Size(47, 17);
            this.radioButtonFilterUser.TabIndex = 2;
            this.radioButtonFilterUser.Text = "Filter";
            this.radioButtonFilterUser.UseVisualStyleBackColor = true;
            this.radioButtonFilterUser.CheckedChanged += new System.EventHandler(this.radioButtonFilterUser_CheckedChanged);
            // 
            // radioButtonAlluser
            // 
            this.radioButtonAlluser.AutoSize = true;
            this.radioButtonAlluser.Checked = true;
            this.radioButtonAlluser.Location = new System.Drawing.Point(16, 26);
            this.radioButtonAlluser.Name = "radioButtonAlluser";
            this.radioButtonAlluser.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAlluser.TabIndex = 1;
            this.radioButtonAlluser.TabStop = true;
            this.radioButtonAlluser.Text = "All";
            this.radioButtonAlluser.UseVisualStyleBackColor = true;
            this.radioButtonAlluser.CheckedChanged += new System.EventHandler(this.radioButtonAlluser_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBoxDateTime);
            this.groupBox3.Controls.Add(this.radioButtonFilterDate);
            this.groupBox3.Controls.Add(this.radioButtonAllDate);
            this.groupBox3.Location = new System.Drawing.Point(16, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 122);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Date Time";
            // 
            // groupBoxDateTime
            // 
            this.groupBoxDateTime.Controls.Add(this.dateTimePickerEndDate);
            this.groupBoxDateTime.Controls.Add(this.dateTimePickerStartDate);
            this.groupBoxDateTime.Controls.Add(this.label2);
            this.groupBoxDateTime.Controls.Add(this.label1);
            this.groupBoxDateTime.Enabled = false;
            this.groupBoxDateTime.Location = new System.Drawing.Point(94, 19);
            this.groupBoxDateTime.Name = "groupBoxDateTime";
            this.groupBoxDateTime.Size = new System.Drawing.Size(302, 91);
            this.groupBoxDateTime.TabIndex = 3;
            this.groupBoxDateTime.TabStop = false;
            this.groupBoxDateTime.Text = "Date Time";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(71, 52);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 2;
            this.dateTimePickerEndDate.Leave += new System.EventHandler(this.dateTimePickerEndDate_Leave);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(71, 26);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "To";
            // 
            // radioButtonFilterDate
            // 
            this.radioButtonFilterDate.AutoSize = true;
            this.radioButtonFilterDate.Location = new System.Drawing.Point(16, 49);
            this.radioButtonFilterDate.Name = "radioButtonFilterDate";
            this.radioButtonFilterDate.Size = new System.Drawing.Size(47, 17);
            this.radioButtonFilterDate.TabIndex = 2;
            this.radioButtonFilterDate.Text = "Filter";
            this.radioButtonFilterDate.UseVisualStyleBackColor = true;
            this.radioButtonFilterDate.CheckedChanged += new System.EventHandler(this.radioButtonFilterDate_CheckedChanged);
            // 
            // radioButtonAllDate
            // 
            this.radioButtonAllDate.AutoSize = true;
            this.radioButtonAllDate.Checked = true;
            this.radioButtonAllDate.Location = new System.Drawing.Point(16, 26);
            this.radioButtonAllDate.Name = "radioButtonAllDate";
            this.radioButtonAllDate.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAllDate.TabIndex = 1;
            this.radioButtonAllDate.TabStop = true;
            this.radioButtonAllDate.Text = "All";
            this.radioButtonAllDate.UseVisualStyleBackColor = true;
            this.radioButtonAllDate.CheckedChanged += new System.EventHandler(this.radioButtonAllDate_CheckedChanged);
            // 
            // radioButtonAllLogs
            // 
            this.radioButtonAllLogs.AutoSize = true;
            this.radioButtonAllLogs.Checked = true;
            this.radioButtonAllLogs.Location = new System.Drawing.Point(16, 26);
            this.radioButtonAllLogs.Name = "radioButtonAllLogs";
            this.radioButtonAllLogs.Size = new System.Drawing.Size(62, 17);
            this.radioButtonAllLogs.TabIndex = 1;
            this.radioButtonAllLogs.TabStop = true;
            this.radioButtonAllLogs.Text = "All Logs";
            this.radioButtonAllLogs.UseVisualStyleBackColor = true;
            this.radioButtonAllLogs.CheckedChanged += new System.EventHandler(this.radioButtonAllLogs_CheckedChanged);
            // 
            // radioButtonFilterLogs
            // 
            this.radioButtonFilterLogs.AutoSize = true;
            this.radioButtonFilterLogs.Location = new System.Drawing.Point(130, 26);
            this.radioButtonFilterLogs.Name = "radioButtonFilterLogs";
            this.radioButtonFilterLogs.Size = new System.Drawing.Size(73, 17);
            this.radioButtonFilterLogs.TabIndex = 2;
            this.radioButtonFilterLogs.Tag = " ";
            this.radioButtonFilterLogs.Text = "Filter Logs";
            this.radioButtonFilterLogs.UseVisualStyleBackColor = true;
            this.radioButtonFilterLogs.CheckedChanged += new System.EventHandler(this.radioButtonFilterLogs_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonFilterLogs);
            this.groupBox2.Controls.Add(this.radioButtonAllLogs);
            this.groupBox2.Location = new System.Drawing.Point(23, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(797, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EventFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 452);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Filter";
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBoxEvents.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxUser.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxDateTime.ResumeLayout(false);
            this.groupBoxDateTime.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.CheckedListBox checkedListBoxUsers;
        private System.Windows.Forms.RadioButton radioButtonAllLogs;
        private System.Windows.Forms.RadioButton radioButtonFilterLogs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBoxEvents;
        private System.Windows.Forms.RadioButton radioButtonFilterEvents;
        private System.Windows.Forms.RadioButton radioButtonAllEvents;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.RadioButton radioButtonFilterUser;
        private System.Windows.Forms.RadioButton radioButtonAlluser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBoxDateTime;
        private System.Windows.Forms.RadioButton radioButtonFilterDate;
        private System.Windows.Forms.RadioButton radioButtonAllDate;
        private System.Windows.Forms.CheckedListBox checkedListBoxEvents;
        private System.Windows.Forms.Button button1;
    }
}