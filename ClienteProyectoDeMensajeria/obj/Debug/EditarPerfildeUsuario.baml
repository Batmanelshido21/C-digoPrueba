   M S B A M L   `   `   `  ����V  RClienteProyectoDeMensajeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ClienteProyectoDeMensajeriaClienteProyectoDeMensajeria  5      7    1ClienteProyectoDeMensajeria.EditarPerfildeUsuario   5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ClienteProyectoDeMensajeria     5      .��5
      � .+�5   
   �� -   5          ��Name$  buttonGuardar��5      $��Guardar��6(   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6:   $
��Left=�6h   $��325,345,0,0q�6�   $	��Top=�6�   $	��142��6�   $��16(�6�   6�   �� 5   
   -   5        $  buttonCancelar��5      $��Cancelar��6)   $ 15��6<   $
��Left=�6j   $��325,395,0,0q�6�   $	��Top=�6�   $	��142��6�   $��16(�6�   
����������	#FF673AB76�   �� 5   
   $��	Mi Perfil��6   $
��Left=�6$   $��
365,10,0,0q�6?   $	��Top=�6S   ���	#DDFFFFFF$��16(�6�   �� 5   
   -   5         ��Name$ textBoxCorreo��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 15��6)   $
��Left=�6c   $��29��6~   $��593,121,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��184��6�   
�������6�   �� 5   
   -   5        $ textBoxUsuario��5      $ 15��6*   $
��Left=�6d   $��29��6   $��303,121,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��184��6�   
�������6�   G� 5   
   -   5         G�Name$ textBoxContrasena��5      $ 15��61   $
��Left=�6k   $��29��6�   $��595,268,0,0q�6�   $	��Top=�6�   $	��184��6�   
�������6�   �� 5   
   $��Correo electrónico��6   $
��Left=�6-   $��
593,87,0,0q�6H   $	��Top=�6\   ���	#DDFFFFFF$��16(�6�   �� 5   
   $��Nombre de Usuario��6   $
��Left=�6,   $��
303,85,0,0q�6G   $	��Top=�6[   ���	#DDFFFFFF$��16(�6�   �� 5   
   $��Contraseña��6   $
��Left=�6%   $��595,232,0,0q�6@   $	��Top=�6U   ���	#DDFFFFFF$��16(�6�   ��6m   Z� 6�   �� 5   
   -   5        $ textBoxTelefono��5      $ 15��6+   $
��Left=�6e   $��29��6�   $��305,268,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��184��6�   
�������6�   �� 5   
   $��Telefono��6   $
��Left=�6#   $��305,232,0,0q�6>   $	��Top=�6S   ���	#DDFFFFFF$��16(�6�   ��6k   Z� 6�   �� 5   
   $��Género��6   $
��Left=�6!   $��
25,240,0,0q�6<   $	��Top=�6P   ���	#DDFFFFFF$��16(�6�   ��6h   Z� 6�   �� 5   
   -   5         ��Name$ comboBoxGenero��5         TextBoxViewMargin$ 2q�6,   $
��Left=�6a   $��
25,269,0,0q�6|   $	��Top=�6�   $	��140��6�   
������� �� Text$ Seleccione un género��6�   	 �� 
IsEditable	 . 
 �� 
IsReadOnly
 . $��28��6Y  �� 5   
   -   5         ��Name$ imagenPerfil��5      $��Stretch=�6'   $	��110��6E   $��50,40,635,0q�6R   $	��Top=�6g   $	��115��6   $
��Fill=�6�   5      �� 5   
   -	   5        $  buttonCargarFoto��5      $��Cargar foto��6+   $ 15��6A   $
��Left=�6o   $��
50,155,0,0q�6�   $	��Top=�6�   $	��112��6�   $��16(�6�   
����������	#FF673AB7$��Normal"�6�   6  5      5      