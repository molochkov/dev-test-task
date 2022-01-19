using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace json_api_test.DTO
{
    public class UploadResponse
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public string Content { get; set; }
    }
}
