/*
 * Created by SharpDevelop.
 * User: sudeeplocaluser
 * Date: 12/28/2012
 * Time: 11:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace FWManager
{
	/// <summary>
	/// Description of Log.
	/// </summary>
	public class Log
	{
		private static string log = "LOG";
		private static string LogFileNameF = FWManager.MainForm.curDir + "\\fwservicelog.txt";
		public static void LogMsg(string message)
		{
			DateTime dt = new DateTime();
			dt = DateTime.UtcNow;
			message = dt.ToLocalTime().ToString() + " : " + message;
			
			lock(Log.log)
			{
				using (TextWriter tw = new StreamWriter(LogFileNameF, true)) {
					tw.WriteLine(message);
				}
			}
		}
	}
}
