using System.Diagnostics;
using Newtonsoft.Json;
namespace ConsoleApp1
{
    internal class res
    {
        public string Name;
        public string svm;
        public string svs;
    }
    internal class ser
    {
        public delegate void Massage();
        static private List<res> vse = new List<res>();
        public static void apchihba(string name, int svm, float svs)
        {
            res p = new res();
            p.Name = name;
            p.svm = $"{svm} - количество символов в минуту";
            p.svs = $"{(double)svs} - количество символов в секунду";
            vse.Add(p);
        }
        public static void serializacia()
        {
            File.WriteAllText("C:\\Users\\user\\Desktop\\Result.json", JsonConvert.SerializeObject(vse));
        }
        public static void nach()
        {
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo a;
            do
            {
                Console.Clear();
                Console.WriteLine("Список лидеров");
                vse.Sort((x, y) =>
                {
                    int ret = String.Compare(y.svm, x.svm);
                    return ret != 0 ? ret :
                    x.svm.CompareTo(y.svm);
                });
                foreach (res res in vse)
                {
                    Console.WriteLine(res.Name);
                    Console.WriteLine(res.svm);
                    Console.WriteLine(res.svs);
                }
                Console.WriteLine();
                Console.WriteLine($"Если хотите добавить себя - нажмите '+'");

                a = Console.ReadKey();
            } while (a.Key != ConsoleKey.Add);
            Console.Clear();
        }
    }

    class Program
    {
        private static int u;
        private static int resi;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ser.nach();
                Console.WriteLine("Введите имя");
                Console.WriteLine();
                string nime = Console.ReadLine();
                Console.Clear();
                potoks(nime);

            }
            void potoks(string n)
            {
                int tm = 0;
                Thread potok2 = new Thread(timer);
                int pos = 0;
                int sop = 0;
                int i = 0;
                string txt = "Боль никто простейшим упрекнуть предаваться справедливости, пользы вами приносило великие некоей: наслаждений. Страдания предпочел, вы постигают нас немалое восхваляющих раз из-за тягостными eсли представление приносило я иной простейшим избегал воспользоваться, наслаждений как кто всю неприятностей возникают. Жизни ни лишь, по, когда презирает, разъясню человек истину стал упрекнуть или боль: то иной, возжаждал — порицающих избегает обстоятельства но. Некое перед, из наслаждение возникает вами наслаждению: если это приносило немалое, говорил некоей такие иной простейшим разъясню никакого. ";
                char[] text = txt.ToCharArray();
                ConsoleKeyInfo ch;
                do
                {
                    Console.Clear();
                    Console.WriteLine(txt);
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Как только будете готовы - нажмите Enter");
                    ch = Console.ReadKey();
                } while (ch.Key != ConsoleKey.Enter);
                Console.Clear();
                Console.WriteLine(txt);
                potok2.Start();
                while (tm != 1)
                {

                    Console.SetCursorPosition(sop, pos);
                    ch = Console.ReadKey(true);
                    if (ch.KeyChar == text[i])
                    {
                        Console.SetCursorPosition(sop, pos);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(ch.KeyChar);
                        sop++;
                        if (sop == 120)
                        {
                            sop = 0;
                            pos++;
                        }
                        i++;
                        if (i == text.Length)
                        {
                            u = 0;
                            ch = Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(sop, pos);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ch.KeyChar);
                    }
                }
                if (i == 0)
                {
                    ser.apchihba(n, 0, 0);
                }
                else
                {
                    ser.apchihba(n, i * (60 / resi), i / resi);
                }
                ser.serializacia();
                void timer()
                {
                    resi = -1;
                    u = 60;
                    do
                    {
                        Console.SetCursorPosition(10, 10);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (u == 60)
                        {

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("1:0");
                            u--;
                            resi++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"0:{u}");
                            u--;
                            resi++;
                        }
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(10, 10);
                        Console.WriteLine("      ");
                    } while (u != 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine($"0:{u}");
                    tm = 1;
                    Console.SetCursorPosition(8, 7);
                    Console.WriteLine("Stop!\n        Нажмите любую клавишу, чтобы продолжить...");
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine((Int32)a.Elapsed.TotalSeconds + 1);
                }
            }
        }
    }
}