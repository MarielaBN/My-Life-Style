namespace MyLifeStyle.Services.Data.Tests.Common
{
    using System.Reflection;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels;
    using MyLifeStyle.Web.ViewModels.Articles;

    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {

            AutoMapperConfig.RegisterMappings(typeof(ArticleServiceModel).GetTypeInfo().Assembly, typeof(Publication).GetTypeInfo().Assembly, typeof(Article).GetTypeInfo().Assembly);
        }
    }
}
