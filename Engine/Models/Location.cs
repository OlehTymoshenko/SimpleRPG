using Engine.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public List<Quest> QuestsAvailableHere { get; private set; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; private set; } = new List<MonsterEncounter>();


        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if(MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.Find(m => m.MonsterID == monsterID)
                    .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if(MonstersHere.Count == 0)
            {
                return null;
            }

            // Total the percentages of all monsters at this location
            int sumOfChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // Select a random number between 1 and the total (in case the total chances is not 100)
            int randomNumInRangeOfChancesSum = RandomNumberGenerator.NumberBetween(1, sumOfChances);

            // Loop through the monster list,
            // adding the monster's percentage chance of appearing to the runningTotal variable.
            // When the random number is lower than the runningTotal,
            // that is the monster to return
            int runningTotal = 0;

            foreach(var monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if(randomNumInRangeOfChancesSum <= runningTotal)
                {
                    return MonstersFactory.CreateMonsterById(monsterEncounter.MonsterID);
                }
            }

            return MonstersFactory.CreateMonsterById(MonstersHere.First().MonsterID);
        }


    }
}
