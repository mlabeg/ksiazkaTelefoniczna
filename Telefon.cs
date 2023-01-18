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
        protected Telefon(){
            KsiazkaTelefoniczna ksiazkaTelefoniczna=new KsiazkaTelefoniczna();
        }
    }
    
    class Siajomi:Telefon{
           Siajomi(): base(){
               this.Producent="Siajomi";   
           }
        Siajomi(string nazwa):this(){
            this.Model=nazwa;
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
