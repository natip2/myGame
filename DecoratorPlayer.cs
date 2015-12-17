using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    abstract class DecoratorPlayer:IPlayer
    { 
        public IPlayer _player;

        public DecoratorPlayer(IPlayer player)
        {
            _player = player;
        }

        public int IdPlayer
        {
            get
            {
                return _player.IdPlayer;
            }
            set
            {
                _player.IdPlayer = value;
            }
        }


        public virtual void MakeMove(IBoard _board)
        {
            _player.MakeMove(_board);
        }
    }
}
