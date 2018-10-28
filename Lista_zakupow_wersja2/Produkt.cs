using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_zakupow_wersja2
{
    class Produkt : ICeny, IComparable<Produkt>
    {
        public decimal Cena { get; private set; }
        public uint KodProduktu { get; private set; }
        public string Nazwa { get; private set; }
        public string OpisProduktu { get; private set; }
        public int Krotnosc { get; private set; }
        public decimal Wartosc { get; private set; }
        public Produkt(uint _kodProduktu, string _nazwa, string _opis, decimal _cena)
        {
            KodProduktu = _kodProduktu;
            Nazwa = _nazwa;
            Cena = _cena;
            OpisProduktu = _opis;
            Krotnosc = 1;
            Wartosc = Krotnosc * Cena;    
        }
        public void ZwiekszIloscProduktu()
        {
            Krotnosc = Krotnosc + 1;
        }
        public void ZmniejszIloscProduktu()
        {
            Krotnosc = Krotnosc - 1;
        }
        public void PoliczNowaWartoscProduktu()
        {
            Wartosc = Krotnosc * Cena;
        }
        public virtual void PodajCene()
        {
            Console.WriteLine($"Cena produktu wynosi: {Cena}zl");
        }

        public int CompareTo(Produkt other)
        {
            if (Cena == other.Cena)
            {
                return 0;
            }
            else if (Cena > other.Cena)
            {
                return 1;
            }
            return -1;
        }
    }
}
