/*
 * Created by SharpDevelop.
 * User: Sudeep
 * Date: 12/3/2012
 * Time: 9:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ServiceProcess;
using System.Diagnostics;

namespace FWManager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public static string curDir = Application.StartupPath;
		ConfigurableFWS cfws = null;
		SortedList configList = new SortedList();
		public static string configFileName = "fwconfig.txt";
		public static string configFileNameF =  curDir + "\\fwconfig.txt";
		public static string srvcExeFileF = curDir + "\\FWService.exe";
		string installUtilFile = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\InstallUtil.exe";
		public static string optI = " /i ";
		public static string optU = " /u ";
		public static char sepPipe = '|';
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Width = 300;
			tabControl1.Selected += new TabControlEventHandler(OnTabPageSelection);

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			ReadConfigFile();
			InstallStart();
			
			// watch as per config file
			cfws = new ConfigurableFWS(FWManager.MainForm.curDir, FWManager.MainForm.configFileName, HandleInitialFiles, OnFileCreate, OnFileChange, OnFileDelete, null);

		}
		
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			if (cbStopService.Checked) {
				rbStop.Checked = true;
			}
			
			base.OnFormClosed(e);
		}
		
		void UpdateConfigListView()
		{
			listView1.Items.Clear();
			for ( int i = 0; i < configList.Count; i++ )
			{
				ListViewItem lvi = new ListViewItem(configList.GetKey(i).ToString());

				lvi.SubItems.Add(configList.GetByIndex(i).ToString().Split(sepPipe)[1]);
				lvi.SubItems.Add(configList.GetByIndex(i).ToString().Split(sepPipe)[2]);
				listView1.Items.Add(lvi);
			}
			
			// just for convinience set the last action in text box
			if(configList.Count > 0)
			{
				tbFile.Text = configList.GetByIndex(configList.Count - 1).ToString().Split(sepPipe)[2];
				tbFile.Select();
			}
		}
		
		void ReadConfigFile()
		{
			if(File.Exists(configFileNameF))
			{
				configList.Clear();

				// create reader & open file
				using (TextReader tr = new StreamReader(configFileNameF)) {
					string line;
					while((line = tr.ReadLine()) != null)
						configList.Add(line.Split(sepPipe)[0], line);
				}
			}
			else
			{
				using (TextWriter tw = new StreamWriter(configFileNameF, true)) {}
			}
			
			UpdateConfigListView();
		}
		
		void WriteToConfigFile()
		{
			using (TextWriter tw = new StreamWriter(configFileName)) {
				for ( int i = 0; i < configList.Count; i++ )
					tw.WriteLine(configList.GetByIndex(i));
			}
			
			UpdateConfigListView();
		}
		
		void BPathClick(object sender, EventArgs e)
		{
			if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
				tbPath.Text = folderBrowserDialog1.SelectedPath;
		}
		
		void BFileClick(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
				tbFile.Text = openFileDialog1.FileName;
		}
		
		void BAddPathClick(object sender, EventArgs e)
		{
			if(tbPath.Text == "")
			{
				MessageBox.Show("Please select a folder to monitor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if(tbFiles.Text == "")
			{
				MessageBox.Show("Please type file(s) to be monitored", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if(tbFile.Text == "")
			{
				MessageBox.Show("Please select a file to execute", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			// catch the excption raised if tried to add same path twice
			try {
				configList.Add(tbPath.Text, tbPath.Text + sepPipe + tbFiles.Text + sepPipe + tbFile.Text);
			} catch (ArgumentException) {
				MessageBox.Show(tbPath.Text + " is already monitored", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			WriteToConfigFile();
		}
		
		void BDeleteClick(object sender, System.EventArgs e)
		{
			ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
			if(checkedItems.Count == 0)
				MessageBox.Show("Please select a path to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{
				foreach ( ListViewItem item in checkedItems )
					configList.Remove(item.SubItems[0].Text);
				
				WriteToConfigFile();
			}
		}
		
		Int64 ProcessCmd(string cmd, int timeout, ref string execMsg)
		{
			Process Process;
			ProcessStartInfo ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + @cmd);
			ProcessInfo.RedirectStandardOutput = true;
			ProcessInfo.CreateNoWindow = true;
			ProcessInfo.UseShellExecute = false;
			Process = Process.Start(ProcessInfo);
			Process.WaitForExit(timeout);

			Int64 exitcode = Process.ExitCode;
			execMsg = Process.StandardOutput.ReadToEnd();
			Process.Close();
			return exitcode;
		}
		
		void RbStartCheckedChanged(object sender, System.EventArgs e)
		{
			ServiceController srvcController = new ServiceController("FWService");
			if (srvcController.Status == ServiceControllerStatus.Stopped)
			{
				srvcController.Start();
				srvcController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(5000));
				lblMsg.Text = "Service started successfully";
			}
			else if (srvcController.Status != ServiceControllerStatus.Running)
				MessageBox.Show("Service is in state: " + srvcController.Status.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		void RbStopCheckedChanged(object sender, System.EventArgs e)
		{
			ServiceController srvcController = new ServiceController("FWService");
			if (srvcController.Status == ServiceControllerStatus.Running)
			{
				srvcController.Stop();
				srvcController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(5000));
				lblMsg.Text = "Service stopped successfully";
			}
			else if (srvcController.Status != ServiceControllerStatus.Stopped)
				MessageBox.Show("Service is in state: " + srvcController.Status.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		void InstallStart()
		{
			string execMsg = "";
			if (ProcessCmd(installUtilFile + optI + srvcExeFileF, 10000, ref execMsg) != 0
			    && !execMsg.Contains("service already exists"))
			{
				MessageBox.Show(execMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			rbStart.Checked = true;
		}

		void RbUninstallCheckedChanged(object sender, System.EventArgs e)
		{
			ServiceController srvcController = new ServiceController("FWService");
			try {
				if (srvcController.Status != ServiceControllerStatus.Stopped)
				{
					srvcController.Stop();
					srvcController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(5000));
				}
			} catch (Exception ex) {
				if (ex.ToString().Contains("service does not exist"))
				{
					MessageBox.Show("Service is already uninstalled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
					throw;
			}

			string execMsg = "";
			if (ProcessCmd(installUtilFile + optU + srvcExeFileF, 10000, ref execMsg) == 0)
			{
				if (MessageBox.Show("Service is uninstalled successfully.\nPlease restart the machine now.", "Info", MessageBoxButtons.OKCancel,
				                    MessageBoxIcon.Information) == DialogResult.OK)
					System.Diagnostics.Process.Start("ShutDown","/r");
				else
					MessageBox.Show("Machine need to be restarted before re-installing the service", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			else
				MessageBox.Show(execMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		void OnTabPageSelection(object sender, TabControlEventArgs e)
		{
			panel1.Left = 305;
			panel2.Left = 305;
			panel3.Left = 305;
			if(tabControl1.SelectedTab == tabPage1)
				panel1.Left = 0;
			else if(tabControl1.SelectedTab == tabPage2)
				panel2.Left = 0;
			else if(tabControl1.SelectedTab == tabPage3)
				panel3.Left = 0;
		}
		
		void HandleInitialFiles(IEnumerable<string> initialfiles)
		{
			foreach (string file in initialfiles) {
				ListViewItem lvi = new ListViewItem(file);
				lvi.SubItems.Add("Enqueued");
				lvMonitor.Items.Add(lvi);
			}
		}
		
		void OnFileCreate(object sender, FileSystemEventArgs e)
		{
			ListViewItem lvi = new ListViewItem(e.FullPath);
			lvi.Name = e.FullPath;
			lvi.SubItems.Add("Enqueued");
			lock(lvMonitor)
				lvMonitor.Items.Insert(0, lvi);
		}
		
		void OnFileChange(object sender, FileSystemEventArgs e)
		{
//			Log.LogMsg("in file change: " + e.FullPath);
//			Log.LogMsg("text: " + lvMonitor.FindItemWithText(e.FullPath).SubItems[1].Text);
			lock(lvMonitor)
				lvMonitor.FindItemWithText(e.FullPath).SubItems[1].Text = "In Process";
		}
		
		void OnFileDelete(object sender, FileSystemEventArgs e)
		{
//			Log.LogMsg("in file delete: " + e.FullPath);
//			Log.LogMsg("text: " + lvMonitor.FindItemWithText(e.FullPath).SubItems[1].Text);
			lock(lvMonitor)
				lvMonitor.FindItemWithText(e.FullPath).SubItems[1].Text = "Done";
		}
	}
}