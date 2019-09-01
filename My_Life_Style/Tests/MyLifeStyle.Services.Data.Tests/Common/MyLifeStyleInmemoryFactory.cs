namespace MyLifeStyle.Services.Data.Tests.Common
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using MyLifeStyle.Data;

    public static class MyLifeStyleInmemoryFactory
    {
        public static ApplicationDbContext InitializeContext()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }
    }
}
