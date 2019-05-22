using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.API.Data;
using SurveyApp.API.Services;

namespace SurveyApp.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public BaseController(AppDbContext context, IMapper mapper, NotificationService notificationService)
        {
            Context = context;
            Mapper = mapper;
            NotificationService = notificationService;
        }

        public AppDbContext Context { get; }
        public IMapper Mapper { get; }
        public NotificationService NotificationService { get; }
    }
}