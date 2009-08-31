using System.Runtime.InteropServices;

namespace MorfeuszNet
{
    /// <summary>
    /// Struktura przechowywująca dane o termie.
    /// Gdy p=-1 to oznacza że jest to ostani węzeł listy zwracanej przy tworzeniu 
    /// formy morfologicznej
    /// zobacz szczegółową dokumentację w orginalnym pliku morfeusz.h
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct InterpMorf
    {
        /// <summary>
        ///number of start node
        /// </summary>
        [FieldOffset(0)]
        public int p;

        /// <summary>
        /// number of  end node
        /// </summary>
        [FieldOffset(4)]
        public int k; 

        /// <summary>
        /// segment (token), odpowiada polu "forma" w orinalnej bibliotece
        /// </summary>
        [FieldOffset(8)]
        public string Word; 

        /// <summary>
        /// lemma, odpowiada polu "haslo" w orinalnej bibliotece
        /// </summary>
        [FieldOffset(12)]
        public string Lemma; 

        /// <summary>
        /// morphosyntactic tag, odpowiada polu "interp" w orinalnej bibliotece
        /// </summary>
        [FieldOffset(16)]
        public string MorhpTags; 
    }
}