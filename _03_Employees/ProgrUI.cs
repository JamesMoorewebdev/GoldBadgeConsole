using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Employees
{
    public class ProgramUI
    {
        protected readonly Repo _badgeRepo = new Repo();
        public void Run()
        {
            SeedDictionary();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu \n" +
                    "\t Pick a Choice! \n" +
                    "\t 1. Add a badge. \n" +
                    "\t 2. Edit a badge. \n" +
                    "\t 3.All badges. \n" +
                    "\t 4.Exit");
                string userSrtInpt = Console.ReadLine();
                switch (userSrtInpt)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please select a number between 1 and 4 \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Console.Clear();

            BadgeRepo newBadge = new BadgeRepo();
            List<string> newBadgeDrs = new List<string>();

            Console.WriteLine("1. Add a Badge \n" +
                "\t What is your ID number?: ");
            newBadge.Num = Convert.ToInt32(Console.ReadLine());
            bool continueToAsk = true;
            while (continueToAsk)
            {
                Console.WriteLine("List a door you want to open: ");
                string userNewDrAccess = Console.ReadLine();
                newBadgeDrs.Add(userNewDrAccess);
                Console.WriteLine("Any other doors(y/n)?");
                string userYOrN = Console.ReadLine();
                if (userYOrN.ToLower() == "y")
                {
                    continueToAsk = true;
                }
                else if (userYOrN.ToLower() == "n")
                {
                    continueToAsk = false;
                    break;
                }
            }
            newBadge.DrAccess = newBadgeDrs;
            _badgeRepo.AddContentsToDictionary(newBadge);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();

        }
        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("2. Edit a Badge \n" +
                "\t What is the badge number you would like to update? ");
            int userBadgeNum = Convert.ToInt32(Console.ReadLine());
            BadgeRepo oldBadge = _badgeRepo.GetBadgeByNum(userBadgeNum);
            if (oldBadge.DrAccess.Count == 0)
            {
                Console.WriteLine("{0} has access to no doors.", oldBadge.Num);
            }
            else if (oldBadge.DrAccess.Count < 1)
            {
                Console.WriteLine("{0} has access to doors {1}", oldBadge.Num, oldBadge.DisplayDrs(oldBadge.DrAccess));
            }
            else if (oldBadge.DrAccess.Count == 1)
            {
                Console.WriteLine("{0} has access to door {1}", Convert.ToString(oldBadge.Num), oldBadge.DisplayDrs(oldBadge.DrAccess));
            }
            else
            {
                Console.WriteLine("Invalid response. Please enter a valid ID number to update.");
            }
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Select an option! \n" +
                  "\t 1. Remove a door. \n" +
                  "\t 2. Add a door. \n" +
                  "\t 3. Return to main menu.");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "remove door":
                        Console.WriteLine("Which door would you like to remove? ");
                        string userDrInpt = Console.ReadLine();
                        bool wasRemoved = _badgeRepo.RemoveADrFromBadge(oldBadge, userDrInpt);
                        if (wasRemoved == true)
                        {
                            Console.WriteLine("Door removed.");
                        }
                        else if (wasRemoved == false)
                        {
                            Console.WriteLine("Door was not removed");
                        }
                        else
                        {
                            Console.WriteLine("An error has occured. Try again.");
                        }

                        if (oldBadge.DrAccess.Count < 1)
                        {
                            Console.WriteLine("{0} has access to doors {1}", Convert.ToString(oldBadge.Num), oldBadge.DisplayDrs(oldBadge.DrAccess));
                        }
                        else if (oldBadge.DrAccess.Count == 1)
                        {
                            Console.WriteLine("{0} has access to door {1}", Convert.ToString(oldBadge.Num), oldBadge.DisplayDrs(oldBadge.DrAccess));
                        }
                        else
                        {
                            Console.WriteLine("Invalid response. Please enter a valid door number to add.");
                        }
                        break;
                    case "2":
                    case "add a door":
                        Console.WriteLine("\n Enter in the door number you would like to refresh: ");
                        string userNewDoorInput = Console.ReadLine();
                        _badgeRepo.AddADrToBadge(oldBadge, userNewDoorInput);
                        if (oldBadge.DrAccess.Count > 1)
                        {
                            Console.WriteLine("{0} has access to doors {1}", Convert.ToString(oldBadge.Num), oldBadge.DisplayDrs(oldBadge.DrAccess));
                        }
                        else if (oldBadge.DrAccess.Count == 1)
                        {
                            Console.WriteLine("{0} has access to door {1}", Convert.ToString(oldBadge.Num), oldBadge.DisplayDrs(oldBadge.DrAccess));
                        }
                        else
                        {
                            Console.WriteLine("Invalid response.");
                        }
                        break;
                    case "3":
                    case "Go back to main options":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response.");
                        break;
                }
            }
            _badgeRepo.AddContentsToDictionary(oldBadge);
            Console.WriteLine(" \n Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllBadges()
        {
            Console.Clear();
            var header = String.Format("{0,-10}{1,20}\n", "Badge #", "Door Access");
            Console.WriteLine(header);
            Dictionary<int, BadgeRepo> idAndBadge = _badgeRepo.ReturnContentsDictionary();
            foreach (KeyValuePair<int, BadgeRepo> keyValuePair in idAndBadge)
            {
                DisplayAll(keyValuePair.Value);
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();

        }
        private void DisplayAll(BadgeRepo badge)
        {
            var output = String.Format("{0,-10}{1,20}", badge.Num, badge.DisplayDrsWithComma(badge.DrAccess));
            Console.WriteLine(output);
        }
        public void SeedDictionary()
        {
            List<string> badgeOneDoors = new List<string>();
            badgeOneDoors.Add("A7");
            BadgeRepo badgeOne = new BadgeRepo(12345, badgeOneDoors);
            _badgeRepo.AddContentsToDictionary(badgeOne);
            List<string> badgeTwoDoors = new List<string>();
            badgeTwoDoors.Add("A1");
            badgeTwoDoors.Add("A4");
            badgeTwoDoors.Add("B1");
            badgeTwoDoors.Add("B2");
            BadgeRepo badgeTwo = new BadgeRepo(22345, badgeTwoDoors);
            _badgeRepo.AddContentsToDictionary(badgeTwo);
            List<string> badgeThreeDoors = new List<string>();
            badgeThreeDoors.Add("A4");
            badgeThreeDoors.Add("A5");
            BadgeRepo badgeThree = new BadgeRepo(32345, badgeThreeDoors);
            _badgeRepo.AddContentsToDictionary(badgeThree);
        }
    }
}
