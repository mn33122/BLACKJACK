using System;

namespace BLACKJACK
{
    public class Kort
    {
        // Kort representerar ett enskilt spelkort med färg, valör och numeriskt värde.

        // kortets färg (t.ex. Hjärter, Ruter, Klöver, Spader)
        public string Farg { get; }
        // kortets valör (t.ex. Ess, 2, Knäkt)
        public string Valor { get; }
        // kortets numeriska värde för blackjack (Ess = 11 initialt)
        public int Varde { get; }

        // Skapa ett kort med färg, valör och numeriskt värde
        public Kort(string farg, string valor, int varde)
        {
            Farg = farg;
            Valor = valor;
            Varde = varde;
        }

        // Ge en läsbar representation som "Ess Hjärter (11)"
        public override string ToString()
        {
            return $"{Valor} {Farg} ({Varde})";
        }
    }
}
