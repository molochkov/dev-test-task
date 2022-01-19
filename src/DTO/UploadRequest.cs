using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace json_api_test.DTO
{
    public class UploadRequest : IDisposable
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public JToken Json { get; set; }

        [Required]
        public byte[] File { get; set; }

        public void Dispose()
        {
            Json = null;
            File = null;
            GC.Collect();
        }

    }
}
