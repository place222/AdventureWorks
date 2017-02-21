﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.DomainModels.ProductModels;
using DAL.Entities.Production;

namespace DAL.Repositories
{
    public interface IProductModelRepository
    {
        Task<PageDomain<ProductModel>> GetProductModelsByPageAsync(int start, int length);

        Task<ProductModelDetailDoamin> GetProductModelDetailByIdAsync(int productModelId);
    }
}
