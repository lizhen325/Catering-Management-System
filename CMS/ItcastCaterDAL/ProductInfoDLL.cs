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
            string sql = "select ProId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,ProStock,ProNum from ProductInfo where DelFlag=" + delflag;
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
            return pi;

        }
    }
}
