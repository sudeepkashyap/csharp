/*
 * Created by SharpDevelop.
 * User: sudeeplocaluser
 * Date: 12/28/2012
 * Time: 11:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using FWManager;

namespace FWManager
{
	public delegate void FSEHPtr(object o, FileSystemEventArgs e);
	public delegate void REHPtr(object o, RenamedEventArgs e);
	public delegate void HandleInitialFilesPtr(IEnumerable<string> l);
	
	/// <summary>
	/// Description of ConfigurableFWS.
	/// </summary>
	public class ConfigurableFWS
	{
		private string configfilename;
		private HandleInitialFilesPtr HandleInitialFiles;
		private FSEHPtr OnFileCreate = null;
		private FSEHPtr OnFileChange = null;
		private FSEHPtr OnFileDelete = null;
		private REHPtr OnFileRename = null;
		private FileSystemWatcher watcher = null;
		private SortedList<string, FileSystemWatcher> fswList = new SortedList<string, FileSystemWatcher>();

		public ConfigurableFWS(String dir, String filename, HandleInitialFilesPtr handleInitialFiles, FSEHPtr onFileCreate, FSEHPtr onFileChange, FSEHPtr onFileDelete, REHPtr onFileRename)
		{
			configfilename = dir + "\\" + filename;
			HandleInitialFiles = handleInitialFiles;
			OnFileCreate = onFileCreate;
			OnFileChange = onFileChange;
			OnFileDelete = onFileDelete;
			OnFileRename = onFileRename;
			// Create a new FileSystemWatcher with the path and config file filter
			watcher = new FileSystemWatcher(FWManager.MainForm.curDir, FWManager.MainForm.configFileName);

			//Watch for changes in LastAccess and LastWrite times, and
			//the renaming of files or directories.
			watcher.NotifyFilter = NotifyFilters.LastAccess
				| NotifyFilters.LastWrite
				| NotifyFilters.FileName
				| NotifyFilters.DirectoryName;

			// Add event handlers.
			watcher.Changed += new FileSystemEventHandler(OnFWConfigChanged);
			watcher.Created += new FileSystemEventHandler(OnFWConfigChanged);
			watcher.Deleted += new FileSystemEventHandler(OnFWConfigDeleted);
//			watcher.Renamed += new RenamedEventHandler(OnRenamed);

			// Begin watching.
			watcher.EnableRaisingEvents = true;
			
			Watch();
		}

		~ConfigurableFWS()
		{
			watcher.EnableRaisingEvents = false;
			watcher.Dispose();
			
			int size = fswList.Keys.Count;
			for (int i = 0; i < size; i++) {
				string path = fswList.Keys[i];
				fswList[path].EnableRaisingEvents = false;
				fswList[path].Dispose();
				fswList.Remove(path);
			}
			fswList = null;
		}
		
		public void Watch()
		{
			List<string> initialfileslist = new List<string>();
			HashSet<string> newPathsSet = new HashSet<string>();
			using(TextReader tr = new StreamReader(FWManager.MainForm.configFileNameF))
			{
				string line;
				while((line = tr.ReadLine()) != null) {
					string path = line.Split(FWManager.MainForm.sepPipe)[0];
					string file = line.Split(FWManager.MainForm.sepPipe)[1];
					newPathsSet.Add(path);

					if (!fswList.ContainsKey(path)) {
						FileSystemWatcher fsw = new FileSystemWatcher(path, file);
						fsw.NotifyFilter = NotifyFilters.LastAccess
							| NotifyFilters.LastWrite
							| NotifyFilters.FileName
							| NotifyFilters.DirectoryName;

						// Add event handlers.
						if (OnFileCreate != null)
							fsw.Created += new FileSystemEventHandler(OnFileCreate);
						if (OnFileChange != null)
							fsw.Changed += new FileSystemEventHandler(OnFileChange);
						if (OnFileDelete != null)
							fsw.Deleted += new FileSystemEventHandler(OnFileDelete);
						if (OnFileRename != null)
							fsw.Renamed += new RenamedEventHandler(OnFileRename);

						// Begin watching.
						fsw.EnableRaisingEvents = true;
						Log.LogMsg("Started monitoring path: " + path);

						fswList.Add(path, fsw);
						
						// enqueue any existing files
						HandleInitialFiles(Directory.EnumerateFiles(path, file));
					}
				}
			}

			// remove the unmonitored paths
			int size = fswList.Keys.Count;
			for (int i = 0; i < size; i++) {
				string path = fswList.Keys[i];
				if (!newPathsSet.Contains(path)) {
					fswList[path].EnableRaisingEvents = false;
					Log.LogMsg("Stopped monitoring path: " + path);
					fswList[path].Dispose();
					fswList.Remove(path);
				}
			}
		}
		void OnFWConfigChanged(object sender, FileSystemEventArgs e) {
			string msg = string.Format("OnFWConfigChanged called: File {0} | {1}", e.FullPath, e.ChangeType.ToString());
			Log.LogMsg(msg);
			
			Watch();
		}

		void OnFWConfigDeleted(object sender, FileSystemEventArgs e) {
			string msg = string.Format("OnFWConfigDeleted called: File {0} | {1}", e.FullPath, e.ChangeType.ToString());
			Log.LogMsg(msg);
			int size = fswList.Keys.Count;
			for (int i = 0; i < size; i++) {
				string path = fswList.Keys[i];
				fswList[path].EnableRaisingEvents = false;
				Log.LogMsg("Stopped monitoring path: " + path);
				fswList[path].Dispose();
				fswList.Remove(path);
			}
		}
	}
}
