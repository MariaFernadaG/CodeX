   M S B A M L   `   `   `  ����G  CProjetoCodex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjetoCodexProjetoCodex  5   	   "    ProjetoCodex.NotificacaoPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:ProjetoCodex  5   	     � Title$  NotificacaoPage��5	   	   $	��720��6!   $
��1280��6.    � WindowStartupLocation$ CenterScreen=�6Q      MaterialDesignBody#���   6v    � WindowStyle$
 None=�6�    � AllowsTransparency$
 True��6�   ��6;   Z� .��5      #  MaterialDesignThemes.Wpf.Card  ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF240832��6    � Offset$ 1Q�61   5      .��5   
   �  � ColumnDefinitions 5      �� 5      $	��15* �6#   �� 5      $	��34* �6#   �� 5      $	��15* �6#   	 � RowDefinitions	 5      �� 5      $	��47* �6    �� 5      $
��313* �6    .+�5        $��0��6"   $��3��62   .��5      � .+�5         .��5!      �� $��524,22,524,22q�6    $��Logocodex.png��67   
 K� ZIndex$
 1��6N   ��5"      �� 5#      $ 0.5,1&�62   $ 0.5,0&�6C   .��5$   "   � $ Black��6/   � 5%   "   $ 	#FF240832��6/   $ 1Q�6A   5&      5(      5)      5*      � 5,       � Cursor$ IBeam��6   $��3��6"    5-      �� 5.      $
��158* �6'   �� 5/      $��1123* �6'   .+�51      �� -   5        $�� ��51       � ToolTip$ Ir para página inicial.��6$   $
��Left=�6F   $��66,0,0,0q�6a   $��Center=�6s   $��45��6�   $��45��6�   $��2��6�   $
 Hand��6�   ��6�   Z� ��6�   Z� ��52      �� 53       �� ImageSource$ /homeButton.png��6%   55      �� 56      $��Logout��6   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6*   $��949,31,73,31q�6[     MaterialDesignFlatButton#��[ 6q   ���	#FFCCBAEC$ IBeam��6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6�   $��1��6�   '  !MaterialDesignThemes.Wpf.PopupBox  57         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen$ False��6S   $��38��58      $��1054,20,0,24q�6   
�������$��1��6F      PopupContent. 59      �� $��	16 10 0 6q�6!    �� Orientation$ 
Horizontal=�64   $��Center=�6M   .+�5:      �� $��Center=�6$   $��DarkMode��6?   d� 5;      -   5         d�Name$ themeToggle��5<   '   $
 Hand��5;   '   $ Ativar Modo Escuro��65   $��12 0 8 0q�6R    d� 	IsChecked 5<   <   �� *IsDarkTheme+6^   �� 5=      -   5         ��Name$ btn_exit��5=   !   $ Fechar Programa��63   $
��Sair��6M   6\   5>      5?      5@        5B         UniformCornerRadius$ 15Q�6"     MaterialDesignPaper#���  6;   $��1��6n   .��5C      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ DialogHostLeft��5C   D      CloseOnClickAway$
 True��6,   .��5D      �� $
 Hand��6!   $��0 0 0 0q�6/    J� RenderTransformOrigin$ 0.5,0.5&�6@   .+�5E      �� -   5         ��Name$ txtEmail��5E   "    �� TextWrapping$
 Wrap=�64   $	��120��6H   $��50��6T   $��	0 100 0 0q�6`   �� 5F      -   5        $ txtNome��5F   "   $
 Wrap=�63   $	��120��6G   $��50��6S   $��0 10 0 0q�6_   �� 5H      -   5        $��Button��5H   !   $ Perfil��62   $��0 25 0 0q�6C   $��37��6U   $	��129��6a   $ Depth2=�6�   ��6m   Z� ��6�   Z� ��5I      �� 5J   "   $ /PerfilButtonOFF.png��6-   5L      �� 5M      $��Button��6!   $ Notificações��62   $��0 25 0 0q�6I   $��37��6[   $	��129��6g   $ Depth2=�6�   ��6s   Z� ��6�   Z� ��5N      �� 5O   "   $ /NotifButtonON.png��6-   5Q      �� 5R      -   5        $��Button��5R   !   $ Configurações��62   $��0 25 0 0q�6J   $��37��6\   $	��129��6h   $ Depth2=�6�   ��6t   Z� ��6�   Z� ��5S      �� 5T   "   $ /ConfigButtonOFF.png��6-   5V      �� 5W      -	   5        $��Button��5W   !   $ Logout��62   $��0 25 0 0q�6C   $��37��6U   $	��129��6a   $ Depth2=�6�   ��6m   Z� ��6�   Z� ��5X      �� 5Y   "   $ /LogoutButtonOFF.png��6-   5[      5\      5]      5^        5`      $ 15Q�6"   #���  6;   $��1��6n   $��2��6{   .��5a        -
   5        $ DialogHostRight��5a   D   $
 True��6,   .��5b      �� $ IBeam��6!   $��0 0 0 0q�60   $ 0.5,0.5&�6A   .+�5d      �� $��Amigos:��6$   $
��Bold"�63   $��13(�6E   $��	10,10,0,5q�6S   �� 5e      -   5         ��Name$ 
ListAmigos��5e   "   $
��Left=�66   $	��Top=�6Q   $	��300��6i   $	��300��6u   ��5f      �� 5g   "   .R�5h   &   �� .+�5i   *   �� $��15(�6J   $��Product Sans)�6X   $��	10,0,10,0q�6r   $��Center=�6�   ��64   �� *Nome+6�   �� 5j   *   $��13(�6I   $��Italic$�6W   $��	10,0,10,0q�6j   $��Center=�6}   ��64   �� *Bio+6}   5l   '   5m   #   5o      5p      5q      5r        5t      $ 15Q�6"   #���  6;   $��1��6n   $��1��6{   $��5,0,5,0q�6�   .��5u        -   5        $ 
DialogHost��5u   D   $
 True��6,   .��5v      �� $
 Hand��6!   .+�5w      �� $��Notificações:��6$   $
��Bold"�69   $��13(�6K   $��	50,50,0,5q�6Y   5x      �� 5y      -   5        $ ListSNotificacoes��5y   "   $
��Bold"�6>   $��
0,30,0,108q�6P   $	��500��6d   $	��400��6p   $
 Hand��6�   ��5z      �� 5{   "   .R�5|   &   �� .+�5}   *   �� $
 Hand��6N   $��Product Sans)�6\   $��16(�6v   $��0 0 0 10q�6�   ��64   �� *
Mensagem+6�   �� 5   *   $ 
Horizontal=�65   .+�5�   .   �� -   5        $ Aceitar Solicitação��5�   5   $
 Hand��6o   $��20��6�   $��50��6�   ��6}   Z� ��5�   2   �� 5�   6   $ /AceitarBtn.png��6A    j� Stretch$ Uniform=�6_   5�   /   �� 5�   .   -   5        $ Recusar Solicitação��5�   5   $
 Hand��6o   $��20 0 0 0q�6�   $��20��6�   $��50��6�   ��6}   Z� ��5�   2   �� 5�   6   $ /NegarBtn.png��6A   $ Uniform=�6]   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      