using System;
using System.Collections.Generic;
using ADONET_Practice.Data.Entities;
using System.Data.SqlClient;

namespace ADONET_Practice.Data {

    public class StudentManager {
        /// <summary>
        /// Method created for inserting or updating an student.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        
        public int SaveStudent(Student student) {

            //Create the SqlQuery for inserting a student.
            string createQuery = String.Format("Insert into Student(StudentID, FirstName, LastName, Email, PhoneNumber, Address, VolunteerSchoolID, VolunteerAvailabilityID) Values('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', {7} );"
                + "Select @@Identity", student.StudentID, student.FirstName, student.LastName, student.Email, student.PhoneNumber, student.Address, student.VolunteerSchoolID, student.VolunteerAvailabilityID);

            //Create the SqlQuery for updating a student.
            string updateQuery = String.Format("Update Student SET StudentID='{0}', FirstName='{1}', LastName='{2}', Email='{3}', PhoneNumber='{4}', Address='{5}', VolunteerSchoolID='{6}', VolunteerAvailabilityID='{7}';",
                student.StudentID, student.FirstName, student.LastName, student.Email, student.PhoneNumber, student.Address, student.VolunteerSchoolID, student.VolunteerAvailabilityID);

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //create a commando object
            SqlCommand command = null;
        
            if (student.StudentID != 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            int savedStudentID = 0;
            try {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null) {
                    savedStudentID = Convert.ToInt32(commandResult);
                } else {
                    //the update SQL query will not return the primary key but if doesn't throw exception 
                    //then we will take it from the already provided data
                    savedStudentID = student.StudentID;
                }
            } catch (Exception ex) {
                //there was a problem executing the script
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            return savedStudentID;
        }

        /// <summary>
        /// Method created for deleting a student 
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudent(int studentID) {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from Student where StudentID = {0}", studentID);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }

        /// <summary>
        /// Method created for returning the students
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<Student> GetStudents() {

            List<Student> result = new List<Student>();

            //Create the SQL Query for returning all the students
            string sqlQuery = String.Format("select * from Student");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Student student = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows) {
                while (dataReader.Read()) {
                    student = new Student();

                    student.StudentID = Convert.ToInt32(dataReader["StudentID"]);
                    student.FirstName = dataReader["FirstName"].ToString();
                    student.LastName = dataReader["LastName"].ToString();
                    student.Email = dataReader["Email"].ToString();
                    student.PhoneNumber = Convert.ToInt32(dataReader["PhoneNumber"]);
                    student.Address = dataReader["Address"].ToString();
                    student.VolunteerSchoolID = Convert.ToInt32(dataReader["VolunteerSchoolID"]);
                    student.VolunteerAvailabilityID = Convert.ToInt32(dataReader["VolunteerAvailabilityID"]);

                    result.Add(student);
                }
            }

            return result;

        }

        /// <summary>
        /// Method created for returing an student by Id
        /// </summary>
        /// <returns></returns>
        public Student GetStudentById(int studentID) {
            Student result = new Student();

            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("select * from Student where StudentID={0}", studentID);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows) {
                while (dataReader.Read()) {
                    result.StudentID = Convert.ToInt32(dataReader["StudentID"]);
                    result.FirstName = dataReader["FirstName"].ToString();
                    result.LastName = dataReader["LastName"].ToString();
                    result.Email = dataReader["Email"].ToString();
                    result.PhoneNumber = Convert.ToInt32(dataReader["PhoneNumber"]);
                    result.Address = dataReader["Address"].ToString();
                    result.VolunteerSchoolID = Convert.ToInt32(dataReader["VolunteerSchoolID"]);
                    result.VolunteerAvailabilityID = Convert.ToInt32(dataReader["VolunteerAvailabilityID"]);
                }
            }

            return result;
        }

    }
}
