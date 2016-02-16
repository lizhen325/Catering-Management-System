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
        /// delete room info
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int SoftDeleteRoomInfoByRoomId(int roomId)
        {
            string sql = "update RoomInfo set DelFlag=1 where RoomId=" + roomId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }
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
            r.RoomMinimunConsume = Convert.ToDecimal(dr["RoomMinimunConsume"]);
            r.RoomName = dr["RoomName"].ToString();
            r.RoomType = Convert.ToInt32(dr["RoomType"]);
            r.SubBy = Convert.ToInt32(dr["SubBy"]);
            r.SubTime = Convert.ToDateTime(dr["subTime"]);
            return r;
        }

        /// <summary>
        /// add room info
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int AddRoomInfo(RoomInfo room)
        {
            //RoomName,RoomType,RoomMinimumConsume,RoomMaxConsumer,IsDefault,SubTime,SubBy
            string sql = "insert into RoomInfo(RoomName,RoomType,RoomMinimunConsume,RoomMaxConsumer,IsDefault,DelFlag,SubTime,SubBy) values(@RoomName,@RoomType,@RoomMinimunConsume,@RoomMaxConsumer,@IsDefault,@DelFlag,@SubTime,@SubBy)";
            return AddOrUpdate(room, sql, 3);
            
        }
        /// <summary>
        /// update
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int UpdateRoomInfo(RoomInfo room)
        {
            string sql = "update RoomInfo set RoomName=@RoomName,RoomType=@RoomType,RoomMinimunConsume=@RoomMinimunConsume,RoomMaxConsumer=@RoomMaxConsumer,IsDefault=@IsDefault where RoomId=@RoomId";
            return AddOrUpdate(room, sql, 4);
        }

        public int AddOrUpdate(RoomInfo room, string sql, int temp)
        {
            SQLiteParameter[] ps = {
                                       new SQLiteParameter("@RoomName",room.RoomName),
                                       new SQLiteParameter("@RoomType",room.RoomType),
                                       new SQLiteParameter("@RoomMinimunConsume",room.RoomMinimunConsume),
                                       new SQLiteParameter("@RoomMaxConsumer",room.RoomMaxConsumer),
                                       new SQLiteParameter("@IsDefault",room.IsDefault)
                                       
                                   };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if(temp == 3)
            {
                list.Add(new SQLiteParameter("@DelFlag", room.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", room.SubTime));
                list.Add(new SQLiteParameter("@SubBy", room.SubBy));
            }
            else if(temp == 4)
            {
                list.Add(new SQLiteParameter("@RoomId", room.RoomId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// get room information by room id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoomInfo GetRoomInfoByRoomId(int id)
        {
            string sql = "select * from RoomInfo where DelFlag=0 and RoomId=" + id;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            RoomInfo room = new RoomInfo();
            if(dt.Rows.Count>0)
            {
                room = RowToRoomInfo(dt.Rows[0]);
            }
            return room;
        }

    }
}
