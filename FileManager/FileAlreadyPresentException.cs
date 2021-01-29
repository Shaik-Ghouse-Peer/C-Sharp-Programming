using System;
using System.Runtime.Serialization;

namespace FileManager
{
    [Serializable]
    internal class FileAlreadyPresentException : Exception
    { 
        public FileAlreadyPresentException(string message="File Is Already Present") : base(message)
        {
        }
    }
}