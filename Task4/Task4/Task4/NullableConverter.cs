namespace Task4
{/// <summary>
 ///  The NullableConvertr class implements an extension method for the Nullable type.
 /// </summary>
    public static class NullableConverter
    {/// <summary>
     /// Method ConvertingNullableInString converts value null from nullable type in string.
     /// </summary>
     /// <param name="value"> Values ​​from nullable type for conversion. </param>
     /// <returns> String type. </returns>
        public static string ConvertingNullableInString( this int? value)
        {
            return value.HasValue ? value.ToString() : "?";
        }       
    }   
}
