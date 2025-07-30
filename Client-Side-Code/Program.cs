using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Client_Side_Code
{
    internal class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5151/api/Student");

            Console.WriteLine("\n__________________________\n");
            Console.WriteLine("___________Welcome_________");
            Console.WriteLine("[1] Show All Students");
            Console.WriteLine("[2] Show Passed Students");
            Console.WriteLine("[3] Show Students Grades Average");
            Console.WriteLine("\n__________________________\n");
            Console.WriteLine("\nEnter option number\n");
            short opNumber;
            if(short.TryParse(Console.ReadLine(),out opNumber))
            {
                if (opNumber == 1)
                {
                    await GetAllStudents();
                }
                else if (opNumber == 2)
                {
                    await GetPassedStudents();
                }
                else if (opNumber == 3)
                {
                    await GetStudentsGradesAvg();
                }
                else
                {
                    Console.WriteLine("Something went wrong!!");
                }
            }

        }

        static async Task GetAllStudents()
        {
            try
            {
                Console.WriteLine("\n__________________________\n");
                Console.WriteLine("\nFetching all students....\n");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("Student/GetAllStudents");
                if (students != null)
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task GetPassedStudents()
        {
            try
            {
                Console.WriteLine("\n__________________________\n");
                Console.WriteLine("\nFetching Passed students....\n");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("Student/GetPassedStudents");
                if (students != null)
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task GetStudentsGradesAvg()
        {
            try
            {
                Console.WriteLine("\n__________________________\n");
                Console.WriteLine("\nFetching students grades average....\n");
                var gradesAverage = await httpClient.GetFromJsonAsync<double>("Student/GetStudentsGradesAvg");
                Console.WriteLine($"Grades Avareage is : {gradesAverage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
}



