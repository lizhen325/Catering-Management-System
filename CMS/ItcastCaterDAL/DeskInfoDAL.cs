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
    public class DeskInfoDAL
    {
        /// <summary>
        /// get all desk information based on room id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByRoom(int roomId)
        {
            string sql = "select * from DeskInfo where DelFlag=0 and RoomId=@RoomId";
            List<DeskInfo> list = new List<DeskInfo>();
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@RoomId", roomId));
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(RowToDeskInfo(dr));
                }
            }
            return list;
        }

        private DeskInfo RowToDeskInfo(DataRow dr)
        {
            DeskInfo d = new DeskInfo();
            d.DeskId = Convert.ToInt32(dr["DeskId"]);
            d.DeskName = dr["DeskName"].ToString();
            d.DeskRegion = dr["DeskRegion"].ToString();
            d.DeskRemark = dr["DeskRemark"].ToString();
            d.DeskState = Convert.ToInt32(dr["DeskState"]);
            d.RoomId = Convert.ToInt32(dr["RoomId"]);
            d.SubBy = Convert.ToInt32(dr["SubBy"]);
            d.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return d;
        }

        /// <summary>
        /// change desk state
        /// </summary>
        /// <param name="deskId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateDeskStateByDeskId(int deskId,int state)
        {
            string sql = "update DeskInfo set DeskState=@DeskState where DelFlag=0 and DeskId=@DeskId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@DeskState", state), new SQLiteParameter("@DeskId", deskId));
        }
    }
}
