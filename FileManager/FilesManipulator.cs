using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FileManager
{
    class FilesManipulator
    {
        public static bool CreateEmptyFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return false;
            }
            else
            {
                FileStream file = File.Create(fileName);
                file.Close();
                return true;
            }
        }
        public static string[] GetAllLinesInFile(string file)
        {
            if (IsFileEmpty(file))
            {
                return null;
            }
            else
            {
                return File.ReadAllLines(file);
            }
        }
        public static string GetLastLineInFile(string file)
        {
            if (IsFileEmpty(file))
            {
                return null;
            }
            else
            {
                return File.ReadAllLines(file).Last();
            }
        }
        public static int GetNumberOfLinesCountInFile(string file)
        {
            return File.ReadAllLines(file).Length;
        }
        public static void AppendTextToFile(string file, string text)
        {
            File.AppendAllText(file, text);
        }
        public static void AddTextToFile(string file, string text)
        {
            File.WriteAllText(file, text);
        }
        public static bool DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
                return true;
            }
            else
            {
                return false;
            }   
        }
        private static bool IsFileEmpty(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Length <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
