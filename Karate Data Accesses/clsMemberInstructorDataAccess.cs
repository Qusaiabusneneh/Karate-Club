using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsMemberInstructorDataAccess
    {
        public static bool GetMemberInstructorInfoByID(int? MemberInstructorID,ref int? MemberID,ref int? InstructorID,ref DateTime AssignDate)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetMemberInstructorInfoByID", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberInstructorID", (object)MemberInstructorID??DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                //MemberID = (int)reader["MemberID"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                //InstructorID = (int)reader["InstructorID"];
                                InstructorID = (reader["InstructorID"] != DBNull.Value) ? (int?)reader["InstructorID"] : null;
                                AssignDate = (DateTime)reader["AssignDate"];
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
        public static bool GetMemberInstructorInfoByMemberID(int? MemberID, ref int? MemberInstructorID, ref int? InstructorID, ref DateTime AssignDate)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetMemberInstructorInfoByMeberID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                //MemberID = (int)reader["MemberID"];
                                MemberInstructorID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                //InstructorID = (int)reader["InstructorID"];
                                InstructorID = (reader["InstructorID"] != DBNull.Value) ? (int?)reader["InstructorID"] : null;
                                AssignDate = (DateTime)reader["AssignDate"];
                            }
                            else
                                isFound = false;
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }
        public static bool GetMemberInstructorInfoByInstructorID(int? InstructorID, ref int? MemberInstructorID, ref int? MemberID, ref DateTime AssignDate)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetMemberInstructorInfoByInstructorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                //MemberID = (int)reader["MemberID"];
                                MemberInstructorID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                //InstructorID = (int)reader["InstructorID"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                AssignDate = (DateTime)reader["AssignDate"];
                            }
                            else
                                isFound = false;
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }
        public static int? AddNewMemberInstructor(int? MemberID,int? InstructorID,DateTime AssignDate)
        {
            int? NewMemberInstructorID = null;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_AddNewMemberInstructor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID??DBNull.Value);
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID??DBNull.Value);
                    command.Parameters.AddWithValue("@AssignDate", AssignDate);
                    SqlParameter OutputIDParam = new SqlParameter("@NewMemberInstructorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(OutputIDParam);
                    try
                    {
                        command.ExecuteNonQuery();
                        NewMemberInstructorID = (int)OutputIDParam.Value;
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
            return NewMemberInstructorID.Value;
        }
        public static bool UpdateMemberInstructor(int? MemberInstructorID,int? MemberID,int? InstructorID,DateTime AssignDate)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_UpdateMemberInstructor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID", (object)MemberInstructorID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignDate", AssignDate);
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
        public static bool DeleteMemberInstructor(int? MemberInstructorID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_DeleteMemberInstructor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID", (object)MemberInstructorID ?? DBNull.Value);
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
        public static DataTable GetAllMemberInstructor()
        {
            DataTable dtMemberInstructor= new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetAllMemberInstructors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dtMemberInstructor.Load(reader);
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
            return dtMemberInstructor;
        } 
        public static bool IsMemberInstructorExist(int? MemberInstructorID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_DoesMemberInstructorExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberInstructorID", (object)MemberInstructorID ?? DBNull.Value);
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
                }
            }
            return isFound;
        }
        public static bool IsMemberInstructorExistByInstructorID(int? InstructorID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_IsMemberInstructorExistByInstructorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                    catch (AggregateException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }
        public static bool IsMemberInstructorExistByMemberID(int? MemberID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_IsMemberInstructorExistByMemberID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
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
                    catch (AggregateException ex)
                    {
                        isFound = false;
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }
    }
}
