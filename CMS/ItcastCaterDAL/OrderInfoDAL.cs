using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class OrderInfoDAL
    {
        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public object AddOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo(SubTime,Remark,OrderState,DelFlag,SubBy,OrderMoney) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy,@OrderMoney);select last_last .rowId";
            SQLiteParameter[] ps = {
                                      new SQLiteParameter("@SubTime",order.SubTime),
                                      new SQLiteParameter("@Remark",order.Remark),
                                      new SQLiteParameter("@OrderState",order.OrderState),
                                      new SQLiteParameter("@DelFlag",order.DelFlag),
                                      new SQLiteParameter("@SubBy",order.SubBy),
                                      new SQLiteParameter("@OrderMoney",order.OrderMoney)
                                  };
            return SqliteHelper.ExecuteSclar(sql, ps);
        }
    }
}
