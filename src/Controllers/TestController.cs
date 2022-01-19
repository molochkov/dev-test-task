using json_api_test.DTO;
using Microsoft.AspNetCore.Mvc;

namespace json_api_test.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly IStorage _storage;
        
        public TestController(IStorage storage)
        {
            _storage = storage;
        }

        [RequestSizeLimit(1_000_000_000)]
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadAsync([FromBody] UploadRequest request)
        {            
            var content = _storage.UploadAsync(request.File);
            var data = _storage.UploadAsync(request.Json);
            await Task.WhenAll(content, data);
            HttpContext.Response.RegisterForDispose(request);
            return Ok(new UploadResponse()
            {
                Name = request.Name,
                Data = data.Result,
                Content = content.Result
            });
        }
    }
}
