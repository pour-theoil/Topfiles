using System;
using System.IO;
using System.Linq;

namespace topfiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = "";
            
            if (args[0] == "-d")
            {
                Console.WriteLine(args[1]);
                sourceDirectory = args[1];
            }
            else
            {
               sourceDirectory = @"C:\Users\frank\Downloads"; 
            }


            int max = 10;
            if (args[2] == "-n")
            {
                 int.TryParse(args[3], out int num);
                 max = num;
            }
            
            RecentFiles topfiles = new RecentFiles();

            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory);

                foreach (string currentFile in txtFiles)
                {
                    
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    Files file = new Files(fileName);
                    try
                    {
                        string path = $@"{sourceDirectory}\{fileName}";

                        // Get the creation time of a well-known directory.
                        DateTime dt = File.GetCreationTime(path);
                        file.time = dt;

                        // var size = File.GetAttributes(path);

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                    topfiles.addFile(file, file.time);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            var sorted = from pair in topfiles.recents
                             orderby pair.Value descending
                             select pair;

            int i = 0;
            foreach (var pair in sorted)
                {
                    if (i < max)
                    {
                        Console.WriteLine($@"{i+1}) {pair.Key.filename} 
created on {pair.Key.time}

");
                        i++;
                    }
                }
                



        }
    }
}
