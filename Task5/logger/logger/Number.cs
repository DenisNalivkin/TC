namespace logger
{
    [TrackingEntityAttribute()]
  public class Number
    {
       [TrackingPropertyAttribute()]
      public int _Number { get;set; }

        public Number (int number)
        {
            _Number = number;
        }
    }
}
