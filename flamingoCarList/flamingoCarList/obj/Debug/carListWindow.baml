   M S B A M L   `   `   `  ����J  FflamingoCarList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:flamingoCarListflamingoCarList  5   	   #    flamingoCarList.carListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:flamingoCarList     5   	     � Title$  carListWindow��5   	   $	��450��6   $	��800��6,   .��5	      � ���	#FFB1ADAD$��0,0,0,-6q�6"    � RowDefinitions 5
   
   �� 5      $
��177* �6   �� 5      $
��263* �6   .+�5   
   �� -   5        $��ClickableImage��5      $��Images/edit.png��6&   $��60��6?   $��60��6J   $��Right=�6V   $��Bottom=�6r   $��0,0,10,5q�6�   $��1��6�   �� 5   
   -   5        $��carListHeader��5      $��Images/carListHeader.jpg��6%   $��UniformToFill=�6G   $	��Top=�6_   $��95��6w   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��FLAMINGO RENT CAR LIST��6C   $	��Top=�6a   $��88��6y   $	��300��6�   
�������$��Algerian)�6�   $��36(�6�   �� 5   
   -   5        $��
goBackIcon��5      $��Images/go_back.png��6"   $��45��6>   $��45��6I   $
��Left=�6U   $��Bottom=�6p   $��	10,0,0,10q�6�    J� RenderTransformOrigin$ 0.508,-0.207&�6�   $��1��6�   �� 5   
   -   5        $��
CarListBox��5      $��32,110,40,70q�6$   ���	#FFFC1A1A$��2��6h   ��6R   Z� ��5      �� 5      .R�5      � $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      �� $	��210��5      $	��100��6$   $��UniformToFill=�61   $��0��6I   $��10q�6Y   ��5       �� *
CarImage+ �� TargetNullValue$3 -pack://application:,,,/Images/placeholder.jpg��5   Y   �� 5       �� Orientation$ Vertical=�6%   $��1��6<   $��Center=�6L   $��Stretch=�6g   .+�5      �� $
��Bold"�6?   $��16(�6Q   $��Stretch=�6_   ��6(   �� *Brand+6_   �� 5      $��14(�6?   $��Stretch=�6M   ��6(   �� *Model+6M   �� 5      $��14(�6>   $��Stretch=�6L   ��6(   �� *Year+6L   �� 5       $��14(�6\   $��Stretch=�6j   ��6(   �� *Price+ �� StringFormat$ Price: {0:C}��6j   5!      5"      5#      5%      5'      5(      