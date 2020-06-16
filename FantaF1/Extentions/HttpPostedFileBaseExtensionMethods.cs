using FantaF1.Models;
using System.Web;

namespace FantaF1.Extentions
{
    public static class HttpPostedFileBaseExtensionMethods
    {
        public static string GetFileName(this HttpPostedFileBase file)
        {
            return file.FileName;
        }

        public static string GetContentType(this HttpPostedFileBase file)
        {
            var contentType = file.ContentType;
            return contentType;
        }

        public static byte[] GetBinaryData(this HttpPostedFileBase file)
        {
            var fileBinary = new byte[file.InputStream.Length];
            file.InputStream.Read(fileBinary, 0, fileBinary.Length);
            return fileBinary;
        }

        public static string GetFileExtension(this HttpPostedFileBase file)
        {
            return System.IO.Path.GetExtension(GetFileName(file));
        }

        public static FileInformation GetFileInformation(this HttpPostedFileBase file)
        {
            return new FileInformation
            {
                FileName = GetFileName(file),
                ContentType = GetContentType(file),
                FileExtension = GetFileExtension(file),
                BinaryData = GetBinaryData(file),
                File = file
            };
        }
    }
}