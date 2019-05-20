using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.API.Data;
using SurveyApp.API.Data.Entities;
using SurveyApp.API.Models;

namespace SurveyApp.API.Controllers
{
    [Route("api/surveys")]
    [ApiController]
    public class SurveysController : BaseController
    {
        public SurveysController(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await Context.Surveys.Include(s => s.Questions).Include(s => s.Submissions).ToListAsync();
            return Ok(result);
        }


        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Context.Surveys.Include(s => s.Questions).Include(s => s.Submissions).FirstOrDefaultAsync(s => s.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Post([FromBody]SurveyRequest request)
        {
            var survey = Mapper.Map<SurveyDb>(request);
            var questions = await Context.Questions.Where(q => request.QuestionIds.Contains(q.Id)).ToListAsync();
            Context.Surveys.Add(survey);
            await Context.SaveChangesAsync();
            questions.ForEach(q => survey.Questions.Add(new SurveyQuestionDb { Survey = survey, Question = q }));
            await Context.SaveChangesAsync();
            var result = await Context.Surveys.Include(s => s.Questions).Include(s => s.Submissions)
                .FirstOrDefaultAsync(s => s.Id == survey.Id);

            return Ok(result);
        }
    }
}