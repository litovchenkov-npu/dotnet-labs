using System;
using Students;

namespace lab5
{
    internal class Program
    {
        static readonly StudentCollection StudentList = new StudentCollection();

        static void Menu()
        {
            Console.WriteLine("1. View all students\n2. View student details\n3. Add a student\n4. Remove a student\n5. Update a student\n6. Exit");

            int option = StudentList.getInt("Select an operation: ");
            switch (option)
            {
                case 1:
                    StudentList.GetStudentList();
                    break;
                case 2:
                    StudentList.GetStudentData();
                    break;
                case 3:
                    StudentList.AddStudent();
                    break;
                case 4:
                    StudentList.RemoveStudent();
                    break;
                case 5:
                    StudentList.UpdateStudent();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
    }
}
