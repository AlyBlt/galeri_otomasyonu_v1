using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriGorevGitHub
{

    internal class Galeri
    {
        // bu sınıf içinde galeri ile ilgili kodlar yazılacak.
        // Galeriye ilişkin herhangi bir verinin değiştirilmesi gerektiğinde ilgili kodlar buraya yazılmalı (kirala, iptal et, ekle vs...)

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return Arabalar.Count;
            }
        }

        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;

                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == "Kirada")
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }

        public int GaleridekiAracSayisi
        {
            get
            {
                return Arabalar.Count(a => a.Durum == "Galeride");
            }
        }

        public int ToplamAracKiralamaSuresi
        {
            get
            {
                int toplam = 0;

                foreach (Araba item in Arabalar)
                {
                    toplam += item.ToplamKiralanmaSuresi;
                }
                return toplam;
            }
        }

        public int ToplamAracKiralamaAdeti
        {
            get
            {
                return Arabalar.Sum(a => a.KiralanmaSayisi);
            }
        }
        public float Ciro;

        public void ArabaKirala(string plaka, int sure)
        {

            Araba a = null;
            if (Arabalar.Any(a => a.Plaka == plaka))
            {
                foreach (Araba item in Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        a = item;
                    }
                }
            }


            if (a != null)
            {
                a.Durum = "Kirada";

                a.KiralamaSureleri.Add(sure);

                Ciro += a.KiralamaBedeli * sure;
            }


        }
        public void ArabaTeslimAl(string plaka)
        {
            // bu plakaya ait arabanın bulunması lazım

            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Galeride";
            }
        }

        public void KiralamaIptal(string plaka)
        {
            // arabayı bul
            Araba a = null;
            if (Arabalar.Any(a => a.Plaka == plaka))
            {
                foreach (Araba item in Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        a = item;
                    }
                }

                if (a != null)
                {
                    Ciro -= a.KiralamaSureleri[a.KiralamaSureleri.Count - 1] * a.KiralamaBedeli;
                    a.KiralamaSureleri.RemoveAt(a.KiralamaSureleri.Count - 1);
                    // a.KiralamaSureleri.RemoveAt
                    // KiralamaSureleri listesindeki en son elemanı listeden çıkar.
                    a.Durum = "Galeride";
                }
            }



        }

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
            this.Arabalar.Add(a);


        }
    }


}
