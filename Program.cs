using System;
using System.Collections.Generic;
using System.Linq;

namespace HeistPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            //creat rolodex
            List<IRobber> rolodex = new List<IRobber>();
            int i = 1;
            //the criminals
            LockSpecialist Bob = new LockSpecialist()
            {
                Name = "Bob",
                SkillLevel = 35,
                PercentageCut = 35,
                Type = "Lock Specialist",
                Index = i++
            };
            LockSpecialist Sally = new LockSpecialist()
            {
                Name = "Sally",
                SkillLevel = 50,
                PercentageCut = 50,
                Type = "Lock Specialist",
                Index = i++
            };
            Muscle Jamar = new Muscle()
            {
                Name = "Jamar",
                SkillLevel = 45,
                PercentageCut = 35,
                Type = "Muscle",
                Index = i++
            };
            Muscle Larry = new Muscle()
            {
                Name = "Larry",
                SkillLevel = 65,
                PercentageCut = 65,
                Type = "Muscle",
                Index = i++
            };
            Hacker Langston = new Hacker()
            {
                Name = "Langston",
                SkillLevel = 75,
                PercentageCut = 50,
                Type = "Hacker",
                Index = i++
            };
            Hacker Quinton = new Hacker()
            {
                Name = "Quinton",
                SkillLevel = 45,
                PercentageCut = 40,
                Type = "Hacker",
                Index = i++
            };
            //add robbers to the Rolodex
            rolodex.Add(Bob);
            rolodex.Add(Sally);
            rolodex.Add(Jamar);
            rolodex.Add(Larry);
            rolodex.Add(Langston);
            rolodex.Add(Quinton);

            //create your criminals 
            Console.WriteLine("Create a Criminal from the options below");
            Console.WriteLine("1.Hacker (Disables alarms)");
            Console.WriteLine("2.Muscle (Disarms guards)");
            Console.WriteLine("3.Lock Specialist (cracks vault)");
            Console.WriteLine();
            string userSelection;

            //do while to let user create some more criminals
            do
            {
                Console.Write("> ");
                string userChoice = Console.ReadLine();
                userSelection = userChoice;
                if (userSelection == "1")
                {
                    Console.WriteLine("Please create your Hacker");
                    Console.WriteLine();
                    Console.Write("Enter Skill Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Skill Level: ");
                    int skillLevel = int.Parse(Console.ReadLine());
                    Console.Write("Enter % needed out of 100: ");
                    int percentageCut = int.Parse(Console.ReadLine());
                    rolodex.Add(new Hacker()
                    {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut,
                        Type = "Hacker",
                        Index = i++
                    });

                }
                if (userSelection == "2")
                {
                    Console.Write("Please create your Muscle");
                    Console.Write("Enter Skill Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Skill Level: ");
                    int skillLevel = int.Parse(Console.ReadLine());
                    Console.Write("Enter % needed out of 100: ");
                    int percentageCut = int.Parse(Console.ReadLine());
                    rolodex.Add(new Muscle()
                    {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut,
                        Type = "Muscle",
                        Index = i++
                    });
                }
                if (userSelection == "3")
                {
                    Console.Write("Please create your Lock Specialist");
                    Console.Write("Enter Skill Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Skill Level: ");
                    int skillLevel = int.Parse(Console.ReadLine());
                    Console.Write("Enter % needed out of 100: ");
                    int percentageCut = int.Parse(Console.ReadLine());
                    rolodex.Add(new LockSpecialist()
                    {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut,
                        Type = "Lock Specialist",
                        Index = i++
                    });
                }
            }
            while (userSelection != "");

            // create a bank with ints set to random
            Random rnd = new Random();
            Bank UsBank = new Bank()
            {
                CashOnHand = rnd.Next(50_000, 1_000_001),
                AlarmScore = rnd.Next(0, 101),
                VaultScore = rnd.Next(0, 101),
                SecurityGuardScore = rnd.Next(0, 101)
            };
            // store and set bank
            Dictionary<string, int> banks = new Dictionary<string, int>();
            banks.Add("Guards", UsBank.SecurityGuardScore);
            banks.Add("Vault", UsBank.VaultScore);
            banks.Add("Alarm", UsBank.AlarmScore);
            var MostSecure = banks.Max(max => max.Key);
            var vH = banks.Max(max => max.Value);
            Console.WriteLine($"Most Secure: {MostSecure} score of {vH}");
            var LeastSecure = banks.Min(min => min.Key);
            var vL = banks.Max(max => max.Value);
            Console.WriteLine($"Least Secure: {LeastSecure} score of {vL}");

            // print out rolodex 
            foreach (var robber in rolodex)
            {
                Console.WriteLine();
                Console.WriteLine("Criminal");
                Console.WriteLine("------------------");
                Console.WriteLine($"Name: {robber.Name}");
                Console.WriteLine($"Type: {robber.Type}");
                Console.WriteLine($"Skill Level: {robber.SkillLevel}");
                Console.WriteLine($"% due: {robber.PercentageCut}");
                Console.WriteLine($"Crew Member #: {robber.Index}");
                Console.WriteLine();
            }
            //number of criminals
            Console.WriteLine($"# of Criminals: {rolodex.Count}");

            //list to hold crew
            List<IRobber> crew = new List<IRobber>();
            Console.WriteLine("Enter the Crew Member #'s to add to your heist team");
            Console.WriteLine("Select at least 1 member from each group(hacker,muscle,lock specialist)");
            int userCrewInput;
            do
            {
                int userChoice = int.Parse(Console.ReadLine());
                userCrewInput = userChoice;
                foreach (IRobber Member in rolodex)
                {
                    if (userCrewInput == Member.Index)
                    {
                        try
                        {
                            crew.Add(Member);
                            Console.WriteLine("Add another Crew Member enter 0 when finished adding");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Thats not a number try again dummy!");
                        }
                    }
                }

            } while (userCrewInput != 0);
            foreach (var teamMate in crew)
            {
                Console.WriteLine($"Crew Member: {teamMate.Name}");
                Console.WriteLine($"Crew Member Speciality: {teamMate.Type}");
            }

            foreach (IRobber theif in crew)
            {
                theif.PerformSkill(UsBank);
            }
            UsBank.Security();
            if (UsBank.IsSecure)
            {
                Console.WriteLine("The heist failed!");
            }
            else
            {
                Console.WriteLine("WE'RE RICH ####!");
            }

        }


    }
}

