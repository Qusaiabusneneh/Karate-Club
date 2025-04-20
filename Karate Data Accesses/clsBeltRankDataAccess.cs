using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsBeltRankDataAccess
    {
        public static bool GetRankInfoByID(int? RankID, ref string RankName, ref decimal TestFees)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetRankInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RankID", (object)RankID??DBNull.Value);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                RankName = (string)reader["RankName"];
                                TestFees = (decimal)reader["TestFees"];
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
        public static bool GetRankInfoByName(string RankName, ref int? RankID, ref decimal TestFees)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetRankinfoByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RankName", RankName);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                // RankID = (int)reader["RankID"];
                                RankID = (reader["RankID"] != DBNull.Value) ? (int?)reader["RankID"] : null;
                                TestFees = (decimal)reader["TestFees"];
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
        public static int? AddNewBeltRank(string RankName,decimal TestFees)
        {
            int? RankID = null;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_AddNewBeltRank", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RankName", RankName);
                    command.Parameters.AddWithValue("@TestFees", TestFees);
                    SqlParameter OutputIDParam = new SqlParameter("@NewRankID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(OutputIDParam);
                    try
                    {
                        command.ExecuteNonQuery();
                        RankID = (int?)OutputIDParam.Value;
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
            return RankID.Value;
        }
        public static bool UpdateBeltRank(int? RankID,string RankName,decimal TestFees)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand()) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RankID", (object)RankID??DBNull.Value);
                    command.Parameters.AddWithValue("@RankName", RankName);
                    command.Parameters.AddWithValue("@TestFees", TestFees);
                    try
                    {
                        RowsAffected=command.ExecuteNonQuery();
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
        public static bool DeleteBeltRank(int? RankID)
        {
            int RowsAffected = -1;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_DeleteBeltRank", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RankID",(object) RankID??DBNull.Value);
                    try
                    {
                        RowsAffected=command.ExecuteNonQuery();
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
            return RowsAffected > 0;
        }
        public static DataTable GetAllBeltRanks()
        {
            DataTable dtRank=new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_GetAllBeltRanks", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dtRank.Load(reader);
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
            return dtRank;
        }
        public static bool IsBeltRankExists(int? RankID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("SP_IsRankExits",connection))
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RankID",(object) RankID??DBNull.Value);
                    try
                    {
                        SqlParameter ReturnParamter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnParamter);
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnParamter.Value == 1;
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

    }
}
