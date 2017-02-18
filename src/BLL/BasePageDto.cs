using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class BasePageDto<T>
    {
        public int ITotalRecords { get; set; }
        public int ITotalDisplayRecords { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
