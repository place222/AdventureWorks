using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreWebApi.Models
{
    public class BaseOutput<T>:BaseOutput
    {
        public T Data { get; set; }
    }
}
