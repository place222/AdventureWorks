using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
    }
}
