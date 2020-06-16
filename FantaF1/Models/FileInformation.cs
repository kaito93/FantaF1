using System.Web;

namespace FantaF1.Models
{
    public class FileInformation
    {
        public string FileName { get; set; }
        public byte[] BinaryData { get; set; }
        public string ContentType { get; set; }
        public string FileExtension { get; set; }
        public HttpPostedFileBase File { get; set; }

    }
}