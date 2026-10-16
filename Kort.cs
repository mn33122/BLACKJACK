using System;

namespace BLACKJACK
{
    public class Kort
    {
        // Kort representerar ett enskilt spelkort med färg, valör och numeriskt värde.

        // The suit / color of the card (e.g. Hjärter, Ruter)
        public string Farg { get; }
        // The face/valor of the card (e.g. Ess, 2, Knäkt)
        public string Valor { get; }
        // The numeric blackjack value for the card (Ace = 11 initially)
        public int Varde { get; }

        // Construct a card with suit, face and numeric value
        public Kort(string farg, string valor, int varde)
        {
            Farg = farg;
            Valor = valor;
            Varde = varde;
        }

        // Provide a readable representation like "Ess Hjärter (11)"
        public override string ToString()
        {
            return $"{Valor} {Farg} ({Varde})";
        }
    }
}
