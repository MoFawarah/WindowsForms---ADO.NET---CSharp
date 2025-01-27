using StudentWCFService.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentWCFService.DAL
{
    public class StudentDataAccess
    {
        private static readonly string _connectionString = "Server=MOH-FAWAREH;Database=StudentsDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static async Task<List<StudentDTO>> GetAllStudents()
        {
            var allStudents = new List<StudentDTO>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("[dbo].[SP_GetAllStudents]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var student = new StudentDTO
                            {
                                Id = !reader.IsDBNull(reader.GetOrdinal("Id")) ? reader.GetInt32(reader.GetOrdinal("Id")) : 0,
                                Name = !reader.IsDBNull(reader.GetOrdinal("Name")) ? reader.GetString(reader.GetOrdinal("Name")) : string.Empty,
                                Age = !reader.IsDBNull(reader.GetOrdinal("Age")) ? reader.GetInt32(reader.GetOrdinal("Age")) : 0,
                                Grade = !reader.IsDBNull(reader.GetOrdinal("Grade")) ? reader.GetDecimal(reader.GetOrdinal("Grade")) : 0
                            };

                            allStudents.Add(student);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log and rethrow the SQL exception
                Console.Error.WriteLine($"SQL Error: {ex.Message}");
                throw new Exception("A database error occurred while retrieving students.", ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                Console.Error.WriteLine($"General Error: {ex.Message}");
                throw new Exception("An unexpected error occurred while retrieving students.", ex);
            }

            return allStudents;
        }

        public static async Task<List<StudentDTO>> GetPassedStudents()
        {
            var passedStudents = new List<StudentDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetPassedStudents", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                passedStudents.Add(new StudentDTO
                                {
                                    Id = !reader.IsDBNull(reader.GetOrdinal("Id")) ? reader.GetInt32(reader.GetOrdinal("Id")) : 0,
                                    Name = !reader.IsDBNull(reader.GetOrdinal("Name")) ? reader.GetString(reader.GetOrdinal("Name")) : string.Empty,
                                    Age = !reader.IsDBNull(reader.GetOrdinal("Age")) ? reader.GetInt32(reader.GetOrdinal("Age")) : 0,
                                    Grade = !reader.IsDBNull(reader.GetOrdinal("Grade")) ? reader.GetDecimal(reader.GetOrdinal("Grade")) : 0,
                                });
                            }
                        }
                    }


                }

            }
            catch (SqlException ex)
            {
                // Log and rethrow the SQL exception
                Console.Error.WriteLine($"SQL Error: {ex.Message}");
                throw new Exception("A database error occurred while retrieving students.", ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                Console.Error.WriteLine($"General Error: {ex.Message}");
                throw new Exception("An unexpected error occurred while retrieving students.", ex);
            }


            return passedStudents;
        }

        public static async Task<List<StudentDTO>> GetFaliedStudents()
        {
            List<StudentDTO> faliedStudents = new List<StudentDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetFailedStudents", conn))
                        
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                faliedStudents.Add(new StudentDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                                    Grade = reader.GetDecimal(reader.GetOrdinal("Grade"))
                                });
                            }
                        }

                    }

                }
                return faliedStudents;
            }
            catch (SqlException ex)
            {
                // Log and rethrow the SQL exception
                Console.Error.WriteLine($"SQL Error: {ex.Message}");
                throw new Exception("A database error occurred while retrieving students.", ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                Console.Error.WriteLine($"General Error: {ex.Message}");
                throw new Exception("An unexpected error occurred while retrieving students.", ex);
            }



        }

        public static async Task<StudentDTO> GetStudentByID(int Id)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetStudentById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = Id;


                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync()) // Check if a row is returned
                        {
                            return new StudentDTO
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Age = reader.GetInt32(reader.GetOrdinal("Age")),
                                Grade = reader.GetDecimal(reader.GetOrdinal("Grade")),
                            };


                        }
                        else
                            return null;

                    }

                }
            }




        }

        public static async Task<StudentDTO> AddNewStudent(StudentRequestDTO newStudent)
        {
           
            try
            {
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using(SqlCommand cmd = new SqlCommand("SP_AddStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = newStudent.Name;
                        cmd.Parameters.Add("@Age", SqlDbType.Int).Value = newStudent.Age;
                        cmd.Parameters.Add("@Grade", SqlDbType.Int).Value = newStudent.Grade;

                        var newStudentId = cmd.Parameters.Add("@NewStudentId", SqlDbType.Int);
                        newStudentId.Direction = ParameterDirection.Output;
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        if (newStudentId.Value == DBNull.Value || newStudentId.Value == null)
                        {
                            throw new Exception("Failed to retrieve the new student ID");
                        }


                        return await GetStudentByID((int)newStudentId.Value);

                    }
                }
            }
            catch (SqlException ex)
            {
                // Log and rethrow the SQL exception
                Console.Error.WriteLine($"SQL Error: {ex.Message}");
                throw new Exception("A database error occurred while retrieving students.", ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                Console.Error.WriteLine($"General Error: {ex.Message}");
                throw new Exception("An unexpected error occurred while retrieving students.", ex);
            }

        }

        public static async Task<StudentDTO> UpdateStudent(int Id, StudentRequestDTO updateRequest)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = Id;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = updateRequest.Name;
                        cmd.Parameters.Add("@Age", SqlDbType.Int).Value = updateRequest.Age;
                        cmd.Parameters.Add("@Grade", SqlDbType.Int).Value = updateRequest.Grade;

                 
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        return await GetStudentByID(Id);

                    }
                }
            }
            catch (SqlException ex)
            {
                // Log and rethrow the SQL exception
                Console.Error.WriteLine($"SQL Error: {ex.Message}");
                throw new Exception("A database error occurred while retrieving students.", ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                Console.Error.WriteLine($"General Error: {ex.Message}");
                throw new Exception("An unexpected error occurred while retrieving students.", ex);
            }

        }

        public static async Task<bool> DeleteStudent(int studentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentId;

                        await conn.OpenAsync();
                        int rowsAffected = (int)await cmd.ExecuteScalarAsync();

                        return rowsAffected == 1;
                    }


                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception for debugging
                throw new InvalidOperationException("An error occurred while deleting the student.", ex);
            }

        }


    }
}