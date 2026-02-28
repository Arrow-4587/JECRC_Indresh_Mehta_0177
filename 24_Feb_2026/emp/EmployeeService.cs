using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    internal class EmployeeService
    {
        private readonly string connectionstring =
 "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeTable;Integrated Security=True";
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===Employee Management System===");
                Console.WriteLine("1. View All Emloyees");
                Console.WriteLine("2. Insert Employees");
                Console.WriteLine("3. Update Employees");
                Console.WriteLine("4. Delete Employees");
                Console.WriteLine("5. Search by Ids");
                Console.WriteLine("6. Search by Departmenmt Name");
                Console.WriteLine("7. Exit ");
                Console.WriteLine("8. Enter the choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewAllEmployees();
                        break;
                    case 2:
                        InsertEmployee();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
        public void ViewAllEmployees()
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "SELECT * FROM Employees";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("\n===Employee List===");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Department: {reader["Department"]}, Salary: {reader["Salary"]}");
            }
        }
        public void InsertEmployee()
        {
            EmployeeModel e = new EmployeeModel();
            Console.WriteLine("Enter Employee Name: ");
            e.Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Department: ");
            e.Department = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary: ");
            e.Salary = Convert.ToInt32(Console.ReadLine());
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "INSERT INTO Employees (Name, Department, Salary) VALUES (@Name, @Department, @Salary)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", e.Name);
            command.Parameters.AddWithValue("@Department", e.Department);
            command.Parameters.AddWithValue("@Salary", e.Salary);
            command.ExecuteNonQuery();

            Console.WriteLine("Employee inserted successfully.");
        }
    }
   
   }
