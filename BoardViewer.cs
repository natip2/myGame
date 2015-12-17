using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class BoadViewer : IBoadViwer
    {
        public BoadViewer(IBoard board)
        {
            (board as TicTacToe).BoardChanged += Update;
        }

        public void Update(Object sender, EventArgs temp)
        {
            Display(sender as TicTacToe);
        }

        public void Display(TicTacToe board)
        {
            Console.WriteLine( board.ToString());
        }
    }
}
