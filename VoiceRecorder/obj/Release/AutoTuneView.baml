   M S B A M L   `   `   `  ����   VoiceRecorder     VoiceRecorder.AutoTuneView   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    >d2http://schemas.microsoft.com/expression/blend/2008    
�������.��� .+��� {��� *	IsEnabled+.+��� $��5q�$��Center=�$
��Bold"�$��20(�.��AutoTune Settings��   �� Orientation$  
Horizontal=�.+��� $��5q� d� 	IsChecked �� *IsAutoTuneEnabled+.��Enable Autotune�� $  
Horizontal=�.+��� $��5q�.��Attack�� $��5q� �� Orientation$ 
Horizontal=� � Minimum$ 0Q� � Maximum$	 200Q� � SmallChange$ 10Q� � LargeChange$ 25Q�$	��180�� � Value ��  �� Path$ 
AttackTime�	 �� Mode$	 TwoWay=��� $��5q����� *AttackMessage+�� $  
Horizontal=�.+��� $	��5,0q�.��Scale:�� $	��5,0q�$	��150������ *Scales+
 �� SelectedItem
 �� *SelectedScale+�� $	��5,0q�$��Snap Pitches:���� $��5q�$	��100������ *	Pitches+���� .R�� ���� .R��� $��16(�$��60�� �� *
Selected+���� *DisplayName+�� $  
Horizontal=�.+��� $��5q�$	��100������ *ApplyCommand+.��Apply�� $��5q�$	��100������ *CancelCommand+.��Cancel�� 
���   �$��4q� �� CornerRadius$ 10��$��Center=�$��Center=� �� Padding$ 20q�
�������y��� *ProcessingMessageVisibility+._��� .+��� $��Processing...��$��20(��� $��Please Wait��$��Center=�