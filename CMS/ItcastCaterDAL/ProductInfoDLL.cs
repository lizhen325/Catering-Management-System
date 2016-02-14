using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class ProductInfoDLL
    {
        public List<ProductInfo> GetProductInfoByDelFlag(int delflag)
        {
            string sql = "select CatId,ProId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,ProStock,ProNum from ProductInfo where DelFlag=" + delflag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<ProductInfo> list = new List<ProductInfo>();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据id查询对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo pi = new ProductInfo();
            pi.ProId = Convert.ToInt32(dr["ProId"]);
            pi.ProName = dr["ProName"].ToString();
            pi.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pi.ProSpell = dr["ProSpell"].ToString();
            pi.ProUnit = dr["ProUnit"].ToString();
            pi.Remark = dr["Remark"].ToString();
            pi.ProStock = Convert.ToInt32(dr["ProStock"]);
            pi.ProNum = dr["ProNum"].ToString();
            pi.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pi.CatId = Convert.ToInt32(dr["CatId"]);
            return pi;

        }

        public int DeleteProductInfoByDelFlag(int id)
        {
            string sql = "update ProductInfo set DelFlag=1 where ProId=@ProId";
            return SqliteHelper.ExecuteNonQuery(sql,new SQLiteParameter("@ProId",id));
        }

        public ProductInfo GetProductInfoById(int id)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProId=@ProId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProId", id));
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }

        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo(CatId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,ProStock,ProNum,SubBy) Values(@CatId,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@ProStock,@ProNum,@SubBy)";
            return AddAndUpdate(pro, sql, 3);
        }

        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CatId=@CatId,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark,ProStock=@ProStock,ProNum=@ProNum where ProId=@ProId";
            return AddAndUpdate(pro, sql, 4);
        }
        
        private int AddAndUpdate(ProductInfo pro, string sql, int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            SQLiteParameter[] ps = {
                                       new SQLiteParameter("@CatId",pro.CatId),
                                       new SQLiteParameter("@ProName",pro.ProName),
                                       new SQLiteParameter("@ProCost",pro.ProCost),
                                       new SQLiteParameter("@ProSpell",pro.ProSpell),
                                       new SQLiteParameter("@ProPrice",pro.ProPrice),
                                       new SQLiteParameter("@ProUnit",pro.ProUnit),
                                       new SQLiteParameter("@Remark",pro.Remark),
                                       new SQLiteParameter("@ProStock",pro.ProStock),
                                       new SQLiteParameter("@ProNum",pro.ProNum)
                                   };
            list.AddRange(ps);
            if(temp == 3)
            {
                list.Add(new SQLiteParameter("@DelFlag", pro.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", pro.SubTime));
                list.Add(new SQLiteParameter("@SubBy", pro.SubBy));
            }
            else if(temp == 4)
            {
                list.Add(new SQLiteParameter("@ProId", pro.ProId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据商品类别的id查询该类别下所有的产品
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catid)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and CatId=" + catid;
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;

        }

        /// <summary>
        /// 根据编号查询产品
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProNum like @ProNum";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProNum", "%" + proNum + "%"));
            List<ProductInfo> list = new List<ProductInfo>();
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            
            return list;
        }

        public object GetProductInfoCountByCatId(int catId)
        {
            string sql = "select count(*) from ProductInfo where DelFlag=0 and CatId="+catId;
            return SqliteHelper.ExecuteSclar(sql);
        }

        /// <summary>
        /// search based on alphaet or id
        /// </summary>
        /// <param name="num"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoBySpellOrNum(string num, int temp)
        {
            string sql = "select * from ProductInfo where DelFlag=0";
            if(temp == 1)
            {
                //alphaet
                sql += " and ProSpell like @ProSpell";
            }
            else if(temp == 2)
            {
                sql += " and ProNum like @ProSpell";
            }
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("ProSpell","%"+ num + "%"));
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }
    }
}
