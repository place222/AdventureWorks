using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#if NET461
using Microsoft.SqlServer.Types;
#endif

namespace DAL.DomainModels.Employees
{
    public class EmployeeAddressDomain
    {
        /// <summary>
        /// 地址1
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// 地址2
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }

#if NET461
        public SqlGeography SpatialLocation { get; set; }
#endif
        /// <summary>
        /// 
        /// </summary>
        public int StateProvinceID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StateProvinceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsOnlyStateProvinceFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StateProvinceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TerritoryID { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public int AddressTypeID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string AddressTypeName { get; set; }
        /// <summary>
        /// 区域码
        /// </summary>
        public string CountryRegionCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string CountryRegionName { get; set; }
    }
}
