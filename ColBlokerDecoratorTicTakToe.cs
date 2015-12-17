using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    [RegisterPlayerInFactoryAttribute(typeof(IColBlokerDecorator))]
    class ColBlokerDecoratorTicTakToe : DecoratorPlayer, IColBlokerDecorator
    {

        public ColBlokerDecoratorTicTakToe(IPlayer player) : base(player)
        {

        }

        public override void MakeMove(IBoard board)
        {
            Console.WriteLine("DecoratorCol");
            base.MakeMove(board);
        }
    }
}
