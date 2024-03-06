using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillCalculation
{
    public class UserDetails
    {
        //Meter id for accessing user -Auto generated-
        private static int _meterId=1000;


        private double _totalBillAmmount=0;
        private int _unitsUsed=0;

        public string UserName { get; set; }

        public long PhoneNumber { get; set; }

        public string MailID { get; set; }

        public string MeterID { get;  }

        public int UnitsUsed{get{return _unitsUsed;}}//read only property

        public double  TotalBillAmmount{ get{return _totalBillAmmount;}  } //read only

        public void BillCalculation(int units)
        {
            
            _unitsUsed=units;
             _totalBillAmmount=(double)units*5;
             
           
        }


        public UserDetails()
        {

        }

        public UserDetails(string firstname,long phoneNumber,string mailID)
        {
            _meterId++;
            MeterID="EB"+_meterId;
            UserName=firstname;
            PhoneNumber=phoneNumber;
            MailID=mailID;
        }

        


    }
}