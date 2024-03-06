using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynfusionLibrary
{
    //Enum declaration
    public enum Gender{Select,Male,Female}
    public enum Department{select,ECE,EEE,CSE}
    //class for storing user deatils
    public class UserDetails
    {
        /*
        a.	UserID (Auto Increment – SF3000)
         b.	UserName
         c.	Gender
         d.	Department – (Enum – ECE, EEE, CSE)
         e .	MobileNumber
        f.	MailID
         g.	WalletBalance

*/
      //Field
      //Static field
      private static int s_userID=3000;

      //Private field
      private double _balance;

      //Property
      public string  UserID { get;  }//Read ONly {property}
      public string  UserName { get; set; }
      public Gender Gender { get; set; }
      public Department  Department{ get; set; }
      public string MobileNumber { get; set; }
      public double WalletBalance { get{return _balance;} }
      public string MailID { get; set; }

      //Constructor 
      public UserDetails(string userNamme,Gender gender,Department department,string mobileNumber,string mailID)
      {
        ++s_userID;
        UserID="SF"+s_userID;
        UserName=userNamme;
        Gender=gender;
        Department=department;
        MobileNumber=mobileNumber;
        MailID=mailID;
      }

      public void  WalletRecharge(double amount)
      {
        _balance+=amount;
      }
      public void  WalletWithdraw(double amount)
      {
        _balance-=amount;
      }


    }
}