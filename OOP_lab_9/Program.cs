using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOP_lab_9
{
    class Program
    {
        public delegate void del(ref string str);
        static void Main(string[] args)
        {
            Application Prog1 = new Application(8);
            Application Prog2 = new Application(18);

            Prog1.Upgrate += ShowMessge;
            Prog1.Work += ShowMessge;

            Prog2.Upgrate += ShowMessge;
            Prog2.Work += ShowMessge;

            Prog1.WorkVersion();
            Prog1.UpgrateVersion(9);
            Prog2.WorkVersion();
            Prog2.UpgrateVersion(16);


            Action<int, int> op;
            op = Add;
            Operation(10, 6, op);
            op = Substract;
            Operation(10, 6, op);
       

            Func<string, string> removeLowerCase = s => s.ToUpper();
            Func<string, string> removeUpperCase = s => s.ToLower();
            Func<string, int, string> removeIndex = (s, i) => s.Remove(i,1);

            string st = "thisString";

            Console.WriteLine(st.Apply(removeLowerCase));
            Console.WriteLine(st.Apply(removeUpperCase));
            Console.WriteLine(st.Apply(removeIndex, 1));


            del d1;
            //Знаки препинания
            string str1 = "Tihonovich, Filipp... Andreevich";

            d1 = delegate (ref string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        str = str.Remove(i, 1);
                    }


                }
                Console.WriteLine(str1);
            };

            d1 += delegate (ref string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',' || str[i] == '.')
                    {
                        str = str.Remove(i, 1);

                        i--;
                    }


                }
                Console.WriteLine(str1);
            };


            d1 += delegate (ref string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str = str.ToUpper();
                }


                Console.WriteLine(str1);
            };

            d1 += (ref string str) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    str = str.Replace(str[i], '6');
                }

                Console.WriteLine(str1);
            };

            d1(ref str1);

    }



        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }

        static void Add(int x1, int x2)
        {
            Console.WriteLine("Сумма чисел: " + (x1 + x2));
        }

        static void Substract(int x1, int x2)
        {
            Console.WriteLine("Разность чисел: " + (x1 - x2));
        }

        private static void ShowMessge(string message)
        {
            Console.WriteLine(message);
        }
    }
}
