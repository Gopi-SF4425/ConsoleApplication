using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynfusionLibrary
{
    public enum Status {Select,Borrowed,Returned}
    //Borrrow details class

    public class BorrowDetails
    {
        /*
        •	BorrowID (Auto Increment – LB2000)
        •	BookID 
        •	UserID
        •	BorrowedDate – ( Current Date and Time )
        •	BorrowBookCount 
        •	Status –  ( Enum - Default, Borrowed, Returned )
         •	PaidFineAmount
*/
    //Field
    //Static Field
    private static int _borrowID=2000;

    private double _fineAmmount;//private field

    //Property
    public string  BorrowID { get;  }//read nly Property
    public string BookID { get; set; }
    public string UserID { get; set; }
    public DateTime BorrowDate { get; set; }
    public int BorrowBookCount { get; set; }
    public Status Status { get; set; }
    public double PaidFineAmount { get{return _fineAmmount;} } //ReadOnly property

    //Constructor
    public BorrowDetails(string bookID,string userID,DateTime borrowdate,int borrowCount,Status status)
    {
        ++_borrowID;
        BorrowID="LB"+_borrowID;
        BookID=bookID;
        UserID=userID;
        BorrowDate=borrowdate;
        BorrowBookCount=borrowCount;
        Status=status;

    }
    public void AddFineAmmount(double ammount)
    {
        _fineAmmount+=ammount;
    }
    }
}