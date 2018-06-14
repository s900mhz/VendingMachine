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
            bool exit = true;
            string userFilename = "";
            string directory = "";
            do
            {
                Console.WriteLine("Please enter a file name (including file type (e.g. .txt): ");
                userFilename = Console.ReadLine();
                //string userFilename = "alices_adventures_in_wonderland.txt";

                Console.WriteLine("Please type in the directory of your text file");
                //directory = @"C:\Workspace\team\team7-c-week4-pair-exercises\file-io-part2-exercises-pair";
                directory = Console.ReadLine();
                
                //Checking that directory exists
                bool directoryExists = Directory.Exists(directory);
                if (!directoryExists)
                {
                    Console.WriteLine("Directory invalid. Please try again.");
                    exit = false;
                    //throw new Exception("Directory does not exist.");
                }
                //else
                //{
                //    exit = true;
                //}

            } while (!exit);
            
                //Console.WriteLine("Please type in the output directory of your text file");
                //OutPutFile = Console.ReadLine();
                OutPutFile = @"test2.txt";
                

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
