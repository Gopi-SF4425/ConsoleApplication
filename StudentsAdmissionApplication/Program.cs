using System;
using System.Collections.Generic;
namespace StudentsAdmissionApplication
{
    public class Program
    {

        //list tor storing student details
        static List<StudentDetails> studentDetailsList=new List<StudentDetails>();
         //list tor storing department details
        static List<DepartmentDetails> departmentDetailsList=new List<DepartmentDetails>();
         //list tor storing admission details
        static List<AdmissionDetails> admissionDetailsList=new List<AdmissionDetails>();
        public static void Main(string[] args)
        {
            //methodcall for storing default details
            DefaultStudentDetails();
            DefaultDepartmentDetails();
            DefaultAdmissiondetails();

            int option;
            do{
                System.Console.WriteLine("**************************");
                System.Console.WriteLine("Enter 1 for Registration");
                System.Console.WriteLine("Enter 2 for Login");
                System.Console.WriteLine("Enter 3 for Available seats ");
                System.Console.WriteLine("Enter 4 for Exit");
                option=int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                    {
                        StudentRegistration();  //MEthod call for Registration
                        
                        break;
                    }
                    case 2:
                    {
                        StudentLogin();        //Method call for Login
                        break;
                    }
                    case 3:
                    {
                        AvalabileSeats();  //Method call for displaying seats
                        break;   
                    }
                    
                }
            }while(option!=4);
            
        }

        //Method for Registering Student
        static void StudentRegistration()
        {
            System.Console.Write("Enter your  name : ");
             string firstName=Console.ReadLine();

             System.Console.Write("Enter your father name : ");
             string fatherName=Console.ReadLine();

            System.Console.Write("Enter your gender : ");
             Gender gender=Enum .Parse<Gender>(Console.ReadLine(),true);

            System.Console.Write("Enter your DOB as 'dd/MM/yyy' format : ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

             System.Console.Write("Enter your Physics Mark: ");
             int physicsMark=Convert.ToInt32(Console.ReadLine());

             System.Console.Write("Enter your Chemistry Mark: ");
             int chemistryMark=Convert.ToInt32(Console.ReadLine());

             System.Console.Write("Enter your Maths Mark: ");
             int mathsMark=Convert.ToInt32(Console.ReadLine());

             StudentDetails details=new StudentDetails(firstName,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            studentDetailsList.Add(details);
            System.Console.WriteLine("your registrarion successful");
            System.Console.WriteLine("your id is:"+details.StudentID);
        }
         //Method for Student Login
        static void StudentLogin()
        {
             System.Console.Write("Enter your StudentID: ");
                 string studentID=Console.ReadLine();
                  StudentDetails studentDetail=new StudentDetails();
                  int flag=0;
                  int choice;
                           //iterating every student  in the list to find the desired customer
                            foreach(StudentDetails details in studentDetailsList)
                            {
                                if(studentID.Equals(details.StudentID))
                                {
                                     studentDetail=details;
                                     flag=1;
                                     break;
                                }
                            }
                            
                            //if the student found with the user id
                            if(flag==1)
                            {

                                do{
                            Console.WriteLine("*********************************");
                             Console.WriteLine("Enter 1 Check Eligibility");
                            System.Console.WriteLine("Enter 2 for show details");
                            System.Console.WriteLine("Enter 3 TakeAdmission");
                            System.Console.WriteLine("Enter 4 for cancel Admission");
                            System.Console.WriteLine("Enter 5 for Show admission details");
                            System.Console.WriteLine("Enter 6 for Exit");

                            choice=int.Parse(Console.ReadLine());
                            switch(choice)
                            {
                                case 1:
                                {
                                     if(studentDetail.IsEligible(75.0))
                                    {
                                        Console.WriteLine("You are eligible");
                                     }
                                     else{
                                         Console.WriteLine("you are not eligible");
                                      }
              
                                    break;
                                }
                                case 2:{

                                    //Method call to display student details
                                    DisplayStudentDetails(studentDetail);
                                    break;
                                    
                                }
                                case 3:
                                {
                                    //Take Admission method

                                    TakeAdmission(studentDetail);
                                   
                                    break;
                                }
                                case 4:
                                {
                                    // cancel Admission method call
                                    CancelAdmission(studentDetail);

                                    break;
                                }
                                case 5:
                                {
                                    //show admission details method call
                                    ShowAdmissionDetails(studentDetail);
                                    break;
                                }
                                
                            }
                        }while(choice!=6);

                            }
                            else{
                                Console.WriteLine("User id does not existes");
                            }
                


        }
         //method do display student details
        static void DisplayStudentDetails(StudentDetails studentDetail)
        {
           
                                    System.Console.WriteLine("Student detals");
                                    System.Console.WriteLine("Student id:"+studentDetail.StudentID);
                                    System.Console.WriteLine("Name: "+studentDetail.StudentName);
                                    System.Console.WriteLine("Father Name: "+studentDetail.FatherName);
                                    System.Console.WriteLine("Gender "+studentDetail.Gender);
                                    System.Console.WriteLine("DOB: "+studentDetail.DOB.ToString("dd/MM/yyy"));
                                    System.Console.WriteLine("Physics mark: "+studentDetail.PhysicsMark);
                                   System.Console.WriteLine("Chemistry mark: "+studentDetail.ChemistryMark);
                                   System.Console.WriteLine("Maths Marks: "+studentDetail.MathsMark);

        }
        //Method to book an application
        static void TakeAdmission(StudentDetails studentDetail)
        {
                  foreach(DepartmentDetails department in departmentDetailsList)
                                    {
                                        Console.WriteLine($"DepartmentID ={department.DepartmentID}  DepartmentNmae = {department.Departmentname}  Number of seats available = {department.NumberOfSeats}");

                                    }
                                    Console.WriteLine("Enter the DepartmentID in whuch you want admission");
                                    string departmentID=Console.ReadLine();
                                    int flag=0;
                                    foreach(DepartmentDetails department in departmentDetailsList)
                                    {
                                        if(departmentID.Equals(department.DepartmentID))
                                        {
                                            flag=1;
                                            if(studentDetail.IsEligible(75.0))
                                            {
                                                if(department.NumberOfSeats>0)
                                                {
                                                    int check=0;
                                                    foreach(AdmissionDetails admission in admissionDetailsList)
                                                    {
                                                        if(admission.StudentID.Equals(studentDetail.StudentID))
                                                        {
                                                            check=1;
                                                            Console.WriteLine("You have already taken a seat in this college");
                                                            break;
                                                        }
                                    
                                                    }
                                                    if(check==0)
                                                    {
                                                        department.NumberOfSeats=department.NumberOfSeats-1;
                                                        AdmissionDetails admission=new AdmissionDetails(studentDetail.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Booked);
                                                        admissionDetailsList.Add(admission);
                                                        Console.WriteLine("Admission took successfully and your Admission id is "+admission.AdmissionID);
                                                    }
                                                    
                                                }
                                                else{
                                                    Console.WriteLine("Seats are available in this department");
                                                }

                                            }
                                            else{
                                                Console.WriteLine("You are not an eleigible student ! because your cutoff is less ");
                                            }
                                            break;
                                        }
                                    }
                                    if(flag==0)
                                    {
                                        Console.WriteLine("The Entered Department ID does not exists");
                                    }
        }
        // cancel admission method to cancel admission
        static void CancelAdmission(StudentDetails student)
        {
            foreach(AdmissionDetails admission in admissionDetailsList)
            {
                if(admission.StudentID.Equals(student.StudentID))
                {
                    if(admission.AdmissionStatus==AdmissionStatus.Booked)
                    {
                        Console.WriteLine("StudentId : "+admission.StudentID);
                        System.Console.WriteLine("DepartmentID :"+admission.DepartmentID);
                        System.Console.WriteLine("Admissiobn ID:"+admission.AdmissionID);
                        System.Console.WriteLine("Admission date:"+admission.AdmissionDate);
                        System.Console.WriteLine("Admission status:"+admission.AdmissionStatus);
                        admission.AdmissionStatus=AdmissionStatus.Cancelled;
                        foreach(DepartmentDetails department in departmentDetailsList)
                       {
                         if(department.DepartmentID==admission.DepartmentID)
                        {
                          department.NumberOfSeats+=1;
                        }
                     }
                     Console.WriteLine("Admission cancelled successfully");

                    }
                }
            }
        }
        //method for Displaying Admission details
        static void ShowAdmissionDetails(StudentDetails student)
        {
            int flag=0;
            foreach(AdmissionDetails admission in admissionDetailsList)
            {
                if(admission.StudentID.Equals(student.StudentID))
                {
                    if(admission.AdmissionStatus==AdmissionStatus.Booked)
                    {
                        flag=1;
                        Console.WriteLine("StudentId : "+admission.StudentID);
                        System.Console.WriteLine("DepartmentID :"+admission.DepartmentID);
                        System.Console.WriteLine("Admissiobn ID:"+admission.AdmissionID);
                        System.Console.WriteLine("Admission date:"+admission.AdmissionDate.ToString("dd/MM/yyyy"));
                        System.Console.WriteLine("Admission status:"+admission.AdmissionStatus);
                    }
                }
            }
            if(flag==0)
            {
                Console.WriteLine("The student does not booked any admission");
            }

        }

        //Method for displaying balance seats
        static void AvalabileSeats()
        {
           foreach(DepartmentDetails department in departmentDetailsList)
                                    {
                                        Console.WriteLine($"DepartmentID ={department.DepartmentID}  DepartmentNmae = {department.Departmentname}  Number of seats available = {department.NumberOfSeats}");

                                    }
        } 
        //Method for storing default details for student
        static void DefaultStudentDetails()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", DateTime.ParseExact("11/11/1999","dd/MM/yyyy",null), Gender.Male, 95, 95, 95);
            StudentDetails student12 = new StudentDetails("Baskaran S", "sethurajan", DateTime.ParseExact("11/11/1999","dd/MM/yyyy",null), Gender.Male, 95, 95, 95);
            studentDetailsList.Add(student1);
            studentDetailsList.Add(student12);
        } 

        //Method for storing default department details
        static void DefaultDepartmentDetails()
        {
            DepartmentDetails department1=new DepartmentDetails("CSE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",29);
            DepartmentDetails department4=new DepartmentDetails("ECE",29);

            departmentDetailsList.Add(department1);
            departmentDetailsList.Add(department2);
            departmentDetailsList.Add(department3);
            departmentDetailsList.Add(department4);

             

        } 

        //Method for storing default Admission details
        static void DefaultAdmissiondetails()
        {
           
            AdmissionDetails admission1=new AdmissionDetails("SF3001","DID101",DateTime.ParseExact("11/05/2022","dd/MM/yyyy",null),AdmissionStatus.Booked);
              foreach(DepartmentDetails department in departmentDetailsList)
              {
                  if(department.DepartmentID==admission1.DepartmentID)
                  {
                    department.NumberOfSeats-=1;
                  }
              }
           AdmissionDetails admission2=new AdmissionDetails("SF3002","DID102",DateTime.ParseExact("12/05/2022","dd/MM/yyyy",null),AdmissionStatus.Booked);
            foreach(DepartmentDetails department in departmentDetailsList)
              {
                  if(department.DepartmentID==admission2.DepartmentID)
                  {
                    department.NumberOfSeats-=1;
                  }
              }
            admissionDetailsList.Add(admission1);

            admissionDetailsList.Add(admission2);
        }



    }
}