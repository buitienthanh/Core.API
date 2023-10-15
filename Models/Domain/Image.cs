using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalk.API.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { set; get; }

        public string FileName { get; set; }

        public string? FileDescription { set; get; }

        public string FileExtension { get; set; }

        public long FileSizeInByte { set; get; }

        public string FilePath { get; set; }
    }
}
