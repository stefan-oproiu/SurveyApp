using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.ImageServer.Data;
using SurveyApp.ImageServer.Data.Models;

namespace SurveyApp.ImageServer.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext context;

        public ImagesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var images = await context.Images.Select(i => i.Name).ToListAsync();
            return Ok(images);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get([FromRoute]string name)
        {
            var image = await context.Images.FirstOrDefaultAsync(i => i.Name == name);
            if (image == null)
            {
                return NotFound();
            }

            return File(image.Content, $"{image.Type}");
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var contentType = Request.Headers["content"].ToString();
                    Console.WriteLine(file.ContentType);
                    byte[] p1 = null;
                    using (var fs1 = file.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }

                    var appImage = new AppImage { Name = Guid.NewGuid().ToString(), Content = p1, Type = contentType };

                    context.Images.Add(appImage);
                    await context.SaveChangesAsync();

                    return Ok(appImage.Name);
                }
                else return BadRequest("file length");
            }
            else return BadRequest("file[0] is null");
        }
    }
}