using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.Repository
{
    public class BadgeRepo
    {
        //Need to make a dictionary for badges. Similar to list or Queue??
        private readonly Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();
        

        public bool CreateBadge(BadgePOCO key)
        {
            if (_badgeRepo.ContainsKey(key.BadgeID) && key != null)
            {
                _badgeRepo.Add(key.BadgeID, key.DoorName);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeRepo;
        }
        public Dictionary<int, List<string>> GetBadgeId(int badgeNum)
        {
            if(_badgeRepo.ContainsKey(badgeNum)) 
            {
                return _badgeRepo;
            }
            else
            {
                return null;
            }
        }
        
        
        public bool UpdateDoors(int badgeNum, string doorName)
        {
            if(_badgeRepo.ContainsKey(badgeNum) && doorName != null)
            {
                List<string> listOfDoors = _badgeRepo[badgeNum];
                listOfDoors.Add(doorName);
                _badgeRepo[badgeNum] = listOfDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDoors(int badgeNum, string doorName)
        {
            if(_badgeRepo.ContainsKey(badgeNum) && doorName != null)
            {
                List<string> listOfDoors = _badgeRepo[badgeNum];
                listOfDoors.Remove(doorName);
                _badgeRepo[badgeNum] = listOfDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
