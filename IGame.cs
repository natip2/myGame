using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    interface IGame
    {
        IBoard _board { get; }
        IPlayer[] _player{ get; }

        Boolean GameIsOver();
        void RunOneStep();

    }
}
