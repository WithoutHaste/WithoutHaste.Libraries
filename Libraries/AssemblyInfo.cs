using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Libraries
{
    public static class AssemblyInfo
    {
		public static Version GetVersion()
		{
			return Assembly.GetExecutingAssembly().GetName().Version;
		}

		public static Dictionary<string, Version> GetAssemblyVersions(string[] dllNames)
		{
			return dllNames.ToDictionary(dll => Path.GetFileNameWithoutExtension(dll), dll => GetAssemblyVersion(dll));
		}

		private static Version GetAssemblyVersion(string dllName)
		{
			if(!dllName.EndsWith(".dll"))
				dllName += ".dll";
			Assembly assembly = Assembly.LoadFrom(dllName);
			return assembly.GetName().Version;
		}
	}
}
