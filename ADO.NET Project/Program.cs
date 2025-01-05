using System;
using System.Data.SqlClient;
using System.Configuration;
using System.CodeDom.Compiler;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using ADO.NET_Project.DTOs;
namespace ADO.NET_Project
{
    internal class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;

        #region PrintAllEmployees

        static void PrintAllEmployees()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select * from Contacts";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();




            while (reader.Read())
            {
                {
                    int contatId = reader["ContactID"] != DBNull.Value ? (int)reader["ContactID"] : 0;
                    EmployeeResponseDTO emp = new EmployeeResponseDTO

                    {
                        FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : "",
                        LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : "",
                        Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                        Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "",
                        Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "",
                        CountryID = reader["CountryID"] != DBNull.Value ? (int)reader["CountryID"] : 0
                    };


                    Console.WriteLine($"First Name: {emp.FirstName}");
                    Console.WriteLine(contatId);

                }

            }
            reader.Close();
            connection.Close();
        }
        #endregion


        #region Print ContactID Of All Employees
        static void PrintContactIDOfAllEmployees()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select ContactID from contacts";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ContactID"]);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Sth Went Wrong!"); ;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }



        }

        #endregion


        #region Print Contacts With FirstName (one parameter)
        static void PrintAllContactsWithFirstName(string FirstName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from contacts where FirstName = @FirstName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");

                }
                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }
        #endregion


        #region Print Contacts With FirstName and ID (two parameters)

        static void PrintContactsWithFirstNameAndID(string FirstName, int ContactID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from Contacts where FirstName = @FirstName and ContactID = @ContactID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@ContactID", ContactID);


            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
                }

                reader.Close();
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region Search: Handling Select With Like Keyword (Start With)
        static void SearchContactsStartWith(string StartWith)
        {
            SqlConnection con = new SqlConnection(connectionString);
            //string query = "SELECT * FROM contacts WHERE firstname LIKE @StartWith";

            //OR
            string query = "SELECT * FROM contacts WHERE firstname LIKE '' + @StartWith + '%'";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@StartWith", StartWith + "%");
            cmd.Parameters.AddWithValue("@StartWith", StartWith);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
                }
                reader.Close();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion


        #region Search: Handling Select With Like Keyword (End With)
        static void SearchContactsEndWith(string EndWith)
        {
            SqlConnection con = new SqlConnection(connectionString);
            //string query = "SELECT * FROM contacts WHERE firstname LIKE @StartWith";

            //OR

            string query = "SELECT * FROM contacts WHERE firstname LIKE '%' + @StartWith +''";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@StartWith",  "%" + EndWith);
            cmd.Parameters.AddWithValue("@StartWith", EndWith);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}.");
                }
                reader.Close();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion


        #region Search: Handling Select With Like Keyword (Contains)
        static void SearchContactsContains(string Contains)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM contacts WHERE firstname LIKE @StartWith";

            //OR

            //string query = "SELECT * FROM contacts WHERE firstname LIKE '%' + @StartWith + '%'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StartWith", "%" + Contains + "%");
            //cmd.Parameters.AddWithValue("@StartWith", Contains);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}.");
                }
                reader.Close();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion


        #region Return Single Value Using Execute Scaler 
        //ExecuteScalar >> cmd.ExecuteScalar() Returns only Single Value (returns only the First Column of the first Row): Like Max or Mohammad or 1 or 3 ...etc.
        static void ReturnSingleValueUsingExecuteScaler(int ContactID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            //string query = "select FirstName from contacts where ContactID = @ContactID";
            string query = "select * from contacts where ContactID = @ContactID"; // returns contactId (first col of first row ^^)
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ContactID", ContactID);


            try
            {
                con.Open();
                object value = cmd.ExecuteScalar();

                if (value != null)
                {
                    value = value.ToString();
                    Console.WriteLine(value);
                }
                else
                {
                    Console.WriteLine("No Result");
                }


                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region FindContactByID
        static bool FindContactByID(int ContactID, EmployeeResponseDTO emp)
        {
            bool isFound = false;


            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * From Contacts Where ContactID = @ContactID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ContactID", ContactID);


            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    emp.ContactID = (int)reader["ContactID"];
                    emp.FirstName = (string)reader["FirstName"];
                    emp.LastName = (string)reader["LastName"];
                    emp.Email = (string)reader["Email"];
                    emp.Phone = (string)reader["Phone"];
                    emp.Address = (string)reader["Address"];
                    emp.CountryID = (int)reader["CountryID"];
                }
                reader.Close();
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }

            return isFound;

        }
        #endregion


        #region InsertNewRecord
        static void InsertNewRecord(EmployeeRequestDTO emp)
        {
            //Note: You are explicitly closing the connection with conn.Close(). While this works,
            //it's unnecessary because the using block automatically disposes of and closes the connection.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int rowsAffected = 0;
                string query = @"
            INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@Email", emp.Email);
                    cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                    cmd.Parameters.AddWithValue("@Address", emp.Address);
                    cmd.Parameters.AddWithValue("@CountryID", emp.CountryID);

                    try
                    {
                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Record inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Record insertion Falied");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        #endregion


        #region InsertNewRecordAndReturnID (Auto Generated Number);
        static int InsertNewRecordAndGetID(EmployeeRequestDTO emp)
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
   
                string query = @"
            INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);" +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);

                    //cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    //or (better)
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = emp.FirstName;


                    //cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    //or (better)
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = emp.LastName;

                    cmd.Parameters.AddWithValue("@Email", emp.Email);
                    cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                    cmd.Parameters.AddWithValue("@Address", emp.Address);
                    cmd.Parameters.AddWithValue("@CountryID", emp.CountryID);

                    try
                    {
                        conn.Open();
                    
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        #endregion


        #region UpdateRecordByID (Update First Name);
        static void UpdateFirstNameByID(int ContactID, string FirstName)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"update Contacts set FirstName = @FirstName where ContactID = @ContactID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occured: {ex.Message}");
                        throw;
                    }
                }

            }


        }
        #endregion


        #region UpdateFullRecordByID;
        static void UpdateFullRecordByID(int ContactID, EmployeeRequestDTO empDTO)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"update Contacts 
                                set FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                Phone = @Phone,
                                Address = @Address,
                                CountryID = @CountryID
                                WHERE ContactID = @ContactID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empDTO.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empDTO.LastName;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empDTO.Email;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = empDTO.Phone;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empDTO.Address;
                    cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = empDTO.CountryID;
                   


                    try
                    {
                        conn.Open();
                        if(cmd.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Row Updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Row Update Failed");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occured: {ex.Message}");
                        throw;
                    }
                }

            }


        }
        #endregion


        #region DeleteRecordByID
        static void DeleteRecordByID(int ContactID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"delete from Contacts where ContactID = @ContactID;";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;

                    int rowsAffected = 0;
                   

                    try
                    {
                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"{rowsAffected} Row Deleted");
                        }
                       else
                        {
                            Console.WriteLine("No rows deleted");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An Error Occured: {ex.Message}");
                        throw;
                    }
                }

            }
        }

        #endregion


        #region Handling In Statement (This ex is on delete, but you can use In with update, select ... etc) >> same approach as delete

        static void DeleteRecordsByIDs(string ContactIDs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Dynamically generate parameterized query
                string query = "DELETE FROM Contacts WHERE ContactID IN (" + ContactIDs + ")";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"{rowsAffected} record(s) deleted.");
                        }
                        else
                        {
                            Console.WriteLine("No Rows Affected");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        #endregion

        static void Main(string[] args)
        {
            











        }


        }
    }

