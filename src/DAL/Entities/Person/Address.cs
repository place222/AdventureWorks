using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#if NET461
using Microsoft.SqlServer.Types;
#endif

namespace DAL.Entities.Person
{
    /// <summary>
    /// 地址
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int AddressID { get; set; }
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
        /// 国家
        /// </summary>
        public int StateProvinceID { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// geography位置数据
        /// </summary>
#if NET461
        public SqlGeography SpatialLocation { get; set; }
#else
        public byte[] SpatialLocation { get; set; }
#endif
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
