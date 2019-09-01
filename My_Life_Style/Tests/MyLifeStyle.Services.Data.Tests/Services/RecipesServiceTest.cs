namespace MyLifeStyle.Services.Data.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Data.Models.Enums;
    using MyLifeStyle.Services.Data.Articles;
    using MyLifeStyle.Services.Data.Recipes;
    using MyLifeStyle.Services.Data.Tests.Common;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Articles;
    using MyLifeStyle.Web.ViewModels.Recipes;
    using Xunit;

    public class RecipesServiceTest
    {
        private RecipesService recipsService;

        public RecipesServiceTest()
        {
            MapperInitializer.InitializeMapper();
        }

        private List<Publication> GetInitialPublicationsData()
        {
            return new List<Publication>
            {
                new Publication
                {
                    Id = "publication_3",
                    Title = "Domati",
                    UserId = "Mimi_1",
                    CreatedOn = DateTime.UtcNow.AddMinutes(-20),
                },
                new Publication
                {
                    Id = "publication_4",
                    Title = "Kashkaval",
                    UserId = "Mimi_2",
                    CreatedOn = DateTime.UtcNow.AddMinutes(-30),
                },
            };
        }


        private List<Recipe> GetInitialRecipesData()
        {
            return new List<Recipe>
            {
                    new Recipe
                    {
                        Ingredients = "Domati i krastavici",
                        Description = "Salata s domati i krastavici",
                        DishType = DishType.Salads,
                        DietType = DietType.Vegan,
                    },
                    new Recipe
                    {
                        Ingredients = "Kashkaval i sirene",
                        Description = "Sandvich s kashkaval i sirene",
                        DishType = DishType.Common,
                        DietType = DietType.Vegetarian,
                    },
            };
        }

        private async Task SeedData(ApplicationDbContext context)
        {
            context.Publications.AddRange(this.GetInitialPublicationsData());
            await context.SaveChangesAsync();
            context.Recipes.AddRange(this.GetInitialRecipesData());
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllRecipes_WithInitialData_ShouldReturnCorrectResult()
        {
            string errorMessagePrefix = "RecipesService Method GetAllRecipes() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();

            await SeedData(context);

            this.recipsService = new RecipesService(context);

            IEnumerable<AllRecipesViewModel> actualResultsEnumerable = await this.recipsService.GetAllRecipes<AllRecipesViewModel>();
            List<AllRecipesViewModel> actualResults = actualResultsEnumerable.ToList();

            List<AllRecipesViewModel> expectedResults = context.Recipes.OrderByDescending(x => x.Publication.CreatedOn).To<AllRecipesViewModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.PublicationTitle == actualEntry.PublicationTitle, errorMessagePrefix + " " + "Title is not returned properly");
                Assert.True(expectedEntry.DishType == actualEntry.DishType, errorMessagePrefix + " " + "DishType is not returned properly");
                Assert.True(expectedEntry.DietType == actualEntry.DietType, errorMessagePrefix + " " + "DietType is not returned properly");
                Assert.True(expectedEntry.Summary == actualEntry.Summary, errorMessagePrefix + " " + "Summary is not returned properly");
            }
        }

        [Fact]
        public async Task GetAllRecipes_WithZeroData_ShouldReturnEmptyResult()
        {

            string errorMessagePrefix = "RecipesService Method GetAllRecipes() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();
            this.recipsService = new RecipesService(context);

            IEnumerable<AllRecipesViewModel> actualResultsEnumerable = await this.recipsService.GetAllRecipes<AllRecipesViewModel>();
            List<AllRecipesViewModel> actualResults = actualResultsEnumerable.ToList();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);

        }

        [Fact]
        public async Task Create_WithCorrectData_ShouldSuccesfullyCreate()
        {
            string errorMessagePrefix = "RecipesService Method CreateRecipe() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();

            await SeedData(context);
            this.recipsService = new RecipesService(context);

            RecipeCreateInputModel recipeCreateInputModel = new RecipeCreateInputModel()
            {
                PublicationTitle = "One Desert",
                Ingredients = "Med i orehi",
                Description = "Razburkvame vsichko",
                DishType = DishType.Desserts,
                DietType = DietType.Raw,
                PublicationUserId = "Mimi_1",
            };

            bool actualResult = await this.recipsService.CreateRecipe(recipeCreateInputModel);
            Assert.True(actualResult, errorMessagePrefix);
        }


    }
}
