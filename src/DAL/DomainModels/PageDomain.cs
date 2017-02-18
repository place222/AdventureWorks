using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels
{
    public class PageDomain<T>
    {
        public int TotalRecord { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
