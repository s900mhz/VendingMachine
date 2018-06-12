using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the list where the text stream will save too. One is a list of words the other is a list of sentences
            var listOfLines = new List<string>();
            var listOfLinesSentence = new List<string>();

            //This asking for user input 
            Console.WriteLine("Please type in the directory of your text file");
            string directory =Console.ReadLine();
            Console.WriteLine("Please type the file name you wish to open");
            string filename = Console.ReadLine();

            //fullpath
            string fullpath = Path.Combine(directory, filename);

            try
            {
                using(StreamReader streamOfText = new StreamReader(fullpath))
                {
                    while (!streamOfText.EndOfStream)
                    {

                        char[] splitChar = { '.', '?', '!' };
                        string line = streamOfText.ReadLine();
                        string[] lineSplitArraySentence = line.Split(splitChar);
                        string[] lineSplitArray = line.Split(' ');

                        foreach (var word in lineSplitArray)
                        {
                            if (word.Length > 1)
                            {
                                listOfLines.Add(word);
                            }
                        }
                        foreach (var sentence in lineSplitArraySentence)
                        {
                            if(sentence.Length > 1)
                            {
                                listOfLinesSentence.Add(sentence);
                            }
                        }
                        //listOfLines.AddRange(lineSplitArray);
                        //listOfLinesSentence.AddRange(lineSplitArraySentence);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Error reading file");
                Console.WriteLine(e.Message);
            }
            //this saves the list counts into int variables
            int wordCount = listOfLines.Count();
            int sentenceCount = listOfLinesSentence.Count();

            Console.WriteLine();
            Console.WriteLine($"{filename} has {wordCount} words. {sentenceCount} sentences)");
            

            Console.ReadKey();
        }
    }
}
