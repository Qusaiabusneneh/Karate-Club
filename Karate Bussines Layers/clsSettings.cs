using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsSettings
    {
        public static byte DefaultSubscriptionPeriod()
        {
            return clsSettingDataAccess.GetDefaultSubscriptionPeriod();
        }
    }
}
