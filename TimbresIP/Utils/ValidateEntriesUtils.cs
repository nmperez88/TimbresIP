using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimbresIP.Utils
{
    class ValidateEntriesUtils
    {
        /// <summary>
        /// Expresion regular para formatos Hora
        /// </summary>
        private static string timeRegularExpression = "^([0-9]|0[0-9]|1[0-9]|2[0-3]):([0-9]|[0-5][0-9])$";
        /// <summary>
        /// Expresion regular para Numeros
        /// </summary>
        private static string numbersRegularExpression = "^[0-9]+$";
        /// <summary>
        /// Expresion regular para formatos Letras
        /// </summary>
        private static string lettersRegularExpression = "^[A-Za-z]+$";


        public string TimeRegularExpression { get => timeRegularExpression; set => timeRegularExpression = value; }
        public string NumbersRegularExpression { get => numbersRegularExpression; set => numbersRegularExpression = value; }
        public string LettersRegularExpression { get => lettersRegularExpression; set => lettersRegularExpression = value; }

        /// <summary>
        /// Validar entrada de solo nuemros
        /// </summary>
        /// <param name="e"></param>
        /// <returns>>Bolean</returns>
        public bool validateNumericEntries(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e.Handled;
        }
        /// <summary>
        /// Validar solo letras
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Bolean</returns>
        public bool validateLetterEntries(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e.Handled;
        }

        /// <summary>
        /// Validar direccion IP
        /// </summary>
        /// <param name="sIP"></param>
        /// <returns>Bolean</returns>
        public bool validateIPAddr(string IP)
        {
            try
            { IPAddress ip = IPAddress.Parse(IP); }
            catch
            { return false; }

            return true;
        }
    }
}
