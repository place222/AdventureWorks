using System.Collections.Generic;

namespace Web.Models.ProductViewModels
{
    public class CategoryTreeViewModel
    {
        public int ProductCategoryID { get; set; }
        public int ProductSubCategoryID { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategoryTreeViewModel> Children { get; set; }
    }
}
