using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsBeltTestsDataAccess
    {
        public static bool GetBeltTestInfoByID(int? TestID,ref int? MemberID,ref int? RankID,ref bool Result,ref DateTime Date,
            ref int? TestedByInstructorID,ref int? PaymentID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_GetBeltTestInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestID", (object)TestID??DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                //MemberID = (int)reader["MemberID"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                //RankID = (int)reader["RankID"];
                                RankID = (reader["RankID"] != DBNull.Value) ? (int?)reader["RankID"] : null;
                                Result = (bool)reader["Result"];
                                Date = (DateTime)reader["Date"];
                                TestedByInstructorID = (reader["TestedByInstructorID"] != DBNull.Value) ? (int?)reader["TestedByInstructorID"] : null;
                                //TestedByInstructorID = (int)reader["TestedByInstructorID"];
                                //PaymentID = (int)reader["PaymentID"];
                                PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int?)reader["PaymentID"] : null;
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
        public static int? AddNewBeltTest(int? MemberID,int? RankID,bool Result,DateTime Date,
            int? TestedByInstructorID,int? PaymentID)
        {
            int? NewTestID = null;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_AddNewTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MemberID",(object)MemberID??DBNull.Value);
                    command.Parameters.AddWithValue("@RankID", (object)RankID??DBNull.Value);
                    command.Parameters.AddWithValue("@Result", Result);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@TestedByInstructorID", (object)TestedByInstructorID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                    SqlParameter OutputIDParam = new SqlParameter("@NewTestID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(OutputIDParam);
                    try
                    {
                        command.ExecuteNonQuery();
                        NewTestID = (int?)OutputIDParam.Value;
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
            return NewTestID;
        }
        public static bool UpdateBeltTest(int? TestID,int? MemberID,int? RankID,bool Result,DateTime Date,
            int? TestedByInstructorID,int? PaymentID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_UpdateTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@RankID", (object)RankID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Result", Result);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@TestedByInstructorID", (object)TestedByInstructorID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
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
        public static bool DeleteBeltTest(int? TestID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_DeleteTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);
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
        public static DataTable GetAllBeltTest()
        {
            DataTable dtBeltTest = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_GetAllBeltTests", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtBeltTest.Load(reader);
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
            return dtBeltTest;

        }
        public static bool IsBeltTestExist(int? TestID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_IsBeltTestExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);
                    try
                    {
                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParameter);
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnParameter.SqlValue == 1;
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
        public static DataTable GetAllBeltTestsForMember(int? MemberID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllBeltTestsForMember", connection))
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
            catch (SqlException ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return dt;
        }
        public static int? GetTestIDByPaymentID(int? PaymentID)
        {
            int? TestID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTestIDByPaymentID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@TestID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        TestID = (int?)outputIdParam.Value;
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

            return TestID;
        }

        public static int CountAllBeltTest()
        {
            return clsDataAccessHelper.Count("SP_GetTestsCount");
        }
    }
}
