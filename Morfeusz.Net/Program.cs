using System;

namespace Morfeusz.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = Morfeusz.About();
            Console.WriteLine(msg);

            string text = "Widziałem dwóch Żołnierzy nie opodal na placu";

           // string text = "na";
            Console.WriteLine(text);

            InterpMorf[] morph = Morfeusz.Analyse(text);


            foreach (var morf in morph)
            {
                Console.WriteLine(morf.haslo+" => "+morf.forma);
            }

            Console.ReadKey();
        }
    }
}
