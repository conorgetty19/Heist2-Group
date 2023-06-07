namespace Heist2Group
{
    public interface IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Profession { get; }

        void PerformSkill(Bank bank)
        {
            //do something
        }
    }
}