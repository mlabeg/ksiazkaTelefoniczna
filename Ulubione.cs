using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ksiazkaTelefoniczna
{
    internal class Ulubione:listaTel
    {
       List<Kontakt> listaUlubione = new List<Kontakt>(5);
        int progUlubione;

        public Ulubione():base()//sprawdzić czy ze względu na to, ze jest to jedna rodzina
                      // nie możesz użyć innego modyfikatra dostępu
        {
            listaUlubione.Capacity = 5;
            prog();
        }
        public void aktualizuj()
        {
            var listaTmp = kontaktList.Where(e => e.licznikPolaczen>0).ToList();
           
            if(listaTmp.Count > 0)
            {
                listaTmp.Sort();
                if(listaTmp.Count > 5) listaTmp.RemoveRange(5,listaTmp.Count-5);
                listaUlubione = listaTmp;
            }
        }

        private void podmien(List<Kontakt> lista)
        {
            for(int i=0;i<lista.Count;i++)
            {
                listaUlubione[i]= lista[i];
            }
        }

        public void dodaj(Kontakt kontakt) {
            if (!listaUlubione.Contains(kontakt))
            {
                if(listaUlubione.Count ==5)
                {
                    if (kontakt.licznikPolaczen >= listaUlubione.Last().licznikPolaczen)
                    {
                        listaUlubione.RemoveAt(4);
                        listaUlubione.Add(kontakt);
                    }
                }
                else
                {
                    listaUlubione.Add(kontakt);
                }
            }
            else
            {
                sortuj();
            }
           
        }
        void sortuj() {
            listaUlubione.Sort();
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

        protected override int menuKontaktow()
        {
            List<string> kontakty = new List<string>();
            for (int i = 0; i < listaUlubione.Count; i++)
            {
                kontakty.Add(listaUlubione[i].nazwa.ToString() + " " + listaUlubione[i].numer.ToString());
            }

            kontaktow.Konfiguruj(kontakty);
            return kontaktow.Wyswietl();
        }

        public override void wyswietlWszystkie()
        {
            if (listaUlubione.Count != 0)
            {
                szczegoly(menuKontaktow(),listaUlubione);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Brak pozycji do wyświetlenia!");
                Console.ReadKey();
            }
        }

        
    }
}
