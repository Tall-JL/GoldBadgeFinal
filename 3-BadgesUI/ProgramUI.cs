using System;
using System.Collections.Generic;
using _3_BadgesPOCO;
using _3_BadgesRepository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_BadgesUI
{
    public class ProgramUI
    {
        BadgesRepo _badgesRepo = new BadgesRepo();
        Dictionary<int, List<string>> _badgesList = new Dictionary<int, List<string>>();
        

        public void Run()
        {
            SeedBadges();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello, What would you like to do?\n" +
                "1. Create a new badge\n" +
                "2. View all badges\n" +
                "3. Edit a badge\n" +
                "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        ViewBadgesList();
                        break;
                    case "3":
                        EditBadge();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void EditBadge()
        {
            throw new NotImplementedException();
        }

        private void ViewBadgesList()
        {
            Console.Clear();
            Console.WriteLine("Here are all badges currently on the system.");

            _badgesRepo.ViewAllBadges();
        }

        private void CreateBadge()
        {
            throw new NotImplementedException();
        }

        private void SeedBadges()
        {
            _badgesList.Add(1, new List<string>());
            _badgesList.Add(2, new List<string>());
            _badgesList.Add(3, new List<string>());
            _badgesList.Add(4, new List<string>());
            _badgesList.Add(5, new List<string>());

            _badgesList[1].Add("A1");
            _badgesList[1].Add("A2");
            _badgesList[2].Add("B1");
            _badgesList[2].Add("B2");
            _badgesList[3].Add("C1");
            _badgesList[3].Add("C2");
            _badgesList[4].Add("D5");
            _badgesList[5].Add("E12");
            
        }
    }
}
