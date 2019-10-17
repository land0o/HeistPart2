using System;

namespace HeistPart2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }

        public void PerformSkill(Bank bank)
        {
            if (SkillLevel >= 50)
            {
                bank.SecurityGuardScore = bank.SecurityGuardScore - 50;
                Console.WriteLine($"{Name} is roughing up the Security Guards. Decreased Security Guards health by 50 points, don't move MFER's!");
            }
            else if (bank.SecurityGuardScore == 0)
            {
                Console.WriteLine($"{Name} has disabled the Security Guards!");
            }

        }
    }
}