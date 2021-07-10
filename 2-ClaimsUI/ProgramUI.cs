using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ClaimsUI
{
    class ProgramUI
    {
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
            throw new NotImplementedException();
        }

        private void SeedMenuItem()
        {
            throw new NotImplementedException();
        }
    }
}