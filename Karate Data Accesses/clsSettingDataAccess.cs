using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsSettingDataAccess
    {
        public static byte GetDefaultSubscriptionPeriod()
        {
            byte defaultPeriod = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetDefaultSubscriptionPeriod", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        object result = command.ExecuteScalar();
                        if (result != null && byte.TryParse(result.ToString(), out byte value))
                            defaultPeriod = value;
                    }
                }
            }
            catch(Exception ex)
            {
                clsLogEvent.LogExceptionToLogViwer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return defaultPeriod;
        }
    }
}
