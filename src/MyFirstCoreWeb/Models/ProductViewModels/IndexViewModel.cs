using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.Entities.Production;

namespace MyFirstCoreWeb.Models.ProductViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CategoryTreeViewModel> CategoryTreeViewModels { get; set; }

        public IEnumerable<ProductWithPhotoViewModel> ProductWithPhotoModels { get; set; }

        public IndexViewModel()
        {
            CategoryTreeViewModels = new List<CategoryTreeViewModel>();
            ProductWithPhotoModels= new List<ProductWithPhotoViewModel>();
        }
    }
}
