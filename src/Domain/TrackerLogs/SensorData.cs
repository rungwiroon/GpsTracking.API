namespace Domain.TrackerLogs
{
    public struct SensorData<T>
        where T : struct
    {
        public int Channel { get; }

        public T Value { get; }

        public SensorData(int channel, T value)
        {
            Channel = channel;
            Value = value;
        }
    }
}
