using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsPaymentDataAccess
    {
        public static bool GetPaymentInfoByID(int? PaymentID, ref decimal Amount, ref DateTime Date, ref int? MemberID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetPaymentInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                Amount = (decimal)reader["Amount"];
                                Date = (DateTime)reader["Date"];
                                //MemberID = (int)reader["MemberID"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                            }
                            else
                                isFound = false;
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
        public static int? AddNewPayment(decimal Amount, DateTime Date, int? MemberID)
        {
            int? PaymentID = null;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_AddNewPayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Amount", Amount);
                   // command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                    try {
                        SqlParameter OutputIDParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(OutputIDParam);
                        command.ExecuteNonQuery();
                        PaymentID = (int?)OutputIDParam.Value;
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
            return PaymentID.Value;
        }
        public static bool UpdatePayment(int? PaymentID, decimal Amount, DateTime Date, int? MemberID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_UpdatePayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                    try
                    {
                        RowsAffected = command.ExecuteNonQuery();
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
            return (RowsAffected > 0);
        }
        public static bool DeletePayment(int? PayemntID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_DeletePayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", (object)PayemntID ?? DBNull.Value);
                    try
                    {
                        RowsAffected = command.ExecuteNonQuery();
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
            return (RowsAffected > 0);
        }
        public static DataTable GetAllPayment()
        {
            DataTable dtPayment = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetAllPayments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPayment.Load(reader);
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
            return dtPayment;
        }
        public static bool IsPaymentExist(int? PaymentID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_IsPaymentExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
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
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }
        public static DataTable GetAllPaymentsForMember(int? MemberID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllPaymentsForMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            catch(Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return dt;
        }
        public static int CountAllPayments()
        {
            return clsDataAccessHelper.Count("SP_GetPaymentsCount");
        }
    }
}
