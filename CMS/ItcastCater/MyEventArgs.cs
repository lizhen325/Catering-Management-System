﻿using System;
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

        public object Obj { get; set; }
    }
}
