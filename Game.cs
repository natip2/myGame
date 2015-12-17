using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Game : IGame
    {
        protected IBoard _board;
        protected IPlayer[] _players;
        protected int _nextPlayerTurn;
        IBoadViwer view;

        public Game(IBoard board,IPlayer[] players)
        {
            _board = board;
            _players = players;
            _nextPlayerTurn = 0;
            view = new BoadViewer(board);

        }

        IBoard IGame._board
        {
            get
            {
                return _board;
            }
        }

        public IPlayer[] _player
        {
            get
            {
                return _players;
            }
        }

        public Boolean GameIsOver()
        {
            return _board.isPlayerWin(_players[_nextPlayerTurn].IdPlayer) ;
        }

        public void RunGame()
        {
            while (!GameIsOver())
            {
                RunOneStep();
            }
        }

        public void RunOneStep()
        {
            _players[_nextPlayerTurn].MakeMove(_board);
            _nextPlayerTurn = (_nextPlayerTurn + 1) % _players.Length;
        }

      
    }
}
