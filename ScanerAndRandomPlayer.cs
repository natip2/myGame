using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [RegisterPlayerInFactoryAttribute(typeof(IScanerAndRandomPlayer))]
    class ScanerAndRandomPlayer :Player, IScanerAndRandomPlayer
    {
        private IRandom _random;
        private IScanner _scanner;

        private Boolean isRandom;
        public ScanerAndRandomPlayer(int id):base(id)
        {
            _random = new RandomPlayer(id);
            _scanner = new ScanPlayer(id);
            isRandom = false;
        }

        public override void MakeMove(IBoard _board)
        {
            BoardCell nextCell = null;
            if (isRandom)
            {
                nextCell = ChooseRandomMove(_board);
            }
            else
            {
                nextCell = ChooseScanMove(_board);
            }
            _board.PlayMove(nextCell.Row, nextCell.Col, _idPlayer);
            isRandom = !isRandom;
        }

        public BoardCell ChooseScanMove(IBoard board)
        {
            return _scanner.ChooseScanMove(board);
        }

        public BoardCell ChooseRandomMove(IBoard board)
        {
            return _random.ChooseRandomMove(board);
        }
    }
}
