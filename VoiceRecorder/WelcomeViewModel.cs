using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NAudio.Wave;
using System.Windows.Input;
using VoiceRecorder.Core;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace VoiceRecorder
{
    class WelcomeViewModel : ViewModelBase, IView
    {
        private ObservableCollection<string> recordingDevices;
        private ObservableCollection<string> recordingDevices2;
        private int selectedRecordingDeviceIndex;
        private int selectedRecordingDeviceIndex2;
        private ICommand continueCommand;
        public const string ViewName = "WelcomeView";
        private int fuckthisToggle = 1;

        public WelcomeViewModel()
        {
            this.recordingDevices = new ObservableCollection<string>();
            this.recordingDevices2 = new ObservableCollection<string>();
            this.continueCommand = new RelayCommand(() => MoveToRecorder());
        }

        public ICommand ContinueCommand { get { return continueCommand; } }

        public void Activated(object state)
        {
            this.recordingDevices.Clear();
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                this.recordingDevices.Add(WaveIn.GetCapabilities(n).ProductName);
            }
            this.recordingDevices2.Clear();
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                this.recordingDevices2.Add(WaveIn.GetCapabilities(n).ProductName);
            }
        }

        private void MoveToRecorder()
        {
            //Messenger.Default.Send(new NavigateMessage(RecorderViewModel.ViewName, SelectedIndex));
            //^ most recent previous config
            Messenger.Default.Send(new NavigateMessage(RecorderViewModel.ViewName, SelectedIndexCyclerB));
            //Messenger.Default.Send(new NavigateMessage(RecorderViewModel.ViewName, SelectedIndex2));
        }

        public ObservableCollection<string> RecordingDevices 
        {
            get { return recordingDevices; }
        }
        public ObservableCollection<string> RecordingDevices2
        {
            get { return recordingDevices2; }
        }
        /*
        public int SelectedIndexCycler
        {
            get
            {
                if (fuckthisToggle == 1)
                {
                    fuckthisToggle = 2;
                    return selectedRecordingDeviceIndex;
                }
                else if (fuckthisToggle == 2)
                {
                    fuckthisToggle = 1;
                    return selectedRecordingDeviceIndex2;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (selectedRecordingDeviceIndex != value)
                {
                    selectedRecordingDeviceIndex = value;
                    RaisePropertyChanged("SelectedIndex");
                }
            }
        }
        */

        public int[] SelectedIndexCyclerB
        {
            get
            {
                return new int[] { selectedRecordingDeviceIndex, selectedRecordingDeviceIndex2 };
            }
            set
            {

            }
        }

        /*
        public int[] SelectedIndexes
        {
            private int[] sindex;
            get
            {
                sindex = new int[2];

            }
            set
            {

            }

        }
        */

        public int SelectedIndex
        {
            get
            {
                /*
                if (fuckthisToggle == 1)
                    {
                    fuckthisToggle = 2;
                    return selectedRecordingDeviceIndex;
                }
                else if (fuckthisToggle == 2)
                    {
                    fuckthisToggle = 1;
                    return selectedRecordingDeviceIndex2;
                }
                */
                return selectedRecordingDeviceIndex;
            }
            set
            {
                if (selectedRecordingDeviceIndex != value)
                {
                    selectedRecordingDeviceIndex = value;
                    RaisePropertyChanged("SelectedIndex");
                }
            }
        }

        public int SelectedIndex2
        {
            get
            {
                return selectedRecordingDeviceIndex2;
            }
            set
            {
                if (selectedRecordingDeviceIndex2 != value)
                {
                    selectedRecordingDeviceIndex2 = value;
                    RaisePropertyChanged("SelectedIndex2");
                }
            }
        }
    }
}
