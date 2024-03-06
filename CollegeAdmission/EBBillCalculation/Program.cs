using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Serialization;
namespace EBBillCalculation
{
    public class Program
    {
       static List<UserDetails> userDetailsList =new List<UserDetails>();
        public static void Main(string[] args)
        {
            //Method for Accessing all modules
            MainMenu();
        }
        //Main menu which contains all options for user
        static void MainMenu()
        {
            int option;
            do{
                 System.Console.WriteLine("Enter 1 for Registration");
                 System.Console.WriteLine("Enter 2 for Login ");
                 System.Console.WriteLine("enter 3 for Exit");
                 option=int.Parse(Console.ReadLine());

                 switch(option)
                 {

                    case 1:
                           {
                            Registration();
                            break;
                           }
                    case 2:
                          {
                            Login();
                            break;
                          }
                 }
                 
               } while(option!=3); 
        }
        //Method  for Registering new user
        static void Registration()
        {
            System.Console.Write("Enter firstname : ");
            string firstname=Console.ReadLine();
            
            System.Console.Write("Enter Mobile Number : ");
            long mobileNumber=Convert.ToInt64(Console.ReadLine());

            System.Console.Write("Enter Mail Id");
            string mailID=Console.ReadLine();

            UserDetails details=new UserDetails(firstname,mobileNumber,mailID);
            userDetailsList.Add(details);

            Console.WriteLine("Registration successfull");    
            Console.WriteLine("your Meter Id is"+details.MailID);

        }
        static void Login()
        {
            System.Console.Write("Enter your MeterID: ");
            string registrationID=Console.ReadLine();
            int flag=0;
            UserDetails user=new UserDetails();
            foreach(UserDetails details in userDetailsList)
            {
                if(registrationID.Equals(details.MeterID))
                {
                    user=details;
                    flag=1;
                    break;
                }
            }
            if(flag==1)
            {
                 int choice;
                    
                 do{
                    System.Console.WriteLine("***********************");
                    System.Console.WriteLine("Enter 1 Calculate Ammount");
                    System.Console.WriteLine("Enter 2 for Printing User details");
                    System.Console.WriteLine("Enter 3 for Exit");
                    choice=int.Parse(Console.ReadLine());
                   
                    switch(choice)
                    {
                        case 1:
                        {
                            Console.WriteLine("enter no of units used");
                            int units=int.Parse(Console.ReadLine());
                            user.BillCalculation(units);
                            Console.WriteLine("user id :"+user.MeterID);
                             Console.WriteLine("username id :"+user.UserName);
                              Console.WriteLine("units  used :"+user.UnitsUsed);
                               Console.WriteLine("Total Bill Ammount :"+user.TotalBillAmmount);
                            break;
                        }
                        case 2:
                        {
                            System.Console.WriteLine("User Details");
                            Console.WriteLine("user id :"+user.MeterID);
                             Console.WriteLine("username name :"+user.UserName);
                             Console.WriteLine("phonenumber :"+user.PhoneNumber);
                             Console.WriteLine("mail id :"+user.MailID);
                             break;

                        }

                    }
                

                 }while(choice!=3);

            }
            else{
                Console.WriteLine("Invalid user");
            }
        }


}
}