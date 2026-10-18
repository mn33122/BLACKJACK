using System;
using System.Collections.Generic;
using System.Text;

namespace BLACKJACK
{
    public class Spelare : Person
    {
        // Enkel spelarklass som ärver den gemensamma Person-funktionaliteten.
        // Innehåller för närvarande endast ett visningsnamn men kan utökas med
        // insats, saldo eller annan spelar-specifik information.
        public string Namn { get; set; } = "Spelare";
    }
}
