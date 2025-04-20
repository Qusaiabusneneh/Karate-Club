using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsDataAccessHelper
    {
        public static int Count(string StoredProcedure)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(StoredProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int value))
                            count = value;
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
            return count;
        }
    }
}
