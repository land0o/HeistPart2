using System;

namespace HeistPart2
{
    public class Hacker : IRobber
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
                bank.AlarmScore = bank.AlarmScore - 50;
                Console.WriteLine($"{Name} is hacking the alarm system. Decreased security 50 points Tap tap tap...code code.. I'm In!");
            }
            else if (bank.AlarmScore == 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system");
            }

        }
    }
}