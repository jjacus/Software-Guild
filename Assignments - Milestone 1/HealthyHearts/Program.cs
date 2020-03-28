using System;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your age? ");
            string input = Console.ReadLine();
            int.TryParse(input, out int age);
            int targetHR = 220 - age;
            double zoneMin = Math.Ceiling((targetHR * 0.5));
            double zoneMax = Math.Ceiling((targetHR * 0.85));

            Console.WriteLine("Your maximum hear rate should be " + (220 - age) + " beats per minute");
            Console.WriteLine("Your target HR zone is " + zoneMin + " - " + zoneMax + " beats per minute");
        }
    }
}
