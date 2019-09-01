namespace MyLifeStyle.Services.Data.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Data.Articles;
    using MyLifeStyle.Services.Data.Tests.Common;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Articles;
    using Xunit;

    public class ArticlesServiceTests
    {
        private ArticlesService articlesService;

        public ArticlesServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        private List<Publication> GetInitialPublicationsData()
        {
            return new List<Publication>
            {
                new Publication
                {
                    Id = "publication_1",
                    Title = "Social Media",
                    UserId = "Mimi_1",
                    CreatedOn = DateTime.UtcNow.AddMinutes(-20),
                },
                new Publication
                {
                    Id = "publication_2",
                    Title = "Interesting Articles",
                    UserId = "Mimi_2",
                    CreatedOn = DateTime.UtcNow.AddMinutes(-30),
                },
            };
        }

        private List<Category> GetInitialCategoriesData()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = "category_1",
                    Name = "Moda",
                    ArticlesCount = 10,
                },
                new Category
                {
                    Id = "category_2",
                    Name = "Sport",
                    ArticlesCount = 10,
                },
            };
        }

        private List<Article> GetInitialArticlesData()
        {
            return new List<Article>
                {
                    new Article
                    {
                    Description = "MyLifeStyle is a social media for sharing of information and ideas",
                    CategoryId = "category_1",
                    PublicationId = "publication_1",
                    },
                    new Article
                    {
                    Description = "Users can create articles in different categories, such as health, sport, arts",
                    CategoryId = "category_2",
                    PublicationId = "publication_2",
                    },
                };
        }


        private async Task SeedData(ApplicationDbContext context)
        {
            context.Publications.AddRange(this.GetInitialPublicationsData());
            await context.SaveChangesAsync();
            context.Categories.AddRange(this.GetInitialCategoriesData());
            await context.SaveChangesAsync();
            // string publicationId = context.Publications.Where(a => a.Title == "Social Media").FirstOrDefault().Id;
            context.Articles.AddRange(this.GetInitialArticlesData());
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllArticles_WithInitialData_ShouldReturnCorrectResult()
        {
            string errorMessagePrefix = "ArticlesService Method GetAllArticles() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();

            await SeedData(context);

            this.articlesService = new ArticlesService(context);

            IEnumerable<ArticleServiceModel> actualResultsEnumerable = await this.articlesService.GetAllArticles<ArticleServiceModel>();

            List<ArticleServiceModel> actualResults = actualResultsEnumerable.ToList();

            List<ArticleServiceModel> expectedResults = context.Articles.OrderByDescending(x => x.Publication.CreatedOn).To<ArticleServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.PublicationTitle == actualEntry.PublicationTitle, errorMessagePrefix + " " + "Title is not returned properly");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not returned properly");
                Assert.True(expectedEntry.CategoryId == actualEntry.CategoryId, errorMessagePrefix + " " + "CategoryId is not returned properly");
                Assert.True(expectedEntry.UserId == actualEntry.UserId, errorMessagePrefix + " " + "UserId is not returned properly");
            }
        }

        [Fact]
        public async Task GetAllArticles_WithZeroData_ShouldReturnEmptyResult()
        {

            string errorMessagePrefix = "ArticlesService Method GetAllArticles() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();
            this.articlesService = new ArticlesService(context);

            IEnumerable<ArticleServiceModel> actualResultsEnumerable = await this.articlesService.GetAllArticles<ArticleServiceModel>();
            List<ArticleServiceModel> actualResults = actualResultsEnumerable.ToList();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);

        }

        [Fact]
        public async Task Create_WithCorrectData_ShouldSuccesfullyCreate()
        {
            string errorMessagePrefix = "ArticlesService Method CreateArticle() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();

            await SeedData(context);
            this.articlesService = new ArticlesService(context);

            ArticleServiceModel articleServiceModel = new ArticleServiceModel()
            {
                PublicationTitle = "Books Exchange",
                Description = "Users can add readed book to list of books for second hand exchange",
                CategoryId = "category_1",
                UserId = "Mimi_1",
            };

            bool actualResult = await this.articlesService.CreateArticle(articleServiceModel);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithCorrectData_ShouldDeleteFromContext()
        {

            string errorMessagePrefix = "ArticlesService Method Delete() does not work properly.";

            var context = MyLifeStyleInmemoryFactory.InitializeContext();

            await SeedData(context);
            this.articlesService = new ArticlesService(context);

            Article articleFromDb = context.Articles.Where(a => a.Description == "MyLifeStyle is a social media for sharing of information and ideas").FirstOrDefault();
            string idToDelete = articleFromDb.Id;

            await this.articlesService.Delete(idToDelete);

            int expectedCount = 1;
            int actualCount = context.Articles.Count();
            Assert.True(expectedCount == actualCount, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithGivenNonExistenId_ShouldThrowArgumentNullException()
        {
            var context = MyLifeStyleInmemoryFactory.InitializeContext();
            await SeedData(context);
            this.articlesService = new ArticlesService(context);
            await Assert.ThrowsAsync<ArgumentNullException>(() => this.articlesService.Delete("Non-Existent"));
        }
    }
}
