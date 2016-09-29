using System;
using System.IO;
using System.Reflection;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using log4net;

namespace OnlineBatchReceiver
{
    /// <summary>
    /// Summary description for OnlineBatchReceiverSoap
    /// </summary>
    // [WebService(Namespace = "http://tempuri.org/")]
    // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [WebServiceBinding(Name = "OnlineBatchReceiverSoap", Namespace = "http://AltInn.no/webservices/")]
    public class OnlineBatchReceiverSoap : WebService
    {
        private readonly ILog _logger;
        private readonly string _filepath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

        public OnlineBatchReceiverSoap()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapDocumentMethod("http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment",
            RequestNamespace = "http://AltInn.no/webservices/",
            ResponseNamespace = "http://AltInn.no/webservices/",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, [XmlElementAttribute(DataType = "base64Binary")] byte[] attachments)
        {
            _logger.Info("ReceiveOnlineBatchExternalAttachment Recieved from: " + username);
            _logger.Debug("ReceiveOnlineBatchExternalAttachment Recieved from: " + username + " Batch: " + batch);

            // Authenticate username + passw
            if (Authenticate(username, passwd))
            {
                _logger.Debug("ReceiveOnlineBatchExternalAttachment, User Aithenticated");
                // Verify batch vs. XSD (Schema verification)
                if (!VerifyBatchSchema(batch))
                {
                    _logger.Debug("ReceiveOnlineBatchExternalAttachment Validation Failed");
                    return Response(resultCodeType.FAILED_DO_NOT_RETRY);
                }

                try
                {
                    // Deserializing object 
                    var serializer = new XmlSerializer(typeof(DataBatch));
                    DataBatch result;

                    using (TextReader reader = new StringReader(batch))
                    {
                        result = (DataBatch)serializer.Deserialize(reader);
                    }

                    // Saving payload to disk
                    var path = Path.Combine(_filepath + "\\RecievedXml\\");
                    Directory.CreateDirectory(path);

                    var pathAndFile = Path.Combine(path, SafeFileName(
                        DateTime.Now + "_" + username + "_" + receiversReference + "_" + sequenceNumber + ".xml"));
                    var file = File.Create(pathAndFile);

                    serializer.Serialize(file, result);
                    file.Close();

                    // TODO save attachments
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return ex.Message;
                }

                _logger.Debug("ReceiveOnlineBatchExternalAttachment Validated OK ");
                return Response(resultCodeType.OK);
            }

            _logger.Debug("ReceiveOnlineBatchExternalAttachment Invalid request");
            return Response(resultCodeType.FAILED_DO_NOT_RETRY);
        }


        private bool Authenticate(string username, string password)
        {
            // Trust everyone :)
            return true;
        }

        private bool VerifyBatchSchema(string batchXml)
        {
            //Validerer skjema med xdocument
            var result = true;
            XDocument xdoc;

            try
            {
                xdoc = XDocument.Parse(batchXml);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }

            //var serializer = new XmlSerializer(typeof(DataBatch));
            //DataBatch data;

            //using (TextReader reader = new StringReader(batchXml))
            //{
            //    data = (DataBatch)serializer.Deserialize(reader);
            //}

            // TODO verify xml validation

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add("", _filepath + "/xsd/genericbatch.2013.06.xsd");

            xdoc.Validate(schemaSet, (sender, e) =>
            {
                _logger.Debug("Validating xml request");
                result = false;
            });

            return result;
        }

        private string Response(resultCodeType code)
        {
            var receiptResult = new OnlineBatchReceiptResult
            {
                resultCode = code,
                resultCodeSpecified = true,
                Value = ""
            };

            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(OnlineBatchReceiptResult));
            serializer.Serialize(stringWriter, receiptResult);
            return stringWriter.ToString();
        }

        private static string SafeFileName(string path)
        {
            return path
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }
    }
}
