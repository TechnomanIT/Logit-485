namespace Log_It.CustomControls
{
    partial class LogitUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogitUC));
            this.labelHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelUnit = new System.Windows.Forms.Label();
            this.tmrTimeOut = new System.Windows.Forms.Timer(this.components);
            this.picTimeOut = new System.Windows.Forms.PictureBox();
             ((System.ComponentModel.ISupportInitialize)(this.picTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.labelHeader.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(150, 40);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Temperature";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(0, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 50);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Min:";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.labelMin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMin.ForeColor = System.Drawing.Color.Transparent;
            this.labelMin.Location = new System.Drawing.Point(49, 211);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(18, 18);
            this.labelMin.TabIndex = 6;
            this.labelMin.Text = "0";
            this.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.labelMax.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax.ForeColor = System.Drawing.Color.Transparent;
            this.labelMax.Location = new System.Drawing.Point(49, 193);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(18, 18);
            this.labelMax.TabIndex = 5;
            this.labelMax.Text = "0";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(93, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Unit";
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(63)))), ((int)(((byte)(214)))));
            this.labelUnit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnit.ForeColor = System.Drawing.Color.Transparent;
            this.labelUnit.Location = new System.Drawing.Point(104, 211);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(20, 18);
            this.labelUnit.TabIndex = 8;
            this.labelUnit.Text = "C";
            this.labelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picTimeOut
            // 
            this.picTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTimeOut.Image = ((System.Drawing.Image)(resources.GetObject("picTimeOut.Image")));
            this.picTimeOut.Location = new System.Drawing.Point(6, 152);
            this.picTimeOut.Name = "picTimeOut";
            this.picTimeOut.Size = new System.Drawing.Size(150, 150);
            this.picTimeOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTimeOut.TabIndex = 10;
            this.picTimeOut.TabStop = false;
            this.picTimeOut.Visible = false;
            // 
            // realTimeBar1
            // 
            this.realTimeBar1.BackColor = System.Drawing.Color.White;
            this.realTimeBar1.BarColorDark = System.Drawing.Color.White;
            this.realTimeBar1.BarColorLight = System.Drawing.Color.Green;
            this.realTimeBar1.BarDirection = Log_It.CustomControls.RealTimeBarNew.Direction.Vertical;
            this.realTimeBar1.BarInfos = null;
            this.realTimeBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimeBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.realTimeBar1.LLimit = 10F;
            this.realTimeBar1.Location = new System.Drawing.Point(0, 40);
            this.realTimeBar1.Max = 90F;
            this.realTimeBar1.Min = -90F;
            this.realTimeBar1.Name = "realTimeBar1";
            this.realTimeBar1.NumberFormat = "+00.0;-00.0";
            this.realTimeBar1.Size = new System.Drawing.Size(150, 150);
            this.realTimeBar1.Suffix = " %";
            this.realTimeBar1.TabIndex = 11;
            this.realTimeBar1.ULimit = 50F;
            this.realTimeBar1.Value = 50F;
            this.realTimeBar1.VerticalDisplay = false;
            // 
            // LogitUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.realTimeBar1);
            this.Controls.Add(this.picTimeOut);
            this.Name = "LogitUC";
            this.Size = new System.Drawing.Size(150, 240);
            ((System.ComponentModel.ISupportInitialize)(this.picTimeOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelUnit;
        private System.Windows.Forms.Timer tmrTimeOut;
        public System.Windows.Forms.PictureBox picTimeOut;
     
    }
}
