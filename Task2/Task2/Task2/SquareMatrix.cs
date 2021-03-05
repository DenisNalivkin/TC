using System;
namespace Task2
{/// <summary>
/// Class SquareMatrix represents   square matrix.
/// </summary>
/// <typeparam name="T"> Class SquareMatrix is generic. </typeparam>
    class SquareMatrix<T>
    {
        protected T[] Data { get; set; }
        public int Rank { get; protected set; }
        public ArgumentsForEvent<T> _ArgumentsForEvent { get; set; }

        public SquareMatrix(T[] array)
        {
            if(array == null)
            {
                throw new ArgumentException();
            }

            var result = Math.Sqrt( array.Length );
            if ( ( result %1 ) != 0 || array.Length == 1 )
            {
                throw new ArgumentException();
            }
            Data = new T[array.Length];
            Array.Copy( array, Data, array.Length );
            Rank = ( int )result;        
        }

        public SquareMatrix()
        {

        }

        public delegate void Matrix<T>( ArgumentsForEvent<T> agrs, int firstIndex, int secondIndex, T oldValue, T newValue );
        public event Matrix<T> MatrixChanged;

        public T this[int i, int j]
        {
            get
            {
                CheckIndex( i );
                CheckIndex( j );
                return Data[i * Rank + j];
            }

            set
            {
                CheckIndex( i );
                CheckIndex( j );
                ArgumentsForEvent<T> agrsEvent = new ArgumentsForEvent<T>( i, j, Data[i * Rank + j], value );
                MatrixChanged?.Invoke( agrsEvent, i, j, Data[i * Rank + j], value );
                Data[i * Rank + j] = value;
            }
        }
        /// <summary>
        /// Method CheckIndex checks input index.  
        /// </summary>
        /// <param name="index"> Index for check. </param>
        protected void CheckIndex( int index )
        {
            if ( index >= Rank || index < 0 )
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
