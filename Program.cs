namespace BLACKJACK
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();

            int datorPoang = 0;
            int spelarPoang = 0;
            string svar;

            Console.WriteLine("=== BLACKJACK ===");

            //
            Console.WriteLine("\nSpelarens tur:");

            do
            {
                int kort = random.Next(1, 11);
                spelarPoang += kort;

                Console.WriteLine($"Du fick {kort}");
                Console.WriteLine($"Du har totalt {spelarPoang} poäng");

                if (spelarPoang > 21)
                {
                    Console.WriteLine("Du fick över 21 poäng!");
                    break;
                }

                Console.Write("Vill du ha ett kort till? (J/N): ");
                svar = Console.ReadLine();

            } while (svar == "J" || svar == "j");






            Console.WriteLine("\nDatorns tur:");


            while (datorPoang < 17)
            {
                int kort = random.Next(1, 11);
                datorPoang += kort;

                Console.WriteLine($"Datorn fick {kort}");
                Console.WriteLine($"Datorn har totalt {datorPoang} poäng");
            }


            Console.WriteLine("\n===== RESULTAT =====");
            Console.WriteLine($"Datorn fick: {datorPoang} poäng");
            Console.WriteLine($"Spelaren fick: {spelarPoang} poäng");


            if (datorPoang > 21 && spelarPoang > 21)
            {
                Console.WriteLine("Ingen vinner! Båda fick över 21 poäng.");
            }
            else if (spelarPoang > 21)
            {
                Console.WriteLine("Datorn vinner!");
            }
            else if (datorPoang > 21)
            {
                Console.WriteLine("Spelaren vinner!");
            }
            else if (spelarPoang > datorPoang)
            {
                Console.WriteLine("Spelaren vinner!");
            }
            else if (datorPoang > spelarPoang)
            {
                Console.WriteLine("Datorn vinner!");
            }
            else
            {
                Console.WriteLine("Oavgjort!");
            }





        }
    }
}
