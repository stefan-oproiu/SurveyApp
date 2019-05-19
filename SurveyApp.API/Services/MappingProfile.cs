using AutoMapper;
using SurveyApp.API.Data.Entities;
using SurveyApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpRequest, UserDb>();
            CreateMap<LoginRequest, UserDb>();
        }
    }
}
