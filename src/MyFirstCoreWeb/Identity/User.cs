using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyFirstCoreWeb.Identity
{
    public class User : IdentityUser<int>
    {

    }

    public class Role : IdentityRole<int>
    {
        
    }
}
