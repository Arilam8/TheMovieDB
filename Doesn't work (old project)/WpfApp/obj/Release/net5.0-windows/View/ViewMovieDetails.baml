   M S B A M L   `   `   `  ���� A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp.ViewWpfApp.View  !    WpfApp.View.ViewFilmDetails   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfApp.View     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Détails du film��$	��450��$
��1200��$��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�.��� $��0,0,0,0q� � 	Resources  �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source��    	 Light 
LightGreen Lime�� $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?��� $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�%    .+�� $
��Left=�$	��280��.+��� -   	 ��Name$	 	TitleFilm��$
��Left=�$��	60,35,0,0q�$��20(�$
��Wrap=�$	��Top=����� 
 �� Path$
 Title��� -    ��Name$ 
PosterFilm��$
��Left=�$	��111��$��
65,204,0,0q�$	��Top=�$	��109������ $
 Poster��� -    ��Name$ label1��$��ID : ��$
��Left=�$��	65,80,0,0q�$	��Top=��� -   $ Id��$
��Left=�$��
109,81,0,0q�$	��Top=�$��92������ $
 Id�� $��	280,0,0,0q�$
��auto��$
��Left=�.+��� $��Actors :��$��0,0,0,0q�$��15(�$
��Left=�&   System.Windows.Controls.DataGrid  $��	0,40,0,40q�$	��231��   AutoGenerateColumns$ false��   	RowHeight$ 20Q�   
IsReadOnly$
 True��$��Center=�   RowHeaderWidth$ 0Q����� *Actors+   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property �@J�IsHitTestVisible �� Value$ false��   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � �� ��  �� 
TargetType"  .R��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Surname�� �� *	Surname+  $ Movies��   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 100	  �� *
NbMovies+� $��	520,0,0,0q�$	��160��$
��Left=�.+��� $��Genres :��$��10,0,0,0q�$��15(��� -   $	 Genres��$��
0,40,10,40q�� $��	700,0,0,0q�$	��250��$
��Left=�.+��� $��
Comments :��$��0,0,0,0q�$��15(�  $��	0,40,0,40q�$
��auto��$ false��$ 20Q�$
 True��$��Center=�$ 0Q����� *
Comments+ �� "  .���  �@J�IsHitTestVisible$ false�� �� "  .���  � �� �� "  .R��� $��Center=�$��Center=�   $
 Rate�� �� *Rate+  $ Comment�� �� *	Content+  $ Username�� �� *
Username+  $
 Date�� �� *Date+� $��	950,0,0,0q�$	��250��$
��Left=�.+��� -    ��Name$ TextUsername��$
��Left=�$��
107,36,0,0q�$��Alpha�� �� TextWrapping$
 Wrap=�$	��Top=�$	��120�� � Cursor$ IBeam���� -   $ label��$��Username��$
��Left=�$��	32,32,0,0q�$	��Top=��� -   $ label2��$
��Rate��$
��Left=�$��	32,63,0,0q�$	��Top=��� -	    ��Name$ 	SlideRate�� �� TickPlacement$ BottomRight=�  �� TickFrequency$  1Q�! �� IsSnapToTickEnabled$
! true��$
��Left=�$��
107,67,0,0q�$	��Top=�$	��120��" � Minimum$" 0Q�# � Maximum$# 5Q��� -
   $ TextComment��$	��...��$
 Wrap=�$��20��$��20��$��Center=�$��0,154,0,180q�$	��159��$ IBeam���� -   $ label3��$��Comments��$
��Left=�$��50��$��
40,123,0,0q�$	��Top=��� -   $ ��Name$$ AjouterCommentaire��$	��Add��$��75��$
��Left=�$��
45,0,0,122q�$��25��$��Bottom=�