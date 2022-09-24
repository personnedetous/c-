using System;
using System.Globalization;
using System.Text;

namespace Sibenice
{
    class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // čtení písmena ch jako c a h 

            Console.WriteLine("Vítejte ve hře Šibenice!");
            while (Hra() == ConsoleKey.Enter); // pro opakování smyčky s dalšími slovy, pokračování hry
            Console.ResetColor();
        }

        
        static ConsoleKey Hra()
        {
            string[] slova = System.IO.File.ReadAllLines(@"slova.txt");
            
            ConsoleColor[] colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
            Random randomColorPicker= new Random(); // změna barvy písma při každé hře
            int randomColorIndex= randomColorPicker.Next(0, colors.Length);
            Console.ForegroundColor= colors[randomColorIndex];

            Random random = new Random();
            int zvolenyIndex = random.Next(0, slova.Length); // vybírání pořadí náhodného slova

            string zvoleneSlovo = slova[zvolenyIndex];

            int delkaSlova = zvoleneSlovo.Length;

            Console.WriteLine("Již na Vás čeká slovo: ");


            string odhaleno = new String('*', delkaSlova);
            Console.WriteLine(odhaleno); // zobrazení neuhodnuých znaků jako "*"
            int zivoty = 6;
            Console.WriteLine("Nyní máte {0} životů.", zivoty);

            int pocetSpatnychPokusu = 0;
            while (pocetSpatnychPokusu < zivoty && odhaleno.Contains('*')) 
            {
                Console.Write("Zadejte písmeno pro uhodnutí slova:");
                ConsoleKey uzivatelZadal = Console.ReadKey().Key; // přečtení zadaného znaku

                string pismeno = uzivatelZadal.ToString().ToLower(); 

                Console.WriteLine("\n Zvolili jste " + pismeno);

                if (zvoleneSlovo.Contains(pismeno))
                {
                    for (int i = 0; i < delkaSlova; i++)
                    {
                        int indexPismene = zvoleneSlovo.IndexOf(pismeno, i, delkaSlova - i); // -1
                        if (indexPismene == -1) // výjimka pro indexy překračující hledaný úsek (pokud v úseku písmeno není, smyčka navrátí "-1")
                        {
                            break;
                        }
                        
                        Console.WriteLine("Uhodl jsi písmeno: {0} na pozici {1}.", pismeno, indexPismene);
                        
                        StringBuilder sb = new StringBuilder(odhaleno);// stringbuilder sb vytvoří string, kde postaví na místo * uhodnuté písmeno
                        sb[indexPismene] = Convert.ToChar(pismeno);
                        odhaleno = sb.ToString();
                        Console.WriteLine(odhaleno); 
                        i = indexPismene;
                    }

                }
                else
                {
                    Console.WriteLine("Toto písmeno ve slově bohužel není."); 
                    pocetSpatnychPokusu++; // pokud písmeno ve slově není, ubere se život, opakování smyčky while
                    int zbyvajici = zivoty-pocetSpatnychPokusu;
                    Console.WriteLine("Zbývá vám {0} životů", zbyvajici);
                }
            }
            if (pocetSpatnychPokusu >= zivoty) //pokud již není splněna podmínka smyčky while- vyčerpání životů
            {
                Console.WriteLine("Prohrál jsi. Zkus to znovu.");

            }
            else //pokud již není splněna podmínka smyčky while- uhodnuta všechna písmena
            {
                Console.WriteLine("Vyhrál jsi!");

            }
            Console.WriteLine("Pro další hru stiskněte enter. Pro ukončení mezerník. ");
            return Console.ReadKey().Key; // navrací stisknutou klávesu, metoda Main() poté čerpá z této návratove hodnoty metody Hra()- v Main() je podmínka pro vykování metody Hra(), dokud navrací ConsoleKey.Enter
        }
    }
}