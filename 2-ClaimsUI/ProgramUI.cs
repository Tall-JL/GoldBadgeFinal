using _2_ClaimsPOCO;
using _2_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ClaimsUI
{
    class ProgramUI
    {
        ClaimsRepo _claimsInQueue = new ClaimsRepo();
        public void Run()
        {
            SeedClaims();
            Menu();
        }

        private void Menu()
        {
            Console.Clear();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would you like to do?\n" +
                "1. View all claims\n" +
                "2. Next claim\n" +
                "3. New claim\n" +
                "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
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

        private bool NewClaim()
        {
            ClaimsModel newClaim = new ClaimsModel();

            Console.Clear();
            Console.WriteLine("Enter number of claim type.\n\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string input = Console.ReadLine();
            int intInput = int.Parse(input);
            newClaim.ClaimType = (ClaimType)intInput;

            Console.WriteLine("What is the description of claim?");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("What is the claim amount?");
            newClaim.ClaimAmount = Console.ReadLine();

            Console.WriteLine("What date did this claim occur? (year, month, day)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //string claimOccurance = Console.ReadLine();
            //DateTime result;

            //if (DateTime.TryParse(claimOccurance, out result))
            //{
            //    return result;
            //}
            //else
            //{
            //    return null;
            //}

            //newClaim.DateOfIncident = result;

            bool success = true;

            if (success)
            {
                _claimsInQueue.AddToQueue(newClaim);
                Console.WriteLine("You've successfully added a claim!");
                return true;
            }
            else
            {
                Console.WriteLine("You've failed to add a claim...");
                return false;
            }
        }

        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details of the next claim to be handled.");

            DisplayClaimInfo(_claimsInQueue.HandleNextClaim());

            Console.WriteLine("Do you want to deal with this claim? (y/n)");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                var success = _claimsInQueue.RemoveFromQueue();
                if (success)
                {
                    Console.WriteLine("You deleted a claim!");
                }
                else
                {
                    Console.WriteLine("Deletion failed...");
                }                
            }
            else if (input == "n")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Invalid operation.");
            }           
        }
        private void DisplayClaimInfo(ClaimsModel claimInfo)
        {
            Console.WriteLine($"Claim ID: {claimInfo.ClaimID}\n" +
                $"ClaimType: {claimInfo.ClaimType}\n" +
                $"Description: {claimInfo.Description}\n" +
                $"ClaimAmount: {claimInfo.ClaimAmount}\n" +
                $"Date of Incident: {claimInfo.DateOfIncident}\n" +
                $"Date of Claim: {claimInfo.DateOfClaim}\n" +
                $"IsValid: {claimInfo.IsValid}\n");
        }

        private void ViewAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Below are all current claims\n\n");

            foreach (var claim in _claimsInQueue._claims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claims Amount: ${claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"IsVald: {claim.IsValid}\n");
            }
        }

        private void SeedClaims()
        {
            ClaimsModel claim1 = new ClaimsModel(ClaimType.Car, "Hit and Run", "500", new DateTime(2021, 4, 21));
            ClaimsModel claim2 = new ClaimsModel(ClaimType.Home, "Meteor hit house", "1700,00", new DateTime(2021, 7, 2));
            ClaimsModel claim3 = new ClaimsModel(ClaimType.Theft, "Stolen sword", "250", new DateTime(2021, 2, 14));
            ClaimsModel claim4 = new ClaimsModel(ClaimType.Car, "Dinosuar trampled car", "30,000", new DateTime(2021, 1, 12));
            ClaimsModel claim5 = new ClaimsModel(ClaimType.Theft, "Refridgerator ran away", "3,000", new DateTime(2021, 7, 9));

            _claimsInQueue.AddToQueue(claim1);
            _claimsInQueue.AddToQueue(claim2);
            _claimsInQueue.AddToQueue(claim3);
            _claimsInQueue.AddToQueue(claim4);
            _claimsInQueue.AddToQueue(claim5);
        }
    }
}