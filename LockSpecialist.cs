using System;
namespace Heist2Group
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Profession { get; } = "Lock Specialist";



        public void PerformSkill(Bank bank)
        {
            //decrement bank's appropriate score by the skillLevel
            bank.VaultScore -= SkillLevel;

            //print robbers name and what they are doing
            Console.WriteLine($"{Name} is cracking locks. Decreased security by {SkillLevel} points.");

            //If bank's score reaches 0 or less, print message saying it's disabled
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has cracked the vault!");
            }
        }
    }
}