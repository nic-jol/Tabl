   M S B A M L   `   `   `  ����J  FOrderingProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OrderingProcessOrderingProcess  5   	   !    OrderingProcess.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OrderingProcess     5   	   c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5   	     � Title$  LoginWindow��5	   	   ���	#FF134F66$	��768��64   $
��1024��6A    � 
ResizeMode$ NoResize=�6N    � 	Resources 5
         WindowControlTemplate1 �� 
TargetType  SolidBorderBrush �� Color  WindowBackgroundBrush  SelectedForegroundBrush  DisabledBackgroundBrush  UnselectedBackgroundBrush  UnselectedForegroundBrush �� 
TargetType �� Property �� Value �� CornerRadius	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 K     &	 n     &	 �     &	 �     &	 �     &	 �     '��     7  7  7  7  �� 5   
   " �69   .R�5      � $��0,-27.546,0,0q�6   5      �� 5   
   $ 	#FF134F66��63   �� 5   
   $ 	#FF134F66��68   �� 5   
   $
 #FFF��6:   �� 5   
   $
 #EEE��6:   �� 5   
   $ 	#FF002038��6<   �� 5   
   $ 	#FF8D8D8D��6<   �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5       � .+�5!      �� $��Border��5"      $��0,0,-4,0q�5#      $��1,1,1,1q�5$      $ 2,12,0,0��5%      ._�5&   "   �� $	 ContentSite��63   $��Center=�5'      $��Center=�5(      $��Header��5)      $��	12,2,12,2q�5*      ��. 5+      5,      5-      
 5.      P� 5/       �@��
IsSelected . . �50   "   ��  �@K�ZIndex$	 100��6A   �� 51   "   $ Border��6)   8    � ��6S   �� 52   "   $ Border��6)    � ��$ 1,1,1,0q�6X   �� 53   "   8   � ��6?   54      P� 55       �@��
IsSelected .  . �56   "   ��  �@K�ZIndex$	 100��6A   �� 57   "   $ Border��6)   8   � ��6S   �� 58   "   $ Border��6)    � ��$ 1,1,1,0q�6X   �� 59   "   8   � ��6?   5:      5C      5E      5F      5G      .��5H      � -   5         �Name$ MainGrid��5H      $��-4.25,0,-4,-3.667q�6   ���	#FFB1CABE � ColumnDefinitions 5I   
   �� 5J      �� 5K      $��0* �6   .+�5M   
   �� -   5         ��Name$ LoginButton��5M      $��Login��6&   $��381.867,566.185,344.035,0q�66   $	��Top=�6Y   ���	#FF858685$��34.96��6�   ���	#FF161616$��18.667(�6�   ��6�   Z� 6�   �� 5N   
   -   5         ��Name$ 
AddressBox��5N      $
��Left=�6&   $��27��6A   $��381.867,418,0,0q�6M    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $��291.348��6�   $��18.667(�6�   �� 5O   
   -   5         ��Name$ 	LogoImage��5O      $��268.24,123.66,268.953,0q�6#   $��tablLogo.png��6D   $	��Top=�6Z   �� 5P   
   -   5         ��Name$ invalidUser��5P      $��381.867,0,344.035,176.482q�6)   $
��Wrap=�6L   $"��Invalid username or password��6`   $��Bottom=�6�   ���	#FF858685$��18(�6�   $��22.185��6�    �� TextAlignment$ Center=�6�   $y�Hidden=�6�   �� 5Q   
   -   5        $ usernameLabel��5Q      $
��Left=�6+   $��27��6F   $��381.867,0,0,324.667q�6R   $
��Wrap=�6o   $��Bottom=�6�   $��119.383��6�   ���	#FF858685$��21.333(�6�   �� 6�   $
��Bold"�6�   $�Username��6�   6  �� 5R   
   -   5        $ 	textBlock��5R      $
��Left=�6'   $��27��6B   $��381.867,0,0,235.667q�6N   $
��Wrap=�6k   $��Bottom=�6   $��119.383��6�   $��21.333(�6�   ���	#FF858685�� 6�   $
��Bold"�6�   $�Password��6�   6�   G� 5S   
   -   5         G�Name$ PasswordBox��5S      $
��Left=�6+   $��381.867,507,0,0q�6F   $	��Top=�6_   $��291.348��6w   $��27��6�   5T      5U      