   M S B A M L   `   `   `  ����V  RClienteProyectoDeMensajeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ClienteProyectoDeMensajeriaClienteProyectoDeMensajeria  5   	   0    *ClienteProyectoDeMensajeria.RegistroCuenta   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ClienteProyectoDeMensajeria     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   .��5
      � .+�5   
   �� -   5          ��Name$  textBoxCorreo��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 15��6)   $
��Left=�6c   $��29��6~   $��610,149,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��184��6�   
�������6�   �� 5   
   -   5        $  textBoxUsuario��5      $ 15��6*   $
��Left=�6d   $��29��6   $��320,149,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��184��6�   
�������6�   G� 5   
   -   5         G�Name$ textBoxContrasena��5      $ 15��61   $
��Left=�6k   $��29��6�   $��612,296,0,0q�6�   $	��Top=�6�   $	��184��6�   
�������6�   �� 5   
   $��Correo electrónico��6   $
��Left=�6-   $��610,115,0,0q�6H   $	��Top=�6]   ���	#DDFFFFFF$��16(�6�   �� 5   
   $��Nombre de Usuario��6   $
��Left=�6,   $��320,113,0,0q�6G   $	��Top=�6\   ���	#DDFFFFFF$��16(�6�   �� 5   
   $��Contraseña��6   $
��Left=�6%   $��612,260,0,0q�6@   $	��Top=�6U   ���	#DDFFFFFF$��16(�6�   ��6m   Z� 6�   �� 5   
   -   5         ��Name$ buttonRegistrar��5      $��	Registrar��6*   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6>   $
��Left=�6l   $��365,364,0,0q�6�   $	��Top=�6�   $	��142��6�   $��16(�6�   6�   �� 5   
   -   5        $ buttonCanelar��5      $��Cancelar��6(   $ 15��6;   $
��Left=�6i   $��365,414,0,0q�6�   $	��Top=�6�   $	��142��6�   $��16(�6�   
����������	#FF673AB7$��Normal"�6�   6	  �� 5   
   $��Registrar Cuenta��6   $
��Left=�6+   $	��Top=�6F   ���	#DDFFFFFF$��36(�6u   $
��Bold"�6�   $	��850��6�   $��Center=�6�   �� 5   
   -   5        $  textBoxTelefono��5      $ 15��6+   $
��Left=�6e   $��29��6�   $��322,296,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��184��6�   
�������6�   �� 5   
   $��Telefono��6   $
��Left=�6#   $��322,260,0,0q�6>   $	��Top=�6S   ���	#DDFFFFFF$��16(�6�   ��6k   Z� 6�   �� 5   
   $��Género��6   $
��Left=�6!   $��
42,268,0,0q�6<   $	��Top=�6P   ���	#DDFFFFFF$��16(�6�   ��6h   Z� 6�   �� 5   
   -   5         ��Name$ comboBoxGenero��5         TextBoxViewMargin$ 2q�6,   $
��Left=�6a   $��
42,297,0,0q�6|   $	��Top=�6�   $	��140��6�   
������� �� Text$ Seleccione un género��6�   	 �� 
IsEditable	 . 
 �� 
IsReadOnly
 . $��28��6Y  �� 5   
   -   5         ��Name$ imagenPerfil��5      $��Stretch=�6'   $	��100��6E   $��42,78,708,0q�6R   $	��Top=�6g   $	��100��6   5      �� 5   
   -	   5        $ buttonCargarFoto��5      $��Cargar foto��6+   $ 15��6A   $
��Left=�6o   $��
40,193,0,0q�6�   $	��Top=�6�   $	��112��6�   $��16(�6�   
����������	#FF673AB7$��Normal"�6�   6  5      5      