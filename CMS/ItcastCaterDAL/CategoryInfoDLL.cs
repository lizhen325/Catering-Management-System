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
    public class CategoryInfoDLL
    {
        public CategoryInfo GetCategoryInfoById(int id)
        {
            string sql = "select * from CategoryInfo where DelFlag=0 and CatId=" + id;
            CategoryInfo ct = null;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                ct = RowToCategoryInfo(dt.Rows[0]);
            }
            return ct;
        }

        public List<CategoryInfo> GetCategoryInfoByDelFlag(int delFlag)
        {
            string sql = "select CatId,CatName,CatNum,Remark from CategoryInfo where DelFlag=" + delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<CategoryInfo> list = new List<CategoryInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToCategoryInfo(dr));
                }
            }
            return list;
        }

        private CategoryInfo RowToCategoryInfo(DataRow dr)
        {
            CategoryInfo ct = new CategoryInfo();
            //if(tp==1)
            //{
            ct.CatId = Convert.ToInt32(dr["CatId"]);
            //}

            ct.CatName = dr["CatName"].ToString();
            ct.CatNum = dr["CatNum"].ToString();
            ct.Remark = dr["Remark"].ToString();
            return ct;
        }

        public int AddCategoryInfo(CategoryInfo ct)
        {
            string sql = "insert into CategoryInfo (CatName,CatNum,Remark,DelFlag,SubTime,SubBy) values(@CatName,@CatNum,@Remark,@DelFlag,@SubTime,@SubBy)";
            return AddAndUpdateCategoryInfo(sql, 1, ct);
        }

        public int UpdateCategoryInfo(CategoryInfo ct)
        {
            string sql = "update CategoryInfo set CatName=@CatName,CatNum=@CatNum,Remark=@Remark where CatId=@CatId";
            return AddAndUpdateCategoryInfo(sql, 2, ct);
        }

        private int AddAndUpdateCategoryInfo(string sql, int temp, CategoryInfo ct)
        {
            SQLiteParameter[] ps ={
                                     new SQLiteParameter("@CatName",ct.CatName),
                                     new SQLiteParameter("@CatNum",ct.CatNum),
                                     new SQLiteParameter("@Remark",ct.Remark)
                                 };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if(temp==1)
            {
                //Insert
                list.Add(new SQLiteParameter("@DelFlag", ct.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", ct.SubTime));
                list.Add(new SQLiteParameter("@SubBy", ct.SubBy));
            }
            else if(temp == 2)
            {
                //Update
                list.Add(new SQLiteParameter("@CatId", ct.CatId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }
    }
}
