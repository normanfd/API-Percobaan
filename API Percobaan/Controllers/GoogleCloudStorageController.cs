using Action;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_Percobaan.Controllers
{
    [ApiController]
    [Route("api/v1/image")]
    public class GoogleCloudStorageController : ControllerBase
    {
        readonly UploadFileGoogleCloudStorageAction action = new UploadFileGoogleCloudStorageAction();
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromBody] ImagesEntity data)
        {
            byte[] Imagebytes = Convert.FromBase64String(data.Base64);
            await action.UploadFileAsync(Imagebytes, "gambarcoba/cobaImage.jpg");
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> DownloadImage()
        {
            var fileStream = action.GetFileStreamAsync("cobaImage.jpg");
            return Ok(fileStream);
        }
        [HttpGet]
        [Route("/signed_url")]
        public async Task<IActionResult> GetSignedUrl()
        {
            var fileStream = action.GetUrlSigned();
            return Ok(fileStream);
        }
    }
}
