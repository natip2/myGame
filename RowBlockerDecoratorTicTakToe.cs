using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [RegisterPlayerInFactoryAttribute(typeof(IRowBlokerDecorator))]
    class RowBlockerDecoratorTicTakToe :DecoratorPlayer , IRowBlokerDecorator
    {

        public RowBlockerDecoratorTicTakToe(IPlayer player): base(player)
        {

        }

        public override void MakeMove(IBoard board)
        {
            Console.WriteLine("DecoratorRow");
            base.MakeMove(board);
        }

    }
}
