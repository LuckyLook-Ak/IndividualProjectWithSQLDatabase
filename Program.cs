using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectWithSQLDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AskUser();
        }
        public static void AskUser()
        {
            bool i = true;
            while (i)
            {
                Console.WriteLine("Assign a Student: press 1\nAssign a Trainer: press 2\nAssign a Course : press 3\nInsert a new Assignment: press 4\n\tEXIT:press 5");
                string switchkey = Console.ReadLine();
                CheckForNulls(switchkey);
                switch (switchkey)
                {
                    case "1":
                        InsertStudent();
                        AskUserForStudentEnroll();                       
                        break;
                    case "2":
                        InsertTrainer();
                        AskUserForTrainerEnroll();
                        break;
                    case "3":
                        InsertCourse();
                        break;
                    case "4":
                        InsertAssignment();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Insert a valid number");
                        break;
                }
                Console.WriteLine("Do you want to make another Insert?\n Type Y for yes\n Type N for no");
                string des = Console.ReadLine();
                CheckForNulls(des);
                if (des == "Y")
                {
                    i = true;
                }
                else
                {
                    i = false;
                }

            }
            Console.WriteLine("Thanks for using my program");

        }

        public static void InsertStudent()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            string insertinfo = "Insert INTO Students (FirstName,LastName,Birthday,TuitionFees) Values (@FirstName,@LastName,@BirthDay,@TuitionFees)";
            SqlCommand insertCommand = new SqlCommand(insertinfo, conn);
            Console.WriteLine("Student Name: ");
            string firstname = Console.ReadLine();
            MakeFirstLetterCapital(firstname);
            firstname = CheckForNulls(firstname);
            insertCommand.Parameters.Add(new SqlParameter("FirstName", firstname));
            Console.WriteLine("Student Last Name: ");
            string lastname = Console.ReadLine();
            MakeFirstLetterCapital(lastname);
            lastname = CheckForNulls(lastname);
            insertCommand.Parameters.Add(new SqlParameter("LastName", lastname));
            Console.WriteLine("Students Birthday: ");
            string birthday = Console.ReadLine();
            birthday = CheckForNulls(birthday);
            insertCommand.Parameters.Add(new SqlParameter("BirthDay", DateTime.Parse(birthday)));
            Console.WriteLine("Students TuitionFees: ");
            decimal tuitiofees = Convert.ToDecimal(Console.ReadLine());
            insertCommand.Parameters.Add(new SqlParameter("TuitionFees", tuitiofees));
            insertCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertTrainer()
        {
            Console.WriteLine("Trainer's Name: ");
            string firstname = Console.ReadLine();
            MakeFirstLetterCapital(firstname);
            firstname = CheckForNulls(firstname);
            Console.WriteLine("Trainer's Last Name: ");
            string lastname = Console.ReadLine();
            MakeFirstLetterCapital(lastname);
            lastname = CheckForNulls(lastname);
            Console.WriteLine("Teaching Subject (C#,Java,Javascript,Python): ");                      
            string subject = Console.ReadLine();
            MakeFirstLetterCapital(subject);
            subject = CheckForNulls(subject);
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            string insertinfo = "Insert INTO Trainers (FirstName,LastName,Subject) Values (@FirstName,@LastName,@Subject)";
            SqlCommand insertCommand = new SqlCommand(insertinfo, conn);
            insertCommand.Parameters.Add(new SqlParameter("FirstName", firstname));
            insertCommand.Parameters.Add(new SqlParameter("LastName", lastname));
            insertCommand.Parameters.Add(new SqlParameter("Subject", subject));
            insertCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertCourse()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            string insertinfo = "Insert INTO Courses (Title,Type,Subject,Start,End) Values (@Title,@Type,@Subject,@Start,@End)";
            SqlCommand insertCommand = new SqlCommand(insertinfo, conn);
            Console.WriteLine("Course Title: ");
            string coursetitle = Console.ReadLine();
            MakeFirstLetterCapital(coursetitle);
            coursetitle = CheckForNulls(coursetitle);
            insertCommand.Parameters.Add(new SqlParameter("Title", coursetitle));
            Console.WriteLine("Course Type: ");
            string type = Console.ReadLine();
            MakeFirstLetterCapital(type);
            type = CheckForNulls(type);
            insertCommand.Parameters.Add(new SqlParameter("Type", type));
            Console.WriteLine("Subject of course: ");
            string subject = Console.ReadLine();
            MakeFirstLetterCapital(subject);
            subject = CheckForNulls(subject);
            insertCommand.Parameters.Add(new SqlParameter("Subject", subject));
            Console.WriteLine("Course's Starting date: ");
            string startdate = Console.ReadLine();
            startdate = CheckForNulls(startdate);
            insertCommand.Parameters.Add(new SqlParameter("Start", DateTime.Parse(startdate)));
            Console.WriteLine("Course's Ending date: ");
            string enddate = Console.ReadLine();
            enddate = CheckForNulls(enddate);
            insertCommand.Parameters.Add(new SqlParameter("End", DateTime.Parse(enddate)));
            insertCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertAssignment()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            string insertinfo = "Insert INTO Assignments (Title,ForCourse,Duration,OralMark,TotalMark) Values (@Title,@ForCourse,@Duration,@OralMark,@TotalMark)";
            SqlCommand insertCommand = new SqlCommand(insertinfo, conn);
            Console.WriteLine("Assignment's Title: ");
            string title = Console.ReadLine();
            MakeFirstLetterCapital(title);
            title = CheckForNulls(title);
            insertCommand.Parameters.Add(new SqlParameter("Title", title));
            Console.WriteLine("Assignment's Subject: ");
            string forcourse = Console.ReadLine();
            MakeFirstLetterCapital(forcourse);
            forcourse = CheckForNulls(forcourse);
            insertCommand.Parameters.Add(new SqlParameter("ForCourse", forcourse));
            Console.WriteLine("Assignment's duration: ");
            string duration = Console.ReadLine();
            duration = CheckForNulls(duration);
            insertCommand.Parameters.Add(new SqlParameter("Duration", duration));
            Console.WriteLine("Assignment's Oral Mark: ");
            decimal oralmark = Convert.ToDecimal(Console.ReadLine());
            insertCommand.Parameters.Add(new SqlParameter("OralMark", oralmark));
            Console.WriteLine("Assignment's Total Mark: ");
            decimal totalmark = Convert.ToDecimal(Console.ReadLine());
            insertCommand.Parameters.Add(new SqlParameter("OralMark", totalmark));
            insertCommand.ExecuteNonQuery();
            conn.Close();

        }
        static string CheckForNulls(string userInput)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Invalid input");
                userInput = Console.ReadLine();

            }
            return userInput;
        }
        private static void SelectStudents()
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;"))
            {
                SqlDataReader rdr = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from Students", conn))
                    {
                        rdr = cmd.ExecuteReader();

                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("\tID:{0}\tName:  {1},{2},Birthday: {3}TuitionFees: {4}\n", rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (rdr != null)
                        rdr.Close();
                    if (conn != null)
                        conn.Close();
                }
            }

        }

        private static void SelectAllCourses()
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;"))
            {
                SqlDataReader rdr = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from Courses", conn))
                    {
                        rdr = cmd.ExecuteReader();

                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                
                                Console.WriteLine("\tID:{0}\tTitle:  {1}, Type: {2},Subject: {3}Starting Date: {4}\tEnding Date: {5}\n", rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5]);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (rdr != null)
                        rdr.Close();
                    if (conn != null)
                        conn.Close();
                }
            }
        }
        public static void DeleteStudent(string name)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open(); 
            string deleteString = $"DELETE FROM Trainers WHERE FirstName = '{name}' ";
            SqlCommand cmd = new SqlCommand(deleteString, conn);
            cmd.ExecuteNonQuery();
        }

        public static void EnrollStudentToCourse()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            string insertinfo = "insert into StudentPerCourse(StudentID,CourseID) values (@StudentID,@CourseID)";
            SqlCommand insertCommand = new SqlCommand(insertinfo, conn);
            int laststudententry = LastStudentID();
            insertCommand.Parameters.Add(new SqlParameter("StudentID", laststudententry));
            Console.WriteLine("Insert the id of the course that you want to assign the student?");
            int courseid = Convert.ToInt32(Console.ReadLine());
            insertCommand.Parameters.Add(new SqlParameter("CourseID", courseid));
            insertCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static int LastStudentID()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");          
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM students ORDER BY ID DESC", conn);
            int studentid = (int)cmd.ExecuteScalar();
            return studentid;
           
            

        }

        public static void AskUserForStudentEnroll()
        {
            Console.WriteLine("Do you want to assign the student to a Course ? (Type Y for Yes and N for No)");
            string useriput = Console.ReadLine();
            if (useriput == "Y")
            {
                EnrollStudentToCourse();
            }
        }

        public static void EnrollTrainerToCourse()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            string insertinfo = "insert into TrainerPerCourse(CourseID,TrainerID) values (@CourseID,@TrainerID)";
            SqlCommand insertCommand = new SqlCommand(insertinfo, conn);
            int lasttrainerentry = LastTrainerID();
            insertCommand.Parameters.Add(new SqlParameter("TrainerID", lasttrainerentry));
            Console.WriteLine("Insert the id of the course that you want to assign the Trainer?\nThe available courses are:");
            TrainerAvailableOptions();
            int courseid = Convert.ToInt32(Console.ReadLine());
            insertCommand.Parameters.Add(new SqlParameter("CourseID", courseid));
            insertCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static int LastTrainerID()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM trainers ORDER BY ID DESC", conn);
            int trainerid = (int)cmd.ExecuteScalar();
            return trainerid;
        }

        public static void AskUserForTrainerEnroll()
        {
            Console.WriteLine("Do you want to assign the trainer into a Course ? (Type Y for Yes and N for No)");
            string useriput = Console.ReadLine();
            if (useriput == "Y")
            {
                EnrollTrainerToCourse();
            }
        }


        public static void TrainerAvailableOptions()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top 1 subject from trainers order by id desc", conn);
            string trainersubject = (string)cmd.ExecuteScalar();
            
            if (trainersubject == "C#")
            {
                using (SqlConnection conn1 = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;"))
                {
                    SqlDataReader rdr1 = null;
                    try
                    {
                        conn1.Open();
                        using (SqlCommand cmd1 = new SqlCommand("select * from Courses where courses.subject = 'C#' ", conn1))
                        {
                            rdr1 = cmd1.ExecuteReader();

                            if (rdr1 != null)
                            {
                                while (rdr1.Read())
                                {

                                    Console.WriteLine("\tID:{0}\tTitle:  {1}, Type: {2},Subject: {3},Starting Date: {4}\tEnding Date: {5}\n", rdr1[0], rdr1[1], rdr1[2], rdr1[3], rdr1[4], rdr1[5]);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (rdr1 != null)
                            rdr1.Close();
                        if (conn1 != null)
                            conn1.Close();
                    }
                }
            }
            else if (trainersubject == "Java")
            {
                using (SqlConnection conn1 = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;"))
                {
                    SqlDataReader rdr1 = null;
                    try
                    {
                        conn1.Open();
                        using (SqlCommand cmd1 = new SqlCommand("select * from Courses where courses.subject = 'Java' ", conn1))
                        {
                            rdr1 = cmd1.ExecuteReader();

                            if (rdr1 != null)
                            {
                                while (rdr1.Read())
                                {

                                    Console.WriteLine("\tID:{0}\tTitle:  {1}, Type: {2},Subject: {3},Starting Date: {4}\tEnding Date: {5}\n", rdr1[0], rdr1[1], rdr1[2], rdr1[3], rdr1[4], rdr1[5]);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (rdr1 != null)
                            rdr1.Close();
                        if (conn1 != null)
                            conn1.Close();
                    }
                }
            }
            else if (trainersubject == "Javascript")
            {
                using (SqlConnection conn1 = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;"))
                {
                    SqlDataReader rdr1 = null;
                    try
                    {
                        conn1.Open();
                        using (SqlCommand cmd1 = new SqlCommand("select * from Courses where courses.subject = 'Javascript' ", conn1))
                        {
                            rdr1 = cmd1.ExecuteReader();

                            if (rdr1 != null)
                            {
                                while (rdr1.Read())
                                {

                                    Console.WriteLine("\tID:{0}\tTitle:  {1}, Type: {2},Subject: {3},Starting Date: {4}\tEnding Date: {5}\n", rdr1[0], rdr1[1], rdr1[2], rdr1[3], rdr1[4], rdr1[5]);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (rdr1 != null)
                            rdr1.Close();
                        if (conn1 != null)
                            conn1.Close();
                    }
                }
            }
            else if (trainersubject == "Python")
            {
                using (SqlConnection conn1 = new SqlConnection("Server=.;Database=ExxperimentsOnIndividualProject;Trusted_Connection=True;"))
                {
                    SqlDataReader rdr1 = null;
                    try
                    {
                        conn1.Open();
                        using (SqlCommand cmd1 = new SqlCommand("select * from Courses where courses.subject = 'Python' ", conn1))
                        {
                            rdr1 = cmd1.ExecuteReader();

                            if (rdr1 != null)
                            {
                                while (rdr1.Read())
                                {

                                    Console.WriteLine("\tID:{0}\tTitle:  {1}, Type: {2},Subject: {3},Starting Date: {4}\tEnding Date: {5}\n", rdr1[0], rdr1[1], rdr1[2], rdr1[3], rdr1[4], rdr1[5]);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (rdr1 != null)
                            rdr1.Close();
                        if (conn1 != null)
                            conn1.Close();
                    }
                }
            }
            

        }
        static string MakeFirstLetterCapital(string word)
        {
            word = (char.ToUpper(word[0]) + word.Substring(1));
            return word;
        }


    }
    

}
