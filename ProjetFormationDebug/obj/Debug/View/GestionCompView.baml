   M S B A M L   `   `   `  ����  ProjetFormationDebug/    )ProjetFormationDebug.View.GestionCompView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      6   �� 5      .+�5   
   �� ��6   �� *	Personnes+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $	��150��6>   ��6$   ��  �� Path$	 Nom�6>   �� 5      $��0q�5      
������ $	��0 1q�5      $��Disabled=�5      ��5      �� *DataContext.Competences+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >� �� Mode$ OneWay=� �� SelectedItem 5      �� $ 
Competence�$ TwoWay=���5      �� 5   "    �� 
TargetType" ��6(   .�5   &   ��  �� Property � ��	 �� Value$	 0q�6@   5$   #   ��5&      �� 5'   "   .R�5(   &   �� $��0q�61   $ 
Horizontal=�6<   5)   #   ��5+      �� 5,   "   .R�5-   &   �� $��Center=�5/   )   $
��Left=�50   )   
 �� Padding$	
 5 1q�51   )   $��0q�67   
�������$��35��53   )   ��5.   )   �� *LibelleCourt+��54   *   �� 55   .   " ��64   .�56   2   ��  � ��
	 �����6^    �� Triggers 57   2   �� 58   6    �� Binding 59   9   ��  ��  �� Mode$ FindAncestor=�" ��$ 
IsSelected� �� Value True5>   9   .a�5?   :   ��  � ��	 6W   �� *	Couleur+5@   7   5B   /   5D   '   5E   #   5G      �� 5H      ��6!   �� *DataContext.ThisOne+ �� *FindAncestor+" >���6�   �� *.+.��6�   test6�   5I      5J      5L      �� 5N   
   $��1��69   ��6   �� *	Personnes+��5O      �� 5P      .R�5Q      �� $ 
Horizontal=�6!   .+�5R      �� $	��150��6>   ��6$   �� $	 Nom�6>   �� 5S      $	��150��6R   ��6$   �� $ Competence.LibelleCourt�6R   5T      5U      5W      5�      5�      