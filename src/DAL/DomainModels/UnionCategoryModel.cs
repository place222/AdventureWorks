using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels
{
    public class UnionCategoryModel
    {
        public int ProductCategoryID { get; set; }
        public int ProductSubCategoryID { get; set; }
        public string Name { get; set; }
    }
}
