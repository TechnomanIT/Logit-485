namespace Log_It.CustomControls
{
    partial class RealTimeBarNew
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
            this.pictureBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBar
            // 
            this.pictureBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBar.Location = new System.Drawing.Point(0, 0);
            this.pictureBar.Name = "pictureBar";
            this.pictureBar.Size = new System.Drawing.Size(150, 150);
            this.pictureBar.TabIndex = 0;
            this.pictureBar.TabStop = false;
            this.pictureBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBar_Paint);
            // 
            // RealTimeBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBar);
            this.Name = "RealTimeBar";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBar_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBar;
    }
}
