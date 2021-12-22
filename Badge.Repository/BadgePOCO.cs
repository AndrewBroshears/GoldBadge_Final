        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.Repository
{
    public class BadgePOCO
    {
        public BadgePOCO() { }
       
        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }
        public string BadgeName { get; set; }

        public BadgePOCO(int badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

    }
}
