using Gebal.UITools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
    internal abstract class listaTel
    {
        protected static List<Kontakt> kontaktList = new List<Kontakt>();
        protected static OstatnioWybrane ostatnioWybrane = new OstatnioWybrane();

        protected static Ulubione ulubione = new Ulubione();

        Menu kontaktow = new Menu();
        Menu szczegolow = new Menu();
        public listaTel()
        {
            szczegolow.Konfiguruj(new string[] { "Zadzwoń", "Wyswietl pelne dane", "Edytuj", "Usun" });
        }
        
        protected int menuKontaktow()
        {
            List<string> kontakty = new List<string>();
            for (int i = 0; i < kontaktList.Count; i++)
            {
                kontakty.Add(kontaktList[i].nazwa.ToString() + " " + kontaktList[i].numer.ToString());
            }

            kontaktow.Konfiguruj(kontakty);
            return kontaktow.Wyswietl();
        }

        protected void szczegoly(int wybrany)
        {
            int wyswietl = szczegolow.Wyswietl(wybrany);
            if (wyswietl >= 0)
            {
                switch (wyswietl)
                {
                    case 0:
                        //zadzwon(kontaktList[wybrany]);
                        kontaktList[wybrany].zadzwon();
                        ostatnioWybrane.dodajPolaczenie(kontaktList[wybrany]);
                        break;
                    case 1:
                        kontaktList[wybrany].wyswietl();
                        break;
                    case 2:
                        kontaktList[wybrany].edytujKontakt();
                        break;
                    case 3:
                        kontaktList.RemoveAt(wybrany);
                        break;
                    default:
                        break;
                }
            }

        }
        public abstract void wyswietlWszystkie();
    }
}
