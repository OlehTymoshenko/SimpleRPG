using Engine.Factories;
using Engine.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Engine.EventArgs;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;


        private Location _currentLocation;
        private Monster _currentMonster;


        public World CurrentWorld { get; set; }
        
        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToUp));
                OnPropertyChanged(nameof(HasLocationToLeft));
                OnPropertyChanged(nameof(HasLocationToRight));
                OnPropertyChanged(nameof(HasLocationToDown));

                AddAllQuestFromCurrentLocationToPlayer();
                GetMonstersAtLocation();
            }
        }

        public Monster CurrentMonster 
        {
            get
            {
                return _currentMonster;
            }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null) 
                {
                    RaiseMessage($"You see a {CurrentMonster.Name} here!\n");
                }
            }
        }

        public bool HasMonster => CurrentMonster != null;

        public bool HasLocationToUp => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;

        public bool HasLocationToLeft => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;

        public bool HasLocationToRight => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;

        public bool HasLocationToDown => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;


        public GameSession()
        {
            CurrentPlayer = new Player()
            {
                Name = "OLEGofren",
                CharacterClass = "Carry",
                ExperiencePoints = 0,
                HitPoints = 13,
                Level = 1,
                Gold = 1970
            };

            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1); // player home
        }

        public void MoveUp()
        {
            if (HasLocationToUp)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }

        public void MoveLeft()
        {
            if (HasLocationToLeft)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }

        public void MoveRight()
        {
            if (HasLocationToRight)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
        }

        public void MoveDown()
        {
            if (HasLocationToDown)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }

        private void AddAllQuestFromCurrentLocationToPlayer()
        {
            foreach (var quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }

        public void GetMonstersAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

    }
}
