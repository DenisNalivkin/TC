namespace Task1
{/// <summary>
 /// Interface IVersionable stores properties Version and LengthVersion which will realize classes Video and Lesson.
 /// </summary>
     interface IVersionable
    {
        byte[] Version {get; set;}
        int LengthVersion {get;}      
    }
}
