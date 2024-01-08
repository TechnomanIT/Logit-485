namespace Log_It.Forms
{
    partial class frmViewLogging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewLogging));
            this.button1 = new System.Windows.Forms.Button();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.radioThisMonth = new System.Windows.Forms.RadioButton();
            this.radioYesterday = new System.Windows.Forms.RadioButton();
            this.radioLastDays = new System.Windows.Forms.RadioButton();
            this.radioToday = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimeInputfrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInputto = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.daysChanger = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputfrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputto)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioCustom
            // 
            this.radioCustom.Location = new System.Drawing.Point(15, 84);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(72, 16);
            this.radioCustom.TabIndex = 9;
            this.radioCustom.Text = "Custom";
            this.radioCustom.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // radioThisMonth
            // 
            this.radioThisMonth.Location = new System.Drawing.Point(15, 51);
            this.radioThisMonth.Name = "radioThisMonth";
            this.radioThisMonth.Size = new System.Drawing.Size(80, 16);
            this.radioThisMonth.TabIndex = 8;
            this.radioThisMonth.Text = "This Month";
            this.radioThisMonth.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // radioYesterday
            // 
            this.radioYesterday.Location = new System.Drawing.Point(100, 18);
            this.radioYesterday.Name = "radioYesterday";
            this.radioYesterday.Size = new System.Drawing.Size(76, 16);
            this.radioYesterday.TabIndex = 7;
            this.radioYesterday.Text = "Yesterday";
            this.radioYesterday.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // radioLastDays
            // 
            this.radioLastDays.Location = new System.Drawing.Point(100, 51);
            this.radioLastDays.Name = "radioLastDays";
            this.radioLastDays.Size = new System.Drawing.Size(72, 16);
            this.radioLastDays.TabIndex = 6;
            this.radioLastDays.Text = "LastDays";
            this.radioLastDays.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // radioToday
            // 
            this.radioToday.Checked = true;
            this.radioToday.Location = new System.Drawing.Point(15, 18);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(56, 16);
            this.radioToday.TabIndex = 5;
            this.radioToday.TabStop = true;
            this.radioToday.Text = "Today";
            this.radioToday.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimeInputfrom);
            this.groupBox1.Controls.Add(this.dateTimeInputto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 86);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Date and Time";
            // 
            // dateTimeInputfrom
            // 
            // 
            // 
            // 
            this.dateTimeInputfrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInputfrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputfrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInputfrom.ButtonDropDown.Visible = true;
            this.dateTimeInputfrom.CustomFormat = "MM/dd/yyyy h:mm:ss tt";
            this.dateTimeInputfrom.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.dateTimeInputfrom.IsPopupCalendarOpen = false;
            this.dateTimeInputfrom.Location = new System.Drawing.Point(60, 36);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInputfrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputfrom.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInputfrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInputfrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputfrom.MonthCalendar.DayClickAutoClosePopup = false;
            this.dateTimeInputfrom.MonthCalendar.DisplayMonth = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInputfrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInputfrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInputfrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInputfrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputfrom.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInputfrom.Name = "dateTimeInputfrom";
            this.dateTimeInputfrom.Size = new System.Drawing.Size(168, 20);
            this.dateTimeInputfrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInputfrom.TabIndex = 22;
            this.dateTimeInputfrom.Value = new System.DateTime(2018, 10, 27, 17, 24, 5, 0);
            // 
            // dateTimeInputto
            // 
            // 
            // 
            // 
            this.dateTimeInputto.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInputto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputto.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInputto.ButtonDropDown.Visible = true;
            this.dateTimeInputto.CustomFormat = "MM/dd/yyyy h:mm:ss tt";
            this.dateTimeInputto.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.dateTimeInputto.IsPopupCalendarOpen = false;
            this.dateTimeInputto.Location = new System.Drawing.Point(60, 55);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInputto.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputto.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInputto.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInputto.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputto.MonthCalendar.DayClickAutoClosePopup = false;
            this.dateTimeInputto.MonthCalendar.DisplayMonth = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInputto.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInputto.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInputto.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInputto.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputto.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInputto.Name = "dateTimeInputto";
            this.dateTimeInputto.Size = new System.Drawing.Size(168, 20);
            this.dateTimeInputto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInputto.TabIndex = 22;
            this.dateTimeInputto.Value = new System.DateTime(2018, 10, 27, 17, 24, 10, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "To";
            // 
            // daysChanger
            // 
            this.daysChanger.Location = new System.Drawing.Point(179, 51);
            this.daysChanger.Name = "daysChanger";
            this.daysChanger.Size = new System.Drawing.Size(61, 20);
            this.daysChanger.TabIndex = 18;
            this.daysChanger.TextChanged += new System.EventHandler(this.daysChanger_TextChanged);
            // 
            // frmViewLogging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 229);
            this.Controls.Add(this.daysChanger);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioThisMonth);
            this.Controls.Add(this.radioYesterday);
            this.Controls.Add(this.radioLastDays);
            this.Controls.Add(this.radioToday);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioCustom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewLogging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Logging";
            this.Load += new System.EventHandler(this.frmViewLogging_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputfrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.RadioButton radioThisMonth;
        private System.Windows.Forms.RadioButton radioYesterday;
        private System.Windows.Forms.RadioButton radioLastDays;
        private System.Windows.Forms.RadioButton radioToday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox daysChanger;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputfrom;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputto;
    }
}