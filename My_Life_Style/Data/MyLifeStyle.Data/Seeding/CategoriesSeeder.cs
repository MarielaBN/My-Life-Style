namespace MyLifeStyle.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyLifeStyle.Data.Models;

    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var seededCategories = new List<string>
            {
                "Общи",
                "Здраве",
                "Хранене",
                "Спорт",
                "Йога",
                "Хоби",
                "Култура",
                "Музика",
                "Танци",
                "Кино",
                "Изобразително Изкуство",
                "Интериор",
                "Мода",
                "Техника",
                "Информационни Технологии",
                "Литература",
                "Психология",
                "Личностно Развитие",
                "Духовно Развитие",
                "Астрология",
                "Природа",
                "Туризъм",
                "Козметика",
                "Красота",
            };

            foreach (var category in seededCategories)
            {
                await dbContext.Categories.AddAsync(new Category { Name = category, ArticlesCount = 0 });
            }
        }
    }
}
