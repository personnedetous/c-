using System;

namespace Maturita
{
    class Program
    {
        static void Main(string[] args)
        {
            Maturant Pavel = new Maturant("Pavel", "Dvořák", "oktáva", "m", "čj", "f", "ch");
            Pavel.vypisInfo();

        }

    }


    class Maturant
    {
        string jmeno;
        string prijimeni;
        string trida;
        string predmet1;
        string predmet2;
        string predmet3;
        string predmet4;
        public Maturant(string jmeno, string prijimeni, string trida, string predmet1,
        string predmet2, string predmet3, string predmet4)
        {
            this.jmeno = jmeno;
            this.prijimeni = prijimeni;
            this.trida = trida;
            this.predmet1 = predmet1;
            this.predmet2 = predmet2;
            this.predmet3 = predmet3;
            this.predmet4 = predmet4;
        }

        public void  vypisInfo() //void u metody co nic nevrací, jen vypisuje
        {
            Console.WriteLine("Jmenuji se {0} {1}, chodím do třídy {2} a maturuji z {3}, {4}, {5}, {6}.", jmeno, prijimeni,
            trida, predmet1, predmet2, predmet3, predmet4);
        }
    }
  
}


