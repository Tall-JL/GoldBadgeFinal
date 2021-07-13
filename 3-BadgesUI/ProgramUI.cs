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
            Console.Clear();

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

        public void ViewBadgesList()
        {
            Console.Clear();
            Console.WriteLine("Here are all badges currently on the system.");

            var badgesInDatabase = _badgesRepo.ViewAllBadges();

            ViewAllBadgesData(badgesInDatabase);
        }

        public void ViewAllBadgesData(Dictionary<int, BadgesModel> badgesModel)
        {
            foreach (var badge in badgesModel.Values)
            {
                Console.WriteLine($"Badge ID: {badge.BadgeID}\n" +
                $"Badge Name: {badge.BadgeName}");


                foreach (var door in badge.DoorNames)
                {
                    Console.WriteLine($"Door Names: {door}");
                    
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------");
            }

        }
        private void CreateBadge()
        {
            Console.Clear();
            BadgesModel newBadge = new BadgesModel();
            string input;
            bool needMoreDoors = true;

            Console.WriteLine("Badge Creation:\n" +
                "What is the badge number?\n");
            newBadge.BadgeID = Int32.Parse(Console.ReadLine());

            while (needMoreDoors)
            {
                string moreDoors;
                Console.WriteLine("Do you need to add doors? (y/n)\n");
                moreDoors = Console.ReadLine().ToLower();

                if (moreDoors == "y")
                {
                    Console.WriteLine("What door will this badge access?\n" +
                                        "(one door at a time)\n");
                    input = Console.ReadLine();
                    newBadge?.DoorNames?.Add(input);
                    Console.WriteLine("Your door has been added!");
                }
                if (moreDoors == "n")
                {
                    Console.WriteLine("Heading back to main menu.");
                    Console.ReadKey();
                    needMoreDoors = false;
                    Menu();
                }

            }
        }

        private void SeedBadges()
        {
            //_badgesList.Add(1, new List<string>());
            //_badgesList.Add(2, new List<string>());
            //_badgesList.Add(3, new List<string>());
            //_badgesList.Add(4, new List<string>());
            //_badgesList.Add(5, new List<string>());

            //_badgesList[1].Add("A1");
            //_badgesList[1].Add("A2");
            //_badgesList[2].Add("B1");
            //_badgesList[2].Add("B2");
            //_badgesList[3].Add("C1");
            //_badgesList[3].Add("C2");
            //_badgesList[4].Add("D5");
            //_badgesList[5].Add("E12");

            BadgesModel badgeA = new BadgesModel(new List<string> { "A1", "A2", "A3" }, "Main Badge");
            BadgesModel badgeB = new BadgesModel(new List<string> { "B1", "E3" }, "Main Badge");
            BadgesModel badgeC = new BadgesModel(new List<string> { "A10", "C2", "B3" }, "Main Badge");

            _badgesRepo.AddBadge(badgeA);
            _badgesRepo.AddBadge(badgeB);
            _badgesRepo.AddBadge(badgeC);
        }
    }
}
