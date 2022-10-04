using YG.API.Attributes;
using YG.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YG.API.Common_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImgController : ControllerBase
    {
        private IHttpClientFactory _factory;
        private MyTypedClient _client;
        public UploadImgController( IHttpClientFactory factory, MyTypedClient client)
        {
            _factory = factory;
            _client = client;
        }

        [HttpPost("UploadImg")]
        public IActionResult UploadImage(List<IFormFile> img, Guid IDBaiVIet)
        {
            var temp = _client.PostImgAndGetData(img,IDBaiVIet);
            return Ok(temp);
        }
    }
}
