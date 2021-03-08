namespace Task1
{/// <summary>
///  Abstract class which stores generals properties for site entities.
/// </summary>
    public abstract class GeneralForSiteEntities
    {
       public abstract System.Guid UniqueIdentifier { get; }
       public abstract string TextDescription { get; set; }
       public const int lengthDescription = 256;
       
        /// <summary>
        /// Overridden ToString method.
        /// </summary>
        /// <returns> String type. </returns>
       public override string ToString()
        {
            return this.TextDescription;
        }
        
        /// <summary>
        ///  Overridden Equals method.
        /// </summary>
        /// <param name="obj"> The second operand for compare.</param>
        /// <returns> True if both operands are equals, or false if not equals. </returns>
       public override bool Equals( object obj )
        {
            GeneralForSiteEntities resultConverting = obj as GeneralForSiteEntities;
            if ( resultConverting != null )
            {
                return UniqueIdentifier == resultConverting.UniqueIdentifier;
            }
            return false;
        }
    }
}
