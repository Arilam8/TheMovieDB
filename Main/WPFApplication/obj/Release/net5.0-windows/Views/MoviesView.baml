   M S B A M L   `   `   `  ���� E  AFluentWPF, Version=0.10.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  I EWPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPFApplication.ConvertersWPFApplication.Converters %   WPFApplication.Views.MoviesView   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  3local'clr-namespace:WPFApplication.Converters  )   #SourceChord.FluentWPF.AcrylicWindow    Enabled$
  True��(   "SourceChord.FluentWPF.AcrylicPanel   NoiseOpacity$ 0Q�   	TintColor$ #1F1F1F��   ExtendViewIntoTitleBar$
 True��   TintOpacity$	 100Q� � Title$ Movies��$��15(�$	��560��$
��1000�� � WindowStyle$
 None=� � 	Resources    TheMovieDBLogo �� 	UriSource  PosterNotFound.  (WPFApplication.Converters.ImageConverter  ImageConverter4  .WPFApplication.Converters.ReleaseDateConverter  ReleaseDateConverter0  *WPFApplication.Converters.RuntimeConverter  RuntimeConverter<  6WPFApplication.Converters.RatingBarTheMovieDBConverter   RatingBarTheMovieDBConverter9  3WPFApplication.Converters.RatingTheMovieDBConverter  RatingTheMovieDBConverter;  5WPFApplication.Converters.NavigationNextPageConverter  NavigationNextPageConverter?	  9WPFApplication.Converters.NavigationPreviousPageConverter # NavigationPreviousPageConverter/
  )WPFApplication.Converters.SearchConverter 	 SearchConverter3  -WPFApplication.Converters.SearchHintConverter 
 SearchHintConverter��%�   &	        &	 (     &	 P     &	 U     &	 Z     &	 _     &	 d     &	 i     &	 n     &		 s     &	
 x     �� $" ../Images/TheMovieDBLogo.png?��� $" ../Images/PosterNotFound.png?�            	  
    .��)  #MaterialDesignThemes.Wpf.DialogHost  	   DialogContent	 � ���#1F1F1F
 � RowDefinitions
 �� $��60 ��� �� $��55 �.+�� $��0��  	MainColor#��[ .+��� $��Center=�$��Center=�$��10 0 0 0q�$��60��$��40(�$
��Bold"�$��Keywords��
������� $  MaterialDesignHeadline3TextBlock#��[ �� $��1��$��15q� �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $��20(�$
��Bold"�$
��OR :��
�������#��[ �� $��10 0 0 0q�$��20(�$��
Spider-man��
�������#��[ �� $��10 0 0 0q�$��20(�$
��Bold"�$��OR��
���  ��#��[ �� $��10 0 0 0q�$��20(�$��
Spider-man��
�������#��[ �� $ 
Horizontal=�$��0 15 0 0q�.+��� $��20(�$
��Bold"�$��AND :��
�������#��[ �� $��10 0 0 0q�$��20(�$��Harisson Ford��
�������#��[ �� $��10 0 0 0q�$��20(�$
��Bold"�$	��AND��
���  ��#��[ �� $��10 0 0 0q�$��20(�$��Tom Holland��
�������#��[ �� $ 
Horizontal=�$��0 15 0 0q�.+��� $��20(�$
��Bold"�$��NOT :��
�������#��[ �� $��10 0 0 0q�$��20(�$
��Bold"�$	��NOT��
���  ��#��[ �� $��10 0 0 0q�$��20(�$��
Spider-man��
�������#��[ �� $ 
Horizontal=�$��0 15 0 0q�.+��� $��20(�$
��Bold"�$	��| :��
�������#��[ �� $��10 0 0 0q�$��20(�$��
Spider-man��
�������#��[ �� $��10 0 0 0q�$��20(�$
��Bold"�$��|��
���  ��#��[ �� $��10 0 0 0q�$��20(�$��NOT Star Wars��
�������#��[ �� $��2��$��center=�$��Center=�$��35��$��OK��
�������#��[ #��[  # MaterialDesignRaisedLightButton#��[    CloseDialogCommand#��Z .��� 
 �� $��60 ��� $
��152* ��� $��50 �.+�� $��0��$	��Top=�$��60��#��[ .+��� -    ��Name$ TitlePageTBK��$
��Left=�$��Center=�$��10 0 0 0q�$��60��$��40(�$
��Bold"�$��Catalog��
�������#��[ �� -    ��Name$ BackButtonBT��$
��Left=�$��Center=�$��Center=�$��Center=�$��10 0 0 0q�$��0q�$��40��$��40��   MaterialDesignFlatDarkButton#��[  � Cursor$
 Hand��$y�Hidden=����� *StopSearchMovieCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�$��40��$��40��
��������� 
�������
������� �� CornerRadius$ 3������ *ActualWidth+ �� ElementName$ SearchBarSP�� �� UpdateSourceTrigger$ PropertyChanged=����� *ActualHeight+$ SearchBarSP��$ PropertyChanged=�._��� -    ��Name$ SearchBarSP��$ 
Horizontal=�$��2 0 0 0q�$	��500��$��40��.+��� -    ��Name$ SearchTypesCB��$��Center=�$��Center=�$��Center=�$��5 0 5 0q�$��75��$��40��$��18(�
���   �$��0q�
���   � �� SelectedIndex$ 0������ *SearchTypes+�� $	��0.5��
���   ��� -    ��Name$ SearchMovieTBX��$��Center=�$��Center=�$��5 0 2 0q�$	��336��$��40��$��18(� �� 
CaretBrush
 �   �
���   �$��0 0 0 0q�$ Arrow��)  #MaterialDesignThemes.Wpf.HintAssist   Hint �� $ SearchTypesCB�� �� Path$ SelectedValue� �� 	Converter# [
 �� $��Center=�$��Center=�$��Center=�$��0q�$��40��$��40��#��[    OpenDialogCommand#��Z $
 Hand��.��  $ InfoOutline=�$��20��$��20��
���   ��� $��Center=�$��Center=�$��Center=�$��0q�$��40��$��40��$
 Hand������ *SearchMovieCommand+����  �� 
TargetType" �� �� BasedOn# [ .���  �� Property � {�  �� Value  �� $
 Text�$ SearchMovieTBX��# [	 .��  $ Magnify=�$��30��$��35��
���   �� $��1��.+��� -   ! ��Name$! MoviesLB��$��Hidden=�" %� VirtualizationMode$" 	Recycling=����� *Movies+���� " ��.���  � ��  �� # �� 
TargetType"# ��.R��� $ ��Name$$ Border��$	��200��$��	0 0 0 0.8q�
�������._��� $ MovieBT��$��0q�$	��200��
������ $��0q����� *ActualWidth+$ MoviesLB��$ PropertyChanged=����� * DataContext.SelectMovieCommand+% �� RelativeSource% �� & �� AncestorType& ListBox���� .��� $	��200������ *ActualWidth+$ MovieBT��$ PropertyChanged=�' � ColumnDefinitions' �� $
��Auto ��� $��1* �.+��� $��0��$��Center=�$��Center=�$��4 0 10 1q�$	��190������ *Poster+# [ ( �� ConverterParameter#( [ �� $��1��$ Vertical=�.+��� $��35(�$
��Bold"�$��NoWrap=�$��WordEllipsis=����� *ActualWidth+$ OverviewTBK��$ PropertyChanged=����� *Title+�� $��3��$ 
Horizontal=�$��0 4 0 0q�.+��� $��20(����� *ReleaseDate+# [   $ Circle=�$��Center=�$��5,3,5,0q�$��0q�$��8��$��8���� $��20(����� *	Runtime+# [   $ Circle=�$��Center=�$��5,3,5,0q�$��0q�$��8��$��8���� $��Center=�$��Center=�$��0 0 4 0q�$��18��#��[  (  "MaterialDesignThemes.Wpf.RatingBar  $��Center=�
)   Min$) 0��
*   Max$* 4��+   
IsReadOnly$
+ True��,   Value, �� *RatingTheMovieDB+# [ - � ToolTip- �� *RatingTheMovieDB+# [   $��Center=�$��5,3,5,0q�$��0q�$��8��$��8������ "  . �� Triggers. �� / �� Binding/ �� *MovieTypes.Count+0 �� Value0 0.a���  � y�$  Hidden=�.���  �@ Kind$  Circle=��� $	��250��$��25������ *
MovieTypes+���� .R��� ���� .R��� $ 
Horizontal=����� " ��.���  � ��  �� "# ��.R��� $��5,0,0,0q�$��25��- �� *Name+���� *Image+�� $ OverviewTBK��$	��120��$��0 4 5 0q�$��17(�$
��Wrap=�$��WordEllipsis=����� *
Overview+1 �� Triggers1 �� $
0 True��/ �� *	Selection+.a��� 2 �� 
TargetName$2 Border��  MainColorSelection#  [  � ��� $��2��#��[ .+��� $
��Left=�$��Center=�$��7 0 0 0q�$��14(�$
��Bold"�
���������`� 3 �� StringFormat$3 
{0} movies��.1��� $ Response.TotalRecords��� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��Center=�$��Center=�$��Center=�$��0q�$��35��$��35������ *!NavigationFirstPageMovieCommand+���� " ��# [ .���  � {�  �� $ Response.PageNumber�# [ . �� / �� *IsLoadMovies+0 True.a���  � {�$  False��.��  $ ChevronDoubleLeft=�$��35��$��35��
��������� $��Center=�$��Center=�$��Center=�$��0q�$��35��$��35������ *$"NavigationPreviousPageMovieCommand+���� " ��# [ .���  � {�  �� $ Response.PageNumber�# [ . �� / �� *IsLoadMovies+0 True.a���  � {�$  False��.��  $ ChevronLeft=�$��35��$��35��
��������� $��Center=�$��7 0 7 0q�$��24(�$
��Bold"�
����������� *Response.PageNumber+$ PropertyChanged=��� $��Center=�$��Center=�$��Center=�$��0q�$��35��$��35������ * NavigationNextPageMovieCommand+���� " ��# [ .���  � {�  `� 4 `� 	Converter#4 [ .1��� $ Response.PageNumber��� $ Response.TotalPages�. �� / �� *IsLoadMovies+0 True.a���  � {�$  False��.��  $ ChevronRight=�$��35��$��35��
��������� $��Center=�$��Center=�$��Center=�$��0q�$��35��$��35��$
 Hand������ * NavigationLastPageMovieCommand+���� " ��# [ .���  � {�  `� #4 [ .1��� $ Response.PageNumber��� $ Response.TotalPages�. �� / �� *IsLoadMovies+0 True.a���  � {�$  False��.��  $ ChevronDoubleRight=�$��35��$��35��
��������� -   $ InformationBT��$��Right=�$��Center=�$��0 0 7 0q�$��0q�$��35��
�������
��� � �
��� � �${�False��#��[ ���� *MoreInformationMovieCommand+.���� $ 
Horizontal=�$��	10 0 12 0q�.+�  $ Information=�$��0 0 5 0q�$��20��$��20��
��������� $��More information�� � -   5  �Name$5 Frame��$��1��6  � NavigationUIVisibility$6 Hidden=�$y�Hidden=�