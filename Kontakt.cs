using Gebal.UITools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ksiazkaTelefoniczna
{
    class Kontakt
    {
        string Nazwa;
        int Numer;

        internal string nazwa { get { return Nazwa; } }
        internal int numer { get { return Numer; } }

        internal Kontakt(string nazwa, int numer)
        {
            Nazwa= nazwa;
            Numer= numer;
        }

    }
    
}
