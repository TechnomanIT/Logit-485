using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Log_It.Forms
{
	/// <summary>
	/// Summary description for ConfigurationWizard.
	/// </summary>
	/// 	
	
	public class CWTryAgain : System.Windows.Forms.Form
	{
		public event WizardCom SearchAgain;	
		public event WizardCom Finish;

        private System.Windows.Forms.Button  btnNext;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFinish;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label2;


		private System.ComponentModel.IContainer components;

		//MainPage mp;
		public CWTryAgain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();					

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CWTryAgain));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNext.Location = new System.Drawing.Point(328, 328);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(80, 24);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = "&Search Again";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnFinish
			// 
			this.btnFinish.Location = new System.Drawing.Point(416, 328);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(72, 24);
			this.btnFinish.TabIndex = 4;
			this.btnFinish.Text = "&Finish";
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(512, 56);
			this.panel1.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(120, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 40);
			this.label1.TabIndex = 8;
			this.label1.Text = "The wizard could not find any new device connected to your system. Please verify " +
				"that device is attached to the system properly.";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ImageIndex = 0;
			this.label2.ImageList = this.imageList1;
			this.label2.Location = new System.Drawing.Point(80, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 32);
			this.label2.TabIndex = 9;
			// 
			// CWTryAgain
			// 
			this.AcceptButton = this.btnFinish;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.btnNext;
			this.ClientSize = new System.Drawing.Size(508, 362);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnFinish);
			this.Controls.Add(this.btnNext);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CWTryAgain";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuration Wizard: Try Again";
			this.ResumeLayout(false);

		}
		#endregion
		
		private void mp_NextPage(int i)
		{
			Console.WriteLine(i);
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (SearchAgain != null)
				SearchAgain();
		}

		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			if (Finish != null)
				Finish();
			this.Hide();
		}					
	}	
}
