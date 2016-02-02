using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using System.Data;
using System.Data.SQLite;

namespace ItcastCater.DAL
{
    public class UserInfoDAL
    {
        //查是否登陆成功
        //判断用户是否登陆成功
        public UserInfo IsLoginByLoginName(string loginName)
        {
            string sql = "select * from UserInfo where LoginUserName=@LoginUserName";
            DataTable dt = SqliteHelper.ExecuteTable(sql,new SQLiteParameter("@LoginUserName",loginName));
            UserInfo user = null;
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    user = RowToUserInfo(dr);
                    
                }
            }
            return user;
        }

        /// <summary>
        /// 该方法是根据账号去数据库查询，返回的是对象
        /// </summary>
        /// <param name="dr">登陆的账号</param>
        /// <returns>UserInfo对象</returns>
       private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            user.LastLoginIp = dr["LastLoginIP"].ToString();
            user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.Pwd = dr["Pwd"].ToString();
            user.UserId = Convert.ToInt32(dr["UserId"]);
            user.UserName = dr["UserName"].ToString();
            return user;
        }
    }
}
