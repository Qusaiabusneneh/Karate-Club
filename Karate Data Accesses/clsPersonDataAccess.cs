using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsPersonDataAccess
    {
        public static bool GetPersonInfoByPersonID(int? PersonID, ref string Name, ref string Address, ref string Phone, ref string Email,
        ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath)
        {
            bool isFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPersonInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID",(object) PersonID??DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                if (reader["Name"] != DBNull.Value)
                                    Name = (string)reader["Name"];
                                else
                                    Name = "";

                                if (reader["Address"] != DBNull.Value)
                                    Address = (string)reader["Address"];
                                else
                                    Address = "";

                                if (reader["Phone"] != DBNull.Value)
                                    Phone = (string)reader["Phone"];
                                else
                                    Phone = "";

                                if (reader["Email"] != DBNull.Value)
                                    Email = (string)reader["Email"];
                                else
                                    Email = "";

                                if (reader["DateOfBirth"] != DBNull.Value)
                                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                                else
                                    DateOfBirth = DateTime.Now;

                                if (reader["Gender"] != DBNull.Value)
                                    Gender = (byte)reader["Gender"];
                                else
                                    Gender = 0;

                                if (reader["ImagePath"] != DBNull.Value)
                                    ImagePath = (string)reader["ImagePath"];
                                else
                                    ImagePath = "";
                            }
                            else
                                isFound = false;
                            reader.Close();
                        }
                    }
                }
                catch (AggregateException ex)
                {
                    clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isFound;
        }
        public static int? AddNewPerson(string Name, string Address, string Phone, string Email, DateTime DateOfBirth, byte Gender, string ImagePath)
        {
            int? PersonID = null;
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        SqlParameter OutputIDParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(OutputIDParam);

                        command.ExecuteNonQuery();
                        PersonID = (int?)OutputIDParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return PersonID;
        }
        public static bool UpdatePerson(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, byte Gender, string ImagePath)
        {
            int RowsAffected = -1;
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return (RowsAffected > 0);
        }
        public static bool DeletePerson(int? PersonID)
        {
            int RowsAffected = -1;
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtPeople.Load(reader);
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return dtPeople;
        }
        public static bool IsPersonExist(int? PersonID)
        {
            bool isFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_IsPersonExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }
    }
}
