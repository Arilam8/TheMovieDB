   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp.ViewWpfApp.View  5   	   !    WpfApp.View.ViewFilmDetails   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfApp.View     5   	     � Title$  Détails du film��5   	   $	��450��6!   $
��1200��6.   .��5	      � $��0,0,0,0q�6   .+�5
   
   � $
��Left=�6   $	��280��6*   .+�5      �� -   5         ��Name$ 	TitleFilm��5      $
��Left=�6G   $��	60,35,0,0q�6b   $��20(�6u   $
��Wrap=�6�   $	��Top=�6�   ��6+   ��  �� Path$ Title�6�   �� 5      -   5         ��Name$ 
PosterFilm��5      $
��Left=�6G   $	��100��6b   $��100,150,0,0q�6o   $	��Top=�6�   $	��100��6�   ��6(   �� $ Poster�6�   �� 5      -   5         ��Name$ label1��5      $��Id : ��6$   $
��Left=�64   $��
90,291,0,0q�6O   $	��Top=�6c   �� 5      -   5        $ Id��5      $
��Left=�6<   $��139,291,0,0q�6W   $	��Top=�6l   ��6    �� $ Id�6l   5      � 5   
   $��	280,0,0,0q�6   $
��auto��6"   $
��Left=�6/   .+�5      �� $��	Acteurs :��6   $��0,0,0,0q�6(   $��15(�69   $
��Left=�6G   &   System.Windows.Controls.DataGrid  5      $��	0,40,0,40q�6   $
��auto��6*      AutoGenerateColumns$ false��6V      	RowHeight$ 20Q�6r      
IsReadOnly$
 True��6�   $��Center=�6�      RowHeaderWidth$ 0Q�6�   ��67   �� *Actors+	   RowStyle	 5      �� 5      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5      ��  �� Property �@J�IsHitTestVisible �� Value$ false��6=   5         	CellStyle 5      �� 5      *  $System.Windows.Controls.DataGridCell"
  6   .�5      ��  � �� 5      �� 5   "    �� 
TargetType"  62   .R�5   &   �� $��Center=�67   $��Center=�6T   5   #   5       5!         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Name+  5%      $ Prénom��6)    69   �� *	Surname+  5&      $ Nombre de films��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6]    6B   �� *NbFilm+6]   5(      5)      � 5*   
   $��	520,0,0,0q�6   $	��160��6"   $
��Left=�6.   .+�5+      �� $��Genres :��6   $��0,0,0,0q�6'   $��15(�68   �� 5,      -   5        $ Genres��5,      $��
0,40,10,40q�6(   5-      � 5.   
   $��	700,0,0,0q�6   $	��250��6"   $
��Left=�6.   .+�5/      �� $��Commentaires :��6   $��0,0,0,0q�6-   $��15(�6>     50      $��	0,40,0,40q�6   $
��auto��6+   $ false��6Y   $ 20Q�6u   $
 True��6�   $��Center=�6�   $ 0Q�6�   ��68   �� *
Comments+	 51      �� 52      "
  6   .�53      ��  �@J�IsHitTestVisible$ false��6=   54       56      �� 57      "
  6   .�58      ��  � �� 59      �� 5:   "   "  62   .R�5;   &   �� $��Center=�67   $��Center=�6T   5<   #   5>      5?       5A        5B      $
 Note��6)    67   �� *Rate+  5C      $ Commentaire��6)    6>   �� *	Content+  5D      $ Utilisateur��6)    6>   �� *
Username+  5E      $
 Date��6)    67   �� *Date+5G      5H      � 5I   
   $��	950,0,0,0q�6   $	��250��6"   $
��Left=�6.   .+�5J      �� -   5         ��Name$ TextUsername��5J      $
��Left=�6,   $��
107,36,0,0q�6G   $��Alpha��6[    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5K      -   5        $ label��5K      $��Username��6#   $
��Left=�66   $��	32,32,0,0q�6Q   $	��Top=�6d   �� 5L      -   5        $ label2��5L      $
��Rate��6$   $
��Left=�63   $��	32,63,0,0q�6N   $	��Top=�6a   �� 5M      -	   5         ��Name$ 	SlideRate��5M       �� TickPlacement$ BottomRight=�6(    �� TickFrequency$ 1Q�6E    �� IsSnapToTickEnabled$
 true��6W   $
��Left=�6r   $��
107,67,0,0q�6�   $	��Top=�6�   $	��120��6�    � Minimum$ 0Q�6�    � Maximum$ 5Q�6�   �� 5N      -
   5        $ TextComment��5N      $��Votre commentaire��6+   $
 Wrap=�6D   $��20��6X   $��20��6g   $��Center=�6u   $��0,154,0,180q�6�   $	��159��6�   �� 5O      -   5        $ label3��5O      $��Commentaire��6$   $
��Left=�6:   $��50��6U   $��
40,123,0,0q�6a   $	��Top=�6u   �� 5P      -   5         ��Name$ AjouterCommentaire��5P      $��Ajouter��61   $��50��6C   $
��Left=�6N   $��
45,0,0,127q�6i   $��20��6�   $��Bottom=�6�   5Q      5R      5S      