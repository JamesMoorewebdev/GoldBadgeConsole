using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bieco
{
    public class ProgramUI
    {
        protected readonly ClaimRepository _claimsRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimsQueue();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item. \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Start a new claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowNextClaim();
                        break;
                    case "3":
                        CreateClaimNow();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4 \n" +
            "Press any key to continue.");
                        break;
                }

            }

        }
        private void ShowAll()
        {
            Console.Clear();
            var header = String.Format("{0,-8}{1,8}{2,30}{3,15}{4,20}{5,20}{6,12}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid?");
            Console.WriteLine(header);
            Queue<InsuranceCl> queueOfClaims = _claimsRepo.GetAllInsuranceClaims();
            foreach (InsuranceCl claim in queueOfClaims)
            {
                DisplayAllClaims(claim);
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowNextClaim()
        {
            Console.Clear();
            Queue<InsuranceCl> queueOfClaims = _claimsRepo.GetAllInsuranceClaims();
            var claim1 = queueOfClaims.Peek();
            DisplayOnClaim(claim1);
            Console.WriteLine("Do you want to start this claim now (yes/no)? ");
            string userYOrN = Console.ReadLine();
            switch (userYOrN.ToLower())
            {
                case "y":
                    queueOfClaims.Dequeue();
                    break;
                case "n":
                    Console.WriteLine("Return to main menu.");
                    break;
                default:
                    Console.WriteLine("You did not enter a (y)es or (n)o");
                    break;
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void CreateClaimNow()
        {
            Console.Clear();
            InsuranceCl newClaim = new InsuranceCl();
            //Claim ID
            Console.WriteLine("Enter the Claim ID:");
            newClaim.ClaimId = Convert.ToInt32(Console.ReadLine());
            //Claim Type
            Console.WriteLine("Enter the Claim Type:");
            string claimTypeString = Console.ReadLine();
            switch (claimTypeString.ToLower())
            {
                case "car":
                case "auto":
                case "vehicle":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "home":
                case "house":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    break;
            }
            Console.WriteLine("Please enter a Claim Description:");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Amount of Damage:");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            newClaim.ClaimAmount = claimAmount;
            Console.WriteLine("Date of Claim:");
            DateTime claimDate = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfClaim = claimDate;
            Console.WriteLine("Date of Incident:");
            DateTime claimAccidentDate = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfIncident = claimAccidentDate;

            if (newClaim.IsValid == true)
            {
                Console.WriteLine("This claim is valid, sorry for your hardships");
            }
            else
            {
                Console.WriteLine("Sorry, this claim is not valid");
            }
            _claimsRepo.AddClaimToQu(newClaim);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayOnClaim(InsuranceCl claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimId} \n" +
                $"Type: {claim.ClaimType} \n" +
                $"Description: {claim.Description} \n" +
                $"Amount: ${claim.ClaimAmount} \n" +
                $"DateOfAccident: {claim.DateOfIncident:d} \n" +
                $"DateOfClaim: {claim.DateOfClaim:d} \n" +
                $"IsValid: {claim.IsValid}");
        }
        private void DisplayAllClaims(InsuranceCl claim)
        {
            var output = String.Format("{0,-8}{1,8}{2,30}{3,15:C2}{4,20:d}{5,20:d}{6,12}", claim.ClaimId, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
            Console.WriteLine(output);
        }
        private void SeedClaimsQueue()
        {
            InsuranceCl claim1 = new InsuranceCl(1, ClaimType.Car, "Pot hole damage", 400.00M, new DateTime(2019, 4, 25), new DateTime(2019, 4, 27));
            _claimsRepo.AddClaimToQu(claim1);
            InsuranceCl claim2 = new InsuranceCl(2, ClaimType.Home, "House struck by lighting", 4000.00M, new DateTime(2019, 4, 11), new DateTime(2019, 4, 12));
            _claimsRepo.AddClaimToQu(claim2);
            InsuranceCl claim3 = new InsuranceCl(3, ClaimType.Theft, "CD Player", 4.00M, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));
            _claimsRepo.AddClaimToQu(claim3);
        }
    }
}