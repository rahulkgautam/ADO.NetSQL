using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NetSQL
{
    class EmployeeDbConnection
    {
        public static void Connection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;database=Payroll_Services; Integrated Security=True";

            try
            {
                string query = "Select *  from Employee_Payroll;";
                SqlConnection connetion = new SqlConnection(connectionString);
                connetion.Open();

                SqlCommand command = new SqlCommand(query, connetion);
                SqlDataReader reader = command.ExecuteReader();                
                    while (reader.Read())
                    {
                        // Access data using reader
                        int empId = reader.GetInt32(0); 
                        string name = reader.GetString(1);
                        double salary = reader.GetDouble(2);
                        DateTime startDate = reader.GetDateTime(3);
                        string gender = reader.GetString(4);
                        long EmpPhone = reader.GetInt64(5);
                        string emp_Address = reader.GetString(6);
                        decimal basicPay = reader.GetDecimal(7);
                        decimal deduction = reader.GetDecimal(8);
                        decimal taxablePay = reader.GetDecimal(9);
                        decimal inconeTax = reader.GetDecimal(10);
                        decimal net_Pay = reader.GetDecimal(11);
                        Console.WriteLine($"EmpID: {empId}, EmpName: {name}, Salary {salary}, StartDate: {startDate}, Gender: {gender}, EmpPhone: {EmpPhone}, empAddress: {emp_Address}, basicPay: {basicPay}, Deduction: {deduction}, Taxable: {taxablePay}, IncomeTax: {inconeTax}, Net_Pay: {net_Pay} \n");
                    }
                
                connetion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
