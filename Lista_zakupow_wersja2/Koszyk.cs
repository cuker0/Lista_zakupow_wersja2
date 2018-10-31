using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_zakupow_wersja2
{
    class Koszyk : ICeny
    {
        List<PozycjaKoszyka> mojKoszyk;// = new List<Produkt>();

       public Koszyk()
        {
            mojKoszyk = new List<PozycjaKoszyka>();
       }
        
             
        public void WyswietlKoszyk()
        {
            Console.WriteLine("W koszyku mamy:");
            for (int i = 0; i < mojKoszyk.Count; i++)
            {
                Produkt produkt = mojKoszyk[i].Produkt;
                Console.WriteLine($"Kod produktu: {produkt.KodProduktu} Nazwa produktu : {produkt.Nazwa} Opis produktu : {produkt.OpisProduktu} Cena: {produkt.Cena} zł Ilosc sztuk {mojKoszyk[i].Krotnosc} Wartosc w koszyku {mojKoszyk[i].Wartosc} zł ");
            }

        }
        public void UsunZKoszyka(uint _kodUsuwanego)
        {
            bool _sprawdzenieCzyJest = false;
            for (int i = 0; i < mojKoszyk.Count; i++)
            {
                if (mojKoszyk[i].KodProduktu == _kodUsuwanego & mojKoszyk[i].Krotnosc == 1)
                {
                    Console.WriteLine($"Usuwam produkt o kodzie {mojKoszyk[i].KodProduktu}");
                    mojKoszyk.RemoveAt(i);
                    mojKoszyk[i].PoliczNowaWartoscProduktu();
                    _sprawdzenieCzyJest = true;
                }
                
                if (mojKoszyk[i].KodProduktu == _kodUsuwanego & mojKoszyk[i].Krotnosc > 1)
                {
                    Console.WriteLine($"Zmniejszam ilość produktu o kodzie {mojKoszyk[i].KodProduktu}");
                    mojKoszyk[i].ZmniejszIloscProduktu();
                    mojKoszyk[i].PoliczNowaWartoscProduktu();
                    _sprawdzenieCzyJest = true;
                }
                

            }
            if (_sprawdzenieCzyJest == false)
            {
                Console.WriteLine($"W koszyku nie ma produktu o kodzie {_kodUsuwanego}");
            }

        }

        public virtual void PodajCene()
        {
            decimal _sumaWartosci = 0;
            for (int i = 0; i < mojKoszyk.Count; i++)
            {
                _sumaWartosci = _sumaWartosci + mojKoszyk[i].Wartosc;

            }
            Console.WriteLine($"Całkowita wartość koszyka wynosi: {_sumaWartosci}");

        }
        
        public void SortujPoCenach()
        {
            mojKoszyk.Sort();
        }
        public void PodsumujKoszyk()
        {
            SortujPoCenach();
            WyswietlKoszyk();
            PodajCene();

        }
        public void DodajDoKoszyka(Produkt NowyProdukt)
        {
            bool _czyJuzJest = false;
            for (int i = 0; i < mojKoszyk.Count; i++)
            {
                if (mojKoszyk[i].KodProduktu == NowyProdukt.KodProduktu)
                {
                    _czyJuzJest = true;
                    mojKoszyk[i].ZwiekszIloscProduktu();
                    mojKoszyk[i].PoliczNowaWartoscProduktu();
                }
                               
            }
            if (_czyJuzJest == false)
            {
                mojKoszyk.Add(NowyProdukt);
                
            }
            else
            {
                Console.WriteLine("Dodałeś produkt który już jest w koszyku - zwiększam jego ilosc");
            }
        }

        
    }
    }
