using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Libraries
{
	public class FileExtensionException : Exception
	{
		public readonly string ExpectedExtension;
		public readonly string ActualExtension;

		public FileExtensionException(string message, string expectedExtension, string actualExtension) : base(message)
		{
			ExpectedExtension = expectedExtension;
			ActualExtension = actualExtension;
		}

		public FileExtensionException(string message, string[] expectedExtensions, string actualExtension) : base(message)
		{
			ExpectedExtension = String.Join(", ", expectedExtensions);
			ActualExtension = actualExtension;
		}
	}
}
