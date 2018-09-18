using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public static class Files
    {
        private const string FOLDER_PREFIX = "MSG";

        public static string getUniqueTempFolder()
        {
            string tempFolder = Path.GetTempPath();
            long counter = 1;
            while (Directory.Exists(String.Concat(tempFolder, @"\", FOLDER_PREFIX, counter.ToString())))
                counter++;
            string newFolder = String.Concat(tempFolder, @"\", FOLDER_PREFIX, counter.ToString());
            Directory.CreateDirectory(newFolder);
            return newFolder;
        }

        public static string getUniqueFileName(string folder, string OriginalName)
        {
            if (!File.Exists(string.Concat(folder, @"\", OriginalName)))
            {
                return string.Concat(folder, @"\", OriginalName);
            }
            long counter = 1;
            while (File.Exists(string.Concat(folder, @"\", OriginalName, " (", counter.ToString(), ")")))
                counter++;
            return string.Concat(folder, @"\", OriginalName, " (", counter.ToString(), ")");
        }

    }
}
