using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    //Staic class declaration
    
    
    public static class Operations
    {
        //List for storing user data and donation details
        static List<UserDetails> userDetailsList=new List<UserDetails>();
        static List<DonationDetails> donationDetailsList=new List<DonationDetails>();
        static UserDetails currentLoggedIndonar;

    //Main Menu
    public static void MainMenu()
    {
        //flag torn the loop
        bool mainFlag=true;
        do{

       
       /*************************************************************/
        System.Console.WriteLine(" 1.User Registration \n 2.User Login \n 3.Fetch Donor Details \n 4.Exit");
        //Main menu option
        int mainMenuOption=int.Parse(Console.ReadLine());
         
         switch(mainMenuOption)
         {
            case 1:
            {
                //method call for Donarregistration
                DonarRegistration();
                break;
            }
            case 2:
            {
                //Method call for Donar Login
                DonarLogin();
                break;
            }
            case 3:
            {
                //Method call to fetch donar details
                FetchDonarDetails();
                break;
            }
            default:
            {
                break;
            }
         }
             }while(mainFlag);
        }     
     
    //Donar Registration
    static void DonarRegistration()
    {
        	//Donor Name	Mobile Number	Blood GroupAge Last Donation
            /*********************************************************************/
            System.Console.Write("Donor Name :");
            string donarName=Console.ReadLine();
            System.Console.Write("Mobile Number: ");
            string mobileNumber=Console.ReadLine();
            System.Console.Write("Enter BloodGroup eg A_Positive : ");
            BloodGroup  bloodGroup=Enum.Parse<BloodGroup>(Console.ReadLine(),true);
            System.Console.Write("enter age :");
            int age=int.Parse(Console.ReadLine());
            System.Console.Write("Enter Lastdonation date ad dd/MM/yyyy format : ");
            DateTime lastDateDonation=DateTime.ParseExact(Console.ReadLine(),"d/MM/yyyy",null);

            UserDetails donar=new UserDetails(donarName,mobileNumber,bloodGroup,age,lastDateDonation);
            userDetailsList.Add(donar);
            System.Console.WriteLine(donar.BloodGroup);
            System.Console.WriteLine("user Registration successful user id is "+donar.DonarID);
            

    }//Registration ends

    //Donar Login
    static void DonarLogin()
    {
        bool subFlag=false;
       System.Console.Write("Enter DonarID : ");
       string loginID=Console.ReadLine();
       foreach(UserDetails donar in userDetailsList)
       {
        if(loginID.Equals(donar.DonarID))
        {
             subFlag=true;
             currentLoggedIndonar=donar;
             System.Console.WriteLine("Logged in successful");
             //SubMenu
             SubMenu();
             break;

        }

       }
       if(subFlag==false){
        System.Console.WriteLine("you are not valid Donar");
       }
    }//Login ends
    //Fetch Donar deatails method
    static void FetchDonarDetails()
    {
        bool flag=false;
        System.Console.WriteLine("Enter Blood Group");
        BloodGroup bloodGroup=Enum.Parse<BloodGroup>(Console.ReadLine());
        foreach(DonationDetails donation in donationDetailsList)
        {
            if(donation.BloodGroup.Equals(bloodGroup))
            {
                foreach(UserDetails donar in userDetailsList)
                {
                    flag=true;
                  if(donar.BloodGroup.Equals(bloodGroup)){
                    System.Console.WriteLine($"Donar name :{donar.DonarName} Donar phonenumber :{donar.MobileNumber}");
                  }
                }
            }
        }
        if(flag==false)
        {
            System.Console.WriteLine("No donar found");
        }
    }//Fetch donar details ends
 //Submenu
    static void SubMenu( )
    {
        bool subFlag=true;
        do{
 
        System.Console.WriteLine("1.Donate Blood \n2.Donation History \n3.Next Eligible Date \n4.Exit");
        int subOption=int.Parse(Console.ReadLine());
        switch(subOption)
        {
            case 1:
            {
                DonateBlood();
                break;
            }
            case 2:{
                DonationHistory();
                break;
            }
            case 3:
            {
                NextEligibleDate();
                break;
            }
            default:
            {
                System.Console.WriteLine("enter a valid option");
                break;
            }
        }

        }while(subFlag==true);
    }//SubMenu ends
   //Donate blood method
    static void DonateBlood()
    {
        System.Console.WriteLine("enter Your Weight");
        double weight=Convert.ToDouble(Console.ReadLine());
        System.Console.WriteLine("enter Your Bloodpressure level");
        double bloodPressure=Convert.ToDouble(Console.ReadLine());
        System.Console.WriteLine("Enter your Hemoglobin Count");
        double hemoglobinCount=Convert.ToDouble(Console.ReadLine());

        if(weight>50 && hemoglobinCount>13 && bloodPressure>130 )
        {
            System.Console.WriteLine(currentLoggedIndonar.LastDonation.AddMonths(6));
            if(currentLoggedIndonar.LastDonation.AddMonths(6)<DateTime.Now)
            {
                DonationDetails donar = new DonationDetails(currentLoggedIndonar.DonarID, DateTime.Now, weight, bloodPressure, hemoglobinCount, currentLoggedIndonar.BloodGroup);
                currentLoggedIndonar.LastDonation=DateTime.Now;
                donationDetailsList.Add(donar);
                System.Console.WriteLine("donation Successful \n  your donation id is"+donar.DonarID);
                System.Console.WriteLine("your next eligible date of donation is "+currentLoggedIndonar.LastDonation.AddMonths(6).ToLongDateString());

            }
            else{
                System.Console.WriteLine("you are not eligble donar");
            }

        }
        else{
            System.Console.WriteLine("youre not a eligible donar");

        }

    }//Danate blood ends
    //Donation history method
        static void DonationHistory()
        {
            bool flag = false;
            System.Console.WriteLine("DonationID	|DonarID|	DonationDate|	Weight|	BloodPressure	|HBCount	|Blood Group");
 
            foreach (DonationDetails details in donationDetailsList)
            {
                
                if (currentLoggedIndonar.DonarID.Equals(details.DonarID))
                {
                    flag = true;
                    
                    
                        System.Console.WriteLine($"{details.DonationID} |{details.DonarID}|{details.DonationDate.ToString("dd/MM/yyyy")}|{details.Weight}|{details.BloodPressure}| {details.HemoglobinCount}|{details.BloodGroup}");

                    
                }
            }
            if(flag==false)
            {
                Console.WriteLine("no donation history found");
            }
        }//Donation History ends
        //Method to check next eligible date
        static void NextEligibleDate()
        {
             System.Console.WriteLine("your next eligible date of donation is "+currentLoggedIndonar.LastDonation.AddMonths(6).ToString("dd/MM/yyyy"));

        }//Check Eligiblity Ends

        //DefaultData
        public static void DefaultData()
        {
            /* DonorID	DonarName	Mobile	BloodGroup	Age	Last Donation Date
             UID1001	Ravichandran	8484848	O_Positive	30	25/08/2022
             UID1002	Baskaran	4747447	AB_Positive	30	30/09/2022*/

            UserDetails user1 = new UserDetails("Ravichandran", "8484848", BloodGroup.O_Positive, 30, new DateTime(2022, 08, 25));
            UserDetails user2 = new UserDetails("	Baskaran", "	4747447", BloodGroup.AB_Positive, 30, new DateTime(2022,09,30));

            userDetailsList.AddRange(new List<UserDetails>{user1,user2});

            /* DID1001	UID1001	10/06/2022	73	120	14	O_Positive
                DID1002	UID1001	10/10/2022	74	120	14	O_Positive
                DID1003	UID1002	11/07/2022	74	120	13.6	AB_Positive*/

            DonationDetails donar1 = new DonationDetails("UID1001", new DateTime(2022, 06, 10), 73, 120, 14, BloodGroup.O_Positive);
            DonationDetails donar2 = new DonationDetails("UID1001", new DateTime(2022, 10, 10), 74, 120, 14, BloodGroup.O_Positive);

            DonationDetails donar3 = new DonationDetails("UID1002", new DateTime(2022, 07, 11), 74, 120, 13.6, BloodGroup.AB_Positive);
            donationDetailsList.AddRange(new List<DonationDetails>{donar1,donar2});
            
            //  Console.WriteLine(" DonorID	|DonarName|	Mobile|	BloodGroup|	Age	|Last Donation Date");
            // foreach(UserDetails user in userDetailsList)
            // {
            //     System.Console.WriteLine($"{user.DonarID} | {user.DonarID} | {user.MobileNumber}|{user.BloodGroup}|{user.Age}|{user.LastDonation}");

                
            // }
            // System.Console.WriteLine("DonationID	|DonarID|	DonationDate|	Weight|	BloodPressure	|HBCount	|Blood Group");


            // foreach(DonationDetails donar in donationDetailsList)
            // {
            //     System.Console.WriteLine($"{donar.DonationID} |{donar.DonarID}|{donar.DonationDate}|{donar.Weight}|{donar.BloodPressure}| {donar.HemoglobinCount}|{donar.BloodGroup}");
        

            // }



        }


    }
 
    
}//Default Ends