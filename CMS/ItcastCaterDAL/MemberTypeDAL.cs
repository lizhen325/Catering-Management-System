using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ItcastCater.Model;
using System.Data;


namespace ItcastCater.DAL
{
    public class MemberTypeDAL
    {
        /// <summary>
        /// 查询所有的会员等级
        /// </summary>
        /// <param name="delFlag">删除表示</param>
        /// <returns>会员等级对象集合</returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            string sql = "select MemType,MemTpName from MemmberType where DelFlag=" + delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<MemberType> list = new List<MemberType>();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MemberType mt = RowToMemberType(dr);
                    list.Add(mt);
                }
            }
            return list;
        }
        private MemberType RowToMemberType(DataRow dr)
        {
            MemberType mt = new MemberType();
            mt.MemTpName = dr["MemTpName"].ToString();
            mt.MemType = Convert.ToInt32(dr["MemType"]);
            return mt;
        }
    }
}
