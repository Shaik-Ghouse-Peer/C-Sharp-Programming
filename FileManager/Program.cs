using System;
using System.IO;

namespace FileManager
{
    class Program
    {    
        static void Main()
        {
            string[] receivedData;
            string lastLine;
            int numberOfLines;
            try
            {
                if (FilesManipulator.CreateEmptyFile(Constants.FILE_PATH) == true)
                {
                    Console.WriteLine("\nINFO: File Created Successfully\n");
                }
                else
                {
                    throw new FileAlreadyPresentException();
                }

                FilesManipulator.AddTextToFile(Constants.FILE_PATH, Constants.TEXT);

                Console.WriteLine("\n----------After Adding Text To File------------");
                receivedData = FilesManipulator.GetAllLinesInFile(Constants.FILE_PATH);
                DataDisplayer.DisplayRecievedData(receivedData);

                FilesManipulator.AppendTextToFile(Constants.FILE_PATH, Constants.APPEND_TEXT);

                Console.WriteLine("\n----------After Appending Text To File------------");
                receivedData = FilesManipulator.GetAllLinesInFile(Constants.FILE_PATH);
                DataDisplayer.DisplayRecievedData(receivedData);

                numberOfLines = FilesManipulator.GetNumberOfLinesCountInFile(Constants.FILE_PATH);
                Console.WriteLine("\nCount Of Number Of Lines In File = {0}\n", numberOfLines);

                lastLine = FilesManipulator.GetLastLineInFile(Constants.FILE_PATH);
                Console.WriteLine("\n--------------Last Line In FIle--------------");
                DataDisplayer.DisplayRecievedData(lastLine);

                if (FilesManipulator.DeleteFile(Constants.FILE_PATH) == true)
                {
                    Console.WriteLine("\n---------File Deleted SuccessFully------------");
                }
                else
                {
                    Console.WriteLine("\nDEBUG: No Such File To Delete - Check File Name\n");
                }

                receivedData = FilesManipulator.GetAllLinesInFile(Constants.FILE_PATH);
            }
            catch(FileNotFoundException exception)
            {
                Console.WriteLine("\nDEBUG: " + exception.Message + " - Check File Name\n");
            }
            catch(DirectoryNotFoundException exception)
            {
                Console.WriteLine("\nDEBUG: " + exception.Message + " - Check File Path\n");
            }
            catch(FileAlreadyPresentException exception)
            {
                Console.WriteLine("\nDEBUG: " + exception.Message + " - Try With Another File Name\n");
            }
            finally
            {
                Console.WriteLine("\n----------You Reached End Of Program-----------\n");
            }   
        }
    }
}
