using AutoMapper;
using MyLifeStyle.Data.Models;
using MyLifeStyle.Data.Models.Enums;
using MyLifeStyle.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLifeStyle.Web.ViewModels.Recipes
{
   public class RecipeDetailsViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PublicationTitle { get; set; }

        public string Ingredients { get; set; }

        public string Description { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public string PublicationUserFullName { get; set; }

        public DishType DishType { get; set; }

        public DietType DietType { get; set; }

        public string PublicationUserId { get; set; }

        public string CurrentUserId { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, RecipeDetailsViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));
        }
    }
}
