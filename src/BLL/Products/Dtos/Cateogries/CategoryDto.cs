using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Products.Dtos.Cateogries
{
    public class CategoryDto
    {
        public int ProductCategoryID { get; set; }
        public int? ProductSubCategoryID { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDto> Children { get; set; }

        public CategoryDto()
        {
            Children = new List<CategoryDto>();
        }
    }
}
