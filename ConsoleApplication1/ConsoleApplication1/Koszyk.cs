using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Koszyk
    {
        public List<Produkt> lstProdukty;
        Produkt lstPrd;

        public Koszyk()
        {
            lstProdukty = new List<Produkt>();
            lstPrd = null;
        }

        public void DodajProdukt(string nazwa, double cena, int ilosc)
        {
            Produkt prd = new Produkt(nazwa, cena, ilosc);
            lstProdukty.Add(prd);
            lstPrd = prd;
        }

        public void SkopiujOstProdukt()
        {
            Produkt prd = lstPrd.Clone() as Produkt;
            lstProdukty.Add(prd);
        }

        public void WypiszZawartosc()
        {
            for (int i = 0; i < lstProdukty.Count; i++ )
                Console.WriteLine(lstProdukty[i].ToString());
        }

        public double WypiszSume()
        {
            double suma = 0;
            for (int i = 0; i < lstProdukty.Count; i++)
                suma += lstProdukty[i].PodajCene();

            return suma;
        }

        public void Usun(int nr)
        {
            lstProdukty.RemoveAt(nr);
        }

        public void Wyczysc()
        {
            lstProdukty.Clear();
            lstPrd = null;
        }

        public void Drukuj(System.IO.StreamWriter file)
        {
            for (int i = 0; i < lstProdukty.Count; i++)
            {
                file.WriteLine(lstProdukty[i].ToString());
            }
            file.WriteLine("Suma do zapłaty to: " + WypiszSume());
        }

        public void Sortuj()
        {
            lstProdukty.Sort();
        }
    }
}
