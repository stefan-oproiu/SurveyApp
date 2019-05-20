using AutoMapper;
using SurveyApp.API.Data.Entities;
using SurveyApp.API.Models;
using System.Linq;

namespace SurveyApp.API.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpRequest, UserDb>();
            CreateMap<LoginRequest, UserDb>();
            CreateMap<SignUpRequest, LoginRequest>();
            CreateMap<QuestionDb, QuestionResponse>();
            CreateMap<QuestionRequest, QuestionDb>();
            CreateMap<SurveyRequest, SurveyDb>();
            CreateMap<SubmissionDb, SubmissionResponse>()
                .ForMember(
                    dest => dest.Questions,
                    opt => opt.MapFrom(src => src.Choices.Select(c => c.QuestionChoice.Question))
                );
            CreateMap<SubmissionRequest, SubmissionDb>();
            CreateMap<SurveyDb, SurveyResponse>()
                .ForMember(
                    dest => dest.Questions,
                    opt => opt.MapFrom(src => src.Questions.Select(q => q.Question))
                );
            CreateMap<ChoiceRequest, QuestionChoiceDb>();
        }
    }
}
