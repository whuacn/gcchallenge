using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

namespace GmatClubTest.License
{
    /// <summary>
    /// Loads/Saves/Validates keys, Issues/Checks licenses.
    /// </summary>
    public abstract class Manager
    {
        /// <summary>
        /// Generates DSA key and returns it as a XML string
        /// </summary>
        /// <returns>XML</returns>
        public static string GenerateKey()
        {
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider(1024);
            return dsa.ToXmlString(true);
        }

        public static DSACryptoServiceProvider LoadKey(string xml)
        {
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider(0);
            dsa.FromXmlString(xml);
            return dsa;
        }

        public static string ExportPublicKey(DSACryptoServiceProvider dsa)
        {
            return dsa.ToXmlString(false);
        }

        public static byte[] ComputeHash(string fileName)
        {
            int DATA_SIZE = 2048;
            byte[] data = new byte[DATA_SIZE];
            Stream fs = new FileStream(fileName, FileMode.Open);
            int read = fs.Read(data, 0, DATA_SIZE);
            fs.Close();

            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(data, 0, read);
        }

        public static void CheckHash(string fileName, byte[] hash)
        {
            byte[] h = ComputeHash(fileName);

            if (h.Length != hash.Length)
                throw new BadLicense("Hash of file '" + fileName + "' is not valid.");

            for (int i = 0; i < h.Length; ++i)
                if (hash[i] != h[i])
                    throw new BadLicense("Hash of file '" + fileName + "' is not valid.");
        }

        public static XmlDocument IssueLicense(XmlLicense license, DSACryptoServiceProvider dsa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (XmlLicense));
            Stream stream = new MemoryStream();
            serializer.Serialize(stream, license);
            stream.Seek(0, SeekOrigin.Begin);

            XmlDocument xml = new XmlDocument();
            // Format the document to ignore white spaces.
            xml.PreserveWhitespace = false;
            xml.Load(stream);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xml);

            // Add the key to the SignedXml document. 
            signedXml.SigningKey = dsa;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add a transformation to the reference.
            Transform trns = new XmlDsigC14NTransform();
            reference.AddTransform(trns);

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            xml.DocumentElement.AppendChild(xmlDigitalSignature);

            return xml;
        }

        public static XmlLicense CheckLicense(string licenseFileName, string publicKeyFileName)
        {
            try
            {
                StreamReader sr = new StreamReader(publicKeyFileName);
                DSACryptoServiceProvider dsa = LoadKey(sr.ReadToEnd());
                sr.Close();

                XmlDocument xml = new XmlDocument();
                // Format the document to ignore white spaces.
                xml.PreserveWhitespace = false;
                xml.Load(licenseFileName);

                // Create a new SignedXml object and pass it
                // the XML document class.
                SignedXml signedXml = new SignedXml(xml);

                // Find the "Signature" node and create a new
                // XmlNodeList object.
                XmlNodeList nodeList = xml.GetElementsByTagName("Signature");

                // Load the signature node.
                signedXml.LoadXml((XmlElement) nodeList[0]);

                if (!signedXml.CheckSignature(dsa))
                    throw new Exception("The XML signature of the license is not valid.");

                xml.DocumentElement.RemoveChild(nodeList[0]);
                XmlSerializer serializer = new XmlSerializer(typeof (XmlLicense));

                XmlLicense l = (XmlLicense) serializer.Deserialize(new XmlNodeReader(xml));

                if (l.Expired < DateTime.Now)
                    throw new Exception("The license is expired.");

                return l;
            }
            catch (Exception e)
            {
                throw new BadLicense(e.Message);
            }
        }
    }
}