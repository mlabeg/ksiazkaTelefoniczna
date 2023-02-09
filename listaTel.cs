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

        protected Menu kontaktow = new Menu();
        Menu szczegolow = new Menu();
        public listaTel()
        {
            szczegolow.Konfiguruj(new string[] { "Zadzwoń", "Wyswietl pelne dane", "Edytuj", "Usun" });
        }
        protected listaTel(List<Kontakt> listaTel) : this()
        {
            kontaktList=listaTel;
        }

       protected void szczegoly(int wybrany,List<Kontakt> lista)
        {
            int wyswietl = szczegolow.Wyswietl(wybrany);
            if (wyswietl >= 0)
            {
                switch (wyswietl)
                {
                    case 0:
                        lista[wybrany].zadzwon();
                        ostatnioWybrane.dodajPolaczenie(lista[wybrany]);
                        break;
                    case 1:
                        lista[wybrany].wyswietl();
                        break;
                    case 2:
                        lista[wybrany].edytujKontakt();
                        uaktualnijZapisaneKontakty();
                        break;
                    case 3:
                         lista.RemoveAt(wybrany);
                        break;
                    default:
                        break;
                }
            }

        }

        public abstract void wyswietlWszystkie();
        protected abstract int menuKontaktow();

        public void uaktualnijZapisaneKontakty()
        {
            LoadAndSafe.safeAll(kontaktList);
        }
    }
}
