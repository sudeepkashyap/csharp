/*
 * Created by SharpDevelop.
 * User: sudee_000
 * Date: 12/3/2012
 * Time: 11:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading;

namespace FWManager
{
	public class FWService : ServiceBase
	{
		public const string MyServiceName = "FWService";
		ConfigurableFWS cfws = null;
		private static Queue<string> myQ = new Queue<string>();
		private static Int64 maxNotifHandledAtATime = 3;
		private static Int64 notifStillHandling = 0;
		private static bool isServiceRunning = true;
		
		public FWService()
		{
			this.ServiceName = MyServiceName;
//			this.CanPauseAndContinue = true;
			ThreadPool.QueueUserWorkItem(new WaitCallback(handleQ));
		}
		
		public static void ExecuteCommand(object Command)
		{
			try {
				string cmd = "/C C:\\FW\\action.bat " + "\"" + Command + "\"";
				Process Process;
				ProcessStartInfo ProcessInfo = new ProcessStartInfo("cmd.exe", cmd);
				ProcessInfo.CreateNoWindow = true;
				ProcessInfo.RedirectStandardOutput = true;
				ProcessInfo.UseShellExecute = false;
				Process = Process.Start(ProcessInfo);
				Process.WaitForExit();
				string msg = string.Format("cmd: {0}: completed with ExitCode: {1}", cmd, Process.ExitCode);
//			string msg = string.Format("cmd: {0}: completed with ExitCode: {1} and msg: {2}",
//			                           cmd, Process.ExitCode, Process.StandardOutput.ReadToEnd());
				Process.Close();
				
//			Thread.Sleep(10000);
				Log.LogMsg(msg);
				
				
			} catch (Exception) {
				
				Log.LogMsg(string.Format("proceess killed "));
			}

			lock(myQ)
			{
				--notifStillHandling;
				Monitor.PulseAll(myQ);
			}
		}
		
		private static void handleQ(object Command)
		{
			Log.LogMsg("handleQ launched");
			
			while(isServiceRunning)
			{
				lock(myQ)
				{
					if ((myQ.Count > 0) && (notifStillHandling < maxNotifHandledAtATime))
					{
						++notifStillHandling;
						
						string filename = myQ.Dequeue();
						//Create the task executor thread.
						ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteCommand), filename);
					}
					else
						Monitor.Wait(myQ);
				}
			}
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			// TODO: Add cleanup code here (if required)
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// Start this service.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: Add start code here (if required) to start your service.
			Log.LogMsg("on start called");
			isServiceRunning = true;
			
			// watch as per config file
			cfws = new ConfigurableFWS(FWManager.MainForm.curDir, FWManager.MainForm.configFileName, HandleInitialFiles, OnFileCreate, null, null, null);
		}
		
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add tear-down code here (if required) to stop your service.
			
			cfws = null;
			isServiceRunning = false;
		}
		
		private void HandleInitialFiles(IEnumerable<string> initialfiles)
		{
			lock(myQ)
			{
				foreach (string file in initialfiles) {
					Log.LogMsg("file enqueued: " + file);
					myQ.Enqueue(file);
				}
				Monitor.PulseAll(myQ);
			}
		}
		
		private void OnFileCreate(object sender, FileSystemEventArgs e) {
			string msg = string.Format("OnFileCreate called: File {0} | {1}", e.FullPath, e.ChangeType.ToString());
			lock(myQ)
			{
				myQ.Enqueue(e.FullPath);
				Monitor.PulseAll(myQ);
			}

			Log.LogMsg(msg);
		}
	}
}