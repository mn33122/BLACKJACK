using System;

namespace BLACKJACK
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // Programmets startpunkt. Main bör endast starta spelet och
            // delegera all logik till BlackJackSpel i enlighet med
            // uppgiftskraven (håll logiken i klasser)
            var spel = new BlackJackSpel();
            spel.Start();
        }
    }
}
