namespace BusinessLayer
{/// <summary>
/// Interface ISensorState has methods ChangeState and Work.
/// </summary>
    public interface ISensorState
    {
        void ChangeState(Sensor measuringSensor);
        void Work(object obj);
    }
}
