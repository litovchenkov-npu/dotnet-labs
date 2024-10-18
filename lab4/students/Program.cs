using System;
using System.Collections.Generic;

namespace Students
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentGroup { get; set; }
        public string StudentMajor { get; set; }
        public string StudentFaculty { get; set; }

        public Student(int studentID, string studentName, int studentGroup, string studentMajor, string studentFaculty)
        {
            StudentID = studentID;
            StudentName = studentName;
            StudentGroup = studentGroup;
            StudentMajor = studentMajor;
            StudentFaculty = studentFaculty;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {StudentID}");
            Console.WriteLine($"Name: {StudentName}");
            Console.WriteLine($"Group: {StudentGroup}");
            Console.WriteLine($"Major: {StudentMajor}");
            Console.WriteLine($"Faculty: {StudentFaculty}");
        }
    }

    public class StudentCollection
    {
        private readonly List<Student> Students = new();

        public int getInt(string prompt)
        {
            int input;
            Console.WriteLine(prompt);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
            return input;
        }

        public string getString(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        public void AddStudent()
        {
            int inputID = getInt("Enter student's ID: ");
            string inputName = getString("Enter student's name: ");
            int inputGroup = getInt("Enter student's group number: ");
            string inputMajor = getString("Enter student's major study: ");
            string inputFaculty = getString("Enter student's faculty: ");

            Students.Add(new Student(inputID, inputName, inputGroup, inputMajor, inputFaculty));
            Console.WriteLine("Student successfully added!");
        }

        public void RemoveStudent()
        {
            GetStudentList();
            int searchIndex = getInt("Enter the index of the student you want to remove: ");

            if (searchIndex >= 0 && searchIndex < Students.Count)
            {
                Students.RemoveAt(searchIndex);
                Console.WriteLine("Student successfully removed!");
            }
            else
            {
                Console.WriteLine("Invalid index. No student found at the given index.");
            }
        }

        public void UpdateStudent()
        {
            GetStudentList();
            int searchIndex = getInt("Enter the index of the student you want to update: ");

            if (searchIndex >= 0 && searchIndex < Students.Count)
            {
                Console.WriteLine("Select an item to change:\n1. ID\n2. Name\n3. Group\n4. Major\n5. Faculty");
                int option = getInt("Enter your choice: ");

                switch (option)
                {
                    case 1:
                        Students[searchIndex].StudentID = getInt("Enter new ID: ");
                        break;
                    case 2:
                        Students[searchIndex].StudentName = getString("Enter new name: ");
                        break;
                    case 3:
                        Students[searchIndex].StudentGroup = getInt("Enter new group number: ");
                        break;
                    case 4:
                        Students[searchIndex].StudentMajor = getString("Enter new major study: ");
                        break;
                    case 5:
                        Students[searchIndex].StudentFaculty = getString("Enter new faculty: ");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                Console.WriteLine("Student data successfully updated!");
            }
            else
            {
                Console.WriteLine("Invalid index. No student found at the given index.");
            }
        }

        public void GetStudentData()
        {
            GetStudentList();
            int searchIndex = getInt("Enter the index of the student you want to view: ");

            if (searchIndex >= 0 && searchIndex < Students.Count)
            {
                Students[searchIndex].Display();
            }
            else
            {
                Console.WriteLine("Invalid index. No student found at the given index.");
            }
        }

        public void GetStudentList()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                Console.WriteLine("Index\tID\tName");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine($"{i}\t{Students[i].StudentID}\t{Students[i].StudentName}");
                }
            }
        }
    }

    internal class Program
    {
        static readonly StudentCollection StudentList = new();

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