using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    public enum BloodGroup{Select,A_Positive, B_Positive, O_Positive, AB_Positive}
    //user details class
    public class UserDetails
    {
        /*
        a.	Donor Name
        b.	Mobile Number
        c.	Blood Group
        d.	Age
        e.	Last Donation

        */

        //Field
        //Static field
        private static int s_donarID=1000;
        //Property
        public string  DonarID { get;}//Read only property
        public string DonarName { get; set; }
        public string MobileNumber { get; set; }
        public BloodGroup BloodGroup{ get; set; }
        public int Age { get; set; }
        public DateTime LastDonation { get; set; }


        //Constructor
        public UserDetails(string userName,string MobileNumber,BloodGroup bloodGroup,int age,DateTime lastDonation)
        {
            ++s_donarID;
            DonarID="UID"+s_donarID;
            DonarName=userName;
            BloodGroup=bloodGroup;
            Age=age;
            LastDonation=lastDonation;


        }

    }
}