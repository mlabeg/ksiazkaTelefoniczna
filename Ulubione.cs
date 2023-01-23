using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
    internal class Ulubione:listaTel
    {
        int progUlubione;

        public Ulubione()//sprawdzić czy ze względu na to, ze jest to jedna rodzina
                      // nie możesz użyć innego modyfikatra dostępu
        {
            kontaktList.Capacity = 5;
        }
        public void dodaj(Kontakt kontakt) {
            if (!kontaktList.Contains(kontakt))
            {
                if(kontaktList.Count < 5)
                {
                    kontaktList.Add(kontakt);
                }
                else
                {
                    prog();//pomyśl czy na pewno za każdym razem trzeba sprawdzać
                        //czy trzeba to robić akurat tutaj, a nie gdzieś indziej
                    if (kontakt.licznikPolaczen >= progUlubione)
                    {
                        kontaktList.RemoveAt(4);
                        kontaktList.Add(kontakt);
                    }
                }
            }
            else
            {
                sortuj();
            }
           
        }
        void sortuj() { 
            
        }//tak to napisać, żeby na początku były kontakty o najmniejszym licznikPolaczen
         //zwrócić uwagę na to, żeby nie zamieniał ze sobą miejsacmi kontaktów o takim samym licznikPolaczen

        void prog()
        {
            foreach(var p in kontaktList)
            {
                if (p.licznikPolaczen > progUlubione)
                {
                    progUlubione = p.licznikPolaczen;
                }
            }
        }

    }
}
