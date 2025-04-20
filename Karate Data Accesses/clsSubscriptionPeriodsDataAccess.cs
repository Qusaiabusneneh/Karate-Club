using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsSubscriptionPeriodsDataAccess
    {
        public static bool GetSubscriptionPeriodsInfoByID(int? PeriodID,ref DateTime StartDate,ref DateTime EndDate,ref decimal Fees,
            ref bool IsPaid,ref int? MemberID,ref int? PaymentID,ref byte IssueReason,ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetSubscriptionPeriodsByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", (object)PeriodID??DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                Fees = (decimal)reader["Fees"];
                                IsPaid = (bool)reader["IsPaid"];
                                //MemberID = (int)reader["MemberID"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                //PaymentID = (int)reader["PaymentID"];
                                PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int?)reader["PaymentID"] : null;
                                IssueReason = (byte)reader["IssueReason"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                isFound = false;
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
            return isFound;
        }
        public static bool GetSubscriptionPeriodsInfoByMemberID(int? MemberID, ref DateTime StartDate, ref DateTime EndDate, ref decimal Fees,
             ref bool IsPaid,ref int?PeriodID, ref int? PaymentID, ref byte IssueReason, ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetSubscriptionPeriodsByMemberID", connection))
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
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                Fees = (decimal)reader["Fees"];
                                IsPaid = (bool)reader["IsPaid"];
                                PeriodID = (reader["PeriodID"] != DBNull.Value) ? (int?)reader["PeriodID"] : null;
                                PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int?)reader["PaymentID"] : null;
                                IssueReason = (byte)reader["IssueReason"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                                isFound = false;
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }
        public static int? AddNewSubscriptionPeriod(DateTime StartDate,DateTime EndDate,decimal Fees,bool IsPaid,
            int? MemberID,int? PaymentID,byte IssueReason,bool IsActive)
        {
            int? NewPeriodID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewPeriod", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@IsPaid", IsPaid);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        SqlParameter OutputIDParam = new SqlParameter("@NewPeriodID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(OutputIDParam);
                        command.ExecuteNonQuery();
                        NewPeriodID = (int?)OutputIDParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return NewPeriodID;
        }
        public static bool UpdateSubscriptionPeriod(int? PeriodID,DateTime StartDate,DateTime EndDate,decimal Fees,bool IsPaid,
            int? MemberID,int? PaymentID,byte IssueReason,bool IsActive)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_UpdatePeriod", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);
                    command.Parameters.AddWithValue("@Fees", Fees);
                    command.Parameters.AddWithValue("@IsPaid", IsPaid);
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
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
        public static bool DeleteSubscriptionPeriod(int? PeriodID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_DeletePeriod", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);
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
        public static DataTable GetAllSubscriptionPeriodsForMember(int?MemberID)
        {
            DataTable dtSubscriptionPeriod=new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_GetAllPeriodsForMember", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID", MemberID);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dtSubscriptionPeriod.Load(reader);
                            }
                            reader.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return dtSubscriptionPeriod;
        }
        public static DataTable GetAllSubscriptionPeriods()
        {
            DataTable dtSubscriptionPeriod = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetAllSubscriptionPeriods", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtSubscriptionPeriod.Load(reader);
                            }
                            reader.Close();
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
            }
            return dtSubscriptionPeriod;
        }
        public static bool IsSubscriptionPeriodExist(int? PeriodID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_IsSubscriptionPeriodExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);
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
        public static int? GetLastActivePeriodIDForMember(int? MemberID)
        {
            int? LastActivePeriodID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLastActivePeriodIDForMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@LastActivePeriodID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        LastActivePeriodID = (int?)outputIdParam.Value;
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

            return LastActivePeriodID;
        }
        public static bool UpdateActivityAndIsPaid(int? PeriodID, bool IsPaid, bool IsActive)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateActivityAndIsPaid", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsPaid", IsPaid);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        RowAffected = command.ExecuteNonQuery();
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

            return (RowAffected > 0);
        }
        public static int? GetPeriodIDByPaymentID(int? PaymentID)
        {
            int? PeriodID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPeriodIDByPaymentID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@PeriodID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        PeriodID = (int?)outputIdParam.Value;
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

            return PeriodID;
        }
        public static int CountAllSubscriptionPeriods()
        {
            return clsDataAccessHelper.Count("SP_GetSubscriptionPeriodsCount");
        }
    }
}
