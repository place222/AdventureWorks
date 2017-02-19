using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// (材料清单)
    /// 项目要的自行车及配件，确定层次关系父母产品组成
    /// </summary>
    public class BillOfMaterials
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BillOfMaterialsID { get; set; }
        /// <summary>
        /// 父级产品编号 Product.ProductID
        /// </summary>
        public int? ProductAssemblyID { get; set; }
        /// <summary>
        /// 组件编号 Product.ProductID
        /// </summary>
        public int ComponentID { get; set; }
        /// <summary>
        /// 项目中开始使用组件的日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 项目停止使用组件的日期
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 确定计量单位的编码
        /// </summary>
        public string UnitMeasureCode { get; set; }
        /// <summary>
        /// 指示组件是从其母的深度（assemblyid）
        /// </summary>
        public int BOMLevel { get; set; }
        /// <summary>
        /// 创建组件所需要的零件的数量
        /// </summary>
        public decimal PerAssemblyQty { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
