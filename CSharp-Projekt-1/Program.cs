using System;

namespace CSharp_Projekt_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random slump = new Random();
            string senasteVinnaren = "Ingen har vunnit än";

            // Setup variables  
            int min = 1;
            int max = 11;
            int cardsToPickAtStart = 2;

            Console.WriteLine("Välkommen till 21:an!");

            string menyVal = "0";
            while (menyVal != "4")
            {
                // Skriv ut huvudmenyn
                Console.WriteLine("Välj ett alternativ");
                Console.WriteLine("1. Spela 21:an");
                Console.WriteLine("2. Visa senaste vinnaren");
                Console.WriteLine("3. Spelets regler");
                Console.WriteLine("4. Avsluta programmet");
                menyVal = Console.ReadLine();

                // Tom rad innan användarens val körs
                Console.WriteLine();

                switch (menyVal)
                {
                    // Spela en omgång av 21:an
                    case "1":
                        int datornsPoäng = 0;
                        int spelarensPoäng = 0;
                        Console.WriteLine("Nu kommer två kort dras per spelare");

                        for (int i = 1; i <= cardsToPickAtStart; i++ )
                        {
                            int computerCard = slump.Next(min, max);
                            int userCard = slump.Next(min, max);

                            datornsPoäng += computerCard;
                            spelarensPoäng += userCard;

                            Console.WriteLine($"Computer Card {i} was a {computerCard}");
                            Console.WriteLine($"Your Card {i} was a {userCard}");
                        }

                        // Låt användaren dra fler kort
                        string kortVal = "";
                        while (kortVal != "n" && spelarensPoäng <= 21)
                        {
                            Console.WriteLine($"Din poäng: {spelarensPoäng}");
                            Console.WriteLine($"Datorns poäng: {datornsPoäng}");
                            Console.WriteLine("Vill du ha ett till kort? (j/n)");
                            kortVal = Console.ReadLine();

                            switch (kortVal)
                            {
                                case "j":
                                    int nyPoäng = slump.Next(1, 11);
                                    spelarensPoäng += nyPoäng;
                                    Console.WriteLine($"Ditt nya kort är värt {nyPoäng} poäng");
                                    Console.WriteLine($"Din totalpoäng är {spelarensPoäng}");
                                    break;

                                case "n":
                                    break;

                                default:
                                    Console.WriteLine("Du valde inte ett giltigt alternativ");
                                    break;
                            }

                        }

                        // Gå tillbaka till huvudmenyn om användaren har över 21
                        if (spelarensPoäng > 21)
                        {
                            Console.WriteLine("Du har mer än 21 och har förlorat");
                            break;
                        }

                        // Datorn drar kort tills den vinner eller går över 21
                        while (datornsPoäng < spelarensPoäng && datornsPoäng <= 21)
                        {
                            int datornsNyaPoäng = slump.Next(1, 11);
                            datornsPoäng += datornsNyaPoäng;
                            Console.WriteLine($"Datorn drog ett kort värt {datornsNyaPoäng}");
                        }

                        Console.WriteLine($"Din poäng: {spelarensPoäng}");
                        Console.WriteLine($"Datorns poäng: {datornsPoäng}");

                        // Undersök vem som vann
                        if (datornsPoäng > 21)
                        {
                            Console.WriteLine("Du har vunnit!");
                            Console.WriteLine("Skriv in ditt namn");
                            senasteVinnaren = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Datorn har vunnit!");
                        }

                        break;

                    // Visa senaste vinnaren
                    case "2":
                        Console.WriteLine($"Senaste vinnaren: {senasteVinnaren}");
                        break;

                    // Visa spelets regler
                    case "3":
                        Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
                        Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1-10 poäng.");
                        Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
                        Console.WriteLine("Både du och datorn får två kort i början. Därefter får du");
                        Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
                        Console.WriteLine("När du är färdig drar datorn kort till den har");
                        Console.WriteLine("mer poäng än dig eller över 21 poäng.");
                        break;

                    // Gör ingenting (programmet avslutas)
                    case "4":
                        break;

                    default:
                        Console.WriteLine("Du valde inte ett giltigt alternativ");
                        break;
                }

                // Tom rad innan nästa körning
                Console.WriteLine();
            }
        }
    }
}
