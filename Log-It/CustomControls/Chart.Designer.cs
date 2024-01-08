namespace Log_It.CustomControls
{
    partial class Chart
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picChart = new System.Windows.Forms.PictureBox();
            this.hsChart = new System.Windows.Forms.HScrollBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picChart);
            this.panel1.Controls.Add(this.hsChart);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 576);
            this.panel1.TabIndex = 2;
            // 
            // picChart
            // 
            this.picChart.BackColor = System.Drawing.Color.Transparent;
            this.picChart.Location = new System.Drawing.Point(0, 0);
            this.picChart.Name = "picChart";
            this.picChart.Size = new System.Drawing.Size(552, 552);
            this.picChart.TabIndex = 3;
            this.picChart.TabStop = false;
            this.picChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picChart_Paint);
            this.picChart.Resize += new System.EventHandler(this.picChart_Resize);
            // 
            // hsChart
            // 
            this.hsChart.LargeChange = 1;
            this.hsChart.Location = new System.Drawing.Point(0, 556);
            this.hsChart.Maximum = 0;
            this.hsChart.Name = "hsChart";
            this.hsChart.Size = new System.Drawing.Size(552, 15);
            this.hsChart.TabIndex = 2;
            this.hsChart.ValueChanged += new System.EventHandler(this.hsChart_ValueChanged);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Chart";
            this.Size = new System.Drawing.Size(552, 576);
            this.Load += new System.EventHandler(this.Chart_Load);
            this.Resize += new System.EventHandler(this.Chart_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hsChart;
        private System.Windows.Forms.PictureBox picChart;
    }
}
