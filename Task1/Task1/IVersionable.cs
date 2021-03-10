namespace Task1
{/// <summary>
 /// Interface  IVersionable stores property Version which will realize classes Video and Lesson.
 /// </summary>
    public interface IVersionable
    {
        byte[] Version {get; set;}
        int LengthVersion {get;}      
    }
}
