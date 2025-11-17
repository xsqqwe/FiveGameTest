using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiveGameTest
{
    //棋子
    public class Chess
    {
        public int RIndex { get; set; }
        public int CIndex { get; set; }
        public ChessState State { get; set; }
    }
}
