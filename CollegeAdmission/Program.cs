using System;
using System.Collections.Generic;
namespace CollegeAdmission
{
      class Program
      {
        public static void Main(string[] args)
        {
            GetDetails();
            
        }
        static void GetDetails()
        {

            //Listobject
            //Object Creation for StudentDetails

            List<StudentDetails> studentsList=new List<StudentDetails>();


            // StudentDetails student=new StudentDetails();
            // System.Console.WriteLine("Enter Personal Details - 1");
            // System.Console.Write("Enter your first name : ");
            // string firstName=Console.ReadLine();

            // student.FirstName=firstName;

            // System.Console.Write("Enter your father name : ");
            // string fatherName=Console.ReadLine();

            // student.FatherName=fatherName;

            // System.Console.Write("Enter your gender : ");
            // string gender=Console.ReadLine();

            // student.Gender=gender;

            // System.Console.Write("Enter your DOB as 'dd/MM/yyy' format : ");
            // DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            // student.DOB=dob;

            // System.Console.Write("Enter your Physics Mark: ");
            // int physicsMark=Convert.ToInt32(Console.ReadLine());
            
            // student.PhysicsMark=physicsMark;

            // System.Console.Write("Enter your Chemistry Mark: ");
            // int chemistryMark=Convert.ToInt32(Console.ReadLine());

            // student.ChemistryMark=chemistryMark;

            // System.Console.Write("Enter your Maths Mark: ");
            //  int mathsMark=Convert.ToInt32(Console.ReadLine());

            //  student.MathsMark=mathsMark;

            //  //Adding student object to StudentsList
            
            // studentsList.Add(student);
            
            // //Second Object for students details
            //  StudentDetails student1=new StudentDetails();

            // System.Console.WriteLine("Enter Personal Details - 2");
            // System.Console.Write("Enter your first name : ");
            // string firstName1=Console.ReadLine();
            // student1.FirstName=firstName1;

            // System.Console.Write("Enter your father name : ");
            // string fatherName1=Console.ReadLine();

            // student1.FatherName=fatherName1;

            // System.Console.Write("Enter your gender : ");
            // string gender1=Console.ReadLine();

            // student1.Gender=gender1; 

            // System.Console.Write("Enter your DOB as 'dd/MM/yyy' format : ");
            // DateTime dob1=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            // student1.DOB=dob1;

            // System.Console.Write("Enter your Physics Mark: ");
            // int physicsMark1=Convert.ToInt32(Console.ReadLine());

            // student1.PhysicsMark=physicsMark1;

            // System.Console.Write("Enter your Chemistry Mark: ");
            // int chemistryMark1=Convert.ToInt32(Console.ReadLine());

            // student1.ChemistryMark=chemistryMark;

            // System.Console.Write("Enter your Maths Mark: ");
            //  int mathsMark1=Convert.ToInt32(Console.ReadLine());
             
            //  student1.MathsMark=mathsMark;
 
            // //Adding second student object to StudentDetails LIist
            //  studentsList.Add(student1);

            // //Third Object for StudentDetails

            // StudentDetails student2=new StudentDetails();

            // System.Console.WriteLine("Enter Personal Details - 2");

            //  System.Console.Write("Enter your first name : ");
            // string firstName2=Console.ReadLine();

            // student2.FirstName=firstName;

            // System.Console.Write("Enter your father name : ");
            // string fatherName2=Console.ReadLine();

            // student2.FatherName=fatherName;

            // System.Console.Write("Enter your gender : ");
            // string gender2=Console.ReadLine();

            // student2.Gender=gender;

            // System.Console.Write("Enter your DOB as 'dd/MM/yyy' format : ");
            // DateTime dob2=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            // student2.DOB=dob;

            // System.Console.Write("Enter your Physics Mark: ");
            // int physicsMark2=Convert.ToInt32(Console.ReadLine());

            // student2.PhysicsMark=physicsMark;

            // System.Console.Write("Enter your Chemistry Mark: ");
            // int chemistryMark2=Convert.ToInt32(Console.ReadLine());

            // student2.ChemistryMark=chemistryMark;

            // System.Console.Write("Enter your Maths Mark: ");
            //  int mathsMark2=Convert.ToInt32(Console.ReadLine());

            //  student2.MathsMark=mathsMark;

            // //Adding third student object to studentsList
            
            //  studentsList.Add(student2);

            //  System.Console.WriteLine("Personal Details - 1");
            //  System.Console.WriteLine("name: "+student.FirstName);
            //  System.Console.WriteLine("Father Name: "+student.FatherName);
            //  System.Console.WriteLine("Gender "+student.Gender);
            //  System.Console.WriteLine("DOB: "+student.DOB.ToString("dd/MM/yyy"));
            //  System.Console.WriteLine("Physics mark: "+student.PhysicsMark);
            //  System.Console.WriteLine("Chemistry mark: "+student.ChemistryMark);
            //  System.Console.WriteLine("Maths Marks: "+student.MathsMark);
 
            //  System.Console.WriteLine();
            //  System.Console.WriteLine("Personal Details -2");
            //  System.Console.WriteLine("Name: "+student.FirstName);
            //  System.Console.WriteLine("Father Name: "+student1.FatherName);
            //  System.Console.WriteLine("Gender "+student1.Gender);
            //  System.Console.WriteLine("DOB: "+student1.DOB.ToString("dd/MM/yyy"));
            //  System.Console.WriteLine("Physics mark: "+student1.PhysicsMark);
            //  System.Console.WriteLine("Chemistry mark: "+student1.ChemistryMark);
            //  System.Console.WriteLine("Maths Marks: "+student1.MathsMark);

            //  System.Console.WriteLine();

            //  System.Console.WriteLine("Personal Details - 3");
            //  System.Console.WriteLine("Name: "+student2.FirstName);
            //  System.Console.WriteLine("Father Name: "+student2.FatherName);
            //  System.Console.WriteLine("Gender "+student2.Gender);
            //  System.Console.WriteLine("DOB: "+student2.DOB.ToString("dd/MM/yyy"));
            //  System.Console.WriteLine("Physics mark: "+student2.PhysicsMark);
            //  System.Console.WriteLine("Chemistry mark: "+student2.ChemistryMark);
            //  System.Console.WriteLine("Maths Marks: "+student2.MathsMark);

             string choice=string.Empty;

             do{
              // StudentDetails student=new StudentDetails();
             System.Console.WriteLine("Enter Personal Details - 1");
             System.Console.Write("Enter your first name : ");
             string firstName=Console.ReadLine();

            // student.FirstName=firstName;

             System.Console.Write("Enter your father name : ");
             string fatherName=Console.ReadLine();

            // student.FatherName=fatherName;

            System.Console.Write("Enter your gender : ");
             Gender gender=Enum .Parse<Gender>(Console.ReadLine(),true);

            // student.Gender=gender;

            System.Console.Write("Enter your DOB as 'dd/MM/yyy' format : ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            // student.DOB=dob;

             System.Console.Write("Enter your Physics Mark: ");
             int physicsMark=Convert.ToInt32(Console.ReadLine());
            
            // student.PhysicsMark=physicsMark;

             System.Console.Write("Enter your Chemistry Mark: ");
             int chemistryMark=Convert.ToInt32(Console.ReadLine());

            // student.ChemistryMark=chemistryMark;

             System.Console.Write("Enter your Maths Mark: ");
             int mathsMark=Convert.ToInt32(Console.ReadLine());

            //  student.MathsMark=mathsMark;

            //  studentsList.Add(student);
            StudentDetails details=new StudentDetails(firstName,fatherName,gender,dob,physicsMark,chemistryMark,mathsMark);
            studentsList.Add(details);
              Console.Write("Do you want to add another user  yes/no: ");
              choice=System.Console.ReadLine().ToLower();
             
             }while(choice=="yes");
           
            
           Console.WriteLine();
           Console.Write("Enter your Registration ID: ");
           string registerID=Console.ReadLine();
          bool flag=true;
          foreach(StudentDetails student3 in studentsList)
          {
            if(registerID.Equals(student3.StudentID))
            {
               flag=false;
              System.Console.WriteLine("Student id:"+student3.StudentID);
              System.Console.WriteLine("Name: "+student3.FirstName);
              System.Console.WriteLine("Father Name: "+student3.FatherName);
              System.Console.WriteLine("Gender "+student3.Gender);
              System.Console.WriteLine("DOB: "+student3.DOB.ToString("dd/MM/yyy"));
              System.Console.WriteLine("Physics mark: "+student3.PhysicsMark);
              System.Console.WriteLine("Chemistry mark: "+student3.ChemistryMark);
              System.Console.WriteLine("Maths Marks: "+student3.MathsMark);
              if(student3.IsEligible(50.0))
              {
                 Console.WriteLine("You are eligible");
              }
              else{
                Console.WriteLine("you are not eligible");
              }
              break;
               
            }
          }
          if(flag)
          {
            Console.WriteLine("NO Student with this ID found");

          }

           
            // foreach(StudentDetails student3 in studentsList)
            // {
            //   System.Console.WriteLine("Student id:"+student3.StudentID);
            //   System.Console.WriteLine("Name: "+student3.FirstName);
            //   System.Console.WriteLine("Father Name: "+student3.FatherName);
            //   System.Console.WriteLine("Gender "+student3.Gender);
            //   System.Console.WriteLine("DOB: "+student3.DOB.ToString("dd/MM/yyy"));
            //   System.Console.WriteLine("Physics mark: "+student3.PhysicsMark);
            //   System.Console.WriteLine("Chemistry mark: "+student3.ChemistryMark);
            //   System.Console.WriteLine("Maths Marks: "+student3.MathsMark);


            // }

            

        }
      }
}
