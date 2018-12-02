using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelperUtils
{
    public static class Files
    {
        private const string FOLDER_PREFIX = "MSG";
        private const string ILLEGAL_FILE_NAME_CHARS= @"[\\/:*?""<>|]";


        public static string GetUniqueTempFolder()
        {
            string tempFolder = Path.GetTempPath();
            long counter = 1;
            while (Directory.Exists(String.Concat(tempFolder, @"\", FOLDER_PREFIX, counter.ToString())))
                counter++;
            string newFolder = String.Concat(tempFolder, @"\", FOLDER_PREFIX, counter.ToString());
            Directory.CreateDirectory(newFolder);
            return newFolder;
        }
        public static string ValidateFileName(string filename)
        {
            Regex illegalInFileName = new Regex(ILLEGAL_FILE_NAME_CHARS);
            return illegalInFileName.Replace(filename, "");
        }

        public static string GetUniqueFileName(string folder, string OriginalName)
        {
            if (!File.Exists(string.Concat(folder, @"\", OriginalName)))
            {
                return string.Concat(folder, @"\", OriginalName);
            }
            long counter = 1;
            while (File.Exists(string.Concat(folder, @"\", Path.GetFileNameWithoutExtension(OriginalName), " (", counter.ToString(), ")",Path.GetExtension(OriginalName))))
                counter++;
            return string.Concat(folder, @"\", Path.GetFileNameWithoutExtension(OriginalName), " (", counter.ToString(), ")", Path.GetExtension(OriginalName));
        }

    }
}
