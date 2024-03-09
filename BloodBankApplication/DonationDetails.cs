using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    
    public class DonationDetails
    {
// 	Donation ID (Auto increment - DID1001)
// 	Donor Id
// 	Donation Date
// 	Weight
// 	Blood Pressure
// 	Hemoglobin Count (above 13.5)
// 	Blood Group – (Enum – A_Positive, B_Positive, O_Positive, AB_Positive)

    //Field  
    //Static field

    private static int  s_donationID=2000;

    //Property
    public string DonarID{get;} //ReadOnly Property
    public string  DonationID { get; set; }
    public DateTime DonationDate { get; set; }
    public double Weight { get; set; }
    public double  BloodPressure { get; set; }
    public double HemoglobinCount { get; set; }
    public BloodGroup BloodGroup{get;set;}
//Constructor
    public DonationDetails(string donarID,DateTime donationDate,double weight,double bloodPressure,double hemoglobinCount, BloodGroup bloodGroup)
    {
          s_donationID++;
          DonarID=donarID;
          DonationID="DID"+s_donationID;
          DonationDate=donationDate;
          Weight=weight;
          BloodPressure=bloodPressure;
          HemoglobinCount=hemoglobinCount;
          BloodGroup=bloodGroup;

    }

    }
}