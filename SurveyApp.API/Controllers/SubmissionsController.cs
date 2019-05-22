using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.API.Data;
using SurveyApp.API.Data.Entities;
using SurveyApp.API.Models;
using SurveyApp.API.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/submissions")]
    [ApiController]
    public class SubmissionsController : BaseController
    {
        public SubmissionsController(AppDbContext context, IMapper mapper, NotificationService notificationService) : base(context, mapper, notificationService)
        {
        }

        [HttpGet]
        [Authorize]
        [Route("{submissionId}")]
        public async Task<IActionResult> Get(int submissionId)
        {
            var submission = await Context.Submissions.Include(s => s.Choices).ThenInclude(c => c.QuestionChoice).ThenInclude(c => c.Question)
                    .FirstOrDefaultAsync(s => s.Id == submissionId);
            return Ok(Mapper.Map<SubmissionResponse>(submission));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery]int? userId)
        {
            var submissions = await Context.Submissions
                .Include(s => s.Choices)
                .ThenInclude(c => c.QuestionChoice)
                .ThenInclude(c => c.Question).ToListAsync();
            
            if (userId != null)
            {
                submissions = submissions.Where(s => s.UserId == userId).ToList();
            }

            var result = Mapper.Map<List<SubmissionResponse>>(submissions);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]SubmissionRequest request)
        {
            var submission = Mapper.Map<SubmissionDb>(request);
            Context.Submissions.Add(submission);
            await Context.SaveChangesAsync();
            var questionChoices = await Context.QuestionChoices.Where(q => request.QuestionChoicesIds.Contains(q.Id)).ToListAsync();
            questionChoices.ForEach(c => submission.Choices.Add(new SubmissionQuestionChoiceDb { SubmissionId = submission.Id, QuestionChoiceId = c.Id }));
            return Ok();
        }

    }
}