   M S B A M L   `   `   `  ����V  RClienteProyectoDeMensajeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ClienteProyectoDeMensajeriaClienteProyectoDeMensajeria  5      6    0ClienteProyectoDeMensajeria.MenuPrincipalUsuario   5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ClienteProyectoDeMensajeria     5      
���   �.��5
      � $
��Left=�6   $	��500��6&   $	��Top=�63   $	��850��6K   .+�5   
   �� $
��Left=�6   $	��285��64   $��
210,80,0,0q�6A   $	��Top=�6U   $	��630��6m   ���	#FF616161���	#FFB84141  J� OpacityMask
  �   �.��5      �� $��Editar��6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6&   $
��Left=�6T   $��
570,25,0,0q�6o   $	��Top=�6�   $��50��6�   5      �� 5   
   $��Eliminar��6   $ 15��6$   $
��Left=�6R   $��780,168,-30,0q�6m   $	��Top=�6�   $��50��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��80��6T   $	��Top=�6`   $	��205��6x   ���	#FF4444445      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��80��6T   $	��Top=�6`   $	��630��6x   ���	#FF444444$��	210,0,0,0q�6�   ._�5      9� -   5         9�Name$ expanderOpcionesAmigo��5       9� 
IsExpanded .  $��Opciones��6I   
�������$��	477,0,1,0q�6�   ��6[   Z� .��5      �� .+�5      �� -   5         ��Name$ 
VerImgChat��5      $��Ver imágenes��61   $	��123��6I   6U   5      5      5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��80��6T   $	��Top=�6`   $	��630��6x   ���	#FF444444$��210,370,-40,0q�6�   ._�5      �� -   5         ��Name$ textboxMensaje��5       �� TextWrapping$
 Wrap=�6.   $�� ��6B   .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 15��6J   
�������$��19,19,144,19q�6�   5      �� 5   
   -   5        $ buttonEnviarMensaje��5      $��Enviar��6.   $ 15��6?   $
��Left=�6m   $��725,393,-15,0q�6�   $	��Top=�6�   $��90��6�   6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��405��6T   $	��Top=�6a   $	��205��6y   ���	#FF444444$��0,85,0,0q�6�   ._�5      �� -   5         ��Name$ 	listChats��5      $��9q�6)   ���	#DDFFFFFF6e   5      �� 5   
   -   5        	 ��Name$	 listViewMensajes��5      $
��Left=�6-   $	��240��6H   $��230,100,0,0q�6U   $	��Top=�6j   $	��530��6�   
����������	#DDFFFFFF��5       �� 5!      .R�5"      �� 
 ��Name$
 panelmensajes��6!    �� Orientation$ Vertical=�68   $��Stretch=�6O   $��Stretch=�6k   .+�5#      �� $��Stretch=�6:   $��Bottom=�6X   $��Arial)�6s   $��14(�6�   ��6$   �� *date+6�   �� 5$      $��Stretch=�6O   $��Bottom=�6m   $��Arial)�6�   $��14(�6�   ���	#FF4D0378��6$   �� *UsuarioChat_nombreUsuario+6�   �� 5%      $��Stretch=�6=   $��Bottom=�6[   $��Arial)�6v   $��14(�6�   ��6$   �� *	mensaje+6�   5&      5'      5)      9� 5+   
   -   5        $ expanderMisOpciones��5+       .  $�� ��6C   
�������$��40,5,645,300q�6v   ��6M   Z� .��5,      �� $��	10,0,13,0q�6   .+�5-      �� -   5        $ buttonPerfil��5-      $��Perfil��6/   $ 15��6@   $
��Auto��6n   $��	15,0,10,0q�6�   $	��Top=�6�   �� 5.      -	   5        $ buttonEstados��5.      $��Estados��60   $ 15��6B   $
��Auto��6p   $��	15,2,10,0q�6�   �� 5/      -
   5        $ buttonAgregarAmigo��5/      $��Amigos��65   $ 15��6F   $
��Auto��6t   $��	15,2,10,0q�6�   6�   �� 50      -   5        $ buttonChatGrupal��50      $��Chat grupal��63   $ 15��6I   $
��Auto��6w   $��	15,1,10,0q�6�   �� 51      -   5        $ buttonCerrarSesion��51      $��Cerrar sesión��65   $ 15��6M   $
��Auto��6{   $��	15,1,10,0q�6�   52      53      �� 55   
   -   5         ��Name$ LabelNombreAmigo��55      $��Amigo��6*   $
��Left=�6:   $��
230,14,0,0q�6U   $	��Top=�6i   $	��120��6�   ���	#DDFFFFFF$��16(�6�   �� 56   
   -   5        $ LabelMiNombreDeUsuario��56      $��Yo��60   $
��Left=�6=   $��	10,14,0,0q�6X   $	��Top=�6k   $	��125��6�   ���	#DDFFFFFF$��16(�6�   6�   �� 57   
   -   5        $��Grabar��57      $ 15��6"   $
��Left=�6P   $��303,455,0,0q�6k   $	��Top=�6�   $��90��6�   6�   �� 58   
   -   5        $��Detener��58      $ 15��6#   $
��Left=�6Q   $��441,455,0,0q�6l   $	��Top=�6�   $��90��6�   6�   �� 59   
   -   5        $��
reproducir��59      $ 15��6&   $
��Left=�6T   $��579,455,0,0q�6o   $	��Top=�6�   $��98��6�   6�   �� 5:   
   -   5        $��eliminar��5:      $ 15��6$   $
��Left=�6R   $��725,455,0,0q�6m   $	��Top=�6�   $��90��6�   6�   5;      5<      