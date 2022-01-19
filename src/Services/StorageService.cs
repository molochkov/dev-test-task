using Newtonsoft.Json.Linq;

namespace json_api_test
{
    public interface IStorage
    {
        public Task<string> UploadAsync(byte[] data);
        public Task<string> UploadAsync(JToken data);
    }

    public class StorageService : IStorage
    {
        public async Task<string> UploadAsync(byte[] data)
        {
            var file = Path.GetTempFileName();
            await File.WriteAllBytesAsync(file, data);
            return file;
        }

        public async Task<string> UploadAsync(JToken data)
        {
            var json = System.Text.Encoding.UTF8.GetBytes(data.ToString());
            return await UploadAsync(json);

        }
    }
}
