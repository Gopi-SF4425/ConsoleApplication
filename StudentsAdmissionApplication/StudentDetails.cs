using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAdmissionApplication
{
    //Enum for gender type
    public enum Gender{
        Select,Male,Female,Transgender
    }

    //Student details class to store basic student deatils
    public class StudentDetails
    {
        //student id to find find the unique student
        private static int s_studentID=3000;
        //Student ID Property
        public string  StudentID { get;  }
        
        //student name property
        public string  StudentName { get; set; }

        //Father name
        public string FatherName{get;set;}

        //Date of birth
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
       //physics mark
        public int PhysicsMark { get; set; }

        //chemistry mark
        public int ChemistryMark { get; set; }

        //maths mark
        public int MathsMark{ get; set; }

        public StudentDetails()
        {

        }

        public StudentDetails(string studentName,string fathername,DateTime dob,
                                  Gender gender,int physicsMark,int chistryMark,int mathsMark)
         {

                  s_studentID++;
                  StudentID="SF"+s_studentID;
                  StudentName=studentName;
                  FatherName=fathername;
                  DOB=dob;
                  Gender=gender;
                  PhysicsMark=physicsMark;
                  ChemistryMark=chistryMark;
                  MathsMark=mathsMark;


                                  
            }
             public double Average()
        {
            double average=(double)(PhysicsMark+ChemistryMark+MathsMark)/3;
            return average;
        }
    public bool IsEligible(double cutOff){
        if(Average()>=cutOff)
        {
            return true;
        }
        else return false;
    }
}
}