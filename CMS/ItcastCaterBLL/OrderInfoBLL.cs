using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class OrderInfoBLL
    {
        OrderInfoDAL dal = new OrderInfoDAL();
        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// 
        public int AddOrderInfo(OrderInfo order)
        {
            return Convert.ToInt32(dal.AddOrderInfo(order));
        }

        /// <summary>
        /// 根据餐桌的id查找该餐桌正在使用订单id
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        /// 
        public int GetOrderIdByDeskId(int deskId)
        {
            return Convert.ToInt32(dal.GetOrderIdByDeskId(deskId));
        }

        /// <summary>
        /// update Money based on orderId and consume
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        /// 
        public void UpdateMoney(decimal money, int orderId)
        {
            dal.UpdateMoney(orderId, money);
        }

        /// <summary>
        /// get sum money based on orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// 
        public decimal GetSumMoney(int orderId)
        {
            return Convert.ToDecimal(dal.GetSumMoney(orderId));
        }
    }
}
