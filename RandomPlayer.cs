using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [RegisterPlayerInFactoryAttribute(typeof(IRandom))]
    class RandomPlayer:Player ,IRandom
    {
        private IRandom rand;
        public RandomPlayer(int id) : base(id)
        {
            rand = new RandomMove();
        }

        public BoardCell ChooseRandomMove(IBoard board)
        {
            return rand.ChooseRandomMove(board);
        }

        public override void MakeMove(IBoard _board)
        {
            BoardCell cell = ChooseRandomMove(_board);
            _board.PlayMove(cell.Row, cell.Col, _idPlayer);
        }
    }
}
