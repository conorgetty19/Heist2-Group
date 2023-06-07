using System;
using System.Collections.Generic;
namespace Heist2Group
{
    class Program
    {
        static void Main(string[] args)
        {
            //new members
            Hacker Hacks = new Hacker()
            {
                Name = "Hacks",
                SkillLevel = 100,
                PercentageCut = 30
            };
            Muscles Brawn = new Muscles()
            {
                Name = "Biggun",
                SkillLevel = 100,
                PercentageCut = 40
            };
            LockSpecialist John = new LockSpecialist()
            {
                Name = "John Locke",
                SkillLevel = 90,
                PercentageCut = 25
            };
            LockSpecialist Swaggins = new LockSpecialist()
            {
                Name = "Frodo Baggins",
                SkillLevel = 40,
                PercentageCut = 30
            };
            Muscles Beef = new Muscles()
            {
                Name = "Hoagie",
                SkillLevel = 65,
                PercentageCut = 5
            };
            List<IRobber> Rolodex = new List<IRobber>()
            {
                Hacks, Brawn, John, Swaggins, Beef
            };
            Console.WriteLine($"{Rolodex.Count}");
            Console.Write("Would you like to make a new character? Y/N: ");
            string answer = Console.ReadLine().ToLower();
            while (answer == "y")
            {
                Rolodex.Add(NewCharacter());
                Console.Write("Would you like to make a new character? Y/N: ");
                answer = Console.ReadLine().ToLower();
            }
            IRobber NewCharacter()
            {
                Console.Write("What is your new character's name? : ");
                string newName = Console.ReadLine().Trim();
                while (String.IsNullOrEmpty(newName))
                {
                    Console.Write("Try again... nerd: ");
                    newName = Console.ReadLine();
                }
                Console.Write(@$"What is {newName}'s specialty? Select the corresponding number.
                1) Hacker
                2) Muscles
                3) Lock Specialist
                : ");
                string specialtyNumber = Console.ReadLine(); //need to be parsed to int on construction of object
                while (String.IsNullOrEmpty(specialtyNumber))
                {
                    Console.Write(@"Try again... pleb: 
                1) Hacker
                2) Muscles
                3) Lock Specialist
                :");
                    specialtyNumber = Console.ReadLine();
                }
                Console.Write($"What is {newName}'s skill level? Select a number between 0 and 100: ");
                string skillLevel = Console.ReadLine(); //needs to be parsed to int on construction of object
                while (String.IsNullOrEmpty(skillLevel))
                {
                    Console.Write("Try again... : ");
                    skillLevel = Console.ReadLine();
                }
                Console.Write($"What percentage cut is {newName} expecting? Select a number between 0 and 100: ");
                string percCut = Console.ReadLine(); //needs to be parsed to int on construction of object
                while (String.IsNullOrEmpty(percCut))
                {
                    Console.Write("Really..? You're hopeless, but try again anyway: ");
                    percCut = Console.ReadLine();
                }
                switch (specialtyNumber)
                {
                    case "1":

                        return new Hacker()
                        {
                            Name = newName,
                            SkillLevel = int.Parse(skillLevel),
                            PercentageCut = int.Parse(percCut)
                        };

                    case "2":
                        return new Muscles()
                        {
                            Name = newName,
                            SkillLevel = int.Parse(skillLevel),
                            PercentageCut = int.Parse(percCut)
                        };

                    case "3":
                        return new LockSpecialist()
                        {
                            Name = newName,
                            SkillLevel = int.Parse(skillLevel),
                            PercentageCut = int.Parse(percCut)
                        };

                    default:
                        Console.WriteLine("You Suck, We'll give you a crew member.");
                        return new Muscles()
                        {
                            SkillLevel = new Random().Next(0, 101),
                            PercentageCut = new Random().Next(0, 2) * 100,
                            Name = newName
                        };
                }
            }
            Bank randomBank = new Bank
            {
                AlarmScore = new Random().Next(0, 100),
                VaultScore = new Random().Next(0, 100),
                SecurityGuardScore = new Random().Next(0, 100),
                CashOnHand = new Random().Next(50000, 1000000)
            };

            Dictionary<string, int> scoreName = new Dictionary<string, int>()
            {
                {"Alarm Score",randomBank.AlarmScore},
                {"Vault Score", randomBank.VaultScore},
                {"Security Guard Score", randomBank.SecurityGuardScore}
            };

            int maxScore = Math.Max(randomBank.AlarmScore, Math.Max(randomBank.VaultScore, randomBank.SecurityGuardScore));
            int minScore = Math.Min(randomBank.AlarmScore, Math.Min(randomBank.VaultScore, randomBank.SecurityGuardScore));

            string mostSecureScore = "";
            string leastSecureScore = "";

            foreach (var entry in scoreName)
            {
                if (entry.Value == maxScore)
                {
                    mostSecureScore = entry.Key;
                }
                if (entry.Value == minScore)
                {
                    leastSecureScore = entry.Key;
                }
            }

            Console.WriteLine($"Most Secure Score: {mostSecureScore}");
            Console.WriteLine($"Least Secure Score: {leastSecureScore}");

            Console.WriteLine("Select your Robbers");
            string continueSelection = "y";

            List<IRobber> Crew = new List<IRobber>();
            int totalPercentageCut = 100;

            List<int> robbersTooExpensive = new List<int>();

            while (continueSelection == "y" && totalPercentageCut > 0)
            {
                int i = 1;
                foreach (IRobber r in Rolodex)
                {
                    if (r.PercentageCut <= totalPercentageCut)
                    {
                        Console.WriteLine($" {i} Name: {r.Name}, Specialty: {r.Profession}, Skill Level: {r.SkillLevel}, Cut: {r.PercentageCut}");
                    }
                    else
                    {
                        Console.WriteLine($" {i} Sorry, but {r.Name} is too expensive.");
                        robbersTooExpensive.Add(i);
                    }
                    i++;
                }
                Console.WriteLine("Enter the corresponding number for the Robber: ");
                int robberNumber = int.Parse(Console.ReadLine());
                while (robbersTooExpensive.Contains(robberNumber))
                {
                    Console.WriteLine("That person is too expensive! Select another.");
                    robberNumber = int.Parse(Console.ReadLine());
                }
                Crew.Add(Rolodex[robberNumber - 1]);
                totalPercentageCut -= Rolodex[robberNumber - 1].PercentageCut;
                Rolodex.RemoveAt(robberNumber - 1);
                //remember to remove final question if no viable crew members
                Console.WriteLine("Would you like to select more Robbers? Y/N");
                continueSelection = Console.ReadLine().ToLower();
            }
            // Perform the skills of each crew member on the bank
            foreach (IRobber crewMember in Crew)
            {
                crewMember.PerformSkill(randomBank);
            }

            // Evaluate if the bank is secure
            if (randomBank.IsSecure)
            {
                Console.WriteLine("Heist failed. The bank's security system is still active.");
            }
            else
            {
                //keeps track of money
                int myTake = randomBank.CashOnHand;
                float myTakeFloat = (float)myTake;

                Console.WriteLine("Heist successful!");
                Console.Write("Hey, this is a report:");
                foreach (IRobber crewMember in Crew)
                {
                    float money = (float)crewMember.PercentageCut / 100 * (float)randomBank.CashOnHand;
                    Console.WriteLine($"{crewMember.Name} received ${money}");
                    myTakeFloat -= money;
                }
                Console.WriteLine($"Your take is ${myTakeFloat}");
            }
        }
    }
}
