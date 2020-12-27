using System;

namespace ConsoleApp2
{
    class Program
    {
     
        struct Brim
        {
            public int N, M, Mine, HodN, HodM, hesh, hesh1, RESN, RESM, res;
            public bool deth;
        }

        static void Main(string[] args)
        {
            Brim brim;
            brim.deth = true;
            brim.RESN = 0;
            brim.RESM = 0;
            Console.ForegroundColor = ConsoleColor.Green;// просто цвет для интереса 
            Random random = new Random();
            Console.WriteLine("Введиет длину игрового поля N");
            brim.N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введиет ширену игрового поля M");
            brim.M = Convert.ToInt32(Console.ReadLine());
            string[,] cell = new string[brim.N, brim.M];   //Задание ширены и длины поля
            do
            {
                Console.WriteLine("Выбирите кол во мин:");
                brim.Mine = Convert.ToInt32(Console.ReadLine());
                if (brim.Mine >= (brim.N * brim.M)) { Console.WriteLine(" Кол во мин слишком велико. Игра невозможна!"); }
            } while (brim.Mine >= (brim.N * brim.M));
            //создание игрового поля
            for (int i =0; i< brim.N; i++)
            {
                for(int t=0;t< brim.M; t++)
                {
                    cell[i, t] ="⌂";
                    Console.Write(cell[i, t]);
                }
                Console.WriteLine();
            }
            //растановка мин
            for (int t = 0; t < brim.Mine; t++)
            {
                brim.hesh = random.Next(0, brim.N);
                brim.hesh1 = random.Next(0, brim.M);
                if (cell[brim.hesh, brim.hesh1] != "9")
                {
                    cell[brim.hesh, brim.hesh1] = "9";
                }
                else { t --; }
            }
                //начало (псевдо начало) , а также вывод числа мин рядом с выбором
                while (brim.deth==true)
                {
                Console.WriteLine("Игровое поле начинаеться с координат N->1. M->1");
                Console.WriteLine("Введите ход по N-> поля");
                brim.HodN = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите ход по M-> поля");
                brim.HodM = Convert.ToInt32(Console.ReadLine());
                // проверка на конец игры (проигрыш) 
                if (brim.HodN != 0 && brim.HodM != 0)
                {brim.HodN--;brim.HodM--;}
                if (cell[brim.HodN, brim.HodM] == "9") { Console.WriteLine("Game Over!"); brim.deth = false; Console.ReadKey(); return; }
                if (brim.HodN == 0 && brim.HodM == 0) { brim.RESN = brim.HodN; brim.RESM = brim.HodM; } 
                else if(brim.HodN != 0) { brim.RESN = brim.HodN -1;}
                else if (brim.HodM != 0) { brim.RESM = brim.HodM - 1; }
                // числа мин 
                brim.res = 0;
                for (int k = brim.RESN; k <= brim.HodN +1; k++)
                {
                    for (int t = brim.RESM; t <= brim.HodM +1 ; t++)
                    {
                        if ((brim.RESN >= 0 && brim.RESM >= 0 && brim.HodN >= 0 && brim.HodM >= 0)&& (k <= brim.N -1&& t <= brim.M -1))
                        {
                            if (Math.Abs(brim.HodN - k) <= 1 && Math.Abs(t - brim.HodM) <= 1 && cell[k, t] == "9")
                            {
                                brim.res++;
                            }
                        }
                    }
                }
                cell[brim.HodN, brim.HodM] = Convert.ToString(brim.res);
                //перерисовка полля по причине того, что это  консоль xD
                Console.Clear();
                for (int i = 0; i < brim.N; i++)
                {
                    for (int t = 0; t < brim.M; t++)
                    {
//Console.Write(cell[i, t]);
                        if (cell[i, t] != "9") { Console.Write(cell[i, t]); }
                        else { Console.Write("⌂"); }
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
