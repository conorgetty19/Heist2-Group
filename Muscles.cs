using System;
namespace Heist2Group
{
    public class Muscles : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Profession { get; } = "Muscles";



        public void PerformSkill(Bank bank)
        {
            //decrement bank's appropriate score by the skillLevel
            bank.SecurityGuardScore -= SkillLevel;

            //print robbers name and what they are doing
            Console.WriteLine($"{Name} is cracking skulls. Decreased security by {SkillLevel} points.");

            //If bank's score reaches 0 or less, print message saying it's disabled
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has killed someone!");
            }
        }
    }
}