using System;
using System.Data;
using System.Data.SqlClient;

namespace Karate_Data_Accesses
{
    public class clsMemberDataAccess
    {
        public static bool GetMemberInfoByID(int? MemberID, ref int? PersonID, ref string EmergencyContactInfo,
            ref int? LastBeltRankID, ref bool IsActive)
        {
            bool IsFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMemberInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID??DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                //PersonID = (int)reader["PersonID"];
                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                EmergencyContactInfo = (string)reader["EmergencyContactInfo"];
                                LastBeltRankID = (reader["LastBeltRankID"] != DBNull.Value) ? (int?)reader["LastBeltRankID"] : null;
                                //LastBeltRankID = (int)reader["LastBeltRankID"];
                                IsActive = (bool)reader["isActive"];
                            }
                            else
                                IsFound = false;
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IsFound = false;
                    clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            return IsFound;
        }
        public static bool GetMemberInfoByPersonID(int? PersonID, ref int? MemberID, ref string EmergencyContactInfo,
            ref int? LastBeltRankID, ref bool IsActive)
        {
            bool IsFound = false;
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMemberInfoByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID",(object) PersonID??DBNull.Value);
                        //command.Parameters.AddWithValue("@PersonID",PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                //MemberID = (int)reader["MemberID"];
                                MemberID = (reader["MemberID"] != DBNull.Value ? (int?)reader["MemberID"] : null);
                                EmergencyContactInfo = (string)reader["EmergencyContactInfo"];
                                //LastBeltRankID = (int)reader["LastBeltRankID"];
                                LastBeltRankID = (reader["LastBeltRankID"] != DBNull.Value ? (int?)reader["LastBeltRankID"]:null);
                                IsActive = (bool)reader["isActive"];
                            }
                            else
                                IsFound = false;
                            reader.Close();
                        }
                    }
                }
                catch (AggregateException ex)
                {
                    clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return IsFound;
        }
        public static int? AddNewMember(int? PersonID, string EmergencyContactInfo, int? LastBeltRankID, bool IsActive)
        {
            int? NewMemberID = null;
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID??DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactInfo", EmergencyContactInfo);
                        command.Parameters.AddWithValue("@LastBeltRankID", (object)LastBeltRankID??DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        SqlParameter OutputParmaID = new SqlParameter("@NewMemberID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(OutputParmaID);
                        command.ExecuteNonQuery();
                        NewMemberID = (int?)OutputParmaID.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return NewMemberID;
        }
        public static int? GetPersonIDByMemberID(int? MemberID)
        {
            int? PersonID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPersonIDByInstructorID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@PersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        PersonID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            return PersonID;
        }
        public static bool UpdateMember(int? MemberID,int? PersonID,string EmergencyContactInfo,int? LastBeltRankID,bool IsActive)
        {
            int RowsAffected = -1;
            string ConnectionString = clsConnectionString.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID",(object) MemberID??DBNull.Value);
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactInfo", EmergencyContactInfo);
                        command.Parameters.AddWithValue("@LastBeltRankID", (object)LastBeltRankID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

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
        public static bool DeleteMember(int? MemberID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID",(object)MemberID ?? DBNull.Value);
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
        public static DataTable GetAllMembers()
        {
            DataTable dtMember = new DataTable();
            string ConnectionString = clsConnectionString.ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetAllMembers", connection))
                {
                    command.CommandType= CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dtMember.Load(reader);
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
            return dtMember;
        }
        public static bool IsMemberExists(int? MemberID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_IsMemberExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NewMemberID", (object)MemberID ?? DBNull.Value);
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        IsFound = (int)ReturnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static int Count()
        {
            int counter = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetMembersCount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int value))
                            counter = value;
                    }
                }
            }
            catch(Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return counter;
        }
        public static bool SetActivity(int?MemberID,bool IsActive)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_SetActivityForMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return RowAffected > 0;
        }
        public static int CountAllMembers()
        {
            return clsDataAccessHelper.Count("SP_GetMembersCount");
        }
    }
}
