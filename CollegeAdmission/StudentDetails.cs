using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{

    ///Ennum Declaration
    /// <summary>
    ///       
    /// </summary>sed too select Student's Gender Information
    /// <Summary
    public enum Gender{Select=10,Male,Female}     //enum always in Pascal case

    /// <summary>
    /// Class student details is used to create instance for students  <see cref="StudentDetails"/> 
    /// Refer Dcumentation on <see href="www.synfusion.com/
    /// </summary>
     
/// <summary>
/// <see cref=""/> 
/// </summary>
    
    public class StudentDetails
    {
        //Field Declaration 
       /* private string _firstName;   //Field

        //Property

        public string FirstName{    //Normal representaion of the property  another name accessor  //  always public 
            get
            {
                return _firstName;   // get method return the value of the field   //if needed 
            }
            set
            {
                _firstName=value;   // set method assign the input to the field    //if needed
            }
        }
        */


        //  Auto Property     
        //  prop tab

        //Field
        /// <summary>
        /// Static field is used to auto increment the ID of the instance of <see cref="StudentDetails"/> 
        /// </summary>
        private static int _studentID=1000;   //Field
        
        /// <summary>
        /// StudentID Property used to hold ID of instance of<see cref="StudentDetails"/> 
        
        public string StudentID { get; }   //Read only property
 
        /// <summary>
        /// StudentID Property used to hold FirstName of instance of<see cref="StudentDetails"/> 
        /// </summary>
        
        public string FirstName { get;set; }
       /// <summary>
       /// Chemistrymark Property used to hold chemistry mark of instance of<see cref="StudentDtails"/> 
       /// </summary>
       /// <value></value>
        public string FatherName { get;set; }
       /// <summary>
       /// Chemistrymark Property used to hold chemistry mark of instance of<see cref="StudentDtails"/> 
       /// </summary>
       /// <value></value>
        public Gender Gender { get; set; }
       /// <summary>
       /// Chemistrymark Property used to hold chemistry mark of instance of<see cref="StudentDtails"/> 
       /// </summary>
       /// <value></value>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Chemistrymark Property used to hold chemistry mark of instance of<see cref="StudentDtails"/> 
        /// </summary>
        /// <value>0 to 100</value>
        public int PhysicsMark{ get; set; }

        public int ChemistryMark { get; set; }

        public int MathsMark { get; set; }

        //default Constructor
        /// <summary>
        /// Constructor Student details used to initalize default values to its properties
        /// </summary>
        public StudentDetails() 
        {
            FirstName="";
            FatherName="";
            Gender="male";
        }
        /// <summary>
        ///  Constructor Student details used to initalize default values to its properties
        /// </summary>
        /// <param name="firstName">FirstName parameter used to assign its value to assiciated property</param>
        /// <param name="fatherName">FathertName parameter used to assign its value to assiciated property</param>
        /// <param name="gender">Gender parameter used to assign its value to assiciated property</param>
        /// <param name="dateTime">Datetime parameter used to assign its value to assiciated property</param>
        /// <param name="physicsMark">Physics Mark parameter used to assign its value to assiciated property</param>
        /// <param name="chemistryMark">FirstName parameter used to assign its value to assiciated property</param>
        /// <param name="mathsMark">FirstName parameter used to assign its value to assiciated property</param>
        public StudentDetails(string firstName,string fatherName,Gender gender,DateTime dateTime,
        int physicsMark,int chemistryMark,int mathsMark)
        {
            _studentID++;
            StudentID="SF"+_studentID;
            FirstName=firstName;
            FatherName=fatherName;
            Gender=gender;
            DOB=DOB;
            PhysicsMark=physicsMark;
            ChemistryMark=chemistryMark;
            MathsMark=mathsMark;
            
        }
      /// <summary>
      /// Method Average used to calculate average mark score of instance of <see cref="StudentDetails"/> 
      /// </summary>
      /// <returns>Returns average of physics,chemistryand maths marks</returns>
        public double Average()
        {
            double average=(double)(PhysicsMark+ChemistryMark+MathsMark)/3;
            return average;
        }
        /// <summary>
        /// Method Iseligible used to check wheather the instance of<see cref="Studentdetails"/>
        ///  is eligible for admission based on cutoff
        /// </summary>
        /// <param name="cutOff">cutOff limit to find eligibility</param>
        /// <returns>Return true if eligible,else false</returns>

        public bool IsEligible(double cutOff){
        if(Average()>=cutOff)
        {
            return true;
        }
        else return false;
    }
    ~StudentDetails()
    {
        
    }



    }
}