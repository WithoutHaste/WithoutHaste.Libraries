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
		/// <summary>
		/// Returns the version of this library.
		/// </summary>
		public static Version GetVersion()
		{
			return Assembly.GetExecutingAssembly().GetName().Version;
		}

		/// <summary>
		/// Returns the version of the specified assembly.
		/// </summary>
		public static Version GetVersion(Assembly assembly)
		{
			return assembly.GetName().Version;
		}

		private static Version GetDllVersion(string dllName)
		{
			if(!dllName.EndsWith(".dll"))
				dllName += ".dll";
			Assembly assembly = Assembly.LoadFrom(dllName);
			return GetVersion(assembly);
		}

		public static string GetSemanticVersion(Assembly assembly)
		{
			Version version = GetVersion(assembly);
			return GetSemanticVersion(version);
		}

		public static string GetSemanticVersion(Version version)
		{
			return String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
		}

		public static Dictionary<string, Version> GetDllVersions(string[] dllNames)
		{
			return dllNames.ToDictionary(dll => Path.GetFileNameWithoutExtension(dll), dll => GetDllVersion(dll));
		}
	}
}
