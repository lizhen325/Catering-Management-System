using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
    public class MemberInfoBLL
    {
        /// <summary>
        /// 根据删除标识查询所有的没有删除的会员
        /// </summary>
        /// <param name="delFlag">删除标识， ===0表示没删除，===1表示删除</param>
        /// <returns></returns>

        MemberInfoDAL dal = new MemberInfoDAL();
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            return dal.GetAllMemberInfoByDelFlag(delFlag);
        }

        public bool DeleteMemberInfoByMemberId(int memberId)
        {
            return dal.DeleteMemberInfoByMemberId(memberId) > 0 ? true : false;
        }

        public MemberInfo GetMemmberInfoByMemmberId(int id)
        {
            return dal.GetMemmberInfoByMemmberId(id);
        }

        /// <summary>
        /// Insert and Update Member Infomation
        /// </summary>
        /// <param name="mem">MemberInfo Class</param>
        /// <param name="temp">Flag 1---Insert, 2----Update</param>
        /// <returns>true/false</returns>
        public bool SaveMemberInfo(MemberInfo mem,int temp)
        {
            int r = -1;
            if(temp == 1)
            {
                //Insert
                r = dal.InsertMemberInfo(mem);
            }
            else if(temp == 2)
            {
                //Update
                r = dal.UpdateMemberInfoByMemberId(mem);

            }
            return r > 0;
        }

        /// <summary>
        /// get member type by memberId
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        /// 
        public string GetMemberTypeByMemberId(int memberId)
        {
            return dal.GetMemberTypeNameByMemberId(memberId);
        }

        /// <summary>
        /// update money By MemId
        /// </summary>
        /// <param name="memId"></param>
        /// <returns></returns>
        /// 
        public bool UpdateMoneyByMemId(int memid, decimal money)
        {
            return dal.UpdateMoneyByMemId(memid, money) > 0;
        }

        /// <summary>
        /// Get member Info by name or num
        /// </summary>
        /// <param name="name"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public List<MemberInfo> GetMemberInfoByNameOrNum(string name, int temp)
        {
            return dal.GetMemberInfoByNameOrNum(name, temp);
        }
    }
}
