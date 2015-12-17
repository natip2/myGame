using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [RegisterPlayerInFactoryAttribute(typeof(IScanner))]
    class ScanPlayer:Player,IScanner
    {
        private IScanner scanPlayer;
        public ScanPlayer(int id):base(id)
        {
            scanPlayer = new Scanner();
        }

        public BoardCell ChooseScanMove(IBoard board)
        {
            return scanPlayer.ChooseScanMove(board);
        }

        public override void MakeMove(IBoard _board)
        {
            BoardCell cell = ChooseScanMove(_board);
            _board.PlayMove(cell.Row, cell.Col, _idPlayer);
            return;
        }
    }
}
