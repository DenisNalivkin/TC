namespace logger
{
    /// <summary>
    /// Numeric class marked with the[TrackingEntityAttribute()] attribute.Created to demonstrate correct operation of the Track() method.
    /// </summary>
    [TrackingEntityAttribute()]
  public class Number
    {
       [TrackingPropertyAttribute()]
      public int _Number { get;set; }

        /// <summary>
        /// Public constructor Number class initializes field _Number.
        /// </summary>
        /// <param name="number"> Value for field _Number. </param>
        public Number (int number)
        {
            _Number = number;
        } 
    }
}
