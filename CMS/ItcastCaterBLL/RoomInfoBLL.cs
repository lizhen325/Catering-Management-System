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
        /// Get all Room information
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        /// 
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
           return dal.GetAllRoomInfoByDelFlag(delFlag);
        }
    }
}
