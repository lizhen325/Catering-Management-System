using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    public class MemberType
    {
        private int _memType;

        public int MemType
        {
            get { return _memType; }
            set { _memType = value; }
        }
        private string _memTpName;

        public string MemTpName
        {
            get { return _memTpName; }
            set { _memTpName = value; }
        }
    }
}
