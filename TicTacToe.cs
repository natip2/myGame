using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TicTacToe : IBoard
    {
        const int FREE_CELL = 9;
        const int BOARD_SIZE = 3;
        const int NUM_IN_ROW_FOR_WIN = 3;

        public event EventHandler BoardChanged;
        protected List<BoardCell> _board;

        public void PlayMove(int row, int col, int player)
        {
            BoardCell cur = _board.FindAll(x => x.Row == row && x.Col == col).First();
            cur.Data = player;
            if (BoardChanged != null)
            {
                BoardChanged(this, null);
            }
        }
        public TicTacToe()
        {
            _board = new List<BoardCell>();
            for (int i = 1; i <= BOARD_SIZE; i++)
            {
                for (int j = 1; j <= BOARD_SIZE; j++)
                {
                    _board.Add(new BoardCell(i, j, FREE_CELL));
                }
            }
        }

        public override string ToString()
        {
            var ret = "";
            var v = _board.GroupBy(x => x.Row);
            foreach (var rowGroup in v)
            {
                foreach (var item in rowGroup)
                {
                    ret += item.ToString() + " | "; 
                }
                ret += System.Environment.NewLine;
            }
            return ret; 
        }

        public List<BoardCell> GetFreeSpaces()
        {
            List<BoardCell> list = new List<BoardCell>();
            list = _board.FindAll(x => x.Data == FREE_CELL);
            return list;
        }

        #region -----winning functions------
        private Boolean WinRow(int row, int player)
        {
            return _board.FindAll(x => x.Data == player && x.Row == row).Count == NUM_IN_ROW_FOR_WIN;
        }
        private Boolean WinCol(int col, int player)
        {
            return _board.FindAll(x => x.Data == player && x.Col == col).Count == NUM_IN_ROW_FOR_WIN;
        }
        private Boolean WindiagLeft(int player)
        {
            return _board.FindAll(x => x.Data == player && x.Row == x.Col).Count == NUM_IN_ROW_FOR_WIN;
        }
        private Boolean WindiagRight(int player)
        {
            return _board.FindAll(x => x.Data == player && (x.Row + x.Col) == 4).Count == NUM_IN_ROW_FOR_WIN;
        }
        
        public Boolean isPlayerWin(int player)
        {
            if (WindiagLeft(player) || WindiagRight(player)){
                return true;
            }
            for (int i = 1; i <= FREE_CELL; i++)
            {
                if (WinRow(i,player) || WinCol(i,player))                
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        //check if col is 3 in row- return the winner , if not return FREE_CELL;
        #region ------memento------
        public IMementoGame CreateMemento()
        {
            IMementoGame mem = new MementoTicTacToe(this);
            return mem;

        }
        public void SetMemento(IMementoGame memento)
        {
            MementoTicTacToe prev = (MementoTicTacToe) memento;
            _board = prev.BoardCopy.Select(item => new BoardCell(item.Row,item.Col,item.Data)).ToList();
        }

        private class MementoTicTacToe : IMementoGame
        {
            List<BoardCell> _boardCopy;

            public List<BoardCell> BoardCopy
            {
                get { return _boardCopy; }
                set { _boardCopy = value; }
            }

            public MementoTicTacToe(TicTacToe tictac)
            {
                _boardCopy = new List<BoardCell>();
                _boardCopy = tictac._board.Select(item => new BoardCell(item.Row,item.Col,item.Data)).ToList();
            }
        }
        #endregion

        #region  --enumarators--
        private IEnumerator GetDiagleftEnumerator()
        {
            return new DiagleftScanner(this);
        }

        private IEnumerator GetDiagrigtEnumerator()
        {
            return new DiagrightScanner(this);
        }

        private IEnumerator GetRowEnumerator()
        {
            return new RowScanner(this);
        }

        private IEnumerator GetColEnumerator()
        {
            return new ColScanner(this);
        }



        private class ColScanner : IEnumerator
        {
            int _currentIndex;
            private TicTacToe ticTacToe;
            public ColScanner(TicTacToe ticTacToe)
            {
                this.ticTacToe = ticTacToe;
                Reset();
            }
            public object Current
            {
                get
                {
                    return this.ticTacToe._board[_currentIndex];
                }
            }

            public bool MoveNext()
            {
                if (_currentIndex == 8)
                {
                    return false;
                }
                if (_currentIndex == 6)
                {
                    _currentIndex = 1 ;
                    return true;

                }
                else if (_currentIndex == 7)
                {
                    _currentIndex = 2;
                    return true;
                }
                return true; ;
            }

            public void Reset()
            {
                _currentIndex = -3;
            }
        }

        private class RowScanner : IEnumerator
        {
            int _currentIndex;
            private TicTacToe ticTacToe;
            public RowScanner(TicTacToe ticTacToe)
            {
                this.ticTacToe = ticTacToe;
                Reset();
            }
            public object Current
            {
                get
                {
                    return this.ticTacToe._board[_currentIndex];
                }
            }

            public bool MoveNext()
            {
                bool retVal = false;
                if (_currentIndex < this.ticTacToe._board.Count - 1)
                {
                    _currentIndex++;
                    retVal = true;

                }
                return retVal;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }
        }

        private class DiagleftScanner : IEnumerator
        {
            int _currentIndex;
            private TicTacToe ticTacToe;
            public DiagleftScanner(TicTacToe ticTacToe)
            {
                this.ticTacToe = ticTacToe;
                Reset();
            }
            public object Current
            {
                get
                {
                    return this.ticTacToe._board[_currentIndex];
                }
            }

            public bool MoveNext()
            {
                bool retVal = false;
                if (_currentIndex < this.ticTacToe._board.Count - 1)
                {
                    _currentIndex += 4;
                    retVal = true;

                }
                return retVal;
            }

            public void Reset()
            {
                _currentIndex = -4;
            }
        }

        private class DiagrightScanner : IEnumerator
        {
            int _currentIndex;
            private TicTacToe ticTacToe;
            public DiagrightScanner(TicTacToe ticTacToe)
            {
                this.ticTacToe = ticTacToe;
                Reset();
            }
            public object Current
            {
                get
                {
                    return this.ticTacToe._board[_currentIndex];
                }
            }

            public bool MoveNext()
            {
                bool retVal = false;
                if (_currentIndex < 6)
                {
                    _currentIndex += 2;
                    retVal = true;

                }
                return retVal;
            }

            public void Reset()
            {
                _currentIndex = 0;
            }
        }
        #endregion
    }
}
