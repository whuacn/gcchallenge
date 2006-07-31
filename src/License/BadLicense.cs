using System;

namespace GmatClubTest.License
{
	public class BadLicense: Exception
	{
		public BadLicense() {}
		public BadLicense(string message): base(message) {}
	}
}
