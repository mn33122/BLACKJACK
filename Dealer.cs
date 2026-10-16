using System;
using System.Collections.Generic;
using System.Text;

namespace BLACKJACK
{
    public class Dealer : Person
    {
        // Dealer-specifik beteende och identitet. Dealern använder samma handlogik
        // som Person men har en fast spelregel: dra kort tills handens värde >= 17.
        public string Namn { get; set; } = "Dealer";

        // Spelmetoden utför dealerns automatiska dragbeteende.
        // Enligt Blackjack-reglerna som implementeras här drar dealern
        // kort från den angivna Kortleken tills handens värde är minst 17.
        // Denna metod skriver ut varje draget kort till konsolen för synlighet.
        public void Play(Kortlek kortlek)
        {
            // Fortsätt dra medan dealerns handvärde är mindre än 17
            while (GetHandValue() < 17)
            {
                var kort = kortlek.DraKort();
                AddCard(kort);
                // Informera spelaren vilket kort dealern drog
                Console.WriteLine($"Dealer drar: {kort}");
            }
        }
    }
}

