namespace MyLifeStyle.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICategoriesService
    {
        IEnumerable<TViewModel> GetAllCategories<TViewModel>();
    }
}
