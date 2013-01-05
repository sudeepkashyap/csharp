/*
 * Created by SharpDevelop.
 * User: Sudeep
 * Date: 12/3/2012
 * Time: 9:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;
using System.Security.Principal;

namespace FWManager
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		[DllImport("user32.dll")] private static extern
			bool SetForegroundWindow(IntPtr hWnd);

		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Process p = PriorProcess();
			if (p != null)
			{
				SetForegroundWindow(p.MainWindowHandle);
				return;
			}
			
//			if(! new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
//			{
//				MessageBox.Show("Please run application as Adminstrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public static Process PriorProcess() {
			// Returns a System.Diagnostics.Process pointing to
			// a pre-existing process with the same name as the
			// current one, if any; or null if the current process
			// is unique.

			Process curr = Process.GetCurrentProcess();
			Process[] procs = Process.GetProcessesByName(curr.ProcessName);
			foreach (Process p in procs)
			{
				if ((p.Id != curr.Id) &&
				    (p.MainModule.FileName == curr.MainModule.FileName))
					return p;
			}
			return null;
		}

	}
}
