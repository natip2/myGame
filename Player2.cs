using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    abstract class Player : IPlayer
    {
        protected int _idPlayer;
        public int IdPlayer
        {
            get
            {
                return _idPlayer;
            }
        }
        public Player(int id)
        {
            _idPlayer = id;
        }
        abstract public void MakeMove(IBoard _board);
    }
}