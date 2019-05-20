using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.API.Data;

namespace SurveyApp.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public BaseController(AppDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public AppDbContext Context { get; }
        public IMapper Mapper { get; }
    }
}