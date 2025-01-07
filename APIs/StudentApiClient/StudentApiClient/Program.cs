
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace StudentApiClient
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7115/api/Students/"); // Set this to the correct URI for your API

           await GetAllStudents();
           await GetPassedStudents();
           await GetAvgGrade();
           await GetStudentByID(1);

            Student newStudent = new Student()
            {
                
                Age = 55,
                Name = "Mohammad",
                Grade = 55,
            };

          await AddNewStudent(newStudent);

            //await DeleteStudentByID(1);


            await UpdateStudentByID(2, new Student { Name = "Salma", Age = 22, Grade = 90 }); // Example: Update student with ID 2

        }

        static async Task GetAllStudents()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching all students...\n");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("GetAll");
                if (students != null)
                {
                    foreach (var student in students)
                    { 
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Age: {student.Grade}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task GetPassedStudents()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching passed students...\n");

                var passedStudnets = await httpClient.GetFromJsonAsync<List<Student>>("GetPassedStudents");

                if (passedStudnets != null)
                {
                    foreach(var student in passedStudnets)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Age: {student.Grade}");
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        static async Task GetAvgGrade()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching passed students...\n");

                // Use GetFromJsonAsync for strongly-typed deserialization
                float avgGrade = await httpClient.GetFromJsonAsync<float>("GetAvgGrade");

                Console.WriteLine($"Avg: {avgGrade}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        static async Task GetStudentByID(int ID)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nFetching student with ID = {ID}\n");

                // Use GetFromJsonAsync for strongly-typed deserialization
                var student = await httpClient.GetFromJsonAsync<Student>($"GetStudentByID/{ID}");

                if(student == null)
                {
                    Console.WriteLine($"Student With ID {ID} is not found");
                    return;
                }

                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Age: {student.Grade}");

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //OR:
        static async Task GetStudentByIDNew(int ID)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nFetching student with ID {ID}...\n");

                var response = await httpClient.GetAsync($"{ID}");

                if (response.IsSuccessStatusCode)
                {
                    var student = await response.Content.ReadFromJsonAsync<Student>();
                    if (student != null)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine($"Bad Request: Not accepted ID {ID}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Not Found: Student with ID {ID} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


  


        static async Task DeleteStudentByID(int ID)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nDeleteing Student...\n");

                var response = await httpClient.DeleteAsync($"DeleteStudentByID/{ID}");

                if (response.IsSuccessStatusCode)
                {
                    var studentDeleted = await response.Content.ReadFromJsonAsync<Student>();

                    if(studentDeleted != null)
                    {
                        Console.WriteLine("Below Record Deleted:");
                        Console.WriteLine($"ID: {studentDeleted.Id}, Name: {studentDeleted.Name}, Age: {studentDeleted.Age}, Grade: {studentDeleted.Grade}");
                    }

                    else
                    {
                        Console.WriteLine("No student data was returned from the server.");
                    }
                }

                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Bad Request: {errorMessage}");
                }


                else 
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Not Found: {errorMessage}");
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        static async Task AddNewStudent(Student newStudent)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nAdding New Student...\n");

                var response = await httpClient.PostAsJsonAsync("AddStudent", newStudent);

                if (response.IsSuccessStatusCode)
                {

                    var addedStudent = await response.Content.ReadFromJsonAsync<Student>();

                    if (addedStudent != null)
                    {
                        Console.WriteLine("Below Record Added:");
                        Console.WriteLine($"ID: {addedStudent.Id}, Name: {addedStudent.Name}, Age: {addedStudent.Age}, Grade: {addedStudent.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("No student data was returned from the server.");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Bad Request: {errorMessage}");
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        static async Task UpdateStudentByID(int ID, Student updateRequest)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nUpdating student with ID {ID}...\n");

                var response = await httpClient.PutAsJsonAsync<Student>($"UpdateStudentByID/{ID}", updateRequest);

                if (response.IsSuccessStatusCode)
                {
                    var studentUpdated = await response.Content.ReadFromJsonAsync<Student>();

                    if (studentUpdated != null)
                    {
                        Console.WriteLine("Below Record Updated:");
                        Console.WriteLine($"ID: {studentUpdated.Id}, Name: {studentUpdated.Name}, Age: {studentUpdated.Age}, Grade: {studentUpdated.Grade}");
                    }

                    else
                    {
                        Console.WriteLine("No student data was returned from the server.");
                    }
                }

                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Bad Request: {errorMessage}");
                }


                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Not Found: {errorMessage}");
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }

    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }


