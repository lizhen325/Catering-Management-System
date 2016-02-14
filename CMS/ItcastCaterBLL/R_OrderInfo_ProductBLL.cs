using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
    public class R_OrderInfo_ProductBLL
    {
        R_OrderInfo_ProcutDAL dal = new R_OrderInfo_ProcutDAL();

        /// <summary>
        /// get order information 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// 
        public List<R_OrderInfo_Product> GetROrderProduct(int orderId)
        {
            return dal.GetROrderInfoProduct(orderId);
        }

        /// <summary>
        /// get sum and count based on orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// 
        public R_OrderInfo_Product GetMoneyAndCount(int orderId)
        {
            return dal.GetMoneyAndUnitCount(orderId);
        }

        /// <summary>
        /// Add order in product
        /// </summary>
        /// <param name="rop"></param>
        /// <returns></returns>
        /// 
        public bool AddROrderInfoProduct(R_OrderInfo_Product rop)
        {
            return dal.AddROrderInfoProduct(rop) > 0;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="rOrderId"></param>
        /// <returns></returns>
        /// 
        public bool SoftDeletROrderProName(int rOrderProId)
        {
            return dal.SoftDeleteROrderProName(rOrderProId) > 0;
        }
    }
}
