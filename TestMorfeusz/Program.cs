using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MorfeuszNet;

namespace TestMorfeusz
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = Morfeusz.About();
            Console.WriteLine(msg);

            string text = "Widziałem dwóch Żołnierzy na placu przy dużym banku";

            // string text = "na";
            Console.WriteLine(text);

            InterpMorf[] morph = Morfeusz.Analyse(text);


            foreach (var morf in morph)
            {
                Console.WriteLine(morf.Word + " => " + morf.Lemma);
            }

            Console.ReadKey();
        }
    }
}
