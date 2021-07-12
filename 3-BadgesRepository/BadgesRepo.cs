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
        Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        //private int _idCounter = default;

        //public void AddBadge(int key, List<string> value)
        //{
        //    if (!_badges.ContainsKey(key))
        //    {
        //        _badges.Add(key, new List<string>());
        //    }
        //    _badges[key].Add(value);
        //}

        public void ViewAllBadges()
        {
            foreach (KeyValuePair<int, List<string>> keyValuePair in _badges)
            {
                Console.WriteLine($"Key: {keyValuePair.Key.ToString()}, Value: {keyValuePair.Value.ToString()}");
            }
            
        }

        //public int idCounter() => ++_idCounter;
    }
}
