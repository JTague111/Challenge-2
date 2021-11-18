using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Challenge_2_Take_2
{
    class App
    {
        private ClaimsRepository _claimRepo = new ClaimsRepository();
        private int input;
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();
        public void Start()
        {
            SeedMenuList();
            Title = "Komodo Insurance";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"
 _   __                          _         _____                                         
| | / /                         | |       |_   _|                                        
| |/ /  ___  _ __ ___   ___   __| | ___     | | _ __  ___ _   _ _ __ __ _ _ __   ___ ___ 
|    \ / _ \| '_ ` _ \ / _ \ / _` |/ _ \    | || '_ \/ __| | | | '__/ _` | '_ \ / __/ _ \
| |\  \ (_) | | | | | | (_) | (_| | (_) |  _| || | | \__ \ |_| | | | (_| | | | | (_|  __/
\_| \_/\___/|_| |_| |_|\___/ \__,_|\___/   \___/_| |_|___/\__,_|_|  \__,_|_| |_|\___\___|
                                                                                                                                                                               
Hello Employee of Komodo Insurance. Please enter Desired Course of action.";
            string[] options = { "See all Claims", "Take care of next claim", "Add claim", "Exit" };
            Selection mainMenu = new Selection(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunSeeItems();
                    break;
                case 1:
                    RunDeleteItems();
                    break;
                case 2:
                    RunAddItems();
                    break;
                case 3:
                    RunExit();
                    break;

            }
        }
        private void RunSeeItems()
        {
            Clear();
            Queue<Claims> listOfClaims = _claimRepo.GetClaims();

            foreach (Claims claim in listOfClaims)
            {
                WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is it valid: {claim.IsValid}");
            }
            WriteLine("Press any key to continue");
            ReadKey();
            RunMainMenu();
        }
        private void RunSeeItems1()
        {
            Clear();
            Queue<Claims> listOfClaims = _claimRepo.GetClaims();

            foreach (Claims claim in listOfClaims)
            {
                WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is it valid: {claim.IsValid}");
            }
        }

        private void RunDeleteItems()
        {
            Clear();
            Claims claim = _claimRepo.Peek();
            WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is it valid: {claim.IsValid}");
            WriteLine("Would you like to take care of this claim (y/n)");

            string number = ReadLine();

            if (number == "y")
            {
                WriteLine("Claim Taken Care of.");
                _ = _claimRepo.Dequeue();
            }
            else
            {
                WriteLine("Claim not taken Care of.");
            }
            RunMainMenu();
        }
        private void RunAddItems()
        {
            Clear();
            Claims newclaim = new Claims();
            //ClaimID
            WriteLine("Enter Claim ID");
            string claimIdString = ReadLine().Trim();
            newclaim.ClaimID = int.Parse(claimIdString);
            //Claim Type
            WriteLine("Enter the Claim Type Number:\n" +
                "1. Home\n" +
                "2. Theft\n" +
                "3. Car");
            string claimTypeAsString = ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newclaim.TypeOfClaim = (ClaimType)claimTypeAsInt;
            //Description
            WriteLine("Enter Claim Description:");
            newclaim.Description = ReadLine().Trim();
            //Claim Amount
            WriteLine("Enter Claim Amount:");
            string claimAmountString = ReadLine().Trim();
            newclaim.ClaimAmount = double.Parse(claimAmountString);
            //Date Of Incident
            WriteLine("Enter Date Of Incident:");
            string dateOfIncidentString = ReadLine().Trim();
            newclaim.DateOfIncident = DateTime.Parse(dateOfIncidentString);
            //Date Of Claim
            WriteLine("Enter Date Of Claim");
            string DateOfClaimString = ReadLine().Trim();
            newclaim.DateOfClaim = DateTime.Parse(DateOfClaimString);
            //Is Valid
            WriteLine("Is the claim valid? (y/n)");
            string isValidString = ReadLine().Trim();

            if(isValidString == "y")
            {
                newclaim.IsValid = true;
            }
            else
            {
                newclaim.IsValid = false;
            }

            _claimRepo.AddClaimToList(newclaim);
            _queueOfClaims.Enqueue(newclaim);

            RunMainMenu();
        }
        private void RunExit()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void SeedMenuList()
        {
            Claims daryl = new Claims(1, ClaimType.Home, "House burned down in fire", 400, new DateTime(2015, 12, 25), new DateTime(2016, 02, 10), true);
            Claims sandra = new Claims(2, ClaimType.Theft, "House broken into, valuables taken", 500, new DateTime(2021, 03, 13), new DateTime(2021, 04, 30), false);
            Claims parker = new Claims(3, ClaimType.Car, "Car broke down in desert", 200, new DateTime(2000, 01, 01), new DateTime(2021, 10, 17), false);
            _queueOfClaims.Enqueue(daryl);
            _queueOfClaims.Enqueue(sandra);
            _queueOfClaims.Enqueue(parker);
            _claimRepo.AddClaimToList(daryl);
            _claimRepo.AddClaimToList(sandra);
            _claimRepo.AddClaimToList(parker);
        }
    }
}
