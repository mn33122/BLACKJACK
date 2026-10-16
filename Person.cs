using System;
using System.Collections.Generic;
using System.Text;

namespace BLACKJACK
{
    public class Person
    {
        // Bas-klass för både Spelare och Dealer. Innehåller gemensam logik för att hantera en hand av kort.

        // Representerar korten en person (spelare eller dealer) för närvarande har.
        public List<Kort> Hand { get; private set; } = new List<Kort>();

        public void AddCard(Kort kort)
        {
            // Lägg till ett draget kort till personens hand
            Hand.Add(kort);
        }

        public void ClearHand()
        {
            // Ta bort alla kort från handen (ny runda)
            Hand.Clear();
        }

        public int GetHandValue()
        {
            // Beräkna det numeriska värdet av handen, med hänsyn till Ess.
            // Ess räknas initialt som 11 (Kort.Varde är 11 för "Ess").
            // Om den totala summan överstiger 21 konverterar vi Ess från 11 till 1
            // genom att subtrahera 10 per Ess tills summan är <= 21 eller det
            // inte finns fler Ess att nedgradera.
            int sum = 0;
            int aces = 0;

            // Summera alla kortvärden och räknar Ess
            foreach (var k in Hand)
            {
                sum += k.Varde;
                if (k.Valor == "Ess") aces++;
            }

            // Medan vi är över 21 och har Ess räknade som 11, konvertera ett Ess
            // från 11 till 1 genom att subtrahera 10 från det totala värdet.
            while (sum > 21 && aces > 0)
            {
                // Konvertera ett Ess från 11 till 1
                sum -= 10;
                aces--;
            }

            return sum;
        }

        // Returnerar en strängrepresentation av personens hand.
        public string HandToString(bool hideFirstCard = false)
        {
            // Använd StringBuilder för effektiv strängsammanfogning
            var sb = new StringBuilder();

            // Iterera över korten i handen och lägg till dem i strängen
            for (int i = 0; i < Hand.Count; i++)
            {
                // Valfritt att dölja det första kortet (används för dealerns initiala visning)
                if (i == 0 && hideFirstCard)
                {
                    sb.AppendLine("[Gömt kort]");
                }
                // Annars, visa kortets läsbara representation
                else
                {
                    // Använd Kort.ToString() för att få en läsbar representation
                    sb.AppendLine(Hand[i].ToString());
                }
            }

            // Returnera den sammanfogade strängen som representerar handen
            return sb.ToString();
        }
    }
}
