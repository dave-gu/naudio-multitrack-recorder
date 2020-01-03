using System;
using System.Windows.Input;
using System.IO;
using VoiceRecorder.Audio;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace VoiceRecorder
{
    class RecorderViewModel : ViewModelBase, IView
    {
        private readonly RelayCommand beginRecordingCommand;
        private readonly RelayCommand stopCommand;
        private readonly IAudioRecorder recorder;
        //adding a new recorder here?
        private readonly IAudioRecorder recorder2;
        private float lastPeak;
        private float lastPeak2;
        private string waveFileName;
        private string waveFileName2;
        public const string ViewName = "RecorderView";

        //public RecorderViewModel(IAudioRecorder recorder)
        public RecorderViewModel(IAudioRecorder recorder, IAudioRecorder recorder2)
        {
            this.recorder = recorder;
            this.recorder2 = recorder2;
            this.recorder.Stopped += OnRecorderStopped;
            this.recorder2.Stopped += OnRecorderStopped;
            beginRecordingCommand = new RelayCommand(BeginRecording,
                () => recorder.RecordingState == RecordingState.Stopped ||
                      recorder.RecordingState == RecordingState.Monitoring);
            stopCommand = new RelayCommand(Stop,
                () => recorder.RecordingState == RecordingState.Recording);
            recorder.SampleAggregator.MaximumCalculated += OnRecorderMaximumCalculated;
            recorder2.SampleAggregator.MaximumCalculated += OnRecorderMaximumCalculated2;
            Messenger.Default.Register<ShuttingDownMessage>(this, OnShuttingDown);


            //do these also need to have secondary objects or some shit?


            /*xx5
            beginRecordingCommand = new RelayCommand(BeginRecording,
                () => recorder2.RecordingState == RecordingState.Stopped ||
                      recorder2.RecordingState == RecordingState.Monitoring);
            stopCommand = new RelayCommand(Stop,
                () => recorder2.RecordingState == RecordingState.Recording);
                */


            //Messenger.Default.Register<ShuttingDownMessage>(this, OnShuttingDown);
            //gonna have to fuckin check these
        }

        void OnRecorderStopped(object sender, EventArgs e)
        {
            Messenger.Default.Send(new NavigateMessage(SaveViewModel.ViewName,
                new VoiceRecorderState(waveFileName, null)));
        }

        void OnRecorderMaximumCalculated(object sender, MaxSampleEventArgs e)
        {
            lastPeak = Math.Max(e.MaxSample, Math.Abs(e.MinSample));
            RaisePropertyChanged("CurrentInputLevel");
            RaisePropertyChanged("RecordedTime");
        }

        void OnRecorderMaximumCalculated2(object sender, MaxSampleEventArgs e)
        {
            lastPeak2 = Math.Max(e.MaxSample, Math.Abs(e.MinSample));
            RaisePropertyChanged("CurrentInputLevel2");
            RaisePropertyChanged("RecordedTime");
        }

        public ICommand BeginRecordingCommand { get { return beginRecordingCommand; } }
        public ICommand StopCommand { get { return stopCommand; } }
        //line below i think should take in the object from the button press on welcomeviewmodel....

        //public void Activated(object state)
        public void Activated(object state)
        {
            //these are dumb. they dont work
            //BeginMonitoring((int)state);
            //BeginMonitoring2((int)state);

            //these work
            //BeginMonitoring(0);
            //BeginMonitoring2(2);

            //i thought this would work but i guess it didn't?
            //BeginMonitoring(((int[])state)[0]);
            
            //BeginMonitoring(((int[])state)[1]);
            
            int whatsthis;
            int whatsthis2;
            whatsthis = ((int[])state)[0];
            whatsthis2 = ((int[])state)[1];
            Console.Out.WriteLine(whatsthis);
            Console.Out.WriteLine(whatsthis2);
            Console.Out.Close();
            BeginMonitoring(whatsthis);
            BeginMonitoring2(whatsthis2);
        }

        private void OnShuttingDown(ShuttingDownMessage message)
        {
            if (message.CurrentViewName == ViewName)
            {
                recorder.Stop();
                //
                recorder2.Stop();
            }
        }

        public string RecordedTime
        {
            get
            {
                var current = recorder.RecordedTime;
                return String.Format("{0:D2}:{1:D2}.{2:D3}", 
                    current.Minutes, current.Seconds, current.Milliseconds);
            }
        }

        private void BeginMonitoring(int recordingDevice)
        {
            //recorder.BeginMonitoring(recordingDevice);
            //RaisePropertyChanged("MicrophoneLevel");

            //recorder.BeginMonitoring(1);
            //recorder2.BeginMonitoring(3);
            recorder.BeginMonitoring(recordingDevice);
            //recorder2.BeginMonitoring(recordingDevice);

            RaisePropertyChanged("MicrophoneLevel");
        }
        private void BeginMonitoring2(int recordingDevice2)
        {
            recorder2.BeginMonitoring(recordingDevice2);
            RaisePropertyChanged("MicrophoneLevel2");
        }

        /*
        private void BeginRecording()
        {
            waveFileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            recorder.BeginRecording(waveFileName);
            RaisePropertyChanged("MicrophoneLevel");
            RaisePropertyChanged("ShowWaveForm");
        }
        */
        private void BeginRecording()
        {
            waveFileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".1.wav");
            waveFileName2 = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".2.wav");
            //waveFileName = Path.Combine(Path.GetDirectoryName(),)
            //waveFileName = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase), String.Format("{0}.1.wav", DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")));
            //waveFileName2 = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase), String.Format("{0}.2.wav", DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")));
            waveFileName = Path.Combine(Directory.GetCurrentDirectory(), String.Format("{0}.1.wav",DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")));
            waveFileName2 = Path.Combine(Directory.GetCurrentDirectory(), String.Format("{0}.2.wav", DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")));
            Console.WriteLine(waveFileName);
            recorder.BeginRecording(waveFileName);
            recorder2.BeginRecording(waveFileName2);
            RaisePropertyChanged("MicrophoneLevel");
            RaisePropertyChanged("MicrophoneLevel2");
            RaisePropertyChanged("ShowWaveForm");
            RaisePropertyChanged("ShowWaveForm2");
        }

        private void Stop()
        {
            recorder.Stop();
            //i added this
            recorder2.Stop();
        }
        
        public double MicrophoneLevel
        {
            get { return recorder.MicrophoneLevel; }
            set { recorder.MicrophoneLevel = value; }
        }

        //i added this
        public double MicrophoneLevel2
        {
            get { return recorder2.MicrophoneLevel; }
            set { recorder2.MicrophoneLevel = value; }
        }

        //uyh apparently CurrentInputLevel isnt a thing anywhere...
        /*
        public double CurrentInputLevel
        {
            get { return recorder.MicrophoneLevel; }
            set { recorder.MicrophoneLevel = value;  }
        }
        */
        // i added this apparently
        /*
        public double CurrentInputLevel2
        {
            get { return recorder2.MicrophoneLevel; }
            set { recorder2.MicrophoneLevel = value; }
        }
        */
        //ok so i guess its just get return last peak


        public bool ShowWaveForm
        {
            get { return recorder.RecordingState == RecordingState.Recording || 
                recorder.RecordingState == RecordingState.RequestedStop; }
        }
        public bool ShowWaveForm2
        {
            get
            {
                return recorder2.RecordingState == RecordingState.Recording ||
              recorder2.RecordingState == RecordingState.RequestedStop;
            }
        }

        // multiply by 100 because the Progress bar's default maximum value is 100
        public float CurrentInputLevel { get { return lastPeak * 100; } }
        public float CurrentInputLevel2 { get { return lastPeak2 * 100; } }

        public SampleAggregator SampleAggregator 
        {
            get
            {
                return recorder.SampleAggregator;
            }
        }
        public SampleAggregator SampleAggregator2
        {
            get
            {
                return recorder2.SampleAggregator;
            }
        }
    }
}