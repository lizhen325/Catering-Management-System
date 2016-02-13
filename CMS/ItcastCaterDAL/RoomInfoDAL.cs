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
    public class RoomInfoDAL
    {
        /// <summary>
        /// Get all Room information
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            List<RoomInfo> list = new List<RoomInfo>();
            string sql = "select * from RoomInfo where DelFlag="+delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(RowToRoomInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// RoomInfo object bind to talbe row
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private RoomInfo RowToRoomInfo(DataRow dr)
        {
            RoomInfo r = new RoomInfo();
            r.IsDefault = Convert.ToInt32(dr["IsDefault"]);
            r.RoomId = Convert.ToInt32(dr["RoomId"]);
            r.RoomMaxConsumer = Convert.ToInt32(dr["RoomMaxConsumer"]);
            //r.RoomMinimumConsume = Convert.ToDecimal(dr["RoomMinimumConsume"]);
            r.RoomName = dr["RoomName"].ToString();
            r.RoomType = Convert.ToInt32(dr["RoomType"]);
            r.SubBy = Convert.ToInt32(dr["SubBy"]);
            r.SubTime = Convert.ToDateTime(dr["subTime"]);
            return r;
        }


    }
}
