using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace SynfusionLibrary
{
    //static class declaration
    public class Operations
    {
        //Lists  to Store Details
        static List<UserDetails> userDetailsList=new List<UserDetails>();
        static List<BookDetails> bookDetailsList=new List<BookDetails>();

        static List<BorrowDetails> borrowDetailsList=new List<BorrowDetails>();

        //CurrentLoggedInuser
        static UserDetails currentLoggedInUser;
       //Main Menu
        public static void MainMenu()
        {
            //Main flag
            bool mainFlag=true;
            do{

            
            //Main MenuOption
            System.Console.WriteLine("*****************************************************");
            System.Console.Write(" 1.UserRegistration \n 2.UserLogin \n 3.Exit \n Select an Option: ");
            //Main Option
            int mainOption=int.Parse(Console.ReadLine());
            switch(mainOption)
            {
                case 1:

                {
                    UserRegistration();
                    break;
                }
                case 2 :
                {
                    UserLogin();
                   break;
                }
                case 3 :
                {
                    mainFlag=false;
                    break;
                }
                default :
                {
                    System.Console.WriteLine("Enter a Valid option");
                    break;
                }

            }
            }while(mainFlag==true);

        }
        
        //UserRegistration
        public static void UserRegistration()
        {
            System.Console.Write("UserName: ");
            string userName=Console.ReadLine();
            
            System.Console.Write("Gender:as eg 'Male' or 'Female' :");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine());
            System.Console.Write("Department as 'eg' CSE :" );
            Department department=Enum.Parse<Department>(Console.ReadLine());
            System.Console.Write("MobileNumber: ");
            string mobileNumber=Console.ReadLine();
            
            System.Console.Write("MailID ");
            string mailID=Console.ReadLine();
            
            System.Console.WriteLine("enter ammount to recharge in wallet balance");
            double balance=Convert.ToDouble(Console.ReadLine());

            UserDetails user=new UserDetails(userName,gender,department,mobileNumber,mailID);
            user.WalletRecharge(balance);

            userDetailsList.Add(user);
            System.Console.WriteLine("Registration successfull \n Your UserID is "+user.UserID);

        }//Registraiton end

        //User Login
        public static void UserLogin()
        {
            bool flag=true;
            System.Console.Write("enter userId: ");
            string loginID=Console.ReadLine();
            foreach(UserDetails user in userDetailsList)
            {
               if(user.UserID.Equals(loginID))
               {
                flag=false;
                System.Console.WriteLine("Login successfull");
                currentLoggedInUser=user;
                //SubMenuOption
                SubMenu();

                break;

               }
            }
            if(flag==true)
            {
                System.Console.WriteLine("Invalid User");
            }
        }

        //SubMenu
        public static void SubMenu()
        {
            bool subFlag=true;
            do{

            System.Console.WriteLine("********************************************************")
;
            System.Console.WriteLine(" 1.Borrowbook \n 2.ShowBorrowedhistory \n 3.ReturnBooks \n 4.WalletRecharge \n 5.Exit \n Select an option");
            int subOption=int.Parse(Console.ReadLine());
            switch(subOption)
            {
                case 1:
                {
                    //Borrow Book Method
                    BorrowBook();
                    break;
                }
                case 2:
                {
                    //BorrowedHistory
                    ShowBorrowedHistory();
                    break;
                }
                case 3:
                {
                    //Return Books
                    ReturnBooks();
                    break;
                }
                case 4:
                {
                    //WalletRecharge Method
                    WalletRecharge();
                    break;
                }
                case 5 :
                {
                    subFlag=false;
                    break;
                }
                default :
                {
                    break;
                }
            }
            }while(subFlag==true);
            
        }
       //Borrow Book Method
       static void BorrowBook()
       {
        //Book Details
        foreach(BookDetails book in bookDetailsList)
               {
                 System.Console.WriteLine($" BoodId :{book.BookID}   | bookName: {book.BookName}   | Author Name:{book.AuthorName}  | BookCount: {book.BookCount}");
               }
        System.Console.Write("Enter Book ID to borrow : ");
        string bookID=Console.ReadLine();
        
        //Check bookid is available or not
        bool flag=true;

        foreach(BookDetails book in bookDetailsList)
        {
            //Check book id is present or not
            if(bookID.Equals(book.BookID))
            {
              flag=false;
              System.Console.Write("Enter the Count of books needed");
              int bookCount=int.Parse(Console.ReadLine());
              //check book count is available
              if(bookCount<=book.BookCount)
              {
                int count=0;
                //Count the books borrowed by user
                foreach(BorrowDetails borrow in borrowDetailsList)
                {
                    if(borrow.UserID.Equals(currentLoggedInUser) &&  borrow.Status==Status.Borrowed)
                    {
                        count+=borrow.BorrowBookCount;
                    }

                }
                //To check needed book count phus already availabe book count is less than 3
                if(count>=3){
                  System.Console.WriteLine("You have borrowed 3 books already”.");
                }
                else if(count+bookCount>3)
                {
                  System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {count} and requested count is {bookCount}, which exceds 3 ”.");
                }
                else{
                    BorrowDetails borrow=new BorrowDetails(bookID,currentLoggedInUser.UserID,DateTime.Now,bookCount,Status.Borrowed);
                    borrow.AddFineAmmount(0);
                    borrowDetailsList.Add(borrow);
                    book.BookCount-=borrow.BorrowBookCount;
                    System.Console.WriteLine("Book Borrowed Successfully");

                }


              }
              else{
                System.Console.WriteLine("Books are not available for the selected count ");
              }


            }
        }
        if(flag==true)
        {
            System.Console.WriteLine("Invalid Book ID Please enter valid ID");
        }
        


       }
        //ShowBorrowed HIstory MEthod
        static void ShowBorrowedHistory()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoggedInUser.UserID.Equals(borrow.UserID) && borrow.Status==Status.Borrowed)
                {
                    flag = false;

                    System.Console.WriteLine($"BorrowID: {borrow.BorrowID}	|BookID: {borrow.BookID} |	UserID:{borrow.UserID}	|BorrowedDate:{borrow.BorrowDate.ToString("dd//MM/yyyy")}	BorrowBookCount	:{borrow.BorrowBookCount}| Status:{borrow.Status}|	PaidFineAmount{borrow.PaidFineAmount}");

                }

            }
            if(flag==true)
            {
                System.Console.WriteLine("NO Book borrow History Found");
            }
        }//Show Borrowed History Ends
        
        //Return Books Method
        static void ReturnBooks()
        {
             bool localFlag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoggedInUser.UserID.Equals(borrow.UserID) && borrow.Status==Status.Borrowed)
                {
                    localFlag = false;

                    System.Console.WriteLine($"BorrowID: {borrow.BorrowID}	|BookID: {borrow.BookID} |	UserID:{borrow.UserID}	|BorrowedDate:{borrow.BorrowDate.ToString("dd//MM/yyyy")}	BorrowBookCount	:{borrow.BorrowBookCount}| Status:{borrow.Status}|	PaidFineAmount{borrow.PaidFineAmount}");

                }

            }
            if(localFlag==true)
            {
                System.Console.WriteLine("NO Book borrow History Found");
            }
            bool flag = true;
            //TO Check wheather book is present are not
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                //To check wheather status is boorowed
                if (currentLoggedInUser.UserID.Equals(borrow.UserID) && borrow.Status==Status.Borrowed)
                {
                    flag = false;

                    
                    DateTime returnDate=borrow.BorrowDate.AddDays(15);
                    //To calculate fine amount
                    double fineAmount=0;
                    if(DateTime.Now>returnDate)
                    {
                        TimeSpan timeDifference=DateTime.Now-returnDate;
                         fineAmount=timeDifference.Days*1;

                    }
                    System.Console.WriteLine("Fine ammount :"+fineAmount);
                    //System.Console.WriteLine($"BorrowID: {borrow.BorrowID}	|BookID: {borrow.BookID} |	UserID:{borrow.UserID}	|BorrowedDate:{borrow.BorrowDate.ToString("dd//MM/yyyy")}	BorrowBookCount	:{borrow.BorrowBookCount}| Status:{borrow.Status}|	PaidFineAmount{borrow.PaidFineAmount} | ReturnDate {borrow.BorrowDate.AddDays(15).ToString("dd/MM/yyyy")} | FineAmount need to be paid {fineAmount}");
                    System.Console.Write("Enter Borrowed ID: ");
                    string borrowID=Console.ReadLine();

                    foreach(BorrowDetails borrow1 in borrowDetailsList )
                    {
                        if(borrowID.Equals(borrow1.BorrowID))
                        {
                           
                            if(borrow1.BorrowDate.AddDays(15)<DateTime.Now)

                            {
                                DateTime returnDate1 = borrow1.BorrowDate.AddDays(15);
                                //To calculate fine amount
                                double fineAmount1 = 0;
                                if (DateTime.Now > returnDate)
                                {
                                    TimeSpan timeDifference = DateTime.Now - returnDate1;
                                    fineAmount1 = timeDifference.Days * 1;

                                }
                                //check wheather wallet as sufficient balance

                                if (currentLoggedInUser.WalletBalance>fineAmount)
                                {
                                    currentLoggedInUser.WalletWithdraw(fineAmount1);
                                    System.Console.WriteLine("fine ammount deducted");
                                    borrow1.Status=Status.Returned;
                                    System.Console.WriteLine("book Returned Successfully");
                                    
                                    
                                    foreach(BookDetails book in bookDetailsList)
                                    {
                                        if(borrow1.BookID==book.BookID)
                                        {
                                          book.BookCount+=borrow1.BorrowBookCount;

                                        }
                                    }
                                    borrow1.BorrowBookCount=0;
                                    break;
                                }
                                else{
                                    System.Console.WriteLine("Wallet Balance if less recharge wallet balace first");
                                }

                            }
                        }
                    }



                }

            }
            if(flag==true)
            {
                System.Console.WriteLine("NO Book borrow History Found");
            }


            
        }

            //Wallet Recharge

            static void WalletRecharge()
        {
            System.Console.Write("Enter the Amount to be Recharged: ");
            double ammount=Convert.ToDouble(Console.ReadLine());
            currentLoggedInUser.WalletRecharge(ammount);
            System.Console.WriteLine("Wallet Recharge Successful");
        }
        //Default data
        public static void DefaultData()
        {
            /*
               SF3001	Ravichandran 	Male	EEE	9938388333	ravi@gmail.com 100
               SF3002	Priyadharshini	Female	CSE	9944444455	priya@gmail.com 150

               */

               UserDetails user1=new UserDetails("Ravichandran",Gender.Male, Department.EEE,"99383883330","ravi@gmail.com");
               user1.WalletRecharge(100);
                UserDetails user2=new UserDetails("Priyadharshini",Gender.Female, Department.CSE,"9944444455","priya@gmail.com");
               user2.WalletRecharge(150);

               userDetailsList.Add(user1);
               userDetailsList.Add(user2);

              /* BID1001	C# 	Author1	3
              BID1002	HTML	Author2	5
              BID1003	CSS	Author1	3
              BID1004	JS	Author1	3
              BID1005	TS	Author2	2
              */

              BookDetails book1=new BookDetails("C#","Author1",	3);
              BookDetails book2=new BookDetails("HTML","Author2",5);
              BookDetails book3=new BookDetails("CSS","Author1",3);
              BookDetails book4=new BookDetails("JS","Author1",3);
              BookDetails book5=new BookDetails("TS","Author2",	2);

              bookDetailsList.Add(book1);
              bookDetailsList.Add(book2);
              bookDetailsList.Add(book3);
              bookDetailsList.Add(book4);
              bookDetailsList.Add(book5);

              /*
              LB2001	BID1001	SF3001	10/09/2023	2	Borrowed	0
              LB2002	BID1003	SF3001	12/09/2023	1	Borrowed	0
              LB2003	BID1004	SF3001	14/09/2023	1	Returned	16
              LB2004	BID1002	SF3002	11/09/2023	2	Borrowed	0
              LB2005	BID1005	SF3002	09/09/2023	1	Returned	20
              */
              BorrowDetails borrow1=new BorrowDetails("BID1001","SF3001",new DateTime(2023,09,10),2,Status.Borrowed);
              borrow1.AddFineAmmount(0);
              BorrowDetails borrow2=new BorrowDetails("BID1003"	,"SF3001",new DateTime(2023,09,12),1,Status.Borrowed);
              borrow2.AddFineAmmount(0);
              BorrowDetails borrow3=new BorrowDetails("BID1004","SF3001",new DateTime(2023,09,14),1,Status.Returned);
              borrow3.AddFineAmmount(16);
              BorrowDetails borrow4=new BorrowDetails("BID1002"	,"SF3002",new DateTime(2023,09,11),2,Status.Borrowed);
              borrow4.AddFineAmmount(0);
              BorrowDetails borrow5=new BorrowDetails("BID1005","SF3002",new DateTime(2023,09,09),	1,Status.Returned);
              borrow5.AddFineAmmount(20);

              borrowDetailsList.Add(borrow1);
              borrowDetailsList.Add(borrow2);
              borrowDetailsList.Add(borrow3);
              borrowDetailsList.Add(borrow4);
              borrowDetailsList.Add(borrow5);

            //   foreach(UserDetails user in userDetailsList)
            //   {
            //     System.Console.WriteLine($"UserId: {user.UserID} | UserName: {user.UserName} | Gender: {user.Gender} Department: {user.Department} | mobile number {user.MobileNumber} |MailId: {user.MailID}");
            //   }
            //   foreach(BookDetails book in bookDetailsList)
            //   {
            //     System.Console.WriteLine($" BoodId :{book.BookID} | bookName: {book.BookName} | Author Name:{book.AuthorName}| BookCount: {book.BookCount}");
            //   }

            //   foreach(BorrowDetails borrow in borrowDetailsList)
            //   {
            //     System.Console.WriteLine($"BorrowID: {borrow.BorrowID}	|BookID: {borrow.BookID} |	UserID:{borrow.UserID}	|BorrowedDate:{borrow.BorrowDate.ToString("dd//MM/yyyy")}	BorrowBookCount	:{borrow.BorrowBookCount}| Status:{borrow.Status}|	PaidFineAmount{borrow.PaidFineAmount}");
            //   }




        }
        
    }
}