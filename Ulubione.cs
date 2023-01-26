using System;
using System.Collections.Generic;
using System.Linq;


namespace ksiazkaTelefoniczna
{
    internal class Ulubione:listaTel
    {
       List<Kontakt> listaUlubione = new List<Kontakt>(5);

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
