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

        public Kontakt() { }    

        internal Kontakt(string nazwa, int numer)
        {
            Nazwa= nazwa;
            Numer= numer;
        }

    }
    class KontaktREMOTE:  Kontakt
    {
        string Imie, Nazwisko;
        string Email;
       internal string imie { get;}
       internal string nazwisko { get { return Nazwisko; } }
       internal string email { get { return Email; } }

    }

    class KontaktPHONE: KontaktREMOTE
    {
        string DrugieImie;
        string Firma;
        DateTime Urodziny;

        internal string drugieImie { get;}
        internal string firma { get;}
        internal string urodziny { get { return Urodziny.ToString(); } }

    }
    
}
