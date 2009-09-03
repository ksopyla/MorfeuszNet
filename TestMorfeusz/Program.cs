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

            Morfeusz.SetEncoding(MorfeuszEncodings.Cp1250);
            string text = "gminę kliknięciu kliknięcie kilkunastu kierować kierujący licytowanie kierowane kojarzyć kojarzony kojarzenie komplikuje komplikować kompiluje kompilować kompilowany ";

            // string text = "na";
            Console.WriteLine(text);

            InterpMorf[] morph = Morfeusz.Analyse(text);


            foreach (var morf in morph)
            {
                string lema=string.Empty;
                if(morf.Lemma!=null)
                {
                    lema = morf.Lemma;

                    //iso-8859-2  windows-1250
                    //Encoding winEncoding = Encoding.GetEncoding("iso-8859-2");
                    //Encoding utfEncoding = Encoding.Unicode;

                    //// Convert the string into a byte[].
                    //byte[] winBytes = winEncoding.GetBytes(lema);
                    

                    //byte[] utfBytes = Encoding.Convert(winEncoding, utfEncoding, winBytes);


                    //char[] utfChars = new char[utfEncoding.GetCharCount(utfBytes, 0, utfBytes.Length)];
                    //utfEncoding.GetChars(utfBytes, 0, utfBytes.Length, utfChars, 0);
                    //lema = new string(utfChars);
                    
                }
                Console.WriteLine(morf.Word + " => " + lema);
            }

            Console.ReadKey();
        }
    }
}
