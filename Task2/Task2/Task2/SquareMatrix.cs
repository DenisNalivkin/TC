using System;
namespace Task2
{/// <summary>
/// Class SquareMatrix represents square matrix.
/// </summary>
/// <typeparam name="T"> Class SquareMatrix is generic. </typeparam>
    class SquareMatrix<T>
    {
        protected T[] Data {get; set;}
        public int Rank {get; protected set;}

        public SquareMatrix(T[] array)
        {
            if( array == null || array.Length == 0 )
            {
                throw new ArgumentException();
            }

            var result = Math.Sqrt( array.Length );
            if ( (result %1) != 0 || array.Length == 1 )
            {
                throw new ArgumentException();
            }
            Data = new T[array.Length];
            Array.Copy(array, Data, array.Length);
            Rank = (int)result;        
        }

        public delegate void Matrix<T>(int firstIndex, int secondIndex, T oldValue, T newValue);
        public event Matrix<T> MatrixChanged;

        protected SquareMatrix()
        {

        }

        public T this[int i, int j]
        {
            get
            {
                CheckIndex(i);
                CheckIndex(j);
                return Data[i * Rank + j];
            }

            set
            {
                CheckIndex(i);
                CheckIndex(j);
                if( !value.Equals(Data[i * Rank + j]) )
                {
                    MatrixChanged?.Invoke(i, j, Data[i * Rank + j], value);
                    Data[i * Rank + j] = value;
                }             
            }
        }

        /// <summary>
        /// Method CheckIndex checks input index.  
        /// </summary>
        /// <param name="index"> Index for check. </param>
        protected void CheckIndex(int index)
        {
            if ( index >= Rank || index < 0 )
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Method ReceiveEvent is shell for event Matrix Changed.
        /// </summary>
        /// <param name="firstIndex"> First index of node from square matrix. </param>
        /// <param name="secondIndex"> Second index of node from square matrix. </param>
        /// <param name="oldValue"> Value before change. </param>
        /// <param name="newValue"> New value. </param>
        protected virtual void ReceiveEvent (int firstIndex, int secondIndex, T oldValue, T newValue)
        {
          MatrixChanged?.Invoke(firstIndex, secondIndex, oldValue, newValue);
        }
    }
}
