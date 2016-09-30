using System.IO;
using System.Xml.Serialization;

namespace OnlineBatchReceiver.Utils
{
    public static class FileUtil
    {
        public static void SaveXmlFileToDisk<T>(string filepath, string folderName, string filename, XmlSerializer serializer, T result)
        {
            var pathAndFile = GetPathWithFilename(filepath, folderName, filename, ".xml");
            var file = File.Create(pathAndFile);

            serializer.Serialize(file, result);
            file.Close();
        }

        private static string GetPathWithFilename(string filepath, string folderName, string filename, string fileextention)
        {
            var path = Path.Combine(filepath + "\\" + folderName + "\\");
            Directory.CreateDirectory(path);

            var pathAndFile = Path.Combine(path, SafeFileName(filename + fileextention));
            return pathAndFile;
        }

        private static string SafeFileName(string path)
        {
            return path.Replace("\\", "").Replace("/", "").Replace("\"", "").Replace("*", "").Replace(":", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "");
        }

        public static bool AlreadyExists(string filepath, string folderName, string username,
            string receiversReference, long sequenceNumber)
        {
            var path = Path.Combine(filepath + "\\" + folderName + "\\");
            var dir = new DirectoryInfo(path);
            var filesInDir = dir.GetFiles("*" + receiversReference + "*.*");

            return filesInDir.Length > 0;
        }

        public static void SaveAttatchmentsAsZip(string filepath, string folderName, string filename, byte[] attachments)
        {
            if (attachments == null || attachments.Length == 0) return;

            File.WriteAllBytes(GetPathWithFilename(filepath, folderName, filename, ".zip"), attachments);
        }
    }
}