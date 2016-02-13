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

        public bool DeleteProductInfoByProId(int id)
        {
            return dal.DeleteProductInfoByDelFlag(id) > 0;
        }

        public ProductInfo GetProductInfoById(int id)
        {
            return dal.GetProductInfoById(id);
        }

        public bool SaverProduct(ProductInfo pro, int temp)
        {
            int r = -1;
            if(temp == 3)
            {
                dal.AddProductInfo(pro);
            }
            else if(temp == 4)
            {
                dal.UpdateProductInfo(pro);
            }
            return r > 0;
        }

        /// <summary>
        /// 根据商品类别的id查询该类别下所有的产品
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catid)
        {
            return dal.GetProductInfoByCatId(catid);
        }

        /// <summary>
        /// 根据编号查询产品
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        /// 
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            return dal.GetProductInfoByProNum(proNum);
        }

        /// <summary>
        /// 根据商品类别id查询该类别下有没有产品
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public int GetProductInfoCountByCatId(int catId)
        {
            return Convert.ToInt32(dal.GetProductInfoCountByCatId(catId));
        }
    }
}
