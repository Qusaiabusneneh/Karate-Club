using Karate_Bussines_Layers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser _CurrentUser;
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string CurrentDirection = System.IO.Directory.GetCurrentDirectory();
                string FilePath = CurrentDirection + "\\data.txt";

                if (Username == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                string DataToSave = Username + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(DataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred : {ex.Message}");
                return false;
            }
        }
        public static bool GetSortedCredential(ref string Username, ref string Password)
        {
            try {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\data.txt";
                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string Line;
                        while ((Line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);
                            string[] Result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            Username = Result[0];
                            Password = Result[1];
                        }
                        return true;
                    }
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred : {ex.Message}");
                return false;
            }
    }
    }
}
