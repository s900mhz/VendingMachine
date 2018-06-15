using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FindAndReplace.Classes;

namespace FindAndReplace.Classes
{
    public class FileOpen
    {
        public static string directory = "";
        public static string OutPutFile = "";

        public static string GetValidDirectory()
        {
            bool exit = false;
            string userFilename = "";
            string directory = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter a file name (including file type (e.g. .txt): ");
                userFilename = Console.ReadLine();
                //string userFilename = "alices_adventures_in_wonderland.txt";

                Console.WriteLine("In what directory is your file name? ");
                //directory = @"C:\Workspace\team\team7-c-week4-pair-exercises\file-io-part2-exercises-pair";
                directory = Console.ReadLine();

                //Checking that directory exists
                bool directoryExists = Directory.Exists(directory);
                if (!directoryExists)
                {
                    Console.WriteLine("Directory invalid. Please try again.");
                }
                else
                {
                    exit = true;
                }

            } while (!exit);

            if (userFilename.Substring(userFilename.Length - 4) != ".txt")
            {
                throw new Exception("Please remember to use a .txt for your filename!");
            }

            // Generating a full path from a folder and a file name
            string fullPath = Path.Combine(directory, userFilename);

            //Checking that file actually exists we need to manipulate
            bool fileExists = File.Exists(fullPath);
            if (!fileExists)
            {
                throw new Exception("File does not exist.");
            }
            return fullPath;
        }

        public static string FileToWrite()
        {
            Console.WriteLine("What file name would you like to print to?");
            string path = Console.ReadLine();
            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(Environment.CurrentDirectory, path);
            }
            OutPutFile = path;
            return OutPutFile;
        }
    }
}
