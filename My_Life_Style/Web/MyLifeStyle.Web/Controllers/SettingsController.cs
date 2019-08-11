﻿namespace MyLifeStyle.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MyLifeStyle.Data.Common.Repositories;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Settings;

    public class SettingsController : BaseController
    {
        private readonly IDeletableEntityRepository<Setting> repository;

        public SettingsController(IDeletableEntityRepository<Setting> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var settings = this.repository.All().To<SettingViewModel>().ToList();
            var model = new SettingsListViewModel { Settings = settings };
            return this.View(model);
        }

        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.repository.AddAsync(setting);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
