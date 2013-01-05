using System.Windows.Forms;
/*
 * Created by SharpDevelop.
 * User: Sudeep
 * Date: 12/3/2012
 * Time: 9:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace FWManager
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.bAddPath = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.cPath = new System.Windows.Forms.ColumnHeader();
			this.cFile = new System.Windows.Forms.ColumnHeader();
			this.cAction = new System.Windows.Forms.ColumnHeader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbFile = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbFiles = new System.Windows.Forms.TextBox();
			this.bPath = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbPath = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cbStopService = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbUninstall = new System.Windows.Forms.RadioButton();
			this.rbStop = new System.Windows.Forms.RadioButton();
			this.rbStart = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lvMonitor = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.lblMsg = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bAddPath);
			this.panel1.Controls.Add(this.bDelete);
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Location = new System.Drawing.Point(0, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(294, 365);
			this.panel1.TabIndex = 11;
			// 
			// bAddPath
			// 
			this.bAddPath.Location = new System.Drawing.Point(10, 132);
			this.bAddPath.Name = "bAddPath";
			this.bAddPath.Size = new System.Drawing.Size(267, 23);
			this.bAddPath.TabIndex = 16;
			this.bAddPath.Text = "Start Monitor Path";
			this.bAddPath.UseVisualStyleBackColor = true;
			this.bAddPath.Click += new System.EventHandler(this.BAddPathClick);
			// 
			// bDelete
			// 
			this.bDelete.Location = new System.Drawing.Point(8, 331);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(267, 23);
			this.bDelete.TabIndex = 14;
			this.bDelete.Text = "Stop Monitoring Path(s)";
			this.bDelete.UseVisualStyleBackColor = true;
			this.bDelete.Click += new System.EventHandler(this.BDeleteClick);
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cPath,
									this.cFile,
									this.cAction});
			this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(8, 165);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(266, 160);
			this.listView1.TabIndex = 13;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// cPath
			// 
			this.cPath.Text = "Path";
			this.cPath.Width = 100;
			// 
			// cFile
			// 
			this.cFile.Text = "File(s)";
			this.cFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cAction
			// 
			this.cAction.Text = "Action";
			this.cAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.cAction.Width = 100;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bFile);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbFile);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbFiles);
			this.groupBox1.Controls.Add(this.bPath);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbPath);
			this.groupBox1.Location = new System.Drawing.Point(6, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(270, 115);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Monitor";
			// 
			// bFile
			// 
			this.bFile.Location = new System.Drawing.Point(223, 81);
			this.bFile.Name = "bFile";
			this.bFile.Size = new System.Drawing.Size(33, 19);
			this.bFile.TabIndex = 10;
			this.bFile.Text = "...";
			this.bFile.UseVisualStyleBackColor = true;
			this.bFile.Click += new System.EventHandler(this.BFileClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Execute";
			// 
			// tbFile
			// 
			this.tbFile.Location = new System.Drawing.Point(56, 81);
			this.tbFile.Name = "tbFile";
			this.tbFile.Size = new System.Drawing.Size(161, 20);
			this.tbFile.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "File(s)";
			// 
			// tbFiles
			// 
			this.tbFiles.Location = new System.Drawing.Point(43, 51);
			this.tbFiles.Name = "tbFiles";
			this.tbFiles.Size = new System.Drawing.Size(212, 20);
			this.tbFiles.TabIndex = 6;
			this.tbFiles.Text = "*.*";
			// 
			// bPath
			// 
			this.bPath.Location = new System.Drawing.Point(223, 20);
			this.bPath.Name = "bPath";
			this.bPath.Size = new System.Drawing.Size(34, 19);
			this.bPath.TabIndex = 5;
			this.bPath.Text = "...";
			this.bPath.UseVisualStyleBackColor = true;
			this.bPath.Click += new System.EventHandler(this.BPathClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Path";
			// 
			// tbPath
			// 
			this.tbPath.Location = new System.Drawing.Point(41, 20);
			this.tbPath.Name = "tbPath";
			this.tbPath.Size = new System.Drawing.Size(178, 20);
			this.tbPath.TabIndex = 3;
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "*bat";
			this.openFileDialog1.InitialDirectory = "C:";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(4, 4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(292, 24);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(284, 0);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Configure";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(284, 0);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Manage";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(284, 0);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Monitor";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.cbStopService);
			this.panel2.Controls.Add(this.groupBox4);
			this.panel2.Location = new System.Drawing.Point(305, 30);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(294, 365);
			this.panel2.TabIndex = 12;
			// 
			// cbStopService
			// 
			this.cbStopService.Checked = true;
			this.cbStopService.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbStopService.Location = new System.Drawing.Point(32, 69);
			this.cbStopService.Name = "cbStopService";
			this.cbStopService.Size = new System.Drawing.Size(235, 30);
			this.cbStopService.TabIndex = 16;
			this.cbStopService.Text = "Stop Service while exiting FWManager";
			this.cbStopService.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbUninstall);
			this.groupBox4.Controls.Add(this.rbStop);
			this.groupBox4.Controls.Add(this.rbStart);
			this.groupBox4.Location = new System.Drawing.Point(10, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(263, 50);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Manage Service";
			// 
			// rbUninstall
			// 
			this.rbUninstall.Location = new System.Drawing.Point(187, 18);
			this.rbUninstall.Name = "rbUninstall";
			this.rbUninstall.Size = new System.Drawing.Size(70, 24);
			this.rbUninstall.TabIndex = 7;
			this.rbUninstall.TabStop = true;
			this.rbUninstall.Text = "Uninstall";
			this.rbUninstall.UseVisualStyleBackColor = true;
			this.rbUninstall.CheckedChanged += new System.EventHandler(this.RbUninstallCheckedChanged);
			// 
			// rbStop
			// 
			this.rbStop.Location = new System.Drawing.Point(109, 18);
			this.rbStop.Name = "rbStop";
			this.rbStop.Size = new System.Drawing.Size(70, 24);
			this.rbStop.TabIndex = 6;
			this.rbStop.TabStop = true;
			this.rbStop.Text = "Stop";
			this.rbStop.UseVisualStyleBackColor = true;
			this.rbStop.CheckedChanged += new System.EventHandler(this.RbStopCheckedChanged);
			// 
			// rbStart
			// 
			this.rbStart.Location = new System.Drawing.Point(22, 18);
			this.rbStart.Name = "rbStart";
			this.rbStart.Size = new System.Drawing.Size(48, 24);
			this.rbStart.TabIndex = 0;
			this.rbStart.TabStop = true;
			this.rbStart.Text = "Start";
			this.rbStart.UseVisualStyleBackColor = true;
			this.rbStart.CheckedChanged += new System.EventHandler(this.RbStartCheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(0, 0);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(104, 24);
			this.radioButton3.TabIndex = 0;
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(0, 0);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(104, 24);
			this.radioButton5.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lvMonitor);
			this.panel3.Location = new System.Drawing.Point(605, 30);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(294, 365);
			this.panel3.TabIndex = 13;
			// 
			// lvMonitor
			// 
			this.lvMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.lvMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lvMonitor.FullRowSelect = true;
			this.lvMonitor.GridLines = true;
			this.lvMonitor.Location = new System.Drawing.Point(14, 15);
			this.lvMonitor.Name = "lvMonitor";
			this.lvMonitor.Size = new System.Drawing.Size(266, 337);
			this.lvMonitor.TabIndex = 14;
			this.lvMonitor.UseCompatibleStateImageBehavior = false;
			this.lvMonitor.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File";
			this.columnHeader1.Width = 180;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 100;
			// 
			// lblMsg
			// 
			this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMsg.Location = new System.Drawing.Point(0, 396);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(291, 23);
			this.lblMsg.TabIndex = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 419);
			this.Controls.Add(this.lblMsg);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FWManager";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbStopService;
		private System.Windows.Forms.RadioButton rbUninstall;
		private System.Windows.Forms.Label lblMsg;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lvMonitor;
		private System.Windows.Forms.Button bAddPath;
		private System.Windows.Forms.RadioButton rbStart;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton rbStop;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox tbFiles;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.ColumnHeader cAction;
		private System.Windows.Forms.ColumnHeader cFile;
		private System.Windows.Forms.ColumnHeader cPath;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox tbFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bFile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button bPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPath;
	}
}