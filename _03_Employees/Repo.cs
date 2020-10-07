using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Employees
{
    public class Repo
    {
        private readonly Dictionary<int, BadgeRepo> _badgeNumAndDrAccess = new Dictionary<int, BadgeRepo>();
        private readonly List<string> _doorAccess = new List<string>();
        public bool AddContentsToDictionary(BadgeRepo badge)
        {
            int startingCount = _badgeNumAndDrAccess.Count;
            _badgeNumAndDrAccess.Add(badge.Num, badge);
            bool wasAdded = (_badgeNumAndDrAccess.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int, BadgeRepo> ReturnContentsDictionary()
        {
            return _badgeNumAndDrAccess;
        }
        public BadgeRepo GetBadgeByNum(int badgeNum)
        {
            BadgeRepo badge = _badgeNumAndDrAccess[badgeNum];
            if (badge != null)
            {
                return badge;
            }
            return null;
        }
        public bool AddADrToBadge(BadgeRepo badge, string drNumber)
        {
            BadgeRepo oldBadge = GetBadgeByNum(badge.Num);
            int startingCount = oldBadge.DrAccess.Count();
            List<string> doors = oldBadge.DrAccess;
            doors.Add(drNumber);
            bool wasAdded = (oldBadge.DrAccess.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool RemoveADrFromBadge(BadgeRepo badge, string doorNumber)
        {
            BadgeRepo oldBadge = GetBadgeByNum(badge.Num);
            int startingCount = oldBadge.DrAccess.Count();
            List<string> doors = oldBadge.DrAccess;
            doors.Remove(doorNumber);
            bool wasRemoved = (oldBadge.DrAccess.Count < startingCount) ? true : false;
            return wasRemoved;
        }
    }
}
