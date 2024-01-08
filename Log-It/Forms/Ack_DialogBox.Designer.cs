namespace Log_It.Forms
{
    partial class Ack_DialogBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxcomments = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelInstrument = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event Type:";
            // 
            // textBoxcomments
            // 
            this.textBoxcomments.Location = new System.Drawing.Point(12, 177);
            this.textBoxcomments.MaxLength = 200;
            this.textBoxcomments.Multiline = true;
            this.textBoxcomments.Name = "textBoxcomments";
            this.textBoxcomments.Size = new System.Drawing.Size(323, 132);
            this.textBoxcomments.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Location:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(119, 12);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(0, 13);
            this.labelType.TabIndex = 0;
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Location = new System.Drawing.Point(119, 41);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(0, 13);
            this.labelDateTime.TabIndex = 0;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(119, 66);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(0, 13);
            this.labelLocation.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comments:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Instrument";
            // 
            // labelInstrument
            // 
            this.labelInstrument.AutoSize = true;
            this.labelInstrument.Location = new System.Drawing.Point(119, 92);
            this.labelInstrument.Name = "labelInstrument";
            this.labelInstrument.Size = new System.Drawing.Size(0, 13);
            this.labelInstrument.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Description:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoEllipsis = true;
            this.labelDescription.Location = new System.Drawing.Point(121, 125);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(214, 37);
            this.labelDescription.TabIndex = 0;
            // 
            // Ack_DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 345);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxcomments);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelInstrument);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Ack_DialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acknowladge";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxcomments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelInstrument;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelDescription;
    }
}