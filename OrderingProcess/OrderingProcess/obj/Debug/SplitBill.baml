   M S B A M L   `   `   `  ����J  FOrderingProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OrderingProcessOrderingProcess  5   	       OrderingProcess.SplitBill   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OrderingProcess     5   	   c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5   	     � Title$  	SplitBill��5	   	   $	��768��6   $
��1024��6(   ���	#FFEFF4EF � 
ResizeMode$ NoResize=�6L   .��5
      � -   5         �Name$ MainGrid��5
      .+�5   
   � -   5        $ 
HeaderGrid��5      $��59��6#   $��
-10,-3,0,0q�6/   $	��Top=�6C   .+�5      �� -   5         ��Name$ TopBack��5      $��6.25,0,-3.667,0q�6)   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'    � Offset$ 1Q�65   � 5      $ 	#FF313031��6'   � 5      $ 	#FF171C1F��6'   $ 0.766Q�69   5      ��5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ 	#FF0F1213��6'   $ 0.389Q�69   � 5      $ Black��6'   $ 1Q�65   5      5      �� 5      -   5         ��Name$ backToTables��5      $
��Left=�6.   $��139.88,12,0,10q�6I   $
��Wrap=�6a   $��Back to Tables��6u   $	��160��6�   ���	#FFEFF4EF$��24(�6�   �� 5      -   5        $ backToBills��5      $
��Left=�6-   $��139.88,12,0,10q�6H   $
��Wrap=�6`   $	��272��6t   ���	#FFEFF4EF$��24(�6�   �� 6�   $�Back to Original S��6�   �� 6�   $�p��6�   �� 6�   $	�lit��6�   6�   %  Microsoft.Expression.Shapes.Arc  5      -   5        	  Name$	 	serverPic��5      
   ArcThickness$
 30Q�6(      ArcThicknessUnit$ Pixel=�6:      EndAngle$	 360Q�6S   $��Right=�6b   $��0,3,92.667,7q�6~    �� Stretch$
 None=�6�      
StartAngle$ 0Q�6�   $��49��6�   
���   ���5       �� 5!       �� ImageSource$ regular - Copy.jpg��6!    j� Stretch$ UniformToFill=�6B   5#      ,  &Microsoft.Expression.Shapes.BlockArrow  5$      -   5          Name$ backArrowTable��5$      $
��Left=�64      Orientation$
 Left=�6O   $	��100��6b   $��15,3,0,4.25q�6n    � Cursor$
 Hand��6�   ��5%      
� 5&      .��5'      � $ 	#FF597C77��6'   $ 1Q�69   � 5(      $ 	#FFA7B9B7��6'   5)      5+        5,      -   5        $ backArrowBills��5,      $
��Left=�64   $
 Left=�6O   $	��100��6b   $��15,3,0,4.25q�6n   $
 Hand��6�   ��5-      
� 5.      .��5/      � $ 	#FF597C77��6'   $ 1Q�69   � 50      $ 	#FFA7B9B7��6'   51      53      �� 54      -	   5         ��Name$ 
ServerName��54      $��Right=�6*   $��0,10.75,0,3.25q�6F    �� TextWrapping$
 Wrap=�6^   $��Sally��6r   $��87.667��6   ���	#FFC6CFD3$
��Bold"�6�   $��24(�6�    �� 
IsReadOnly . ��6�   Z� ��6�   Z� 6�   55      � 56   
   -
   5        $ ChangeSplitGrid��56      $��	0,61,0,-5q�6(   .+�57      �� -   5        $ 
tableTitle��57      $��43��6,   $��	4,1.5,0,0q�68   $
��Wrap=�6K   $��Table 20��6_   $	��Top=�6o   $��32(�6�   ���	#FF313031$
��Bold"�6�   $
��Left=�6�   $	��138��6�   A� 58      -   5         A�Name$ 
SplitsGrid��58      $��0,307,0,5.25q�6.   ���	#FF313031 A� Columns$ 2��6[   �� 59      -   5         ��Name$ ItemScroller��59      $��262.5��61   $��
4,44.5,0,0q�6@   $	��Top=�6T   .��5:      A� -   5        $ 	ItemsGrid��5:      $	��994��61   5;      �� 5<      -   5         ��Name$ 	userSplit��5<      $��Use This Split��6(   $��Right=�6A   $
��44.5��6]   $��0,0,10,0q�6k   $	��Top=�6}   $	��177��6�   $��26.667(�6�   ���	#FFEFF4EF��6�   Z� ��5=      
� 5>      .��5?      � $ 	#FF243330��6'   $ 1Q�69   � 5@      $ 	#FF4C5856��6'   5A      5C      �� 5D      -   5        $ helpOrdering��5D      $��?��6+   $
��Left=�67   $��	142,4,0,0q�6R   $��44��6e   $��1,0,1,1q�6p   $��26.667(�6�   $
��Bold"�6�   ���	#FFEFF4EF���	#FFFF7900$
��39.5��6�   $	��Top=�6   � ToolTip$} wDrag and drop items into the seat below. Double tap an item to split it into multiple pieces for splitting across seats��6  ��6�   Z� 6  5E      � 5F   
   -   5        $ AllFourGrid��5F      $��10,61,-10,-7q�6$   .+�5G      �� -   5        $ 	titleText��5G      $��95��6+   $��10,0,0,0q�67   $
��Wrap=�6I   $	��Top=�6]   $��64(�6u   ���	#FF313031$
��Left=�6�   $
��1000��6�   �� 6�   $�[��6�   �� 6�   $�table��6�   �� 6�   $�]��6�   6�   �� 5H      -   5        $ changeButton��5H      $��Change Split��6+   $
��Left=�6B   $��103.5��6]   $��0,0,0,18q�6l   $��Bottom=�6~   $	��493��6�   $��48(�6�   ���	#FFEFF4EF��6�   Z� ��5I      
� 5J      .��5K      � $ 	#FF597C77��6'   $ 1Q�69   � 5L      $ 	#FE90A8A4��6'   5M      5O      �� 5P      -   5        $ 
keepButton��5P      $��Keep Split & Pay��6)   $��103.5��6H   $��	0,0,20,18q�6W   $��Bottom=�6j   $��48(�6�   $��Right=�6�   $	��493��6�   ���	#FFEFF4EF��6�   Z� ��5Q      
� 5R      .��5S      � $ 	#FE90A8A4��6'   $ 0Q�69   � 5T      $ 	#FF597C77��6'   $ 1Q�69   5U      5W      �� 5X      -   5        $ eachSeatScroller��5X      $��0,95,20,130.5q�65   .��5Y      A� -   5        $ eachSeatGrid��5Y      ���	#FF313031$��457.5��6K   $��971.5��6Z   $ 2��6h   $
��Left=�6t   5Z      5[      A� 5\   
   -   5        $ SplitWarningGrid��5\      $��0,59,0,-4.351q�60   .+�5]      � -   5        $ splitOrWhole��5]      $%��298.268,273.537,299.839,193.263q�6)   ���	#FF0B0B0B J� Effect 5^      3  -System.Windows.Media.Effects.DropShadowEffect  5_      .+�5a      �� -   5        $ 	textBlock��5a      $��10,10,10,97.911q�6/   $
��Wrap=�6H   ���	#FFEFF4EF$��32(�6s   �� 6�   $
�You ��6�   �� 6�   $�m��6�   �� 6�   $�ust add all items ��6�   �� 6�   $�to one of the ��6�   �� 6�   $�seats��6�   �� 6�   $�!��6�   6  �� 5b      -   5        $ splitItemButton��5b      $��Ok��62   $��82.911��6?   $��53.181,0,54,10q�6O   $��Bottom=�6g   ���	#FFEFF4EF$��32(�6�   ��6�   Z� ��5c      
� 5d      .��5e      � $ 	#FF4C5856��6+   $ 0Q�6=   � 5f      $ 	#FF243330��6+   $ 1Q�6=   5g      5i      5j      5k      A� 5l   
   -   5        $ SplitSliderGrid��5l      $��10,59,-10,0q�6/   .+�5m      � -   5        $ 
SplitPopup��5m      $��233,199,233,175q�6'   ���	#FF0B0B0B 5n        5o      .+�5q      �� -   5         ��Name$ splitSlider��5q      $��50��6.   $��
66,0,66,96q�6:   $��Bottom=�6N    �� IsSnapToTickEnabled .  � Minimum$ 1Q�6�   �� 5r      -   5        $ promptSplit��5r      $��90��61   $��66,42,186,0q�6=   $
��Wrap=�6R   $	��Top=�6f   ���	#FFEFF4EF$��53.333(�6�   �� 6�   $�
# of Split��6�   �� 6�   $�s:��6�   6�   �� 5s      -   5        $ 
splitCount��5s      $��Right=�60   $��90��6L   $��	0,42,66,0q�6X   $
��Wrap=�6k   $��1��6   $	��Top=�6�   $��84��6�   ���	#FFEFF4EF$��64(�6�   $
��Bold"�6�   �� 5t      -    5        $ okSplit��5t      $��OK��6*   $
��Left=�67   $��64��6R   $��	66,0,0,32q�6^   $��Bottom=�6q   $	��198��6�   ���	#FFEFF4EF$��32(�6�   ��6�   Z� ��5u      
� 5v      .��5w      � $ 	#FF4C5856��6+   $ 0Q�6=   � 5x      $ 	#FF243330��6+   $ 1Q�6=   5y      5{      �� 5|      -!   5        $ cancelSplit��5|      $��Cancel��6.   $��Right=�6?   $��64��6[   $��	0,0,66,32q�6g   $��Bottom=�6z   $	��198��6�   ���	#FFEFF4EF$��32(�6�   ��6�   Z� ��5}      
� 5~      .��5      � $ 	#FF4C5856��6+   $ 0Q�6=   � 5�      $ 	#FF243330��6+   $ 1Q�6=   5�      5�      5�      5�      � 5�   
   -"   5        $ MultipleBills��5�      $��0,59,-10,-0.585q�6&   .+�5�      �� -#   5        $ 
multiTitle��5�      $��95��6,   $��10,0,0,0q�68   $
��Wrap=�6J   $	��Top=�6^   $��64(�6v   ���	#FF313031$
��Left=�6�   $
��1000��6�   �� 6�   $�[��6�   �� 6�   $�table��6�   �� 6�   $�]��6�   6�   A� 5�      -$   5        $ BillListGrid��5�      $��10,95,18,10q�60   $
��Left=�6E   $	��Top=�6`   $ 1��6x   �� 5�      -%   5        $ donePayButton��5�      $��Done Payments��6,   $��115.585��6D   $��261,0,261,10q�6U   $��Bottom=�6k   $��64(�6�   ���	#FFEFF4EF��5�      
� 5�      .��5�      � $ 	#FF243330��6'   $ 1Q�69   � 5�      $ 	#FF4C5856��6'   5�      5�      5�      5�      5�      