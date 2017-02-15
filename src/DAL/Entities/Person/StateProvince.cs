using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 
    /// </summary>
    public class StateProvince
    {
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
        public string CountryRegionCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsOnlyStateProvinceFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TerritoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
