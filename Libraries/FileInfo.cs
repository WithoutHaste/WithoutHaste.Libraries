using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Libraries
{
	public static class FileInfo
	{
		/// <summary>
		/// Throws exception if the filename does not have the expected extension.
		/// </summary>
		/// <param name="filename">Filename, may include path.</param>
		/// <param name="extension">File extension, starting with '.'</param>
		/// <exception cref="ArgumentException">Filename is null.</exception>
		/// <exception cref="ArgumentException">Extension is null.</exception>
		/// <exception cref="FileExtensionException">Unexpected file extension.</exception>
		public static void ValidateExtension(string filename, string extension)
		{
			if(filename == null)
				throw new ArgumentException("Filename cannot be null.", "filename");
			if(extension == null)
				throw new ArgumentException("Extension cannot be null.", "extension");

			string expectedExtension = extension.ToLower();
			string actualExtension = Path.GetExtension(filename).ToLower();
			if(actualExtension != expectedExtension)
			{
				throw new FileExtensionException("Unexpected file extension.", expectedExtension, actualExtension);
			}
		}

		/// <summary>
		/// Throws exception if the filename does not have any of the possible extensions.
		/// </summary>
		/// <param name="filename">Filename, may include path.</param>
		/// <param name="extensions">Possible file extensions, each starting with '.'</param>
		/// <exception cref="ArgumentException">Filename is null.</exception>
		/// <exception cref="ArgumentException">Extensions is null.</exception>
		/// <exception cref="FileExtensionException">Unexpected file extension.</exception>
		public static void ValidateExtension(string filename, string[] extensions)
		{
			if(filename == null)
				throw new ArgumentException("Filename cannot be null.", "filename");
			if(extensions == null)
				throw new ArgumentException("Extensions cannot be null.", "extensions");

			string actualExtension = Path.GetExtension(filename).ToLower();
			foreach(string extension in extensions)
			{
				string expectedExtension = extension.ToLower();
				if(actualExtension == expectedExtension)
				{
					return;
				}
			}
			throw new FileExtensionException("Unexpected file extension.", extensions.Select(e => e.ToLower()).ToArray(), actualExtension);
		}
	}
}
