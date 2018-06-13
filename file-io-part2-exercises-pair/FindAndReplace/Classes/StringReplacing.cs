using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAndReplace.Classes;
using System.IO;

namespace FindAndReplace.Classes
{
    class StringReplacing
    {
        public static string FindAndReplace()
        {
            string fullDirectoryPath = FileOpen.GetValidDirectory();
            string searchInput = StringFinder.GetFindString();
            string searchReplace = StringFinder.GetReplaceString();
            string outputFullPath = Path.Combine(FileOpen.directory, FileOpen.OutPutFile);

            try
            {
                using (StreamReader sr = new StreamReader(fullDirectoryPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputFullPath, true))
                    {

                        // For each line in the input file, read it in                    
                        while (!sr.EndOfStream)
                        {
                            // Read an individual line
                            string line = sr.ReadLine();
                            //Splitting the lines
                            //string[] words = line.Split(' ');

                           // foreach (var item in words) //looping through each word
                           // {
                                string fixedWords = "";
                                                            
                                     fixedWords = line.Replace(searchInput, searchReplace);
                                                                    
                                sw.WriteLine(fixedWords);
                            //}
                            // Write the new line to the output file
                            
                        }
                    }
                    
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            return null;

        }
    }
}
