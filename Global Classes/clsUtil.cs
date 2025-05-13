﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Global_Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
        public static bool CreateFileFolderDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error creating folder :" + ex.Message);
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo fi= new FileInfo(FileName);
            string extn=fi.Extension;
            return GenerateGUID() + extn;
        }
        public static bool CopyImageToProjectImageFolder(ref string SourceFile)
        {
            string DestinationFolder = @"D:\old\OneDrive\Pictures\Karate Icons";
            if (!CreateFileFolderDoesNotExist(DestinationFolder))
                return false;

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);
            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch(IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SourceFile = DestinationFile;
            return true;
        }
    }
}
