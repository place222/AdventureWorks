using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstCoreWebApi.Controllers
{
    public class BaseController : Controller
    {
        protected ILogger<BaseController> Logger { get; }

        public BaseController(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<BaseController>();
        }
    }
}
