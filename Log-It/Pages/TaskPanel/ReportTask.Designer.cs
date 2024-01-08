namespace Log_It.Pages.TaskPanel
{
    partial class ReportTask
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entityListBox1 = new Log_It.CustomControls.EntityListBox(this.components);
            this.dateTimeInputto = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInputfrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputfrom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dateTimeInputto);
            this.panel1.Controls.Add(this.dateTimeInputfrom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 117);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // entityListBox1
            // 
            this.entityListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entityListBox1.FormattingEnabled = true;
            this.entityListBox1.Location = new System.Drawing.Point(12, 128);
            this.entityListBox1.Name = "entityListBox1";
            this.entityListBox1.Size = new System.Drawing.Size(205, 407);
            this.entityListBox1.TabIndex = 5;
            this.entityListBox1.DoubleClick += new System.EventHandler(this.entityListBox1_DoubleClick);
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
            this.dateTimeInputto.CustomFormat = "dd/MM/yyyy h:mm:ss tt";
            this.dateTimeInputto.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.dateTimeInputto.IsPopupCalendarOpen = false;
            this.dateTimeInputto.Location = new System.Drawing.Point(7, 78);
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
            this.dateTimeInputto.Size = new System.Drawing.Size(200, 20);
            this.dateTimeInputto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInputto.TabIndex = 28;
            this.dateTimeInputto.Value = new System.DateTime(2018, 10, 27, 17, 24, 10, 0);
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
            this.dateTimeInputfrom.CustomFormat = "dd/MM/yyyy h:mm:ss tt";
            this.dateTimeInputfrom.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.dateTimeInputfrom.IsPopupCalendarOpen = false;
            this.dateTimeInputfrom.Location = new System.Drawing.Point(7, 31);
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
            this.dateTimeInputfrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimeInputfrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInputfrom.TabIndex = 27;
            this.dateTimeInputfrom.Value = new System.DateTime(2018, 10, 27, 17, 24, 5, 0);
            // 
            // ReportTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.entityListBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ReportTask";
            this.Size = new System.Drawing.Size(236, 561);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputfrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomControls.EntityListBox entityListBox1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputto;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputfrom;
    }
}
