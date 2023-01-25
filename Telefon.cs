using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
     abstract class Telefon
    {
        protected string Producent;
        protected string Model;
        protected KsiazkaTelefoniczna ksiazkaTel;
        public Telefon(){//KOMPOZYCJA razem z linią 31
            KsiazkaTelefoniczna ksiazkaTel=new KsiazkaTelefoniczna();
        }
    }
    
    class Siajomi:Telefon{
           Siajomi(): base(){
               this.Producent="Siajomi";   
           }
        Siajomi(string nazwa):this(){
            this.Model=nazwa;
        }

        public void wyswietlDaneKontaktu(Kontakt kontakt)//ZALEŻNOŚĆ
        {
            Console.WriteLine($"Kontakt: {kontakt.nazwa}, {kontakt.numer}");
        }

        private void ResetDoUstawienFabrycznych()//KOMPOZYCJA razem z linią 14
        {
            ksiazkaTel = null;
        }
        void dodanoKontakt()//ASOCJACJA
        {
            ksiazkaTel.liczbaKontaktów++;
        }
    }

    class Epyl:Telefon
    {
        Epyl() : base()
        {
            this.Producent = "Epyl";
        }
        Epyl(string nazwa) : this()
        {
            this.Model=nazwa;
        }
    }
}
