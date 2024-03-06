using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    //enum for gender
    public enum Gender{
        Select,Male,Female
    }
    //class which contains customer details
    public class CustomerDetails
    {
        //unique id for customer
        private static int _customerID=1000;
        //balance ammount
        private double _balanceAmmount=1000;
        //cusomer name
        public string CustomerName{get;set;}
        //customer gender
        public Gender Gender{get;set;}
        //customer phone number
        public long PhoneNumber{get;set;}
        //customer mail id
        public string MailID{get;set;}
        //customer dob
        public DateTime DOB{get;set;}

        //properties for customer details
        public string CustomerID{get;}

        public double BalanceAmmount{get;}

        //Default Constructor
        public CustomerDetails()
        {

        }
        //Parameter constructor
        public CustomerDetails(string customerName,Gender gender,long phoneNumber,string mailID,DateTime dob)
        {
            _customerID++;
            CustomerID="HDFC"+_customerID;
            CustomerName=customerName;
            Gender=gender;
            PhoneNumber=phoneNumber;
            MailID=mailID;
            DOB=dob;
        }

       //withdraw method
        public bool Withdraw(double ammount)
        {
            if(_balanceAmmount-ammount<0)
            {
                return false;
            }
            _balanceAmmount-=ammount;
            return true;
        }
        //Deposit method
        public void Deposit(double ammount)
        {
            _balanceAmmount+=ammount;
        }
        //Method for checking current balance
        public void BalanceCheck()
        {
            Console.WriteLine($"Hi {CustomerName} your current Balance is :{_balanceAmmount}");
        }




        
    }
}