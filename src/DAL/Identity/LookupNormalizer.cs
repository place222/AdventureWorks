using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class LookupNormalizer:ILookupNormalizer
    {
        public string Normalize(string key)
        {
            return key;
        }
    }
}
