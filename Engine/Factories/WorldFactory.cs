using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            var newWorld = new World();

            newWorld.AddLocation(new Location()
            {
                Name = "Farmer's Field",
                XCoordinate = -2,
                YCoordinate = -1,
                Description = "There are rows of corn growing here, with giant rats hiding between them.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/FarmFields.png"
            });
            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(new Location()
            {
                Name = "Farmer's House",
                XCoordinate = -1,
                YCoordinate = -1,
                Description = "This is the house of your neighbor, Farmer Ted.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/Farmhouse.png"
            });

            newWorld.AddLocation(new Location()
            {
                Name = "Home",
                XCoordinate = 0,
                YCoordinate = -1,
                Description = "This is your home",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/Home.png"
            });

            newWorld.AddLocation(new Location()
            {
                Name = "Trading Shop",
                XCoordinate = -1,
                YCoordinate = 0,
                Description = "The shop of Susan, the trader.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/Trader.png"
            });

            newWorld.AddLocation(new Location()
            {
                Name = "Town square",
                XCoordinate = 0,
                YCoordinate = 0,
                Description = "You see a fountain here.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/TownSquare.png"
            });

            newWorld.AddLocation(new Location()
            {
                Name = "Town Gate",
                XCoordinate = 1,
                YCoordinate = 0,
                Description = "There is a gate here, protecting the town from giant spiders.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/TownGate.png"
            });

            newWorld.AddLocation(new Location()
            {
                Name = "Spider Forest",
                XCoordinate = 2,
                YCoordinate = 0,
                Description = "The trees in this forest are covered with spider webs.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/SpiderForest.png"
            });
            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(new Location()
            {
                Name = "Herbalist's hut",
                XCoordinate = 0,
                YCoordinate = 1,
                Description = "You see a small hut, with plants drying from the roof.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/HerbalistsHut.png"
            });


            newWorld.AddLocation(new Location()
            {
                Name = "Herbalist's garden",
                XCoordinate = 0,
                YCoordinate = 2,
                Description = "There are many plants here, with snakes hiding behind them.",
                ImageName = @"pack://application:,,,/Engine;component/Images/Locations/HerbalistsGarden.png"
            });
            newWorld.LocationAt(0, 2).QuestsAvailableHere.Add(QuestFactory.GetQuestById(1));
            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}
