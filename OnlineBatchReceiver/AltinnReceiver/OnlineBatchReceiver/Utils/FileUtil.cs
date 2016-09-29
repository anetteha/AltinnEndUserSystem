using System;
using System.IO;
using System.Xml.Serialization;

namespace OnlineBatchReceiver.Utils
{
    public static class FileUtil
    {
        public static void SaveXmlFileToDisk<T>(string filepath, string folderName, string filename, XmlSerializer serializer, T result)
        {
            var path = Path.Combine(filepath + "\\" + folderName + "\\");
            Directory.CreateDirectory(path);

            var pathAndFile = Path.Combine(path, SafeFileName(filename));
            var file = File.Create(pathAndFile);

            serializer.Serialize(file, result);
            file.Close();
        }

        private static string SafeFileName(string path)
        {
            return path.Replace("\\", "").Replace("/", "").Replace("\"", "").Replace("*", "").Replace(":", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "");
        }
    }
}