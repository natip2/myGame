using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class BoardCell
    {
        int _col;

        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }

        int _row;

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        int _data;

        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public BoardCell(int row, int col, int data)
        {
            _row = row;
            _col = col;
            _data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
