using System;
using System.Threading;

namespace TestTask.Model
{
    public class SensorGenerator
    {
        public readonly DataInTheMoment[] DataInTheMoments;
        private const int Count = 60000;
        private readonly Random _random = new Random();

        public event Action CreateNewData;

        private int _currentIndex;

        public int CurrentIndex
        {
            get => _currentIndex;
            private set => _currentIndex = value % Count;
        }

        public SensorGenerator()
        {
            CurrentIndex = 0;
            DataInTheMoments = new DataInTheMoment[Count];
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(10);
                var value = _random.Next(100);
                var data = new DataInTheMoment
                {
                    Time = DateTime.Now,
                    Value = value
                };
                DataInTheMoments[CurrentIndex] = data;
                CurrentIndex++;
                CreateNewData?.Invoke();
            }
        }
    }
}
