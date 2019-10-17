using System;
using System.Collections.Generic;

namespace HeistPart2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure { get; set; }
        

        public void Security()
        {
            if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
            {
                IsSecure = false;
            }
            else if (AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
            {
                IsSecure = true;
            }

        }
    }
}