using System.Collections.Generic;
using System.Threading;
using System.Windows;
using TestTask.Model;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly List<SensorGenerator> Sensors = new List<SensorGenerator>();
        private const int CountSensors = 3;
        

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            for (var i = 0; i < CountSensors; i++)
            {
                var sensor = new SensorGenerator();
                Thread myThread = new Thread(sensor.Start);
                myThread.Start();
                Sensors.Add(sensor);
            }
        }
    }
}
