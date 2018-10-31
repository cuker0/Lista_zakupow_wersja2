using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_zakupow_wersja2
{
    class PozycjaKoszyka 
    {
        public Produkt Produkt { get; } // ustawianie tylko z konstruktora
        public uint Krotnosc { get; private set; }
        public decimal Wartosc { get { return Krotnosc * Produkt.Cena; ; } }

        public PozycjaKoszyka(Produkt produkt)
        {
            Produkt = produkt;
            Krotnosc = 1;
        }

        public void ZwiekszKrotnosc()
        {
            Krotnosc++;
        }

        public void ZmniejszKrotnosc()
        {
            Krotnosc--;
        }

        /*
        public void PodajCene()
        {
            decimal wartosc = Krotnosc * Produkt.Cena;
            Console.WriteLine($"Wartosc pozycji w koszyku wynosi: {wartosc}");
        }
        */
    }
}
