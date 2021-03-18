using System;
using System.Text.RegularExpressions;

namespace ClienteProyectoDeMensajeria.ClasesReutilizables
{
    static public class Validacion
    {
        static public bool EsCorreoElectronicoValido(string correo)
        {
            Boolean EsValido;
            string ExpresionRegular = "^[_a-z0-9-]+(.[_a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)(.[a-z]{2,4})$";           
            Match validacion = Regex.Match(correo, ExpresionRegular);
            EsValido = validacion.Success;
            return EsValido;
        }
        static public bool validarLetrasSinAcentosYNumeros(string texto)
        {
            string formato = "[a-zA-Z0-9._]";
            if (Regex.IsMatch(texto, formato))
            {
                if (Regex.Replace(texto, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public bool validarLetrasConAcentosYNumeros(string texto)
        {
            string formato = "[a-zA-ZäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ0-9._]";
            if (Regex.IsMatch(texto, formato))
            {
                if (Regex.Replace(texto, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public bool validarSoloLetrasConAcentos(string texto)
        {
            // string formato = "[a-zA-Z]";
            string formato = @"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ]+";
            if (Regex.IsMatch(texto, formato))
            {
                if (Regex.Replace(texto, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public bool validarSoloNumeros(string entrada)
        {
            string formato = "[0-9]";
            if (Regex.IsMatch(entrada, formato))
            {
                if (Regex.Replace(entrada, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        static public bool validarSoloNumerosConPunto(string entrada)
        {
            string formato = "[0-9.]";
            if (Regex.IsMatch(entrada, formato))
            {
                if (Regex.Replace(entrada, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

