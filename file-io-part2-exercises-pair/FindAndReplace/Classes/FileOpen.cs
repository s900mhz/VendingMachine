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
        public static string OutPutFile { get; set; }
        public static string GetValidDirectory()
        {
            bool exit = false;
            string userFilename = "";
            while (!exit)
            {
                Console.WriteLine("Please enter a file name (including file type (e.g. .txt): ");
                userFilename = Console.ReadLine();
                //string userFilename = "alices_adventures_in_wonderland.txt";

                Console.WriteLine("Please type in the directory of your text file");
                //directory = @"C:\Workspace\team\team7-c-week4-pair-exercises\file-io-part2-exercises-pair";
                string directory = Console.ReadLine();

                //Getting our bearing(GPS)
                string currentDirectory = Directory.GetCurrentDirectory();
                //Checking that directory exists
                bool directoryExists = Directory.Exists(directory); //NEED TO REFACTOR
                if (!directoryExists)
                {
                    exit = true;
                    throw new Exception("Directory does not exist.");
                    

                }

            }
                
                Console.WriteLine("Please type in the output directory of your text file");
                OutPutFile = Console.ReadLine();
                //OutPutFile = @"TestFile.txt";
                //Console.WriteLine("Please type the file name you wish to open");
                //string filename = Console.ReadLine();

                //need to modify path for final product
                if (userFilename.Substring(userFilename.Length - 4) != ".txt")
                {
                    throw new Exception("Please remember to use a .txt for your filename, please!");
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
    }
}
