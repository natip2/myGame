using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    abstract  class Game:IGame
    {
        protected IBoard _board;
        protected IPlayer[] players;


        abstract public int GameIsOver();
        public void RunOneStep();
        public void DisplayGame();

        /*      public IBoard Board
              {
                  get { return _board; }
                  set { _board = value; }
              }
              IPlayer[] _players;
              int _nextPlayerTurn;

              public Game(IBoard board,IPlayer[] players)
              {
                  _board = board;
                  _players = players;
                  _nextPlayerTurn = 0;

              }
              public int GameIsOver()
              {
                  return _board.IsGameOver();           
              }

              public void RunOneStep()
              {
                  _players[_nextPlayerTurn].MakeMove(_board, _nextPlayerTurn);
                  _nextPlayerTurn = (_nextPlayerTurn + 1) % _players.Length;
              }
              public void DisplayGame()
              {
                  _board.DisplayBoard();
              }
              */

    }
}
