using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelperUtils
{
    /// <summary>
    /// Util class for handling files
    /// </summary>
    public static class Files
    {
        private const string FOLDER_PREFIX = "MSG";
        private const string ILLEGAL_FILE_NAME_CHARS= @"[\\/:*?""<>|]";

        /// <summary>
        /// Generate uniqe name for temp folder based on prefix
        /// </summary>
        /// <returns>string with path</returns>
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
        /// <summary>
        /// Check if file name is valid
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>True if valid</returns>
        public static string ValidateFileName(string filename)
        {
            Regex illegalInFileName = new Regex(ILLEGAL_FILE_NAME_CHARS);
            return illegalInFileName.Replace(filename, "");
        }
        /// <summary>
        /// Ensure the file name is unique in the folder, and change filename to ensure uniqueness
        /// </summary>
        /// <param name="folder">Folder path where file is to be located</param>
        /// <param name="OriginalName">Original file name</param>
        /// <returns>Complete revised path</returns>
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
