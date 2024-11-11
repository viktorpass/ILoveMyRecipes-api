using AutoMapper;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.Mappings {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            CreateMap<RecipeType, RecipeTypeDTO>().ReverseMap();
            CreateMap<RecipeType, RecipeTypePutDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserPutDTO>().ReverseMap();
            CreateMap<Recipe, RecipePutDTO>().ReverseMap();


        }
    }
}
