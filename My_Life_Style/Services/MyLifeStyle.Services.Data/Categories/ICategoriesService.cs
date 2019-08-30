namespace MyLifeStyle.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<TViewModel>> GetAllCategories<TViewModel>();
    }
}
