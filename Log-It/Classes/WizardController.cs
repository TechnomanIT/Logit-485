using System;
using Log_It.Forms;

namespace Classes
{	
	public class WizardController
	{
		public event EventHandler Closing;
		public CWMain cwmain = new CWMain();
		private CWAdd cwadd = new CWAdd();
		private CWDelete cwdelete = new CWDelete();
		private CWUpdate cwupdate = new CWUpdate();
		public CWSearch cwsearch = new CWSearch();
		private CWTryAgain cwtryagain = new CWTryAgain();
        BAL.LogitInstance instance;
		public WizardController(LogitMaincs form1, BAL.LogitInstance instance)
		{
            this.instance = instance;
            cwmain.instance = instance;
			cwmain.MdiParent = form1;
			cwadd.MdiParent = form1;
			cwdelete.MdiParent = form1;
			cwupdate.MdiParent = form1;
			cwsearch.MdiParent = form1;
			cwtryagain.MdiParent = form1;	
		
			//cwmain.NextPage +=new Wizard(cwmain_NextPage);
            //cwadd.MainPage +=new WizardCom(cwadd_MainPage);
            //cwadd.NextPage +=new WizardCom(cwadd_NextPage);
            //cwdelete.MainPage +=new WizardCom(cwdelete_MainPage);
            //cwupdate.MainPage +=new WizardCom(cwupdate_MainPage);
			cwsearch.MainPage +=new WizardCom(cwsearch_MainPage);
			cwtryagain.SearchAgain += new WizardCom(cwtryagain_SearchAgain);
			cwmain.Finish +=new WizardCom(g_Finish);
            //cwadd.Finish +=new WizardCom(g_Finish);
            //cwdelete.Finish +=new WizardCom(g_Finish);
            //cwupdate.Finish +=new WizardCom(g_Finish);
			cwtryagain.Finish +=new WizardCom(g_Finish);
			cwsearch.TimeOut +=new WizardCom(cwsearch_TimeOut);
			cwsearch.NewDevice += new WizardCom(cwsearch_NewDevice);			
		}
		
		private void cwmain_NextPage(int i)
		{
			this.cwmain.Hide();
			switch(i)
			{
				case 0:					
					this.cwsearch.progressBarControl1.Value = 0;
					this.cwsearch.timer1.Enabled = true;
					this.cwsearch.Show();
					break;
				case 1:					
					this.cwdelete.Show();
					break;
				case 2:										
					this.cwupdate.Show();
					break;			
			}
		}

		private void cwadd_NextPage()
		{
			this.cwadd.Hide();			
			//this.cwsearch.progressBarControl1.Value = 0;
			this.cwsearch.timer1.Enabled = true;
			this.cwsearch.Show();

		}

		private void cwadd_MainPage()
		{
			this.cwadd.Hide();			
			this.cwmain.Show();

		}

		private void cwdelete_MainPage()
		{
			this.cwdelete.Hide();			
			this.cwmain.Show();
		}

		private void cwupdate_MainPage()
		{
			this.cwupdate.Hide();			
			this.cwmain.Show();
		}

		private void cwsearch_MainPage()
		{
			this.cwsearch.Hide();			
			this.cwmain.Show();
		}

		private void cwtryagain_SearchAgain()
		{
			this.cwtryagain.Hide();			
			//this.cwsearch.progressBarControl1.Position = 0;
			this.cwsearch.timer1.Enabled = true;
			this.cwsearch.Show();
		}

		private void g_Finish()
		{
			if(this.Closing != null)
				this.Closing(this, new EventArgs());
		}

		private void cwsearch_TimeOut()
		{
			cwsearch.Hide();			
			cwtryagain.Show();
		}

		private void cwsearch_NewDevice()
		{
			cwsearch.Hide();			
			cwadd.Show();
			//cwadd.ResetCauseValidate();
		}
	}
}
