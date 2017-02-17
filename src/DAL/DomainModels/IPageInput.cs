using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels
{
    public interface IPageInput
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
