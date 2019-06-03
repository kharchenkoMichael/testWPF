using System;
using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace TestTask
{
    public partial class MainWindow : Window
    {
        public List<DetailsForm> DetailsForms = new List<DetailsForm>();

        public MainWindow()
        {
            InitializeComponent();
            var app = (App) Application.Current;
            foreach (var sensorGenerator in app.Sensors)
            {
                var form = new DetailsForm();
                DetailsForms.Add(form);
            }

            Messenger.Default.Register(this, new Action<string>(ProcessMessage));
        }
        

        private void ProcessMessage(string msg)
        {
            var command = msg.Split(' ');
            if (command[0].ToLower() != "main")
                return;

            switch (command[1])
            {
                case "open":
                    var sensorNumber = int.Parse(command[2]);
                    var window = DetailsForms[sensorNumber];
                    window.Owner = this;
                    if (window.IsEnabled)
                        window.Focus();
                    else
                        window.Show();
                    break;
                case "close":
                    Close();
                    break;
            }
        }
    }
}
