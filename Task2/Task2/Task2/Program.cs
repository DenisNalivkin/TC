namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1,2,3,4,5,6,7,8,9};
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>( array );

            // Example how works usual method for processing for event.
            squareMatrix.MatrixChanged += ShowCnange;

            // Example how works anonymous method for processing for event.
            squareMatrix.MatrixChanged += delegate ( int firstIndex, int secondIndex, int oldValue, int newValue )
             {
                 System.Console.WriteLine($"First index of node where changed value: { firstIndex }");
                 System.Console.WriteLine($"Second index of node where changed value: { secondIndex }");
                 System.Console.WriteLine($"Value before change: { oldValue }");
                 System.Console.WriteLine($"New value: { newValue }");
             };
            
            //Example how works lambda expression for processing for event. 
            squareMatrix.MatrixChanged += ( firstIndex, secondIndex, oldValue, newValue ) =>
             {
                 System.Console.WriteLine($"First index of node where changed value: { firstIndex }");
                 System.Console.WriteLine($"Second index of node where changed value: { secondIndex }");
                 System.Console.WriteLine($"Value before change: { oldValue }");
                 System.Console.WriteLine($"New value: { newValue }");
             };            
        }
        private static void  ShowCnange ( int firstIndex, int secondIndex, int oldValue, int newValue )
        {
            System.Console.WriteLine($"First index of node where changed value: { firstIndex }");
            System.Console.WriteLine($"Second index of node where changed value: { secondIndex }");
            System.Console.WriteLine($"Value before change: { oldValue }");
            System.Console.WriteLine($"New value: { newValue }");
        }
    }
}
