namespace Task2
{/// <summary>
/// Class ArgumentsForEvent stores data for event.
/// </summary>
/// <typeparam name="T"> Class ArgumentsForEvent is generic. </typeparam>
    class ArgumentsForEvent<T>
    {
        public int FirstIndex { get; set; }
        public int SecondIndex { get; set; }
        public T OldValue { get; set; }
        public T NewValue { get; set; }
        public ArgumentsForEvent()
        {

        }
        public ArgumentsForEvent( int firstIndex, int secondIndex, T oldValue, T newValue )
        {
            this.FirstIndex = firstIndex;
            this.SecondIndex = secondIndex;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}
