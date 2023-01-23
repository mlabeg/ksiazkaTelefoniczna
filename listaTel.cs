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
        protected List<Kontakt> kontaktList = new List<Kontakt>();

        private int menuKontaktow()
        //nie ruszaj tej metody, jest używana równie przez metodę usun()
        //zastanawiam się czy jest możliwość, żeby menuKkontaktow() wywoływać tylko raz, nie za każdym razem jak wywołamy jakąś nadrzędną fukcję
        //żeby była to "właściwość klasy", a nie danej funkcji //<- właśnie wydaje mi się,
        ////że nie, bo o to chodzi w menu, że trzeba je wywołać za każdym razem
        {
            List<string> kontakty = new List<string>();
            for (int i = 0; i < kontaktList.Count; i++)
            {
                kontakty.Add(kontaktList[i].nazwa.ToString() + " " + kontaktList[i].numer.ToString());

            }

            Menu kontaktow = new Menu();
            kontaktow.Konfiguruj(kontakty);
            return kontaktow.Wyswietl();
        }

        private void szczegoly(int wybrany)
        {
            Menu szczegoly = new Menu();

            szczegoly.Konfiguruj(new string[] { "Zadzwoń", "Wyswietl pelne dane", "Edytuj", "Usun" });

            int wyswietl = szczegoly.Wyswietl(wybrany);
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
    }
}
