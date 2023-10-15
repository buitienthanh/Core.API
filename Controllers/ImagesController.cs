using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] ImageRequestDto imageRequestDto)
        {
            ValidateFileUpload(imageRequestDto);

            if (ModelState.IsValid)
            {
                Image image = new Image
                {
                    File = imageRequestDto.File,
                    FileName = imageRequestDto.FileName,
                    FileDescription = imageRequestDto.FileDescription,
                    FileExtension = Path.GetExtension(imageRequestDto.File.FileName),
                    FileSizeInByte = imageRequestDto.File.Length
                };

                await imageRepository.Upload(image);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageRequestDto imageRequestDto)
        {
            var allowedExtentions = new string[] { ".jpg", ".png", ".jpeg" };

            if (!allowedExtentions.Contains(Path.GetExtension(imageRequestDto.File.FileName)))
            {
                ModelState.AddModelError("File", "Định dạng file không hỗ trợ.");
            }

            if (imageRequestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "Dung lượng file không được vượt quá 10MB.");
            }

        }

    }
}
