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
    }
}
