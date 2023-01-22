using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
    internal class Polaczenie
    {
        Kontakt kontakt;
        DateTime data;
        public Kontakt Kontakt { get { return kontakt; } }

        public string KontaktNazwa { get { return this.kontakt.nazwa; } }
        public string KontaktNumer { get { return this.kontakt.numer; } }
        public string date2str()
        {
            return data.ToString();
        }

        public Polaczenie(Kontakt kontakt)
        {
            this.kontakt = kontakt;
            this.data = DateTime.Now;
        }
        public void wyswietlPolaczenie()
        {
            Console.WriteLine(kontakt.nazwa + kontakt.numer + 
                data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":"+data.Minute);
        }
    }
}
