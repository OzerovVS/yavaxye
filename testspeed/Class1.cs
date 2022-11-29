using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testspeed
{
    internal class baze
    {
        private static Thread potok1 = new Thread(potok);
        private static Thread potok2 = new Thread(rst);
        private static int vr;
        public static void baza()
        {
            List<testspeed.ttx> tabl = new List<testspeed.ttx>();
            ConsoleKeyInfo bb;
            do
            {
                bb = nachalo(tabl);
            } while (bb.Key != ConsoleKey.Add);
            Console.Clear();
            Console.WriteLine("Введите имя: ");
            string namee = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            potok2.Start();
        }
        static void potok()
        {
            vr = 60;
            Stopwatch a = new Stopwatch();
            for (int i = 60; i >= 0; i -= 1)
            {
                a.Start();
                Console.SetCursorPosition(25, 6);
                Console.WriteLine("    ");
                if (i == 60)
                {
                    Console.SetCursorPosition(25, 6);
                    Console.WriteLine("1:00");
                }
                else
                {
                    Console.SetCursorPosition(25, 6);
                    Console.WriteLine($"0:{i}");
                    if (i == 0)
                    {
                        vr = 0;
                        a.Stop();
                    }
                }
                Thread.Sleep(1000);

            }
            int b = (int)a.Elapsed.TotalSeconds;
            Console.WriteLine(b);
        }
        static ConsoleKeyInfo nachalo(List<testspeed.ttx> tabl)
        {
            Console.Clear();
            Console.WriteLine("Список лидеров");
            foreach (testspeed.ttx ttx in tabl)
            {
                Console.WriteLine();
                Console.WriteLine(ttx);
            }
            Console.WriteLine();
            Console.WriteLine($"Для добавления себя в таблицу нажмите '+'");
            ConsoleKeyInfo Key = Console.ReadKey();
            return Key;
        }
        static void rst()
        {
            string txt = "Дорогие друзья, постоянный количественный рост и сфера нашей активности влечет за собой процесс внедрения и модернизации системы обучения кадров, соответствующей насущным потребностям! Равным образом курс на социально - ориентированный национальный проект требует от нас анализа форм воздействия.Значимость этих проблем настолько очевидна, что начало повседневной работы по формированию позиции играет важную роль в формировани и соответствующих условий активизации!";
            Console.WriteLine(txt);
            Console.WriteLine();
            Console.WriteLine("Когда будете готовы, нажмите Enter");
            ConsoleKeyInfo h = Console.ReadKey();
            char[] text = txt.ToCharArray();
            List<char> nadpis = new List<char>();
            ConsoleKeyInfo simvol;
            int pos = 0;
            int sop = 0;
            if (h.Key == ConsoleKey.Enter)
            {
                potok1.Start();
            }
            do
            {
                for (int i = 0; i < text.Length; i++)
                {
                    
                    simvol = Console.ReadKey();
                    if (simvol.KeyChar == text[i])
                    {
                        nadpis.Add(simvol.KeyChar);
                        Console.SetCursorPosition(sop, pos);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(nadpis[i]);
                        sop++;
                        if (sop == 121)
                        {
                            sop = 1;
                            pos++;
                        }
                    }
                    
                }

            } while(vr != 0);
        }
    }

    internal class ttx
    {
        public string name;
        public string svm;
        public string svs;
    }
}
