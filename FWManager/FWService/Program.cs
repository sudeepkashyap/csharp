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
using System.ServiceProcess;
using System.Text;

namespace FWManager
{
	static class Program
	{
		/// <summary>
		/// This method starts the service.
		/// </summary>
		static void Main()
		{
			// To run more than one service you have to add them here
			ServiceBase.Run(new ServiceBase[] { new FWService() });
		}
	}
}
