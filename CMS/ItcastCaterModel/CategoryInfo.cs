using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    public class CategoryInfo
    {
        //CatId,CatName,CatNum,Remark,DelFlag,SubTme,SubBy
        private int _catId;

        public int CatId
        {
            get { return _catId; }
            set { _catId = value; }
        }
        private string _catName;

        public string CatName
        {
            get { return _catName; }
            set { _catName = value; }
        }
        private int _catNum;

        public int CatNum
        {
            get { return _catNum; }
            set { _catNum = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        
        private DateTime _subTime;

        public DateTime SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        private int _subBy;

        public int SubBy
        {
            get { return _subBy; }
            set { _subBy = value; }
        }

        private int _delFlag;

        public int DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
    }
}
