using System;
using System.Xml.Serialization;


namespace GmatClubTest.License
{
	[XmlRootAttribute("license")]
	public class XmlLicense
	{
		public XmlLicense() {}
		public XmlLicense(string user, string licenseType, DateTime expired, string serialNumber, DateTime issued)
		{
			this.User = user;
			this.LicenseType = licenseType;
			this.Expired = expired;
			this.SerialNumber = serialNumber;
			this.Issued = issued;
		}

		public string User;
		public string LicenseType;
		public DateTime Expired;
		public string SerialNumber;
		public DateTime Issued;
	}
}
