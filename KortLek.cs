using System;
using System.Collections.Generic;
using System.Text;

namespace BLACKJACK
{
    public class Kortlek
    {
        // Kortlek representerar en standardkortlek med 52 kort som kan blandas och dra kort från.
        private List<Kort> kortlek;

        // Aktuellt index för nästa kort att dra från kortleken
        private int aktuelltKort;

        // Kortlek konstruktor skapar en ny kortlek, blandar den och sätter aktuelltKort till 0
        public Kortlek()
        {
            kortlek = new List<Kort>();

            SkapaKortlek();

            BlandaKort();

            aktuelltKort = 0;
        }

        // SkapaKortlek skapar en standardkortlek med 52 kort
        private void SkapaKortlek()
        {
            // Färger och valörer för korten
            string[] farger =
            {
            "Hjärter",
            "Ruter",
            "Klöver",
            "Spader"
        };

            // Valörer för korten
            string[] valorer =
            {
            "Ess",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Knäkt",
            "Dam",
            "Kung"
        };

            // Skapa korten och lägg till dem i kortleken
            foreach (string farg in farger)
            {
                for (int i = 0; i < valorer.Length; i++)
                {
                    int varde;

                    if (i == 0)
                    {
                        varde = 11;
                    }
                    else if (i >= 10)
                    {
                        varde = 10;
                    }
                    else
                    {
                        varde = i + 1;
                    }

                    Kort kort = new Kort(
                        farg,
                        valorer[i],
                        varde
                    );

                    kortlek.Add(kort);
                }
            }
        }

        // Blandakort slumpmässigt blandar kortleken
        public void BlandaKort()
        {
            Random random = new Random();

            for (int i = 0; i < kortlek.Count; i++)
            {
                int slumpIndex =
                    random.Next(kortlek.Count);

                Kort temp = kortlek[i];

                kortlek[i] = kortlek[slumpIndex];

                kortlek[slumpIndex] = temp;
            }
        }

        // DraKort returnerar ett kort från kortleken och ökar aktuelltKort med 1
        public Kort DraKort()
        {
            Kort kort = kortlek[aktuelltKort];

            aktuelltKort++;

            return kort;
        }
    }
}
