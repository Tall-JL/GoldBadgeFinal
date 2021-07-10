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
            SeedMenuItem();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
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

        private void NewClaim()
        {
            throw new NotImplementedException();
        }

        private void NextClaim()
        {
            throw new NotImplementedException();
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

        private void SeedMenuItem()
        {
            ClaimsModel claim1 = new ClaimsModel(ClaimType.Car,"Hit and Run", 500, new DateTime(2021, 4, 21)) ;
            ClaimsModel claim2 = new ClaimsModel(ClaimType.Home,"Meteor hit house", 170000, new DateTime(2021, 7, 2)) ;
            ClaimsModel claim3 = new ClaimsModel(ClaimType.Theft,"Stolen sword", 250, new DateTime(2021, 2, 14)) ;
            ClaimsModel claim4 = new ClaimsModel(ClaimType.Car,"Dinosuar trampled car", 30000, new DateTime(2021, 1, 12)) ;
            ClaimsModel claim5 = new ClaimsModel(ClaimType.Theft,"Refridgerator ran away", 3000, new DateTime(2021, 7, 9)) ;

            _claimsInQueue.AddToQueue(claim1);
            _claimsInQueue.AddToQueue(claim2);
            _claimsInQueue.AddToQueue(claim3);
            _claimsInQueue.AddToQueue(claim4);
            _claimsInQueue.AddToQueue(claim5);
        }
    }
}