using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ItcastCater.Model;
using ItcastCater.DAL;
namespace ItcastCater.BLL
{
    public class ProductInfoBLL
    {
        ProductInfoDLL dal = new ProductInfoDLL();

        public List<ProductInfo> GetProductInfoByDelFlag(int delflag)
        {
            return dal.GetProductInfoByDelFlag(delflag); 
        }
    }
}
