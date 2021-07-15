using _3_BadgesPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_BadgesRepository
{
    public class BadgesRepo
    {

        private readonly Dictionary<int, BadgesModel> _badges = new Dictionary<int, BadgesModel>();
        private int _idCounter = default;
        //public int idCounter() => ++_idCounter;
        public bool AddBadge(BadgesModel newBadge)
        {
            if (newBadge == null)
            {
                return false;
            }
            else
            {
                _idCounter++;
                newBadge.BadgeID = _idCounter;
                _badges.Add(newBadge.BadgeID, newBadge);
                return true;
            }
        }
        public Dictionary<int, BadgesModel> ViewAllBadges()
        {
            return _badges;
        }

        //public bool UpdateBadge(int oldID, BadgesModel newBadge)
        //{
        //    BadgesModel oldBadge = GetBadgeByKey(oldID);

        //    if (oldBadge != null)
        //    {
        //        oldBadge.BadgeID = newBadge.BadgeID;
        //        oldBadge.BadgeName = newBadge.BadgeName;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public BadgesModel GetBadgeByKey(int badgeKey)
        {
            foreach (var badge in _badges)
            {
                if (badge.Key == badgeKey)
                {
                    return badge.Value;
                }
            }
            return null;
        }
    }
}
