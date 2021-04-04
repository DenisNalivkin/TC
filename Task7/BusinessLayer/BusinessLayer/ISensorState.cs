namespace BusinessLayer
{
    public  interface ISensorState
    {
        void ChangeState(Sensor measuringSensor);
        void Work(object obj);
    }
}
