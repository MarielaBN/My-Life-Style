namespace MyLifeStyle.Web.ViewModels.Recipes
{
    using System;

    using AutoMapper;
    using MyLifeStyle.Common;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Data.Models.Enums;
    using MyLifeStyle.Services.Mapping;

    public class AllRecipesViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PublicationTitle { get; set; }

        public DishType DishType { get; set; }

        public DietType DietType { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public string PublicationId { get; set; }

        public string Summary { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, AllRecipesViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));

            configuration.CreateMap<Recipe, AllRecipesViewModel>()
                .ForMember(
                x => x.Summary,
                opt => opt.MapFrom(x => x.Description.Substring(0, GlobalConstants.SummaryLength) + "..."));
        }
    }
}
