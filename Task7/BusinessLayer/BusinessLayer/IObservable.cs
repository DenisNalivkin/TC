namespace BusinessLayer
{
    public interface IObservable
    {   
        void NotifyObservers( Sensor sensor);
    }
}
