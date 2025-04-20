using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsUserDataAccess
    {
        public static bool GetUserInfoByUserID(int? UserID,ref int? PersonID,ref string Username,ref string Password,
            ref int Permissions,ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_GetUserInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PersonID = (int)reader["PersonID"];
                                Username = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                isFound = false;

                            reader.Close();
                        }
                    }
                    catch(AggregateException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }
        public static bool GetUserInfoByPersonID(int? PersonID,ref int? UserID,ref string Username,ref string Password,
            ref int Permissions,ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetUserInfoByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                isFound = false;
                            reader.Close();
                        }
                    }
                    catch(AggregateException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }
        public static bool GetUserInfoByUsernameAndPassword(string Username,string Password,ref int? PersonID, ref int? UserID,
                 ref int Permissions, ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                Permissions = (int)reader["Permissions"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                isFound = false;
                            reader.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }
        public static int AddNewUser(int? PersonID,string Username,string Password,int Permissions,bool IsActive)
        {
            Nullable<int> UserID = null;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_AddNewUser",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Permissions", Permissions);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    SqlParameter OutputIDParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(OutputIDParam);
                    try
                    {
                        command.ExecuteNonQuery();
                        UserID = ((int)command.Parameters["@NewUserID"].DbType);
                    }
                    catch(AggregateException ex)
                    {
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return UserID.Value;
        }
        public static bool UpdateUser(int? UserID,int? PersonID,string Username,string Password,int Permissions,bool IsActive)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_UpdateUser",connection))
                {
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserID", UserID);
                    command.Parameters.AddWithValue("PersonID", PersonID);
                    command.Parameters.AddWithValue("Username", Username);
                    command.Parameters.AddWithValue("Password", Password);
                    command.Parameters.AddWithValue("Permissions", Permissions);
                    command.Parameters.AddWithValue("IsActive", IsActive);
                    try
                    {
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(AggregateException ex)
                    {
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return (RowsAffected > 0);
        }
        public static bool DeleteUser(int? UserID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_DeleteUser",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(AggregateException ex)
                    {
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    { connection.Close(); }
                }
            }
            return (RowsAffected > 0);
        }
        public static DataTable GetAllUsers()
        {
            DataTable dtUser = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_GetAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtUser.Load(reader);
                            }
                            reader.Close();
                        }
                    }
                    catch(AggregateException ex)
                    {
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return dtUser;
        }
        public static bool IsUserExistByUsernameAndPassword(string Username,string Password)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_IsUserExistByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        IsFound = (int)ReturnParameter.Value == 1;
                    }
                    catch(AggregateException ex)
                    {
                        IsFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return IsFound;
        }
        public static bool IsUserExistByUsername(string Username)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_DoesUserExistByUsername", connection))
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    try
                    {
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnParameter.Value == 1;
                    }
                    catch(AggregateException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }
        public static bool IsUserExistByPersonID(int? PersonID)
        {
            bool isFound = false;
            using (SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_IsUserExistsByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        isFound=(int)ReturnParameter.Value == 1;
                    }
                    catch(AggregateException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }

        public static int CountAllUsers()
        {
            return clsDataAccessHelper.Count("SP_GetUsersCount");
        }
    }
}
