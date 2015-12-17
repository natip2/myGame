using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IPlayer
    {
        int IdPlayer { get; set; }
        void MakeMove(IBoard _board);
    }
}
