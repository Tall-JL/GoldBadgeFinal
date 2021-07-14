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
            Console.Clear();

            ViewBadgesList();
            Console.WriteLine("---------------------------------\n");
            Console.WriteLine("What badge number would you like to edit?\n");
            int input = Int32.Parse(Console.ReadLine());
            BadgesModel oldBadge = _badgesRepo.GetBadgeByKey(input);

            Console.WriteLine($"Badge ID #{oldBadge.BadgeID} has access to ");
            GetAllDoors(oldBadge);
            
            bool doorsToEdit = true;
            while (doorsToEdit)
            {
                Console.WriteLine("Would you like to edit badge doors? (y/n)\n");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    Console.WriteLine("What would you like to do?\n\n" +
                        "1. Remove a door\n" +
                        "2. Add a door\n");
                    int input2 = Int32.Parse(Console.ReadLine());

                    switch (input2)
                    {
                        case 1:
                            Console.WriteLine("What door would you like to remove?");
                            string doorToRemove = Console.ReadLine();
                            RemoveDoor(oldBadge.BadgeID, doorToRemove);
                            break;
                        case 2:
                            Console.WriteLine("What door would you like to add?");
                            string doorToAdd = Console.ReadLine();
                            AddDoor(oldBadge.BadgeID, doorToAdd);
                            break;
                        default:
                            break;
                    }
                }
                if (answer == "n")
                {
                    Console.WriteLine("Editting done!");
                    doorsToEdit = false;
                }
            }
            Console.WriteLine($"Badge ID #{oldBadge.BadgeID} has access to ");
            GetAllDoors(oldBadge);
        }
        private void AddDoor(int oldBadgeID, string doorToAdd)
        {
            BadgesModel badgeAddDoor = _badgesRepo.GetBadgeByKey(oldBadgeID);
            badgeAddDoor?.DoorNames?.Add(doorToAdd);
        }
        private void RemoveDoor(int oldBadgeID, string doorToRemove)
        {
            BadgesModel badgeRemoveDoor = _badgesRepo.GetBadgeByKey(oldBadgeID);
            badgeRemoveDoor?.DoorNames?.Remove(doorToRemove);
        }
        public void GetAllDoors(BadgesModel badge)
        {
            foreach (var doorname in badge.DoorNames)
            {
                Console.WriteLine(doorname);
            }
            
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
        private bool CreateBadge()
        {
            Console.Clear();
            BadgesModel newBadge = new BadgesModel();
            string input;
            bool needMoreDoors = true;

            Console.WriteLine("What is the badge name:\n");
            newBadge.BadgeName = Console.ReadLine();

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
                    Console.WriteLine("Your door has been added!\n");
                }
                if (moreDoors == "n")
                {
                    Console.WriteLine("Heading back to main menu.");
                    Console.ReadKey();
                    needMoreDoors = false;
                }

            }

            bool success = true;
            if (success)
            {
                _badgesRepo.AddBadge(newBadge);
                Console.WriteLine("Badge successfully made!");

                return true;
            }
            else
            {
                Console.WriteLine("Badge creation failed...");

                return false;
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
            BadgesModel badgeB = new BadgesModel(new List<string> { "B1", "E3" }, "Hall Badge");
            BadgesModel badgeC = new BadgesModel(new List<string> { "A10", "C2", "B3" }, "Security Badge");

            _badgesRepo.AddBadge(badgeA);
            _badgesRepo.AddBadge(badgeB);
            _badgesRepo.AddBadge(badgeC);
        }
    }
}
