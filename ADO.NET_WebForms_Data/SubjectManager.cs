using System;
using System.Collections.Generic;
using ADONET_Practice.Data.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ADONET_Practice.Data {

    class SubjectManager {
        /// <summary>
        /// Method created for returning the article categories
        /// </summary>
        /// <returns>List of Subjects</returns>
        public List<Subject> GetSubjects() {

            List<Subject> result = new List<Subject>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from Subject");

            //Create dataset
            DataSet dataSet = new DataSet();

            //Create and open a connection to SQL Server 
            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString)) {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
            }

            //Add a name to the table from dataset
            dataSet.Tables[0].TableName = "Subject";

            Subject subject = null;
            //iterate the table from dataset and fill the "result" list
            foreach (DataRow dataRow in dataSet.Tables["Subject"].Rows) {
                subject = new Subject();

                subject.SubjectID = Convert.ToInt32(dataRow["SubjectID"]);
                subject.SubjectDescriptiom = dataRow["SubjectDescriptiom"].ToString();
                subject.SchoolID = Convert.ToInt32(dataRow["SchoolID"]);

                result.Add(subject);

            }
            return result;

        }

        /// <summary>
        /// Method created for returing a Subject category by Id
        /// </summary>
        /// <returns>subject</returns>
        public Subject GetSubjectById(int subjectID) {
            Subject result = new Subject();

            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("select * from SchoolID where subjectID={0}", subjectID);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows) {
                while (dataReader.Read()) {
                    result.SubjectID = Convert.ToInt32(dataReader["SubjectID"]);
                    result.SubjectDescriptiom = dataReader["SubjectDescriptiom"].ToString();
                    result.SchoolID = Convert.ToInt32(dataReader["SchoolID"]);
                }
            }

            return result;
        }
    }
}
