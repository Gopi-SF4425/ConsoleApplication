using System;
using BloodBankApplication;
namespace BloodbankApplicaiton
{
    public class Program
    {
        //Main Program starts
        public static void Main()
        {
            //Calling defaultdata
            Operations.DefaultData();

            //Calling Mainmenu
            Operations.MainMenu();

        }
    }
}