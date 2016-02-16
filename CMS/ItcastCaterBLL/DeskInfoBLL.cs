using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
    public class DeskInfoBLL
    {
        private DeskInfoDAL dal = new DeskInfoDAL();
        /// <summary>
        /// get all desk information based on room id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            return dal.GetAllDeskInfoByRoom(roomId);
        }

        /// <summary>
        /// change desk state
        /// </summary>
        /// <param name="deskId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        /// 
        public bool UpdateDeskStateByDeskId(int deskId,int state)
        {
            return dal.UpdateDeskStateByDeskId(deskId, state) > 0;
        }

        /// <summary>
        /// get all desk informatiion by delflag=0
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        /// 
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            return dal.GetAllDeskInfoByDelFlag(delFlag);
        }

        /// <summary>
        /// get desk by roomId, estimate there is desk in the room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool GetDeskCountByRoomId(int roomId)
        {
            return Convert.ToInt32(dal.GetDeskCountByRoomId(roomId)) > 0;
        }
    }
}
