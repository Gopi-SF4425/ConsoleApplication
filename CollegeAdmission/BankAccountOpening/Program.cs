using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
namespace BankAccountOpening
{
    
    public class  Program
    {
        //List for storing multiple customer objects 
        static List<CustomerDetails> customersList=new List<CustomerDetails>();
        public static void Main(string[] args)
        {
            //Entry method
            Banking();
        }

        //method for dealing with all banking modules     
        static void Banking()
        {
            
            int option;
            do{
                System.Console.WriteLine("**************************");
                System.Console.WriteLine("Enter 1 for Registration");
                System.Console.WriteLine("Enter 2 for Login");
                System.Console.WriteLine("Enter 3 for Exit ");
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
                        CustomerLogin();
                        break;
                    }
                    
                }
            }while(option!=3);
        }


        //Registration Module
        static void Registration()
        {

            // details to be entered name,gender,mobile number, mailid,dob
            System.Console.Write("Enter your Name: ");
            string customerName=Console.ReadLine();

            System.Console.Write("Enter your Gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.Write("Enter your Mobile number : ");
            long mobileNumber=Convert.ToInt64(Console.ReadLine());

            System.Console.Write("Enter your Mail id : ");
            string mailID=Console.ReadLine();
            
            System.Console.Write("Enter your Date of Birth in 'dd/MailMessage/yyyy' format: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

           //calling parameter constructor to assign values
            CustomerDetails customer=new CustomerDetails(customerName,gender,mobileNumber,mailID,dob);     
            //adding the new customer to the list
            Program.customersList.Add(customer);

            Console.WriteLine($"Registration Successfull /n Your CustomerID is {customer.CustomerID}");
      }
              //Login Module
              static void CustomerLogin()
              {
                        System.Console.Write("Enter your CustomerID: ");
                        string registrationID=Console.ReadLine();
                        int choice;
                        if(Login(registrationID))
                        {
                           
                           CustomerDetails customerDetail=new CustomerDetails();
                           //iterating every customer in the list to find the desired customer
                            foreach(CustomerDetails details in customersList)
                            {
                                if(registrationID.Equals(details.CustomerID))
                                {
                                     customerDetail=details;
                                     break;
                                }
                            }
                            do{
                            Console.WriteLine("*********************************");
                             Console.WriteLine("Enter 1 for Deposit");
                            System.Console.WriteLine("Enter 2 for Withdraw");
                            System.Console.WriteLine("Enter 3 Balance check");
                            System.Console.WriteLine("Enter 4 for Exit");

                            choice=int.Parse(Console.ReadLine());
                            switch(choice)
                            {
                                case 1:
                                {
                                    System.Console.WriteLine("Enter Ammount to be Deposited");
                                    double ammount=Convert.ToInt32(Console.ReadLine());

                                    //method call to depsosit ammount to the account
                                    customerDetail.Deposit(ammount);
                                    customerDetail.BalanceCheck();
                                    break;
                                }
                                case 2:{
                                    System.Console.WriteLine("Enter Ammount to be Withdrawn");
                                    double ammount=Convert.ToInt32(Console.ReadLine());

                                    //method call to wihdraw ammount from balance
                                    if(!customerDetail.Withdraw(ammount))
                                    {
                                        Console.WriteLine("In sufficient balance");
                                    }
                                    else{
                                    customerDetail.BalanceCheck();
                                    }
                                    break;
                                    
                                }
                                case 3:
                                {
                                    //methodcall to check balance
                                    customerDetail.BalanceCheck();
                                    break;
                                }
                            }
                        }while(choice!=4);
                        
                            
                        }
             else{
                 Console.WriteLine("Invalid User");
                 }
                 
                        
                    }
     //method to check valid customer
       static bool Login(string registrationID)
      {
        
       foreach(CustomerDetails details in customersList)
       {
        if(registrationID.Equals(details.CustomerID))
        {
            
            return true;
        }
       }
       return false;
      }
    }
}