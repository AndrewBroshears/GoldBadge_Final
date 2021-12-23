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
        public void Run()
        {
            RunApplication();
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges\n" +
                "99. Exit");
        }
        private void RunApplication()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        GetBadges();
                        break;
                    case "99":
                        isRunning = false;
                        Console.WriteLine("Thanks");
                        break;
                    default:
                        break;
                }
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
                
                if (userInputYes == "y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Successfully added Badge!");
                    Console.ReadKey();
                    addDoors = false;

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
            if (int.TryParse(Console.ReadLine(), out app2Number))
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
            _badgeRepo.UpdateDoors(userInputUpdateBadge);
        }
        private void GetBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _badgeRepo.GetBadges();
            Console.WriteLine(String.Format("|{0, -10}|{1, -10}|", "Badge#", "Door Access"));
            
            foreach (var b in badges)
            {
                string doors = GetDoors(b.Key);
                Console.WriteLine(String.Format("|{0, -10}|{1, -10}|", $" {b.Key }", $"{doors}"));
            }
            Console.ReadKey();
        }
        private string GetDoors(int badgeNum)
        {
            string doors = "";
            Dictionary<int, List<string>> badges = _badgeRepo.GetBadges();
            List<string> listOfDoors = badges[badgeNum];
            if (listOfDoors.Count == 0)
            {
                Console.WriteLine("No badges to display.");
            }
            else
            {
                return doors;
            }
            return doors;
        }
    }
}
