using System;
using System.Xml.Serialization;

namespace GmatClubTest.License
{
    [XmlRoot("license")]
    public class XmlLicense
    {
        public XmlLicense()
        {
        }

        public XmlLicense(string user, string licenseType, DateTime expired, string serialNumber, DateTime issued)
        {
            User = user;
            LicenseType = licenseType;
            Expired = expired;
            SerialNumber = serialNumber;
            Issued = issued;
        }

        public string User;
        public string LicenseType;
        public DateTime Expired;
        public string SerialNumber;
        public DateTime Issued;
    }
}