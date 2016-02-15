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

    public class MemberInfoDAL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public int InsertMemberInfo(MemberInfo mem)
        {
            string sql = "insert into MemmberInfo(MemName,MemMobilePhone,MemAddress,MemType,MemNum,MemGender,MemDiscount,MemMoney,Delflag,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty) values(@MemName,@MemMobilePhone,@MemAddress,@MemType,@MemNum,@MemGender,@MemDiscount,@MemMoney,@Delflag,@SubTime,@MemIntegral,@MemEndServerTime,@MemBirthdaty)";

            return AddAndUpdateMemberInfo(1,sql,mem);
        }

        public int UpdateMemberInfoByMemberId(MemberInfo mem)
        {
            
            string sql = "update MemmberInfo set MemName=@MemName,MemMobilePhone=@MemMobilePhone,MemAddress=@MemAddress,MemType=@MemType,MemNum=@MemNum,MemGender=@MemGender,MemDiscount=@MemDiscount,MemMoney=@MemMoney,MemIntegral=@MemIntegral,MemEndServerTime=@MemEndServerTime,MemBirthdaty=@MemBirthdaty where MemmberId=@MemmberId";

            return AddAndUpdateMemberInfo(2,sql,mem);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="sql"></param>
        /// <param name="mem"></param>
        /// <returns></returns>
        private int AddAndUpdateMemberInfo(int temp,string sql,MemberInfo mem)
        {
            SQLiteParameter[] ps = { 
                                       new SQLiteParameter("@MemName",mem.MemName),
                                       new SQLiteParameter("@MemMobilePhone",mem.MemMobilePhone),
                                       new SQLiteParameter("@MemAddress",mem.MemAddress),
                                       new SQLiteParameter("@MemType",mem.MemType),
                                       new SQLiteParameter("@MemNum",mem.MemNum),
                                       new SQLiteParameter("@MemGender",mem.MemGender),
                                       new SQLiteParameter("@MemDiscount",mem.MemDiscount),
                                       new SQLiteParameter("@MemMoney",mem.MemMoney),
                                       new SQLiteParameter("@MemIntegral",mem.MemIntegral),
                                       new SQLiteParameter("@MemEndServerTime",mem.MemEndServerTime),
                                       new SQLiteParameter("@MemBirthdaty",mem.MemBirthdaty)
                                   };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if (temp == 1)
            {

                list.Add(new SQLiteParameter("@Delflag", mem.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", mem.SubTime));
            }
            else if(temp == 2)
            {
                list.Add(new SQLiteParameter("@MemmberId", mem.MemmberId));
            }
              return SqliteHelper.ExecuteNonQuery(sql,list.ToArray());
        }


        /// <summary>
        /// 根据id修改会员的删除标识
        /// </summary>
        /// <param name="id">会员的id</param>
        /// <returns>对象</returns>
        public MemberInfo GetMemmberInfoByMemmberId(int id)
        {
            string sql = "select * from MemmberInfo where DelFlag=0 and MemmberId=" + id;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            MemberInfo mem = null;
            if (dt.Rows.Count > 0)
            {
                mem = RowToMemberInfo(dt.Rows[0]);
            }
            return mem;
        }

        /// <summary>
        /// 根据id修改会员的删除标识
        /// </summary>
        /// <param name="memberId">memberid</param>
        /// <returns>受影响的行数</returns>
        public int DeleteMemberInfoByMemberId(int memberId)
        {
            string sql = "update MemmberInfo set DelFlag=1 where MemmberId=" + memberId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据删除标识查询所有的没有删除的会员
        /// </summary>
        /// <param name="delFlag">删除标识， ===0表示没删除，===1表示删除</param>
        /// <returns></returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            string sql = "select MemmberId,MemName,MemMobilePhone,MemType,MemNum,MemGender,MemDiscount,MemMoney,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty,MemAddress,MemPhone from MemmberInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberInfo(dr));
                }
            }
            return list;
        }

        private MemberInfo RowToMemberInfo(DataRow dr)
        {
            MemberInfo mem = new MemberInfo();
            mem.MemAddress = dr["MemAddress"].ToString();
            mem.MemBirthdaty = Convert.ToDateTime(dr["MemBirthdaty"]);
            mem.MemDiscount = Convert.ToDecimal(dr["MemDiscount"]);
            mem.MemGender = dr["MemGender"].ToString();
            mem.MemEndServerTime = Convert.ToDateTime(dr["MemEndServerTime"]);
            mem.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            mem.MemmberId = Convert.ToInt32(dr["MemmberId"]);
            mem.MemMobilePhone = dr["MemMobilePhone"].ToString();
            mem.MemName = dr["MemName"].ToString();
            mem.MemNum = dr["MemNum"].ToString();
            mem.MemPhone = dr["MemPhone"].ToString();
            mem.MemType = Convert.ToInt32(dr["MemType"]);
            mem.SubTime = Convert.ToDateTime(dr["SubTime"]);
            mem.MemMoney = Convert.ToDecimal(dr["MemMoney"]);
            return mem;
        }

        /// <summary>
        /// get member type by memberId
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public string GetMemberTypeNameByMemberId(int memberId)
        {
            string sql = "select MemTpName from MemmberType inner join MemmberInfo on MemmberInfo.MemType=MemmberType.MemType where MemmberId="+memberId;
            return SqliteHelper.ExecuteSclar(sql).ToString();
        }
        


    }
}
