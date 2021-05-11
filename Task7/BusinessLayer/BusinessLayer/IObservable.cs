namespace BusinessLayer
{
    /// <summary>
    /// Interface IObservable has method NotifyObservers.
    /// </summary>
    public interface IObservable
    {   
        void NotifyObservers( Sensor sensor);
    }
}
