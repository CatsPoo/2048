   M S B A M L   `   `   `  ����   2048    _2048.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  2048 by Ron Gorlik�� � Icon$/ )/2048;component/Images/Apps-2048-icon.png�� � SizeToContent$ WidthAndHeight=�.��� $	��458��$	��359�� � DataContext ��  � ColumnDefinitions �� $
��321* ��� $	��36* ��� $��2* � � RowDefinitions �� $��45 ��� $	��342 ��� $	��26* �.+��� -   $��image17��$��2��$	��148��$
��Left=�$��-4,2,0,0q�$
��Fill=�$	��Top=�$	��367��$/��)/2048;component/Images/Screenshot_jjj.png��$��3���� -   $��image1��$��1��$��57��$
��Left=�$��	32,83,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image2��$��1��$��57��$
��Left=�$��
103,83,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image3��$��1��$��57��$
��Left=�$��
174,83,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image4��$��1��$��57��$
��Left=�$��
245,83,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image5��$��1��$��57��$
��Left=�$��
32,146,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image6��$��1��$��57��$
��Left=�$��103,146,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -	   $��image7��$��1��$��57��$
��Left=�$��174,146,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -
   $��image8��$��1��$��57��$
��Left=�$��245,146,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image9��$��1��$��57��$
��Left=�$��
32,209,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image10��$��1��$��57��$
��Left=�$��103,209,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image11��$��1��$��57��$
��Left=�$��174,209,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image12��$��1��$��57��$
��Left=�$��245,209,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image13��$��1��$��57��$
��Left=�$��
32,272,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image14��$��1��$��57��$
��Left=�$��103,272,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image15��$��1��$��57��$
��Left=�$��174,272,0,0q�$/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��image16��$��1��$��57��$
��Left=�$��245,272,0,0q� J� SnapsToDevicePixels . $/��)/2048;component/Images/2048-highscore.jpg��$
��Fill=�$	��Top=�$��65���� -   $��Up��$��^��$��1��$��23��$
��Left=�$��133,335,0,0q�$	��Top=�$��75��$��2���� -   $��Right��$��>��$��2��$��23��$
��Left=�$��
214,12,0,0q�$	��Top=�$��75���� -   $
��left��$��<��$��2��$��23��$
��Left=�$��	52,12,0,0q�$	��Top=�$��75���� -   $
��Down��$��v��$��2��$��23��$
��Left=�$��
133,32,0,0q�$	��Top=�$��75���� -   $��image18��$��1��$	��246��$
��Left=�$��	32,83,0,0q�$$��/2048;component/Images/Win.png��$
��Fill=�$	��Top=�$y�Hidden=�$	��278���� -   $��image19��$��1��$	��246��$
��Left=�$��	32,83,0,0q�$+��%/2048;component/Images/Untitled-1.png��$
��Fill=�$	��Top=�$y�Hidden=�$	��278���� -   $��button1��$��Random block��$��8(�$��2��$��2��$��25��$
��Left=�$��
295,30,0,0q�$	��Top=�$��60���� -   $��Score1��$��20(����	#FFC44EB9$��41��$
��Left=�$��
144,36,0,0q�$	��Top=�$��95��$��1���� -   $��image20��$��55��$
��Left=�$��
151,43,0,0q�$
��Fill=�$	��Top=�$��88��$-��'/2048;component/Images/Screenshot_k.png��$��2���� -   $��image21��$��55��$
��Left=�$��
245,43,0,0q�$
��Fill=�$	��Top=�$��88��$��2��$.��(/2048;component/Images/Screenshot_jm.png��$��2���� -   $��	HighScore��$��Adobe Heiti Std)�$��Normal"�$��28��$��Center=�$��250,12,32,302q�$��Center=�$��75�����	#FFE8E8E8$��0��$��2��$��Center=�$��1���� -   $��Score2��$��28��$��148,12,81,0q�$	��Top=�$��Normal"�$��Adobe Heiti Std)����	#FFE8E8E8 J� 	AllowDrop .  $��Center=�$��0��$��92��$��Center=�$��1���� -   $
��Mul1��$��X��$��Adobe Heiti Std)�$��Normal"�$��28��$��Right=�$��	0,15,69,0q�$	��Top=�$��38�����	#FFE8E8E8$��1���� -    $��label2��$��Not conected to Database��$��2��$��23��$
��Left=�$��	-6,54,0,0q�$	��Top=�$	��325��$��8(�o� -!   $��menu1��$��23��$
��Left=�$	��Top=�$	��357��$��2��$��0,3,0,0q�.@�m� $
��File��|�.  .@�m� $��New Game��m� $
��Exit��m� -"   $��High Scores��|�.  