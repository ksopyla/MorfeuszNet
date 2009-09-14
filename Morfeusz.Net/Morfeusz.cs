using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MorfeuszNet
{
    public enum MorfeuszOptions
    {
        Encoding = 1
    }

    public enum MorfeuszEncodings
    {
        Utf8 = 8,
        Iso88592 = 88592,
        Cp1250 = 1250,
        Cp852 = 852
    }


    /// <summary>
    /// Klasa opakowująca funkcje z orginalnej dll'ki 
    /// Analizatora morfologicznego Morfeusz SIAT morfeusz.dll
    /// http://nlp.ipipan.waw.pl/~wolinski/morfeusz/
    /// (Morfeusz SIAT wersja 0.66 2006/06/04 Copyright (c) 2006 by Marcin Woliński Dane lingwistyczne 2008/02/20 Copyright (c) 2008 by Zygmunt Saloni & Marcin Woliński)
    /// Autor tego wrappera: Krzysztof Sopyła(ksopyla@uwm.edu.pl)
    /// </summary>
    public class Morfeusz
    {
        /// <summary>
        /// Zwraca informacje o autorach
        /// </summary>
        /// <returns></returns>
        [DllImport("morfeusz.dll", SetLastError = true, EntryPoint = "morfeusz_about")]
        public static extern string About();

        [DllImport("morfeusz.dll", SetLastError = true,  EntryPoint = "morfeusz_set_option")]
        public static extern int MorfeuszSetOption(int option, int value);

        public static int SetEncoding(MorfeuszEncodings encoding)
        {
            return MorfeuszSetOption((int) MorfeuszOptions.Encoding, (int) encoding);
        }


        /* Z pliku morfeusz.h
         * Analyse a piece of text:

    'tekst' - the string to be analysed.  It should neither start nor
    end  within a  word.   Morfeusz has  limited  space for  results.
    Don't pass  to this function more  than a typical  paragraph at a
    time.  The best  strategy is probably to pass  to Morfeusz either
    separate words or lines of text.

    RETURNS a  table of  InterpMorf structures representing  edges of
    the  resulting  graph.   The   result  remains  valid  till  next
    invocation of morfeusz_analyse().  The function does not allocate
    any memory, the space is reused on subsequent invocations.

    The  starting node  of resulting  graph has  value of  0  on each
    invocation.  The end of results is marked with a sentinel element
    having the value -1 in the 'p' field.  If a segment is unknown to
    Morfeusz,  the  'haslo'  and  'interp' fields  in  the  resulting
    structure are NULL.
 */
        /// <summary>
        /// Dokonuje analizy
        /// </summary>
        /// <param name="tekst"></param>
        /// <returns></returns>
        [DllImport("morfeusz.dll", SetLastError = true, EntryPoint = "morfeusz_analyse")]
        static extern IntPtr MorfAnalyse(string tekst);


        /// <summary>
        /// Dokonuje analizy tekstu i zwraca tablicę struktur
        /// </summary>
        /// <param name="text"></param>
        /// <returns>InterpMorf array</returns>
        public static InterpMorf[] Analyse(string text)
        {
            //iso-8859-2  windows-1250
            //Encoding winEncoding = Encoding.GetEncoding("windows-1250");
            //Encoding utfEncoding = Encoding.Unicode;


            //byte[] utfBytes = utfEncoding.GetBytes(text);
            ////Encoding.Convert(winEncoding, utfEncoding, winBytes);

            //byte[] winBytes = Encoding.Convert(utfEncoding, winEncoding, utfBytes);


            //char[] winChars = new char[winEncoding.GetCharCount(winBytes, 0, winBytes.Length)];
            //winEncoding.GetChars(winBytes, 0, winBytes.Length, winChars, 0);
            //text = new string(winChars);


            

            SetEncoding(MorfeuszEncodings.Cp1250);
            
            //IntPtr morfStruct = new IntPtr(MorfAnalyse(tekst));
            IntPtr morfStruct = MorfAnalyse(text);


            List<InterpMorf> morf = new List<InterpMorf>(3);

            int itemSize = Marshal.SizeOf(typeof(InterpMorf));

            int offset = 0;

            InterpMorf interpMorf;

            try
            {
                interpMorf = (InterpMorf) Marshal.PtrToStructure((IntPtr) ((int) morfStruct + (offset*itemSize)),
                                                                 typeof (InterpMorf));
            }catch(Exception ex)
            {
                Console.WriteLine("Param: {0}  Error: {1} Msg:{2}",text,ex.GetType().ToString(),ex.Message );
                throw;
            }
            //gdy p==-1 to znaczy że to jest ostatni InterpMorf na liście
            while (interpMorf.p != -1)
            {
                offset++;
                morf.Add(interpMorf);
                interpMorf = (InterpMorf)Marshal.PtrToStructure((IntPtr)((int)morfStruct + (offset * itemSize)),
                                                                 typeof(InterpMorf));
            }

            return morf.ToArray();

        }




    }
}