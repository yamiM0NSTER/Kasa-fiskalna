using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Aplikacja
    {
        ConsoleKeyInfo klawisz;
        
        Koszyk curKoszyk;

        public Aplikacja()
        {
            curKoszyk = new Koszyk();
        }

        public void WczytajKlawisz()
        {
            Legenda();

            klawisz = Console.ReadKey();
            while(WykonajDzialanie() != 0)
            {
                Legenda();

                klawisz = Console.ReadKey();
            }
        }

        public int WykonajDzialanie()
        {
            switch(klawisz.Key)
            {
                case ConsoleKey.E:
                    {
                        return 0;
                    }
                    break;
                case ConsoleKey.P:
                    {
                        Console.WriteLine();
                        Console.Write("Podaj nazwę produktu: ");
                        string nazwa = Console.ReadLine();
                        Console.Write("Podaj cenę jednostkową produktu: ");
                        double cena = double.Parse( Console.ReadLine() );
                        Console.Write("Podaj ilość produktu: ");
                        int ilosc = int.Parse(Console.ReadLine());

                        curKoszyk.DodajProdukt(nazwa, cena, ilosc);

                        Console.WriteLine();
                        Console.WriteLine("Dodano nowy produkt. Kliknij klawisz aby kontynuować");
                        
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.K:
                    {
                        curKoszyk.SkopiujOstProdukt();

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Skopiowano ostatni produkt. Kliknij klawisz aby kontynuować");

                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.Z:
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Zawartość koszyka:");
                        curKoszyk.WypiszZawartosc();
                        Console.WriteLine();

                        Console.WriteLine("Kliknij klawisz aby kontynuować");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.S:
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        double suma = curKoszyk.WypiszSume();
                        Console.WriteLine("Suma do zapłaty to: " + suma);
                        Console.WriteLine();

                        Console.WriteLine("Kliknij klawisz aby kontynuować");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.X:
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Podaj numer produktu: ");
                        int nr = int.Parse(Console.ReadLine());
                        curKoszyk.Usun(nr);
                        Console.WriteLine();

                        Console.WriteLine("Produkt na pozycji "+nr+ " został usunięty. Kliknij klawisz aby kontynuować");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.W:
                    {
                        string str = 
                                System.DateTime.Now.Day.ToString().PadLeft(2, '0') +
                                System.DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                System.DateTime.Now.Year.ToString().PadLeft(4, '0') +
                                System.DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                                System.DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                                System.DateTime.Now.Second.ToString().PadLeft(2, '0') + ".txt";

                        System.IO.StreamWriter file = new System.IO.StreamWriter(str);
                        curKoszyk.Drukuj(file);
                        file.Close();

                        curKoszyk.Wyczysc();
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Paragon wydrukowany. Kliknij klawisz aby kontynuować");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.N:
                    {
                        curKoszyk.Wyczysc();
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Nowy koszyk utworzony. Kliknij klawisz aby kontynuować");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.T:
                    {
                        curKoszyk.Sortuj();
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Koszyk Posortowany. Kliknij klawisz aby kontynuować");
                        Console.ReadKey();
                    }
                    break;
            }


            return 1;
        }

        private void Legenda()
        {
            Console.Clear();
            Console.WriteLine("Legenda:");
            Console.WriteLine(" P - dodaj produkt do koszyka");
            Console.WriteLine(" K - skopiuj ostatnio wprowadzony produkt");
            Console.WriteLine(" Z - pokaż zawartość koszyka");
            Console.WriteLine(" S - pokaż sumę do zapłaty");
            Console.WriteLine(" T - posortuj produkty alfabetycznie");
            Console.WriteLine(" X - skasuj produkt z listy (musisz znać wcześniej numer na liście)");
            Console.WriteLine(" W - wydrukuj paragon");
            Console.WriteLine(" N - dodaj nowy koszyk");
            Console.WriteLine(" E - zakończ działanie programu");
        }
    }
}
