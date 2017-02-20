using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels.Products
{
    public class ProductInfoDomain
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品标识码
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// false:产品是采购的 true:商品内部制造的
        /// </summary>
        public bool MakeFlag { get; set; }
        /// <summary>
        /// false:不畅销 true:畅销
        /// </summary>
        public bool FinishedGoodsFlag { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 最低库存量
        /// </summary>
        public int SafetyStockLevel { get; set; }
        /// <summary>
        /// 触发采购订单或工作订单的库存水平
        /// </summary>
        public int ReorderPoint { get; set; }
        /// <summary>
        /// 标准成本
        /// </summary>
        public decimal StandardCost { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 测量尺寸的单位
        /// </summary>
        public string SizeUnitMeasureCode { get; set; }
        /// <summary>
        /// 测量尺寸的单位名称
        /// </summary>
        public string SizeUnitMeasureCodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeightUnitMeasureCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeightUnitMeasureCodeName { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 生成需要天数
        /// </summary>
        public int DaysToManufacture { get; set; }
        /// <summary>
        /// 生产线
        /// R = road M = Moutain T = Touring S=Standard
        /// </summary>
        public string ProductLine { get; set; }
        /// <summary>
        /// 等级 H = hight M = medium L = low
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 款式 W = womens M = mens U = Universal
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public int? ProductSubcategoryID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ProductSubcategoryName { get; set; }
        /// <summary>
        /// 产品模型
        /// </summary>
        public int? ProductModelID { get; set; }
        /// <summary>
        /// 开始销售日期
        /// </summary>
        public DateTime SellStartDate { get; set; }
        /// <summary>
        /// 销售结束日期
        /// </summary>
        public DateTime? SellEndDate { get; set; }
        /// <summary>
        /// 打折日期
        /// </summary>
        public DateTime? DiscontinuedDate { get; set; }
    }
}
