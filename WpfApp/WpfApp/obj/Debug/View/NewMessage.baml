   M S B A M L   `   `   `  ����
  WpfApp9)clr-namespace:WpfApp.View;assembly=WpfAppWpfApp.View  5   	       WpfApp.View.NewMessage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:WpfApp.View;assembly=WpfApp     5   	     � Title$  
NewMessage��5   	   $	��400��6   $��417.428��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ MessageTypeLabel��5
      $��Message Type��6*   $
��Left=�6A   $��	20,20,0,0q�6\   $	��Top=�6o   $
��Bold"�6�   �� 5   
   -   5         ��Name$ MessageTypeComboBox��5      $
��Left=�60   $��	20,51,0,0q�6K   $	��Top=�6^   $	��120��6v   6�   �� 5   
   -   5        $ SenderLabel��5      $��Sender:��6%   $
��Left=�67   $��	20,78,0,0q�6R   $	��Top=�6e   $
��Bold"�6}   �� 5   
   -   5         ��Name$ SenderTextBox��5      $
��Left=�6)   $��2,0,0,0q�6D   $��
20,109,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ SirCheckBox��5      $!��Significant Incident Report��6(   $
��Left=�6N   $��
145,54,0,0q�6i   $	��Top=�6}   $y�	Collapsed=�6�   �� 5   
   -   5        $ SubjectLabel��5      $��Subject:��6&   $
��Left=�69   $��
145,78,0,0q�6T   $	��Top=�6h   $y�	Collapsed=�6�   $
��Bold"�6�   �� 5   
   -   5        $ SubjectTextBox��5      $
��Left=�6*   $��2,0,0,0q�6E   $��145,109,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��120��6�   $y�	Collapsed=�6�   �� 5   
   -   5        $ NatureLabel��5      $��Nature of Incident:��6%   $
��Left=�6C   $��
145,78,0,0q�6^   $	��Top=�6r   $y�	Collapsed=�6�   $
��Bold"�6�   �� 5   
   -	   5        $ NatureComboBox��5      $
��Left=�6+   $��145,105,0,0q�6F   $	��Top=�6[   $	��120��6s   $y�	Collapsed=�6   �� 5   
   -
   5        $ SortCodeLabel��5      $��
Sort Code:��6'   $
��Left=�6<   $��
270,78,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   $y�	Collapsed=�6�   �� 5   
   -   5        $ SortCodeTextBox��5      $
��Left=�6+   $��2,0,0,0q�6F   $��270,109,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   $y�	Collapsed=�6�   �� 5   
   -   5        $ MessageBodyLabel��5      $��Message:��6*   $
��Left=�6=   $��
20,132,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   �� 5   
   -   5        $ MessageBodyTextBox��5      $
��Left=�6.   $	��150��6I   $��2,0,2,0q�6V   $��
20,163,0,0q�6h   $
 Wrap=�6|   $	��Top=�6�   $	��370��6�   �� 5   
   -   5         ��Name$ SendBtn��5      $
��Send��6"   $
��Left=�61   $��
20,320,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ ClearBtn��5      $��Clear��6#   $
��Left=�63   $��315,320,0,0q�6N   $	��Top=�6c   $��75��6{   6�   5      5      