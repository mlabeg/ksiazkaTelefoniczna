using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ksiazkaTelefoniczna
{
    static class LoadAndSafe
    {
        public static void safe(Kontakt kontakt)
        {
            string kontaktSerialize = JsonConvert.SerializeObject(kontakt);
            File.WriteAllText($@"C:\Users\enix\source\repos\ksiazkaTelefoniczna\kontaktyJson\{kontakt.nazwa}Serialized.json", kontaktSerialize);
        }

        public static void safeAll(List<Kontakt> kontakts)
        {
            string ksiazkaTelCala=JsonConvert.SerializeObject(kontakts);
            File.WriteAllText(@"C:\Users\enix\source\repos\ksiazkaTelefoniczna\kontaktyJson\KsiazkaTelSerialized.json", ksiazkaTelCala);
            //WriteAllText chamsko nadpisuje istniejący plik
        }

        public static List<Kontakt> loadAll()
        {
            if (File.Exists(@"C:\Users\enix\source\repos\ksiazkaTelefoniczna\kontaktyJson\KsiazkaTelSerialized.json"))
            {
                string ksiazkaTelCala = File.ReadAllText(@"C:\Users\enix\source\repos\ksiazkaTelefoniczna\kontaktyJson\KsiazkaTelSerialized.json");
                List<Kontakt> kontakts = JsonConvert.DeserializeObject<List<Kontakt>>(ksiazkaTelCala);
                return kontakts;
            }
            return new List<Kontakt>();
        }

    }
}
