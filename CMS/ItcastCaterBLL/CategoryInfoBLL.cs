using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class CategoryInfoBLL
    {
        CategoryInfoDLL dal = new CategoryInfoDLL();
        public List<CategoryInfo> GetCategoryInfoByDelFlag(int delflag)
        {
            return dal.GetCategoryInfoByDelFlag(delflag);
        }
        public CategoryInfo GetCategoryInfoById(int id)
        {
            return dal.GetCategoryInfoById(id);
        }

        public bool SaveCategoryInfo(CategoryInfo ct,int temp)
        {
            int r = -1;
            if(temp == 1)
            {
                //insert
                r = dal.AddCategoryInfo(ct);
            }
            else if(temp == 2)
            {
                //Update
                r = dal.UpdateCategoryInfo(ct);
            }
            return r > 0;
        }
    }
}
