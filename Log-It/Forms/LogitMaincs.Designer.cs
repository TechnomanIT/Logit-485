using System.Windows.Forms;
namespace Log_It.Forms
{
    partial class LogitMaincs
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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Application Properties", 1, 1);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("DataBase Maintenance", 2, 2);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Event Log", 3, 3);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("User Option", 4, 4);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Application Options", 0, -2, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogitMaincs));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusComPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.sideNav1 = new DevComponents.DotNetBar.Controls.SideNav();
            this.sideNavPanel2 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAddDevice = new System.Windows.Forms.Button();
            this.panelDevices = new System.Windows.Forms.Panel();
            this.sideNavPanel3 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.panelReport = new System.Windows.Forms.Panel();
            this.sideNavPanel1 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.paneltask = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.sideNavItem1 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.separator1 = new DevComponents.DotNetBar.Separator();
            this.sideNavItem2 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem3 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem4 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.sideNav1.SuspendLayout();
            this.sideNavPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.sideNavPanel3.SuspendLayout();
            this.sideNavPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusUser,
            this.toolStripStatusLabel1,
            this.toolStripStatusComPort,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 888);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1136, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusUser
            // 
            this.toolStripStatusUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusUser.Name = "toolStripStatusUser";
            this.toolStripStatusUser.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusUser.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusComPort
            // 
            this.toolStripStatusComPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusComPort.Name = "toolStripStatusComPort";
            this.toolStripStatusComPort.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusComPort.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 20);
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // sideNav1
            // 
            this.sideNav1.Controls.Add(this.sideNavPanel2);
            this.sideNav1.Controls.Add(this.sideNavPanel3);
            this.sideNav1.Controls.Add(this.sideNavPanel1);
            this.sideNav1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideNav1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sideNavItem1,
            this.separator1,
            this.sideNavItem2,
            this.sideNavItem3,
            this.sideNavItem4});
            this.sideNav1.Location = new System.Drawing.Point(0, 0);
            this.sideNav1.Margin = new System.Windows.Forms.Padding(4);
            this.sideNav1.Name = "sideNav1";
            this.sideNav1.Padding = new System.Windows.Forms.Padding(1);
            this.sideNav1.Size = new System.Drawing.Size(440, 888);
            this.sideNav1.TabIndex = 16;
            this.sideNav1.Text = "sideNav1";
            // 
            // sideNavPanel2
            // 
            this.sideNavPanel2.Controls.Add(this.tableLayoutPanel2);
            this.sideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel2.Location = new System.Drawing.Point(100, 41);
            this.sideNavPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.sideNavPanel2.Name = "sideNavPanel2";
            this.sideNavPanel2.Size = new System.Drawing.Size(335, 846);
            this.sideNavPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddDevice, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelDevices, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 846);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button4.Location = new System.Drawing.Point(4, 394);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(327, 126);
            this.button4.TabIndex = 3;
            this.button4.Text = "Event Log";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button3.Image = global::Log_It.Properties.Resources.icons8_doughnut_chart_501;
            this.button3.Location = new System.Drawing.Point(4, 134);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(327, 122);
            this.button3.TabIndex = 0;
            this.button3.Text = "Chart";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Log_It.Properties.Resources.if_03_171510;
            this.button2.Location = new System.Drawing.Point(4, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(327, 122);
            this.button2.TabIndex = 0;
            this.button2.Text = "Display";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonAddDevice.ForeColor = System.Drawing.Color.Black;
            this.buttonAddDevice.Image = global::Log_It.Properties.Resources.icons8_edit_property_501;
            this.buttonAddDevice.Location = new System.Drawing.Point(4, 264);
            this.buttonAddDevice.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Size = new System.Drawing.Size(327, 122);
            this.buttonAddDevice.TabIndex = 0;
            this.buttonAddDevice.Text = "Add/Modifie";
            this.buttonAddDevice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelDevices
            // 
            this.panelDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDevices.Location = new System.Drawing.Point(4, 528);
            this.panelDevices.Margin = new System.Windows.Forms.Padding(4);
            this.panelDevices.Name = "panelDevices";
            this.panelDevices.Size = new System.Drawing.Size(327, 314);
            this.panelDevices.TabIndex = 1;
            // 
            // sideNavPanel3
            // 
            this.sideNavPanel3.Controls.Add(this.panelReport);
            this.sideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel3.Location = new System.Drawing.Point(116, 46);
            this.sideNavPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.sideNavPanel3.Name = "sideNavPanel3";
            this.sideNavPanel3.Size = new System.Drawing.Size(317, 839);
            this.sideNavPanel3.TabIndex = 14;
            this.sideNavPanel3.Visible = false;
            // 
            // panelReport
            // 
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 0);
            this.panelReport.Margin = new System.Windows.Forms.Padding(4);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(317, 839);
            this.panelReport.TabIndex = 0;
            // 
            // sideNavPanel1
            // 
            this.sideNavPanel1.Controls.Add(this.tableLayoutPanel1);
            this.sideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel1.Location = new System.Drawing.Point(116, 46);
            this.sideNavPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.sideNavPanel1.Name = "sideNavPanel1";
            this.sideNavPanel1.Size = new System.Drawing.Size(317, 839);
            this.sideNavPanel1.TabIndex = 2;
            this.sideNavPanel1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.paneltask, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(317, 839);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // paneltask
            // 
            this.paneltask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneltask.Location = new System.Drawing.Point(4, 423);
            this.paneltask.Margin = new System.Windows.Forms.Padding(4);
            this.paneltask.Name = "paneltask";
            this.paneltask.Size = new System.Drawing.Size(309, 412);
            this.paneltask.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageKey = "icons8-database-40.png";
            this.treeView1.Location = new System.Drawing.Point(4, 4);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node1";
            treeNode11.SelectedImageIndex = 1;
            treeNode11.Tag = "AP";
            treeNode11.Text = "Application Properties";
            treeNode11.ToolTipText = "0";
            treeNode12.ImageIndex = 2;
            treeNode12.Name = "Node2";
            treeNode12.SelectedImageIndex = 2;
            treeNode12.Tag = "DB";
            treeNode12.Text = "DataBase Maintenance";
            treeNode12.ToolTipText = "1";
            treeNode13.ImageIndex = 3;
            treeNode13.Name = "Node4";
            treeNode13.SelectedImageIndex = 3;
            treeNode13.Tag = "EL";
            treeNode13.Text = "Event Log";
            treeNode13.ToolTipText = "2";
            treeNode14.ImageIndex = 4;
            treeNode14.Name = "Node5";
            treeNode14.SelectedImageIndex = 4;
            treeNode14.Tag = "UO";
            treeNode14.Text = "User Option";
            treeNode14.ToolTipText = "3";
            treeNode15.ImageIndex = 0;
            treeNode15.Name = "Node0";
            treeNode15.SelectedImageIndex = -2;
            treeNode15.Tag = "Option";
            treeNode15.Text = "Application Options";
            treeNode15.ToolTipText = "01";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(309, 411);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            // 
            // sideNavItem1
            // 
            this.sideNavItem1.IsSystemMenu = true;
            this.sideNavItem1.Name = "sideNavItem1";
            this.sideNavItem1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.sideNavItem1.Symbol = "";
            this.sideNavItem1.Text = "Menu";
            // 
            // separator1
            // 
            this.separator1.FixedSize = new System.Drawing.Size(3, 1);
            this.separator1.Name = "separator1";
            this.separator1.Padding.Bottom = 2;
            this.separator1.Padding.Left = 6;
            this.separator1.Padding.Right = 6;
            this.separator1.Padding.Top = 2;
            this.separator1.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical;
            // 
            // sideNavItem2
            // 
            this.sideNavItem2.Name = "sideNavItem2";
            this.sideNavItem2.Panel = this.sideNavPanel1;
            this.sideNavItem2.Symbol = "";
            this.sideNavItem2.SymbolColor = System.Drawing.Color.Black;
            this.sideNavItem2.Text = "Home";
            this.sideNavItem2.Title = "Home";
            this.sideNavItem2.Click += new System.EventHandler(this.sideNavItem2_Click);
            // 
            // sideNavItem3
            // 
            this.sideNavItem3.Checked = true;
            this.sideNavItem3.Name = "sideNavItem3";
            this.sideNavItem3.Panel = this.sideNavPanel2;
            this.sideNavItem3.Symbol = "57532";
            this.sideNavItem3.SymbolColor = System.Drawing.Color.Black;
            this.sideNavItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.sideNavItem3.Text = "Devices";
            this.sideNavItem3.Title = "Devices";
            this.sideNavItem3.Click += new System.EventHandler(this.sideNavItem3_Click);
            // 
            // sideNavItem4
            // 
            this.sideNavItem4.Name = "sideNavItem4";
            this.sideNavItem4.Panel = this.sideNavPanel3;
            this.sideNavItem4.Symbol = "";
            this.sideNavItem4.SymbolColor = System.Drawing.Color.Black;
            this.sideNavItem4.Text = "Report";
            this.sideNavItem4.Title = "Report";
            this.sideNavItem4.Click += new System.EventHandler(this.sideNavItem4_Click);
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(440, 0);
            this.panelControl.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(696, 888);
            this.panelControl.TabIndex = 19;
            // 
            // LogitMaincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 913);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.sideNav1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogitMaincs";
            this.Text = "Logit Chart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogitMaincs_FormClosing);
            this.Load += new System.EventHandler(this.LogitMaincs_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.sideNav1.ResumeLayout(false);
            this.sideNav1.PerformLayout();
            this.sideNavPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.sideNavPanel3.ResumeLayout(false);
            this.sideNavPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUser;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.Controls.SideNav sideNav1;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel1;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem1;
        private DevComponents.DotNetBar.Separator separator1;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel paneltask;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel2;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel3;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem3;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelDevices;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Button button3;
        private ToolStripStatusLabel toolStripStatusComPort;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button button4;
        private Button button2;
        private Button buttonAddDevice;
    }
}



