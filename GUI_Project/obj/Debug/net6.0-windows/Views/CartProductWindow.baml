   M S B A M L   `   `   `  ����F  BGUI_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GUI_Project.ViewsGUI_Project.Views  5   	   )clr-namespace:GUI_ProjectGUI_Project  5   	   )    #GUI_Project.Views.CartProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GUI_Project.Views     5   	   )dirclr-namespace:GUI_Project     5   	     � Title$  CartProductWindow��5	   	   $	��190��6#   $	��300��60    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency$
 True��5   	   
������  � DataContext 5         GUI_Project.MainWindowVM  5   
   .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��1q�6#   ���#999999��5      �� 5       �� Color$ White��6"   5      ._�5      � .+�5      ��  �� Orientation$ Vertical=�6   .+�5      ��    
normalText#��[  6    $��14(�6D   $��
10 20 10 0q�6R   $��Add the Quantity��6f   �� 5      #��[  6N   $��14(�6r   $��0 10 0 0q�6�   ��6    �� 	 �� ElementName$
	 sldr��
 �� Path$
 Value�6�   �� 5      -   5         ��Name$
 sldr��5      $��30 10 30 10q�6+    � Minimum$ 1Q�6@    � Maximum$	 100Q�6L    �� IsSnapToTickEnabled$
 True��6Z    �� TickFrequency$ 1Q�6u    � Value 6�   �� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $ 
Horizontal=�6!   $��Center=�6:   .+�5       �� -   5          messageBoxSecondaryButton#��[ 5    !   $��Cancel��6T   6e   �� 5!      -   5          messageBoxPrimaryButton#��[ 5!   !   $	��Add��6R   ��6x   �� *CartProductsCommand+5"      5#      5$      5%      5&      5'      