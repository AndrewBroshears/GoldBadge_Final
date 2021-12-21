using Claim.POCO;
using Claim.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Insurance.UI
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance\n" +
                    "Select a menu option:\n" +
                    "1. See all claims:\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "99. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        GetClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "99":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void GetClaims()
        {
            Console.Clear();
            Queue<ClaimPOCO> viewAllClaims = _claimRepo.GetClaims();
            Console.WriteLine(String.Format("|{0, -7}|{1, -7}|{2, -30}|{3, -7}|{4, -25}|{5, -25}|{6, -7}|", "ClaimID", "Type", "Description", "ClaimAmount", "Date of Incident", "Date of Claim", "Is Valid"));

            if (viewAllClaims.Count > 0)
            {
                foreach (ClaimPOCO c in viewAllClaims)
                {
                    Console.WriteLine(String.Format("|{0, -7}|{1, -7}|{2, -30}|{3, -10}|{4, -25}|{5, -25}|{6, -7}|", $"{c.ClaimID}", $"{c.TypeOfClaim}", $"{c.Description}", $"{c.ClaimAmount}", $"{c.DateOfIncident.ToString("MM/dd/yyyy")}", $"{c.DateOfClaim.ToString("MM/dd/yyyy")}", $"{c.IsValid}"));
                }
            }
            else
            {
                Console.WriteLine("No claims available.");
            }
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
        }

        public void NextClaim()
        {
            Console.Clear();
            ClaimPOCO nextClaim = _claimRepo.NextClaim();
            if(nextClaim != null)
            {
                Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                    $"Type: {nextClaim.TypeOfClaim}\n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"Is Valid: {nextClaim.DateOfClaim}");
                Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    _claimRepo.RemoveClaim();
                    Console.WriteLine("Claim has been dealt with.");
                }
                else
                {
                    Console.WriteLine("Claim was not dealt with.");
                }
            }
        }
        public void CreateNewClaim()
        {
            Console.WriteLine("Enter the Claim id:");
            int claimID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the claim type:\n" +
                "1=Car, 2=Home, 3=Theft");
            ClaimPOCO.ClaimType typeOfClaim = (ClaimPOCO.ClaimType)int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a claim description:");
            string description = Console.ReadLine();
            Console.WriteLine("Amount of Damage:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Date of Incident:\n" +
                "MM/DD/YYYY");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Date of Claim:\n" +
                "MM/DD/YYYY");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());
            bool isValid = _claimRepo.IsClaimValid(dateOfIncident, dateOfClaim);
            ClaimPOCO claimToAdd = new ClaimPOCO(claimID, typeOfClaim, description, amount, dateOfIncident, dateOfClaim, isValid);
            if (_claimRepo.AddClaim(claimToAdd) == true)
            {
                Console.WriteLine("Successfully added new claim!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Unsuccessfull. Please try again.");
                Console.ReadKey();
            }
        }
    }
}
