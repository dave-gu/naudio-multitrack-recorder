   M S B A M L   `   `   `  ���� M  IVoiceRecorder.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.CoreVoiceRecorder.Core   VoiceRecorder    VoiceRecorder.RecorderView   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    Imy<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.Core      � 	Resources   �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint �� EndPoint � Offset � Color��%G  '�       �� " �.���  � �� �� " �.R�� $��14��$	��200��.+��� $��
PART_Track������ $	 0,0&�$	 1,0&�.��� $ 0Q�$ 	#FF00FF00��� $	 0.9Q�$ 	#FFFFFF00��� $ 1Q�$ 	#FFFF0000��]� .+��� $��PART_Indicator��$
��Left=��� $
��Mask�����#C0C0C0�� $��1q����#888888.���� 
�������.+��� $��5q�$��Center=�$
��Bold"�$��20(�.��.NET Voice Recorder�� $��5q�.��-+Check the levels before starting recording:� $��5q�	 � Orientation$	 
Horizontal=�$��20��
 � Value
 �� *CurrentInputLevel+ �� Mode$ OneWay=�� $��5q�$	 
Horizontal=�$��20��
 �� *CurrentInputLevel2+$ OneWay=��� $��5q�.��Microphone Level:�� $��5q� �� Orientation$ 
Horizontal=� � Maximum$	 100Q�
 �� *MicrophoneLevel+$ TwoWay=���  �� Orientation$ 
Horizontal=�.+���    CircleButton#��[  $��5q� � ToolTip$ Start Recording������ *BeginRecordingCommand+��   
StopButton#��[ $��5q�$ Stop Recording������ *StopCommand+�� 
���   �$��2q� �� CornerRadius$ 3��$��2q�._��� $	��3,1q�$
��Bold"�$��16(����� *RecordedTime+/   )VoiceRecorder.Core.PolygonWaveFormControl  $��5q�$��55��   SampleAggregator �� *SampleAggregator+{��� *ShowWaveForm+  $��5q�$��55�� �� *SampleAggregator2+{��� *ShowWaveForm2+