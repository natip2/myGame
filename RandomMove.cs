using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class RandomMove : IRandom
    {
        public BoardCell ChooseRandomMove(IBoard board)
        {
            List<BoardCell> freeCell = board.GetFreeSpaces();

            Random rnd = new Random();
            int nextStep = rnd.Next(0, freeCell.Count);
            return freeCell[nextStep];
        }
    }
}
