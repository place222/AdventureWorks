using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels.Categories;

namespace DAL.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDomain>> GetCategoriesAsync();
    }
}
