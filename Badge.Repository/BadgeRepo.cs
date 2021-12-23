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
        public List<BadgePOCO> _badge = new List<BadgePOCO>();

        public bool CreateBadge(BadgePOCO badge)
        {
            if(badge == null)
            {
                return false;
            }
            _badge.Add(badge);
            _badgeRepo.Add(badge.BadgeID, badge.DoorName);
            return true;
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
        
        
        public bool UpdateDoors(int badgeNum)
        {
            if(badgeNum != 0)
            {
                _badgeRepo.Remove(badgeNum);
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
