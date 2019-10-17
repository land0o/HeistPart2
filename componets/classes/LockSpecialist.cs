using System;

namespace HeistPart2
{
    public class LockSpecialist : IRobber
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
                bank.VaultScore = bank.VaultScore - 50;
                Console.WriteLine($"{Name} is breaking into the vault. Vault Score has decreased by 50 points, Shhhh almost got it!");
            }
            else if (bank.VaultScore == 0)
            {
                Console.WriteLine($"{Name} has disabled the Vault system");
            }

        }
    }
}