using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RecipeTastic.Dtos;
using RecipeTastic.Models;

namespace RecipeTastic.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<RecipeBook, RecipeBookDto>();
            Mapper.CreateMap<RecipeBookDto, RecipeBook>();
        }
    }
}