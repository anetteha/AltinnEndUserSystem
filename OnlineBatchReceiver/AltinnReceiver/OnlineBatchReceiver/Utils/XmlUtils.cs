using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OnlineBatchReceiver.Utils
{
    public static class XmlUtils
    {
        public static XmlSerializer GetXmlSerializerOfType<T>()
        {
            // Creating XmlSerializer object 
            var serializer = new XmlSerializer(typeof(T));

            return serializer;
        }

        public static T DeserializeXmlString<T>(XmlSerializer serializer, string batch)
        {
            T result;

            using (TextReader reader = new StringReader(batch))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }

        public static bool ValidateBatchXml(string batchXml, string filepath, List<string> xmlSchemas)
        {
            try
            {
                var doc = new XmlDocument();

                foreach (var xmlSchema in xmlSchemas)
                {
                    doc.Schemas.Add("", filepath + xmlSchema);
                }

                doc.LoadXml(batchXml);
                doc.Validate(xmlValidationEventHandler);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void xmlValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Warning:
                    throw new XmlSchemaValidationException();
                case XmlSeverityType.Error:
                    throw new XmlSchemaValidationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string SerializeXmlObjectToString<T>(T receiptResult)
        {
            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stringWriter, receiptResult);
            return stringWriter.ToString();
        }
    }
}