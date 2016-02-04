using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    public class ProductInfo
    {
        private int _proId;

        public int ProId
        {
            get { return _proId; }
            set { _proId = value; }
        }
        private int _catId;

        public int CatId
        {
            get { return _catId; }
            set { _catId = value; }
        }
        private string _proName;

        public string ProName
        {
            get { return _proName; }
            set { _proName = value; }
        }
        private decimal _proCost;

        public decimal ProCost
        {
            get { return _proCost; }
            set { _proCost = value; }
        }
        private string _proSpell;

        public string ProSpell
        {
            get { return _proSpell; }
            set { _proSpell = value; }
        }
        private decimal _proPrice;

        public decimal ProPrice
        {
            get { return _proPrice; }
            set { _proPrice = value; }
        }
        private string _proUnit;

        public string ProUnit
        {
            get { return _proUnit; }
            set { _proUnit = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _delFlag;

        public int DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
        private DateTime _subTime;

        public DateTime SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        private decimal _proStock;

        public decimal ProStock
        {
            get { return _proStock; }
            set { _proStock = value; }
        }
        private string _proNum;

        public string ProNum
        {
            get { return _proNum; }
            set { _proNum = value; }
        }
        private int _subBy;

        public int SubBy
        {
            get { return _subBy; }
            set { _subBy = value; }
        }
    }
}
