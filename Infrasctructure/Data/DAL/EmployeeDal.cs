using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrasctructure.Data.DAL
{
    public class EmployeeDal
    {
        private readonly string _connectionString;

        public EmployeeDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            try
            {
                string sqlProcedure = "GetEmployees";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(sqlProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    await connection.OpenAsync().ConfigureAwait(false);
                    using (SqlDataReader rdr = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await rdr.ReadAsync().ConfigureAwait(false))
                        {
                            EmployeeDto employee = new EmployeeDto();
                            employee = MapFromReader(rdr);

                            employees.Add(employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

            return employees;
        }

        private EmployeeDto MapFromReader(SqlDataReader rdr)
        {
            EmployeeDto employee = new EmployeeDto();

            employee.Id = Convert.ToInt32(rdr["Id"]);
            employee.Name = rdr["Name"].ToString();
            employee.Surname = rdr["Surname"].ToString();
            employee.Email = rdr["Email"].ToString();
            employee.PhoneNumber = rdr["PhoneNumber"].ToString();
            employee.Adress = rdr["Adress"].ToString();
            employee.City = rdr["City"].ToString();
            employee.Neto = Convert.ToDecimal(rdr["Neto"]);
            employee.Bruto = Convert.ToDecimal(rdr["Bruto"]);

            return employee;
        }

        public async Task<bool> CreateEmployee(EmployeeDto employee)
        {
            try
            {
                employee.Bruto = CalculateBruto(employee.Neto);

                string sqlProcedure = "CreateEmployee";
                
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(sqlProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Surname", employee.Surname);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Adress", employee.Adress);
                    command.Parameters.AddWithValue("@Email", employee.Adress);
                    command.Parameters.AddWithValue("@City", employee.City);
                    command.Parameters.AddWithValue("@Neto", employee.Neto);
                    command.Parameters.AddWithValue("@Bruto", employee.Bruto);

                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
                throw;
            }

            return true;
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            EmployeeDto employee = new EmployeeDto();

            try
            {
                string sqlProcedure = "GetEmployee";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(sqlProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    await connection.OpenAsync().ConfigureAwait(false);
                    using (SqlDataReader rdr = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (await rdr.ReadAsync().ConfigureAwait(false))
                        {
                            employee = MapFromReader(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                string sqlProcedure = "DeleteEmployee";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(sqlProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
                throw;
            }

            return true;
        }

        public async Task<bool> EditEmployee(EmployeeDto employee)
        {
            try
            {
                employee.Bruto = CalculateBruto(employee.Neto);

                string sqlProcedure = "EditEmployee";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(sqlProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Surname", employee.Surname);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Adress", employee.Adress);
                    command.Parameters.AddWithValue("@Email", employee.Adress);
                    command.Parameters.AddWithValue("@City", employee.City);
                    command.Parameters.AddWithValue("@Neto", employee.Neto);
                    command.Parameters.AddWithValue("@Bruto", employee.Bruto);

                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
                throw;
            }

            return true;
        }

        private decimal CalculateBruto(decimal neto)
        {
            decimal bruto = 0;
            decimal result = 0;

            if (neto < 28402)
                bruto = ((neto - 1830) + (decimal)0.199 * 28402) / (decimal)0.9;

            else if (neto > 405750)
                bruto = ((neto - 1830) + (decimal)0.199 * 405750) / (decimal)0.9;

            else
                bruto = (neto - 1830) / (decimal)0.701;

            result = neto;
            result += (bruto - 18300) * (decimal)0.1;
            result += bruto * (decimal)0.14;
            result += bruto * (decimal)0.0515;
            result += bruto * (decimal)0.0075;
            result += bruto * (decimal)0.115;
            result += bruto * (decimal)0.0515;

            return result;
        }
    }
}
