using Microsoft.AspNetCore.Mvc;

namespace InFeminine_Web_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagensController : ControllerBase
    {
        private readonly StorageService _storageService;

        public ImagensController(StorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("upload-url")]
        public IActionResult GetUploadUrl([FromQuery] string fileName)
        {
            var url = _storageService.GenerateUploadUrl(fileName);
            return Ok(new { url });
        }

        [HttpGet("download-url")]
        public IActionResult GetDownloadUrl([FromQuery] string fileName)
        {
            var url = _storageService.GenerateDownloadUrl(fileName);
            return Ok(new { url });
        }
    }
}