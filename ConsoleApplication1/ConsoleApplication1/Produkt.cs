using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Produkt : ICloneable, IComparable
    {
        protected string nazwa;
        protected double cenaJednostkowa;
        protected int ilosc;

        public Produkt(string nazwa, double cena, int ilosc)
        {
            this.nazwa = nazwa;
            this.cenaJednostkowa = cena;
            this.ilosc = ilosc;
        }

        public object Clone()
        {
            return new Produkt(this.nazwa, this.cenaJednostkowa, this.ilosc);
        }

        public override string ToString()
        {
            return this.nazwa +" " + this.cenaJednostkowa + " " + this.ilosc;
        }

        public double PodajCene()
        {
            return cenaJednostkowa * ilosc;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Produkt prd = obj as Produkt;
            if (prd == null)
                return 1;

            if (this.nazwa == prd.nazwa)
                return -this.cenaJednostkowa.CompareTo(prd.cenaJednostkowa);
            else
                return this.nazwa.CompareTo(prd.nazwa);     
        }

    }
}
