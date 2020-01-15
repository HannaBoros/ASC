using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertorBaza1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Numarul de convertit: ");
            String NumInit = (Console.ReadLine());


           
            int Base1;
            Console.WriteLine();
            Console.WriteLine("Baza initiala:");
            Base1 = Convert.ToInt32(Console.ReadLine());


            ///Citirea bazei finale

            int Base2;
            Console.WriteLine();
            Console.WriteLine("Baza finala:");
            Base2 = Convert.ToInt32(Console.ReadLine());

            ///Verificarea corectitudinii bazei initiale

            if (Base1 < 2 || Base2 > 16)
            {
                Console.WriteLine();
                Console.WriteLine("Baza initiala este incorecta!");
                Console.WriteLine();
                Console.WriteLine("Trebuie sa fie intre 2 si 16");
                Environment.Exit(0);
            }


            ///Verificarea corectitudinii bazei finale

            if (Base2 < 2 || Base2 > 16)
            {
                Console.WriteLine();
                Console.WriteLine("Baza finala este incorecta!");
                Console.WriteLine();
                Console.WriteLine("Trebuie sa fie de la 2 la 16");
                Environment.Exit(0);
            }

            ///Despartire in parte intreaga si fractionara

            String ParteIntreaga;
            String ParteFractionara;
            int index = NumInit.IndexOf('.');
            if (index >= 0)
            {
                ParteIntreaga = NumInit.Substring(0, index);
                ParteFractionara = NumInit.Substring(NumInit.LastIndexOf('.') + 1);
            }
            else
            {
                ParteIntreaga = NumInit;
                ParteFractionara = "0";
            }

            ///Verificarea apartinerii in baza initiala

            bool Verificare = false;
            bool Verificare1 = false;

            List<string> ToCheck = new List<string>();
            for (int i = 0; i < Base1; i++)
            {
                ToCheck.Add(i.ToString());
            }

            if (Base1 <= 10)
            {
                for (int i = 0; i < ParteIntreaga.Length; i++)
                    if (!ToCheck.Contains(ParteIntreaga.Substring(i, 1)))
                    {
                        Verificare = true;
                    }
                for (int i = 0; i < ParteFractionara.Length; i++)
                    if (!ToCheck.Contains(ParteFractionara.Substring(i, 1)))
                    {
                        Verificare1 = true;
                    }
            }
            if (Base1 == 11)
            {
                Verificare = ParteIntreaga.ToCharArray().Any(c => !"0123456789aA".Contains(c));
                Verificare1 = ParteFractionara.ToCharArray().Any(c => !"0123456789aA".Contains(c));
            }
            if (Base1 == 12)
            {
                Verificare = ParteIntreaga.ToCharArray().Any(c => !"0123456789abAB".Contains(c));
                Verificare1 = ParteFractionara.ToCharArray().Any(c => !"0123456789abAB".Contains(c));
            }
            if (Base1 == 13)
            {
                Verificare = ParteIntreaga.ToCharArray().Any(c => !"0123456789abcABC".Contains(c));
                Verificare1 = ParteFractionara.ToCharArray().Any(c => !"0123456789abcABC".Contains(c));
            }
            if (Base1 == 14)
            {
                Verificare = ParteIntreaga.ToCharArray().Any(c => !"0123456789abcdABCD".Contains(c));
                Verificare1 = ParteFractionara.ToCharArray().Any(c => !"0123456789abcdABCD".Contains(c));
            }
            if (Base1 == 15)
            {
                Verificare = ParteIntreaga.ToCharArray().Any(c => !"0123456789abcdeABCDE".Contains(c));
                Verificare1 = ParteFractionara.ToCharArray().Any(c => !"0123456789abcdeABCDE".Contains(c));
            }
            if (Base1 == 16)
            {
                Verificare = ParteIntreaga.ToCharArray().Any(c => !"0123456789abcdefABCDEF".Contains(c));
                Verificare1 = ParteFractionara.ToCharArray().Any(c => !"0123456789abcdefABCDEF".Contains(c));
            }
            if (Verificare == true || Verificare1 == true)
            {
                Console.WriteLine();
                Console.WriteLine("Textul introdus nu apartine bazei initiale");
                Environment.Exit(0);
            }


            ///Conversie in baza 10

            //Conversie parte intreaga in baza 10

            //int Convertit = Convert.ToInt32(ParteIntreaga, Baza1); Converteste in baza 10 doar din bazele 2, 8, 10, 16.

            int Putere = 1;
            int Convertit = 0;
            for (int i = ParteIntreaga.ToCharArray().Length - 1; i >= 0; i--)
            {
                if (ParteIntreaga.ToCharArray()[i] >= '0' && ParteIntreaga.ToCharArray()[i] <= '9')
                    Convertit += ((int)ParteIntreaga.ToCharArray()[i] - '0') * Putere;
                else
                    Convertit += ((int)ParteIntreaga.ToCharArray()[i] - 'A' + 10) * Putere;
                Putere *= Base1;
            }

            //Conversie parte fractionara in baza 10

            int Lungime1 = ParteFractionara.Length;
            double Convertit1 = 0;
            for (int i = ParteFractionara.ToCharArray().Length - 1; i >= 0; i--)
            {
                if (ParteFractionara.ToCharArray()[i] >= '0' && ParteFractionara.ToCharArray()[i] <= '9')
                    Convertit1 += ((int)ParteFractionara.ToCharArray()[i] - '0') * Math.Pow(Base1, -i - 1);
                else
                    Convertit1 += ((int)ParteFractionara.ToCharArray()[i] - 'A' + 10) * Math.Pow(Base1, -i - 1);
            }

            ///Conversie in baza dorita

            //Partea fractionara

            string ParteaFractionara = "";
            while (Convertit1 % 1 != 0)
            {
                Convertit1 = Convertit1 * Base2;
                if ((int)Convertit1 >= 0 && (int)Convertit1 <= 9)
                    ParteaFractionara += (char)((int)Convertit1 + 48);
                else
                    ParteaFractionara += (char)((int)Convertit1 - 10 + 65);
                Convertit1 = Convertit1 - (int)Convertit1;
                if (Convertit1 % 1 != 0)
                {
                    Convertit1 = Convertit1 * Base2;
                    if ((int)Convertit1 >= 0 && (int)Convertit1 <= 9)
                        ParteaFractionara += (char)((int)Convertit1 + 48);
                    else
                        ParteaFractionara += (char)((int)Convertit1 - 10 + 65);
                    Convertit1 = Convertit1 - (int)Convertit1;
                    break;
                }
            }

            //Partea intreaga

            string Invers = "";
            while (Convertit > 0)
            {
                if (Convertit % Base2 >= 0 && Convertit % Base2 <= 9)
                    Invers += (char)(Convertit % Base2 + 48);
                else
                    Invers += (char)(Convertit % Base2 - 10 + 65);
                Convertit /= Base2;
            }
            char[] Temporar1 = Invers.ToCharArray();
            Array.Reverse(Temporar1);
            string ParteaIntreaga = new string(Temporar1);


            Convertit1 = Convertit1 * Base2;
            if ((int)Convertit1 >= 0 && (int)Convertit1 <= 9)
                ParteaFractionara += (char)((int)Convertit1 + 48);
            else
                ParteaFractionara += (char)((int)Convertit1 - 10 + 65);
            Convertit1 = Convertit1 - (int)Convertit1;

            ///Afisarea rezultatului final

            string NumarFinal = "0";
            if (ParteaFractionara != "0")
                NumarFinal = ParteaIntreaga + "." + ParteaFractionara;
            else
                NumarFinal = ParteaIntreaga;


            Console.WriteLine();
            Console.WriteLine("Numarul dupa conversie este: {0}", NumarFinal);
            Console.WriteLine();

        }
    }
}
