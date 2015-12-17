using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Scanner : IScanner
    {
        public BoardCell ChooseScanMove(IBoard board)
        {
            return board.GetFreeSpaces()[0];

        }
    }
}
