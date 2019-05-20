using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurveyApp.API.Data;
using SurveyApp.API.Data.Entities;
using SurveyApp.API.Models;

namespace SurveyApp.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        private readonly IHttpClientFactory factory;
        private readonly IConfiguration configuration;

        public QuestionsController(AppDbContext context, IMapper mapper, IHttpClientFactory factory, IConfiguration configuration) : base(context, mapper)
        {
            this.factory = factory;
            this.configuration = configuration;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Get([FromQuery]List<int> questionIds)
        {
            var questions = Context.Questions.Include(q => q.Choices);
            List<QuestionDb> qq = new List<QuestionDb>();
            if (questionIds != null && questionIds.Count > 0)
            {
                qq = await questions.Where(u => questionIds.Contains(u.Id)).ToListAsync();
            }
            else
            {
                qq = await questions.ToListAsync();
            }

            var result = Mapper.Map<List<QuestionResponse>>(qq);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]QuestionRequest request, [FromBody]IFormFile file)
        {
            var endpoint = $"{configuration["ImageServer:Url"]}/api/images";
            var client = factory.CreateClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

            client.BaseAddress = new Uri(endpoint);

            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);

            ByteArrayContent bytes = new ByteArrayContent(data);

            MultipartFormDataContent multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "file", file.FileName);

            var response = await client.PostAsync("", multiContent);
            var name = await response.Content.ReadAsStringAsync();

            var result = Mapper.Map<QuestionDb>(request);
            result.ImageUrl = $"{configuration["ImageServer:Url"]}/{name}";

            Context.Questions.Add(result);
            await Context.SaveChangesAsync();

            return Ok(Mapper.Map<QuestionResponse>(result));
        }
    }
}