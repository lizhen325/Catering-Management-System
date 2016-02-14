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
    public class R_OrderInfo_ProcutDAL
    {
        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="rOrderId"></param>
        /// <returns></returns>
        public int SoftDeleteROrderProName(int rOrderProId)
        {
            string sql = "update R_OrderInfo_Product set DelFlag=1 where ROrderProId=@ROrderProId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@ROrderProId", rOrderProId));
        }
        /// <summary>
        /// Add order in product
        /// </summary>
        /// <param name="rop"></param>
        /// <returns></returns>
        public int AddROrderInfoProduct(R_OrderInfo_Product rop)
        {
            string sql = "insert into R_OrderInfo_Product(OrderId,ProId,DelFlag,SubTime,State,UnitCount) values(@OrderId,@ProId,@DelFlag,@SubTime,@State,@UnitCount)";

            SQLiteParameter[] ps = {
               new SQLiteParameter("@OrderId",rop.OrderId),  
                new SQLiteParameter("@ProId",rop.ProId), 
                 new SQLiteParameter("@DelFlag",rop.DelFlag), 
                  new SQLiteParameter("@SubTime",rop.SubTime), 
                   new SQLiteParameter("@State",rop.State), 
                    new SQLiteParameter("@UnitCount",rop.UnitCount), 
                                   };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// get sum and count based on orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public R_OrderInfo_Product GetMoneyAndUnitCount(int orderId)
        {
            string sql = "select count(*), sum(ProPrice*UnitCount) from R_OrderInfo_Product inner join ProductInfo on ProductInfo.ProId=R_OrderInfo_Product.ProId where R_OrderInfo_Product.DelFlag=0 and OrderId=" + orderId;
            R_OrderInfo_Product rop = null;
            using(SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql))
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        rop = new R_OrderInfo_Product();
                        rop.CT = Convert.ToInt32(reader[0]);
                        //avoid null
                        if(DBNull.Value == reader[1])
                        {
                            rop.MONEY = 0;
                        }
                        else
                        {
                            rop.MONEY = Convert.ToDecimal(reader[1]);
                        }
                    }
                }
            }
            return rop;
        }

        /// <summary>
        /// get order information 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<R_OrderInfo_Product> GetROrderInfoProduct(int orderId)
        {
            string sql = "select ROrderProId,ProName,ProPrice,UnitCount,ProUnit,CatName,R_OrderInfo_Product.SubTime from R_OrderInfo_Product inner join ProductInfo on R_OrderInfo_Product.ProId=ProductInfo.ProId inner join CategoryInfo on ProductInfo.CatId=CategoryInfo.catId where OrderId=@OrderId and R_OrderInfo_Product.DelFlag=0";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@OrderId", orderId));
            List<R_OrderInfo_Product> list = new List<R_OrderInfo_Product>();
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(RowToROrderInfoProduct(dr));
                }
            }
            return list;
        }

        private R_OrderInfo_Product RowToROrderInfoProduct(DataRow dr)
        {
            R_OrderInfo_Product rop = new R_OrderInfo_Product();
            rop.CatName = dr["CatName"].ToString();
            rop.ProName = dr["ProName"].ToString();
            rop.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            rop.ProUnit = dr["ProUnit"].ToString();
            rop.ROrderProId = Convert.ToInt32(dr["ROrderProId"]);
            rop.SubTime = Convert.ToDateTime(dr["SubTime"]);
            rop.UnitCount = Convert.ToDecimal(dr["UnitCount"]);
            rop.ProMoney = rop.UnitCount * rop.ProPrice;
            return rop;
        }
    }
}
