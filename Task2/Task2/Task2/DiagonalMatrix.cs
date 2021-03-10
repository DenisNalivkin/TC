﻿namespace Task2
{/// <summary>
///  Class DiagonalMatrix represents diagonal  matrix.
/// </summary>
/// <typeparam name="T"> Class DiagonalMatrix is generic. </typeparam>
    class DiagonalMatrix<T>: SquareMatrix<T>
    {
        public DiagonalMatrix(T[] data) : base()
        {
            Rank = (int)System.Math.Sqrt(( double )data.Length);
            Data = new T[Rank];
            GetDiagonalNumbers(data);        
        }
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

        protected void GetDiagonalNumbers(T [] inputData)
        {
           int indexInputData = 0; 
           for ( int i = 0; i < Rank; i++ )
            {
                this.Data[i] = inputData[indexInputData];
                indexInputData += Rank+1; 
            }         
        }
    }
}
