using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();


        public bool AddLocation(Location newLocation)
        {
            var isLocationAlreadyExistsInTheCoordinates = _locations.Any(l => (l.XCoordinate == newLocation.XCoordinate) && 
                                                                              (l.YCoordinate == newLocation.YCoordinate));

            if (isLocationAlreadyExistsInTheCoordinates) return false;

            _locations.Add(newLocation);
            return true;
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            return _locations.FirstOrDefault(l => (l.XCoordinate == xCoordinate) &&
                                                  (l.YCoordinate == yCoordinate));
        }

    }
}
