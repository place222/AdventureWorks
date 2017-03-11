﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreWebApi.Models
{
    public class BaseOutput
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public BaseOutput()
        {
            ErrorCode = 200;
        }
    }
}
