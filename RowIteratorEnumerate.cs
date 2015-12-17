using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class RowIteratorEnumerate<T>:IEnumerable<T>
    {
        private TicTacToe _board;
        private int indexer;






        public IEnumerator<T> GetEnumerator()
        {
            return new RowInumerator<T>(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class RowInumerator<T> : IEnumerator<T>
        {

            public T Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
