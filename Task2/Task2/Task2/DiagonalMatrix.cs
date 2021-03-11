using System;
namespace Task2
{/// <summary>
///  Class DiagonalMatrix represents diagonal matrix.
/// </summary>
/// <typeparam name="T"> Class DiagonalMatrix is generic. </typeparam>
    class DiagonalMatrix<T>: SquareMatrix<T> 
    {/// <summary>
     /// Public constructor initializing the fields of the DiagonalMatrix class object.
     /// </summary>
     /// <param name="data"> The array from which the data will be retrieved.  </param>
        public DiagonalMatrix(T[] data) : base(data)
        {
            Rank = (int)System.Math.Sqrt(( double )data.Length);
            Data = new T[Rank];
            GetDiagonalNumbers(data);        
        }

        /// <summary>
        ///  Indexer retrieves data from a diagonal matrix at two indices.
        /// </summary>
        /// <param name="i"> Vertical node index. </param>
        /// <param name="j"> Horizontal node index </param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get
            {              
                CheckIndex(i);
                CheckIndex(j);
                if (i == j)
                {
                    return Data[i];
                }
                return default(T);
            }
            set
            {
                CheckIndex(i);
                CheckIndex(j);
                if (i == j)
                {
                    if ( !value.Equals(Data[i]) )
                    {
                        ReceiveEvent(i, j, Data[i], value);
                        Data[i] = value;
                    }
                }
                else
                {
                    throw new System.ArgumentException();
                }
            }           
        }

        /// <summary>
        ///  Method ovveride ReceiveEvent for getting event from base class of SquareMatrix.
        /// </summary>
        /// <param name="firstIndex"> First index of node from square matrix. </param>
        /// <param name="secondIndex"> Second index of node from square matrix. </param>
        /// <param name="oldValue"> Value before change. </param>
        /// <param name="newValue"> New value. </param>
        protected override void ReceiveEvent(int firstIndex, int secondIndex, T oldValue, T newValue)
        {
            base.ReceiveEvent(firstIndex, secondIndex, oldValue, newValue) ;
        }

        /// <summary>
        ///  GetDiagonalNumbers method retrieves numbers from input array for DiagonalMatrix.
        /// </summary>
        /// <param name="numbersArray"> The array from which to retrieve numbers. </param>
        private void GetDiagonalNumbers(T [] numbersArray)
        {
           int nodeIndex = 0; 
           for ( int i = 0; i < Rank; i++ )
            {
                this.Data[i] = numbersArray[nodeIndex];
                nodeIndex += Rank+1; 
            }
        }       
    }
}
