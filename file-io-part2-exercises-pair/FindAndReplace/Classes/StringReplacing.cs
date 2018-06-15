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
            string outputFullPath = FileOpen.FileToWrite();
            string searchInput = StringFinder.GetFindString();
            string searchReplace = StringFinder.GetReplaceString();
            

            try
            {
                using (StreamReader sr = new StreamReader(fullDirectoryPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputFullPath, false))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            
                                string fixedWords = "";
                                                            
                                     fixedWords = line.Replace(searchInput, searchReplace);
                                                                    
                                sw.WriteLine(fixedWords);
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
