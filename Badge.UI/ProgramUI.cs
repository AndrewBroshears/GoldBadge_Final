using Badge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        private bool _isRunning = true;
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                RunApplication();
            }
        }

        private void RunApplication()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges\n" +
                "99. Exit");
            int appNumber;
            if(int.TryParse(Console.ReadLine(), out appNumber))
            {
                switch (appNumber)
                {
                    case 1:
                        CreateBadge();
                        break;
                    case 2:
                        UpdateBadge();
                        break;
                    case 3:
                        GetAllBadges();
                        break;
                    case 99:
                        _isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                return;
            }
        }
        private void CreateBadge()
        {
            Console.Clear();
            BadgePOCO badgeToBeAdded = new BadgePOCO();
            List<string> listOfDoors = new List<string>();
            
            Console.WriteLine("What is the number on the badge:");
            badgeToBeAdded.BadgeID = int.Parse(Console.ReadLine());

            bool addDoors = true;
            while (addDoors)
            {
                Console.WriteLine("List a door that it needs access to:");
                string userInputDoor = Console.ReadLine();
                listOfDoors.Add(userInputDoor);
                Console.WriteLine("Any other doors(y/n)?");
                string userInputYes = Console.ReadLine();

                if(userInputYes == "y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Successfully added Badge!");
                    addDoors = false;
                    Console.ReadKey();
                        
                }
            }
                badgeToBeAdded.DoorName = listOfDoors;
                _badgeRepo.CreateBadge(badgeToBeAdded);
        
        }
        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to Update?");
            int userInputUpdateBadge = int.Parse(Console.ReadLine());
            Console.WriteLine($"{_badgeRepo.GetBadgeId(userInputUpdateBadge)}\n" +
                $"What would you like to do?\n" +
                $"1. Remove a door\n" +
                $"2. Add a door");

            int app2Number;
            if (!int.TryParse(Console.ReadLine(), out app2Number))
            {
                switch (app2Number)
                {
                    case 1:
                        Console.WriteLine("Which door would you like to remove");
                        string userDoorRemove = (Console.ReadLine());
                        _badgeRepo.RemoveDoors(userInputUpdateBadge, userDoorRemove);
                        Console.WriteLine("Door removed");
                        Console.WriteLine($"{_badgeRepo.GetBadgeId(userInputUpdateBadge)}");
                        break;
                    case 2:
                        Console.WriteLine("Add a door");
                        int userDoorAdd = int.Parse(Console.ReadLine());
                        break;
                }
            }
            else
            {
                Console.ReadKey();
            }  
        }
        private void GetAllBadges()
        { 
            Console.WriteLine(String.Format("|{0, -20}|{1, -20}|", "Badge#", "Door Access"));

            Console.WriteLine($"{_badgeRepo.GetBadges()}");

        }
    }
}
