using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;
using ItcastCater.BLL;

namespace ItcastCater.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        /// <summary>
        /// 该方法是根据账号去数据库查询，返回的是对象
        /// </summary>
        /// <param name="dr">登陆的账号</param>
        /// <returns>UserInfo对象</returns>
        
        public bool IsLoginByLoginName(string loginName,string pwd,out string msg)
        {
            bool flag = false;
            UserInfo user = dal.IsLoginByLoginName(loginName);
            if(user != null)
            {
                if(pwd == user.Pwd)
                {
                    flag = true;
                    msg = "登陆成功";
                }
                else
                {
                    msg = "密码错误";
                }
            }
            else
            {
                msg = "账号不存在";
            }
            return flag;
        }
    }
}
