using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
    public class MemberTypeBAL
    {
        MemberTypeDAL dal = new MemberTypeDAL();
        /// <summary>
        /// 查询所有的会员等级
        /// </summary>
        /// <param name="delFlag">删除表示</param>
        /// <returns>会员等级对象集合</returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            return dal.GetAllMemberTypeByDelFlag(delFlag);
        }
    }
}
