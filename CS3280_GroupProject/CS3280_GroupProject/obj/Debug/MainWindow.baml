   M S B A M L   `   `   `  ����N  JCS3280_GroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CS3280_GroupProjectCS3280_GroupProject  5   	   $    CS3280_GroupProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CS3280_GroupProject     5   	     � Title$  Invoice System��5   	   $��504.011��6    $��643.105��61    � WindowStyle$ 
ToolWindow=�6A    � WindowStartupLocation$ CenterScreen=�6Z   .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   �� 5      $	��93* �6   �� 5      $
��459* �6   �� 5      $	��83* �6   .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $��55��6T   $��	10,10,0,0q�6`   $	��Top=�6s   $	��613��6�   $��3��6�   ._�5      �� -   5         ��Name$ pnl_GeneralControls��5       �� Orientation$ 
Horizontal=�66   $��Center=�6O   .+�5      �� -   5         ��Name$ btn_New��5      $��New Invoice��6*   $	��100��6@   $��
10,10,0,10q�6L   $��Center=�6`   6}   �� 5      -   5        $ btn_Save��5      $��Save Invoice��6+   $	��100��6B   $��
10,10,0,10q�6N   $��Center=�6b   {�.  6�   �� 5      -   5        $ 
btn_Search��5      $��Search for Invoice��6-   $	��100��6J   $��
10,10,0,10q�6V   $��Center=�6j   6�   �� 5      -   5        $ btn_EditInventory��5      $��Edit Inventory��64   $	��100��6M   $��
10,10,0,10q�6Y   $��Center=�6m   6�   5      5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��56��6T   $��	10,71,0,0q�6`   $	��Top=�6s   $	��613��6�   $��3��6�   ._�5      �� -   5        $ pnl_InvoiceControls��5      $��0,-1,0,0q�66   $ 
Horizontal=�6H   .+�5      �� -   5         ��Name$ lb_InvoiceID��5      $
��Left=�62   $
��Wrap=�6M   $��Invoice #0000��6a   $	��Top=�6v   $��18(�6�   $��	5,15,15,0q�6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ btn_Date��5      $��	5,10,0,10q�6/   $��25��6B   	   Text$
	 Date��6N   6Z   �� 5      �� 5      -	   5        $ lb_Total��5      $
��Left=�6.   $
��Wrap=�6I   $��Total $0��6]   $	��Top=�6m   $��18(�6�   $	��144��6�   $��	25,15,0,0q�6�   �� 5      -
   5        $ 
btn_Delete��5      $��Delete Invoice��6-   $��95��6F   $��
85,15,0,15q�6Q   $��25��6e   ���	#FFE04343$
��Bold"�6�   {�.  6�   5      5      &   System.Windows.Controls.DataGrid  5    
   -   5        
  Name$

 grid��5       $
��Left=�6!   $	��322��6<   $��
10,132,0,0q�6I   $	��Top=�6]   $	��352��6u   $��2��6�   6�   � 5!   
   $��1��6   $
��Left=�6   $	��301��6:   $��274.293,132,0,0q�6G   $	��Top=�6`   $	��257��6x   $��2��6�   .+�5"      �� $��
Item Code:��6   $
��Left=�6)   $��3,22,0,0q�6D   $	��Top=�6V   $
��Bold"�6n   �� 5#      $��Cost:��6   $
��Left=�6$   $��4,95,0,0q�6?   $	��Top=�6Q   $
��Bold"�6i   �� 5$      -   5         ��Name$ cm_Item��5$      $��10,48,10,228q�6(   $��25��6>   {�.  6�   �� 5%      -   5        $ btn_Add��5%      $	��Add��6&   $��10,258,183,-21q�64   {�.  6b   �� 5&      -   5        $ btn_Edit��5&      $��Update Item��6'   $��79,258,100,-21q�6=   {�.  6g   �� 5'      -   5        $ tb_Price��5'      $
��Left=�6*   $��
51,100,0,0q�6E   $
��Wrap=�6Y   $��No Item Selected��6m   $	��Top=�6�   $	��196��6�   �� 5(      $��Item Description:��6   $
��Left=�60   $��	4,139,0,0q�6K   $	��Top=�6^   $
��Bold"�6v   �� 5)      -   5        $ tb_Desc��5)      $
��Left=�6)   $��
10,165,0,0q�6D   $
��Wrap=�6X   $��No Item Selected��6l   $	��Top=�6�   $	��237��6�   $��96��6�   �� 5*      -   5        $ btn_DeleteItem��5*      $��Remove Item��6-   $��162,258,17,-21q�6C   {�.  6m   5+      5,      5-      