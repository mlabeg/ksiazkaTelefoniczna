using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
    abstract class Telefon
    {
        string Producent;
        string Model;
        Telefon(){
            KsiazkaTelefoniczna ksiazkaTelefoniczna=new KsiazkaTelefoniczna();
        }
    }
    
    class Xiaomi:Telefon{
           Xiaomi(){
               base();
               this.Producent="Xiaomi";   
           }
        Xiaomi(string nazwa){
            Xiaomi();
            this.Model=nazwa;
        }
    }
}
