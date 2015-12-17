using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [RegisterPlayerInFactoryAttribute(typeof(IHuman))]
    class HumanPlayer : Player , IHuman
    {
        IMementoGame memento = null;

        public HumanPlayer(int id):base(id)
        {
            
        }

        public override void MakeMove(IBoard board)
        {
            if (isUseMemento(board))
            {
                return;
                
            }
            List<BoardCell> list = board.GetFreeSpaces();
            Console.WriteLine("Enter cell to insert");
            string str = Console.ReadLine();
            int cell;
            Int32.TryParse(str, out cell);

            while (!isExistInList(list, cell))
            {
                Console.WriteLine("The cell is not avalible, enter new one");
                str = Console.ReadLine();
                Int32.TryParse(str, out cell);
            }

            board.PlayMove(((cell - 1) / 3) + 1, ((cell - 1) % 3) + 1, _idPlayer);
            memento = (board as TicTacToe).CreateMemento();
        }

        private bool isUseMemento(IBoard board)
        {
            int cancal = 0;
            if (memento != null)
            {
                Console.WriteLine("1-for memnto, any other key for keep playing");
                string str = Console.ReadLine();
                Int32.TryParse(str, out cancal);
                if (cancal == 1)
                {
                    (board as TicTacToe).SetMemento(memento);
                    return true;
                }
            }
            return false;
        }

        private bool isExistInList(List<BoardCell> list, int cell)
        {
            int row = ((cell - 1) / 3) + 1;
            int col = ((cell - 1) % 3) + 1;
            return list.Exists((x) => x.Col == col && x.Row == row);

        }
    }
}
