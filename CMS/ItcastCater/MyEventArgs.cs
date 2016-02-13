using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater
{
    public class MyEventArgs:EventArgs
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Temp { get; set; }

        /// <summary>
        /// object
        /// </summary>
        public object Obj { get; set; }

        /// <summary>
        /// money
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
