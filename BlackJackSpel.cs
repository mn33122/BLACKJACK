using System;
using System.Collections.Generic;
using System.Text;

namespace BLACKJACK
{
    public class BlackJackSpel
    {
        // BlackJackSpel ansvarar för spel-loopen och runda-hantering.
        // Den använder Kortlek för kortdragning och Person-typerna
        // Spelare och Dealer för att representera deltagarna.

        // Start-metoden är programmets huvudsakliga spel-loop. Den kör en ny runda
        public void Start()
        {
            // Starta huvudloopen för spelet. Varje iteration kör en ny runda.
            Console.WriteLine("Välkommen till Blackjack!");

            bool spela = true;

            while (spela)
            {
                // Spela en runda
                StartRunda();

                // Fråga spelaren om denne vill spela en ny runda
                Console.Write("Spela en runda till? (J/N): ");
                var s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s) || !(s.Equals("J", StringComparison.OrdinalIgnoreCase)))
                {
                    // Avsluta huvudloopen om svaret inte är J/j
                    spela = false;
                }
            }

            Console.WriteLine("Tack för spelet!");
        }

        // StartRunda hanterar logiken för en enskild runda av Blackjack.
        private void StartRunda()
        {
            // Initialisera kortlek och deltagare för rundan
            var kortlek = new Kortlek();
            var spelare = new Spelare();
            var dealer = new Dealer();

            // Dela ut två kort till spelare och dealer växelvis
            spelare.AddCard(kortlek.DraKort());
            dealer.AddCard(kortlek.DraKort());
            spelare.AddCard(kortlek.DraKort());
            dealer.AddCard(kortlek.DraKort());

            Console.WriteLine("\n--- Ny runda ---\n");

            // --- Spelarens tur ---
            // Spelaren kan välja att "hit" (dra) eller "stand" (stanna)
            bool spelarTur = true;
            while (spelarTur)
            {
                Console.WriteLine("Dina kort:");
                Console.WriteLine(spelare.HandToString());
                Console.WriteLine($"Värde: {spelare.GetHandValue()}\n");

                // Om spelaren redan har över 21, bryt ut (busted)
                if (spelare.GetHandValue() > 21)
                {
                    Console.WriteLine("Du blev tjock! (över 21)");
                    break;
                }

                // Fråga spelaren om ett nytt kort
                Console.Write("Vill du ha ett kort till? (J/N): ");
                var svar = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(svar) && svar.Equals("J", StringComparison.OrdinalIgnoreCase))
                {
                    var kort = kortlek.DraKort();
                    spelare.AddCard(kort);
                    Console.WriteLine($"Du drog: {kort}\n");
                }
                else
                {
                    // Spelaren väljer att stanna
                    spelarTur = false;
                }
            }

            // --- Dealerns tur ---
            // Visa dealerns kort men dölj det första (vanlig blackjack-uppvisning)
            Console.WriteLine("\nDealerns kort:");
            Console.WriteLine(dealer.HandToString(hideFirstCard: true));

            // Om spelaren inte blev tjock får dealern spela enligt sina regler
            if (spelare.GetHandValue() <= 21)
            {
                Console.WriteLine("Dealern spelar...\n");
                dealer.Play(kortlek);
            }

            // --- Visa slutresultat för rundan ---
            Console.WriteLine("\n--- Slutresultat ---");
            Console.WriteLine("Dealerns kort:");
            Console.WriteLine(dealer.HandToString());
            Console.WriteLine($"Dealerns värde: {dealer.GetHandValue()}\n");

            Console.WriteLine("Dina kort:");
            Console.WriteLine(spelare.HandToString());
            Console.WriteLine($"Ditt värde: {spelare.GetHandValue()}\n");

            // Avgör vinnare utifrån de slutgiltiga värdena
            var spelareVarde = spelare.GetHandValue();
            var dealerVarde = dealer.GetHandValue();

            if (spelareVarde > 21)
            {
                if (dealerVarde > 21)
                {
                    Console.WriteLine("Ingen vinner, båda blev tjocka.");
                }
                else
                {
                    Console.WriteLine("Dealern vinner.");
                }
            }
            else if (dealerVarde > 21)
            {
                Console.WriteLine("Du vinner! Dealern blev tjock.");
            }
            else if (spelareVarde > dealerVarde)
            {
                Console.WriteLine("Du vinner! Närmare 21.");
            }
            else if (dealerVarde > spelareVarde)
            {
                Console.WriteLine("Dealern vinner.");
            }
            else
            {
                Console.WriteLine("Oavgjort (push). ");
            }

            Console.WriteLine();
        }
    }
}

