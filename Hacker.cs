using System;
namespace Heist2Group
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Profession { get; } = "Hacker";


        public void PerformSkill(Bank bank)
        {
            //decrement bank's appropriate score by the skillLevel
            bank.AlarmScore -= SkillLevel;

            //print robbers name and what they are doing
            Console.WriteLine($"{Name} is hacking the alarm. Decreased security by {SkillLevel} points.");

            //If bank's score reaches 0 or less, print message saying it's disabled
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }
    }
}