using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IBoard
    {

        List<BoardCell> GetFreeSpaces();        
        Boolean isPlayerWin(int player);
        void PlayMove(int row, int col, int player);
    }
}
