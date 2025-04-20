using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsInstructorsDataAccess
    {
        public static bool GetInstructorInfoByID(int? InstructorID,ref int? PersonID,ref string Qualification)
        {
            bool isFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_GetInstructorInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID??DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                //PersonID = (int)reader["PersonID"];
                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                if (reader["Qualification"] != DBNull.Value)
                                    Qualification = (string)reader["Qualification"];
                                else
                                    Qualification = "NULL";
                            }
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
        public static bool GetInstructortInfoByPersonID(int? PersonID, ref int? InstructorID, ref string Qualification)
        {
            bool isFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetIsntructorInfoByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", (object)PersonID??DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                //InstructorID = (int)reader["InstructorID"];
                                InstructorID = (reader["InstructorID"] != DBNull.Value) ? (int?)reader["InstructorID"] : null;
                                if (reader["Qualification"] != DBNull.Value)
                                    Qualification = (string)reader["Qualification"];
                                else
                                    Qualification = "NULL";
                            }
                            reader.Close();
                        }
                    }
                    catch (AggregateException ex)
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
        public static int? AddNewInstructor(int? PersonID, string Qualification)
        {
            int? InstructorID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewInstructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Qualification", (object)Qualification ?? DBNull.Value);
                        SqlParameter OutputIDParam = new SqlParameter("@NewInstructorID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(OutputIDParam);
                        command.ExecuteNonQuery();
                        InstructorID = (int?)OutputIDParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return InstructorID;
        }
        public static bool UpdateInstructor(int? InstructorID,int? PersonID,string Qualification)
        {
            int RowsAffected = -1;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_UpdateInstructor", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Qualification", Qualification);
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
        public static bool DeleteInstructor(int? InstructorID)
        {
            int RowsAffected = -1;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_DeleteInstructor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
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
        public static DataTable GetAllInstructor()
        {
            DataTable dtInstructors=new DataTable();
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetAllInstructors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                dtInstructors.Load(reader);
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
            return dtInstructors;
        }
        public static bool IsInstructorExist(int? InstructorID)
        {
            bool isFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_DoesInstructorExist", connection))
                {
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
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
        public static bool IsInstructorExistByPersonID(int? PersonID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_IsInstructorExistByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                    try
                    {
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        isFound = (int?)ReturnParameter.Value == 1;
                    }
                    catch (AggregateException ex)
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
        //public static bool IsInstructorTrainingMember(int?MemberID)
        //{

        //}
        public static int CountAllInstructors()
        {
            return clsDataAccessHelper.Count("SP_GetInstructorsCount");
        }
    }
}
