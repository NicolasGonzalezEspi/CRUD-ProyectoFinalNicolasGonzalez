   M S B A M L   `   `   `  ����  trabajoFinalInterfaces#    trabajoFinalInterfaces.Borrar   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Borrar��5      .��5      � 
���OO/�.+�5	   
   �� $��BORRAR��6   $��20(�5
      $
��Bold"�6"   
�������$
��Left=�5      $	��Top=�6/   $��	10,10,0,0q�5      �� 5   
   $��	Producto:��6   $��16(�5      
�������$
��Left=�5      $��	30,50,0,0q�6/   $	��Top=�5      �� 5   
   -   5         ��Name$ txtProductoBorrar��5      $	��200��5      $��25��6   $
��Left=�5      $��	30,80,0,0q�6-   $	��Top=�5      �� 5   
   -   5        $��Borrar��5      $��80��5      $��30��6   
���  ��
�������$
��Left=�5      $��
250,80,0,0q�6,   $	��Top=�5      5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dgProductos��5!         AutoGenerateColumns$ False��5"         
IsReadOnly$
 True��5#      $��30,130,30,20q�5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Producto��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Producto+6T     5(      $ 
Categoría��6%   $ * 6V    68   �� *
Categoría+6V   5*      5,      5-      