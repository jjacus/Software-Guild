using System;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            Console.Write("What is your dog's name? ");
            string dogName = Console.ReadLine();
            Console.WriteLine("Well then, I have this highly reliable report on " + dogName + "'s prestigious background right here.\n");
            Console.WriteLine(dogName + " is:\n");

            int pug = randomizer.Next(100);
            int golden = randomizer.Next(100 - pug);
            int terrier = randomizer.Next(100 - golden - pug);
            int chihuahua = randomizer.Next(100 - terrier - golden - pug);
            int corgi = 100 - chihuahua - terrier - golden - pug;

            Console.WriteLine(pug + "% Pug.");
            Console.WriteLine(golden + "% Golden Retriever.");
            Console.WriteLine(terrier + "% Jack Russell Terrier.");
            Console.WriteLine(chihuahua + "% Chihuahua.");
            Console.WriteLine(corgi + "% Corgi.\n");

            Console.WriteLine("Wow, that's QUITE the dog!");
        }
    }
}
