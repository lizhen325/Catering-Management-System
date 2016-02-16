using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class RoomInfoBLL
    {

        private RoomInfoDAL dal = new RoomInfoDAL();

        /// <summary>
        /// delete room info
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool SoftDeleteRoomInfoByRoomId(int roomId)
        {
            return dal.SoftDeleteRoomInfoByRoomId(roomId) > 0;
        }

        /// <summary>
        /// Get all Room information
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        /// 
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
           return dal.GetAllRoomInfoByDelFlag(delFlag);
        }

        /// <summary>
        /// add room info
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool AddOrUpdate(RoomInfo room,int temp)
        {
            int r = -1;
            if(temp == 3)
            {
                r = dal.AddRoomInfo(room);
            }
            else if(temp == 4)
            {
                r = dal.UpdateRoomInfo(room);
            }
            return r > 0;
        }

         /// <summary>
        /// get room information by room id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoomInfo GetRoomInfoByRoomId(int id)
        {
            return dal.GetRoomInfoByRoomId(id);
        }
    }
}
