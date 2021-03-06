﻿using System;
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
            string sql = "insert into OrderInfo(SubTime,Remark,OrderState,DelFlag,SubBy,OrderMoney) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy,@OrderMoney);select last_insert_rowId()";
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

        /// <summary>
        /// 根据餐桌的id查找该餐桌正在使用订单id
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public object GetOrderIdByDeskId(int deskId)
        {
            string sql = "select OrderInfo.OrderId from R_Order_Desk inner join OrderInfo on R_Order_Desk.OrderId =OrderInfo.OrderId where OrderInfo.OrderState=1 and DeskId=" + deskId;
            return SqliteHelper.ExecuteSclar(sql);
        }

        /// <summary>
        /// update Money based on orderId and consume
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int UpdateMoney(int orderId,decimal money)
        {
            string sql = "update OrderInfo set OrderMoney=@OrderMoney where OrderId=@OrderId and DelFlag=0";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@OrderMoney", money), new SQLiteParameter("@OrderId", orderId));
        }

        /// <summary>
        /// get sum money based on orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public object GetSumMoney(int orderId)
        {
            string sql = "select OrderMoney from OrderInfo where OrderId=@OrderId and OrderState=1 and DelFlag=0";
            return SqliteHelper.ExecuteSclar(sql, new SQLiteParameter("@OrderId", orderId));

        }

        /// <summary>
        /// update Order Info 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderInfoMoney(OrderInfo order)
        {
            string sql = "update OrderInfo set OrderState=2, OrderMemId=@OrderMemId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@Discount where OrderId=@OrderId";
            SQLiteParameter[] ps ={
                                     new SQLiteParameter("@OrderMemId",order.OrderMemId),
                                     new SQLiteParameter("@EndTime",order.EndTime),
                                     new SQLiteParameter("@OrderMoney",order.OrderMoney),
                                     new SQLiteParameter("@DisCount",order.DisCount),
                                     new SQLiteParameter("@OrderId",order.OrderId)
                                 };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
