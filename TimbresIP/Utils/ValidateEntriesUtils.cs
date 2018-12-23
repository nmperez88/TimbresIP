using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimbresIP.Utils
{
    class ValidateEntriesUtils
    {
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

        public bool validateEnteredText(string Text)
        {
            int ValorNumerico = 0;

            if (int.TryParse(Text, out ValorNumerico))
            {
                return true;
            }
            return false;
        }

        //public bool validateEnteredHour(string text)
        //{
        //    if ()
        //    {

        //    }
        //}
    }
}
